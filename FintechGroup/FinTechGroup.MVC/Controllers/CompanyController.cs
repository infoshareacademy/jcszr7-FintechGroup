using FinTechGroup.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinTechGroup.Web.Controllers
{
    public class CompanyController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CompanyController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult IndexForGuests()
        {
            IEnumerable<Company> companies = _db.Companies.ToList();
            return View(companies);
        }

        public ViewResult Search(string searchString)
        {
            var companies = from c in _db.Companies
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                companies = companies.Where(c => c.CompanyName.Contains(searchString) || c.Ticker.Contains(searchString));              
            }
            return View(companies.ToList());
        }
        [Authorize]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.CompanyNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CompanyTickerSort = sortOrder == "Ticker" ? "ticker_desc" : "Ticker";
            var companies = from c in _db.Companies
                            select c;
            switch (sortOrder)
            {
                case "name_desc":
                    companies = companies.OrderByDescending(c => c.CompanyName);
                    break;
                case "Ticker":
                    companies = companies.OrderBy(c => c.Ticker);
                    break;
                case "ticker_desc":
                    companies = companies.OrderByDescending(c => c.Ticker);
                    break;
                default:
                    companies = companies.OrderBy(c => c.CompanyName);
                    break;
            }
            return View(companies.ToList());

        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Companies.Add(company);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var companyFromDb = _db.Companies.Find(id);

            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _db.Companies.Update(company);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var companyFromDb = _db.Companies.Find(id);

            if (companyFromDb == null)
            {
                return NotFound();
            }
            return View(companyFromDb);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Companies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Companies.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
