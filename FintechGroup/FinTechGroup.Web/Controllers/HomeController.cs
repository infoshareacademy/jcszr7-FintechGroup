using FinTechGroup.Domain;
using FinTechGroup.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinTechGroup.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            var companies = await _db.Companies.ToListAsync();

            return companies;
        }
    }
}
