using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Casestudy11.Model;
using System.Net;
using casestudy11.Data;
using SkillMgnt.Data;

namespace Casestudy11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInfoesController : ControllerBase
    {

       private readonly WebApiContext _context;

        //private readonly ISkillMgntContext _context;

        public EmployeeInfoesController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeInfoes
        /// <summary>
        /// Api to fetch all the details employees in an organisation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetEmployeeInfo()
        {
            var res = from e in _context.EmployeeInfo
                      select new { e.empEmailId,e.empId,e.empName,e.grade,e.hccOrganization,e.pmEmailId,e.pmId,e.project,e.role };


            // if(res==null)
            // {
            //   thrownewHttpResponseException(HttpStatusCode.NotFound);
            // }
            if (res == null)
            {
                return NotFound("");
            }

            return res.ToList();
        }
/*
         GET: api/EmployeeInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeInfo>> GetEmployeeInfo(int id)
        {
            var employeeInfo = await _context.EmployeeInfo.FindAsync(id);

            if (employeeInfo == null)
            {
                return NotFound();
            }

            return employeeInfo;
        }

        // PUT: api/EmployeeInfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeInfo(int id, EmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.empId)
            {
                return BadRequest();
            }

            _context.Entry(employeeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeInfoExists(id))
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

        // POST: api/EmployeeInfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeInfo>> PostEmployeeInfo(EmployeeInfo employeeInfo)
        {
            _context.EmployeeInfo.Add(employeeInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeInfoExists(employeeInfo.empId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeInfo", new { id = employeeInfo.empId }, employeeInfo);
        }

        // DELETE: api/EmployeeInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeInfo>> DeleteEmployeeInfo(int id)
        {
            var employeeInfo = await _context.EmployeeInfo.FindAsync(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            _context.EmployeeInfo.Remove(employeeInfo);
            await _context.SaveChangesAsync();

            return employeeInfo;
        }

        private bool EmployeeInfoExists(int id)
        {
            return _context.EmployeeInfo.Any(e => e.empId == id);
        }
*/

    }
}
