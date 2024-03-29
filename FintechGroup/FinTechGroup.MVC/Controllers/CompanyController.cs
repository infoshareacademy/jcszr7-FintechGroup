﻿using FintechGroup.Services;
using FinTechGroup.Domain;
using FinTechGroup.Persistance.EntityFramework.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using static FintechGroup.Services.AlphaVantageModels;

namespace FinTechGroup.Web.Controllers
{
    public class CompanyController : Controller
    {


        private readonly ApplicationDbContext _db;
        private readonly IAlphaVantageService alphaVantageService;

        public CompanyController(ApplicationDbContext db, IAlphaVantageService alphaVantageService)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            this.alphaVantageService = alphaVantageService ?? throw new ArgumentNullException(nameof(alphaVantageService));
        }

        public async Task <IActionResult> IndexForGuests()
        {
            var rootInfo = await alphaVantageService.GetAlphaVantageCompanyRootInfo("IBM");
            IEnumerable<Company> companies = _db.Companies.ToList();


            // Tu kończy się odpowiedzialność tego serwisu pobierającego dane
            // i tutaj przekształcamy te dane to widoku "użytkowniko-friendly"
            DataTable dt = new DataTable();

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

        public IActionResult Details()
        {
            IEnumerable<ExchangeRate> exchange = _db.ExchangeRates.ToList();
            return View(exchange);
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
        public IActionResult AddDetails()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDetails( ExchangeRate exchangeRate)
        {
            if (ModelState.IsValid)
            {
                _db.ExchangeRates.AddRange(exchangeRate);
                _db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(exchangeRate);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company, ExchangeRate exchange)
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
