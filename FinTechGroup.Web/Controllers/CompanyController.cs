using FinTechGroup.Domain;
using FinTechGroup.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinTechGroup.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CompanyController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "GetCompanies")]

        public async Task<IEnumerable<Company>> GetAll()
        {
            var companies = await dbContext.Companies.ToListAsync();

            return companies;
        }
    }
}
