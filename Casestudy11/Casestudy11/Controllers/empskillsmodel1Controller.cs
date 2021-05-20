using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Casestudy11.Data;
using Casestudy11.Model;
using Casestudy11.DTO;

namespace Casestudy11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empskillsmodel1Controller : ControllerBase
    {
        private readonly Casestudy11Context _context;

        public empskillsmodel1Controller(Casestudy11Context context)
        {
            _context = context;
        }

        // GET: api/empskillsmodel1
        [HttpGet]
        public Object Getempskillsmodel1()
        {
            //return await _context.empskillsmodel1.ToListAsync();
            var res = from e in _context.empskillsmodel1 where e.approval_status == 0 select new { e.skilltype, e.id, e.Empid.project, e.Empid.grade, e.Empid.pmId, e.Empid.empName, e.approval_status, e.skillid.name, e.skillid.skillCatName, e.approvedby, e.approveddate };
            // return await _context.empskillsmodel.ToListAsync();
            return res.ToList();

        }
        [HttpGet("all")]
        public Object Getallempskillsmodel()
        {
            var res = from e in _context.empskillsmodel1 select new { e.skill_end_date, e.skill_start_date, e.Empid, e.skillid, e.skilltype, e.id, e.Empid.pmId, e.approval_status, e.approvedby, e.approveddate, e.Rating, e.primary };
            // return await _context.empskillsmodel.ToListAsync();
            return res.ToList();
        }


        // GET: api/empskillsmodel1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<empskillsmodel1>> Getempskillsmodel1(int id)
        {
            var empskillsmodel1 = await _context.empskillsmodel1.FindAsync(id);

            if (empskillsmodel1 == null)
            {
                return NotFound();
            }

            return empskillsmodel1;
        }

        // PUT: api/empskillsmodel1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Putempskillsmodel1(int id, empskillsmodel1 empskillsmodel1)
        //{
        //    if (id != empskillsmodel1.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(empskillsmodel1).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!empskillsmodel1Exists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSkill(int id, update ESkill)
        {
            //if (id != employeeSkill.pkAuto)
            //{
            //    return BadRequest();
            //}
            bool Con = true;
            while (Con)
            {
                empskillsmodel1 empSkill = await _context.empskillsmodel1.Where(d => d.id == Convert.ToInt32(ESkill.id) && d.approval_status != Convert.ToInt32(ESkill.status))
             .Select(d => d).FirstOrDefaultAsync();


                if (empSkill == null)
                {
                    Con = false;
                    break;
                }
                empSkill.approval_status = Convert.ToInt32(ESkill.status);
                _context.Entry(empSkill).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NoContent();
                }

            }
            return NoContent();
        }



        // POST: api/empskillsmodel1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<empskillsmodel1>> Postempskillsmodel1(empskillsmodel1 empskillsmodel1)
        {
            _context.empskillsmodel1.Add(empskillsmodel1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getempskillsmodel1", new { id = empskillsmodel1.id }, empskillsmodel1);
        }

        // DELETE: api/empskillsmodel1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<empskillsmodel1>> Deleteempskillsmodel1(int id)
        {
            var empskillsmodel1 = await _context.empskillsmodel1.FindAsync(id);
            if (empskillsmodel1 == null)
            {
                return NotFound();
            }

            _context.empskillsmodel1.Remove(empskillsmodel1);
            await _context.SaveChangesAsync();

            return empskillsmodel1;
        }

        private bool empskillsmodel1Exists(int id)
        {
            return _context.empskillsmodel1.Any(e => e.id == id);
        }
    }
}
