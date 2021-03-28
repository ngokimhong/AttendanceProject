using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Contracts;

namespace AttendanceProject.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        
        private IRepositoryWrapper _repoWrapper;

        public CompaniesController(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            var Companies = await _repoWrapper.Company.GetAllCompanyAsync(companyParameters);


            return Ok(Companies);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(Guid id)
        {
            var company = await _repoWrapper.Company.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(Guid id, Company company)
        {
            if (id != company.BranchId)
            {
                return BadRequest();
            }

            _repoWrapper.Company.UpdateCompany(company);

            try
            {
                await _repoWrapper.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _repoWrapper.Company.CreateCompany(company);
            try
            {
                await _repoWrapper.save();
            }
            catch (DbUpdateException)
            {
                if (CompanyExists(company.BranchId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCompany", new { id = company.BranchId }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(Guid id)
        {
            var company = await _repoWrapper.Company.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _repoWrapper.Company.Delete(company);
            await _repoWrapper.save();

            return company;
        }

        private bool CompanyExists(Guid id)
        {
            return _repoWrapper.Company.GetCompanyByIdAsync(id) != null;
        }
    }
}
