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
using Microsoft.AspNetCore.Cors;
using casestudy11.Data;
using SkillMgnt.Data;

namespace Casestudy11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSkillsController : ControllerBase
    {
        // private readonly WebApiContext _context;
        private readonly ISkillMgntContext _context;

        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EmployeeSkillsController));



        public EmployeeSkillsController(ISkillMgntContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeSkills
        /// <summary>
        /// Api will fetch all the Employee  with there skills who are registered in an organization
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("/Manager")]
        [HttpGet]
        public async Task<Object> GetMgrEmployeeSkill1([FromQuery] string user)
        {
            var r = _context.EmployeeInfo.Where(e => e.pmId != null).Where(e => e.pmId.empId == Convert.ToInt32(user)).Select(e => e.empId).ToList();
            var res = new List<Object>();
            dynamic el;
            foreach (int eid in r)
            {
                el = _context.EmployeeSkill
                           .Where(e => e.approvalStatus == 0).Where(e => e.empId.empId == eid)
                           .Select(e => new { e.primary, e.empId.empId, e.empName, e.rating, e.hccOrganization, e.grade, e.lastUpdatedDate, e.skillStartDate, e.skillEndDate, e.skillType, e.approvedBy, e.approvedDate, e.SkillId.skillId, e.approvalStatus })
                           .ToList();
                foreach (var item in el)
                {
                    res.Add(item);
                }
            }
            return res.ToList();
        }




        [HttpGet]
        public Object GetEmployeeSkill()
        {
            var res = from e in _context.EmployeeSkill
                      select new { e.primary, e.empId.empId, e.empName, e.rating, e.hccOrganization, e.grade, e.lastUpdatedDate, e.skillStartDate, e.skillEndDate, e.skillType, e.approvedBy, e.approvedDate, e.SkillId.skillId, e.approvalStatus };
            if (res == null)
            {
                return NotFound("");
            }

            return res.ToList();
        }

        // GET: api/EmployeeSkills/5

        /// <summary>
        /// Api will fetch details of a perticular employee and skills who registered in organization from EmpIdSkillIdDto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="es"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeSkill>> GetEmployeeSkill(int id, [FromQuery] EmpIdSkillIdDto es)
        {
            EmployeeSkill empSkill = await _context.EmployeeSkill.Where(d => d.empId.empId == es.empId && d.SkillId.skillId == es.skillId)
                .Select(d => d)
                .FirstOrDefaultAsync();

            //var employeeSkill = await _context.EmployeeSkill.FindAsync(id);
            EmployeeInfo emp = await _context.EmployeeInfo.FindAsync(es.empId);
            SkillMaster skill = await _context.SkillMaster.FindAsync(es.skillId);
            empSkill.empId = emp;
            empSkill.SkillId = skill;

            if (empSkill == null)
            {
                return NotFound();
            }

            return empSkill;
        }

        // PUT: api/EmployeeSkills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// to update the details of employee who are already registered in skills
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeSkillDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeSkill(int id, EmployeeSkillDTO employeeSkillDto)
        {
            //if (id != employeeSkill.pkAuto)
            //{
            //    return BadRequest();
            //}

            EmployeeSkill empSkill = await _context.EmployeeSkill.Where(d => d.empId.empId == employeeSkillDto.empId && d.SkillId.skillId == employeeSkillDto.SkillId)
                .Select(d => d).FirstOrDefaultAsync();

            //var employeeSkill = await _context.EmployeeSkill.FindAsync(id);
            EmployeeInfo emp = await _context.EmployeeInfo.FindAsync(employeeSkillDto.empId);
            SkillMaster skill = await _context.SkillMaster.FindAsync(employeeSkillDto.SkillId);

            if (emp == null || skill == null)
            {
                return NotFound();
            }

            empSkill.empId = emp;
            empSkill.SkillId = skill;

            empSkill.pkAuto = empSkill.pkAuto;
            empSkill.primary = employeeSkillDto.primary;
            empSkill.empId = emp; 
            empSkill.empName = employeeSkillDto.empName;
            empSkill.rating = employeeSkillDto.rating;
            empSkill.hccOrganization = employeeSkillDto.hccOrganization;
            empSkill.grade = employeeSkillDto.grade;
            empSkill.lastUpdatedDate = employeeSkillDto.lastUpdatedDate;
            empSkill.skillStartDate = employeeSkillDto.skillStartDate;
            empSkill.skillEndDate = employeeSkillDto.skillEndDate;
            empSkill.group = employeeSkillDto.group;
            empSkill.skillType = employeeSkillDto.skillType;
            empSkill.approvedBy = employeeSkillDto.approvedBy;
            empSkill.approvedDate = employeeSkillDto.approvedDate;
            empSkill.SkillId = skill;
            empSkill.approvalStatus = employeeSkillDto.approvalStatus;

            //  _context.Entry(empSkill).State = EntityState.Modified;
            _context.MarkAsModified(empSkill);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
        //////////////////////////////////////
        ///

        [HttpPut]
        public async Task<IActionResult> PutEmployeeSkill(EmpSkillPostDTO empSkillPostDTO)
        {
            EmployeeSkill empSkill = await _context.EmployeeSkill.Where(d => d.empId.empId == Convert.ToInt32(empSkillPostDTO.empId) && d.SkillId.skillId == Convert.ToInt32(empSkillPostDTO.SkillId))
            .Select(d => d).FirstOrDefaultAsync();




            EmployeeInfo emp = await _context.EmployeeInfo.FindAsync(Convert.ToInt32(empSkillPostDTO.empId));
            SkillMaster skill = await _context.SkillMaster.FindAsync(Convert.ToInt32(empSkillPostDTO.SkillId));



            if (empSkill == null || emp == null || skill == null)
            {

              _log4net.Fatal(DateTime.Today.Date + "; Input = " + empSkillPostDTO.empId + "; Controller: EmployeeSkillsController" + "; Exception: Given details of Emp_Skill does not exist");
                return NotFound();
            }



            empSkill.empId = emp;
            empSkill.SkillId = skill;



            empSkill.pkAuto = empSkill.pkAuto;
            empSkill.primary = Convert.ToInt32(empSkillPostDTO.primary);
            empSkill.empId = emp;
            empSkill.rating = Convert.ToInt32(empSkillPostDTO.rating);



            empSkill.lastUpdatedDate = DateTime.Now;

            empSkill.skillStartDate = empSkillPostDTO.skillStartDate;
            empSkill.skillEndDate = empSkillPostDTO.skillEndDate;
            empSkill.group = empSkillPostDTO.group;
            empSkill.skillType = empSkillPostDTO.skillType;
            empSkill.SkillId = skill;
            empSkill.approvalStatus = 0;



            //   _context.Entry(empSkill).State = EntityState.Modified;

            _context.MarkAsModified(empSkill);



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }



            return NoContent();

        }




            /*
             POST: api/EmployeeSkills
             To protect from overposting attacks, enable the specific properties you want to bind to, for
             more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<EmployeeSkill>> PostEmployeeSkill(EmployeeSkill employeeSkill)
            {
                _context.EmployeeSkill.Add(employeeSkill);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmployeeSkill", new { id = employeeSkill.pkAuto }, employeeSkill);
            }

            //POST: api/EmployeeSkillss
            [HttpPost]
            public async Task<ActionResult<EmployeeSkill>> PostEmployeeSkill(EmployeeSkillDTO employeeSkillDto)
            {
                EmployeeInfo emp = await _context.EmployeeInfo.FindAsync(employeeSkillDto.empId);
                SkillMaster skill = await _context.SkillMaster.FindAsync(employeeSkillDto.SkillId);

                EmployeeSkill empSkill = new EmployeeSkill();
                empSkill.primary = employeeSkillDto.primary;
                empSkill.empId = emp;
                empSkill.empName = employeeSkillDto.empName;
                empSkill.rating = employeeSkillDto.rating;
                empSkill.hccOrganization = employeeSkillDto.hccOrganization;
                empSkill.grade = employeeSkillDto.grade;
                empSkill.lastUpdatedDate = employeeSkillDto.lastUpdatedDate;
                empSkill.skillStartDate = employeeSkillDto.skillStartDate;
                empSkill.skillEndDate = employeeSkillDto.skillEndDate;
                empSkill.group = employeeSkillDto.group;
                empSkill.skillType = employeeSkillDto.skillType;
                empSkill.approvedBy = employeeSkillDto.approvedBy;
                empSkill.approvedDate = employeeSkillDto.approvedDate;
                empSkill.SkillId = skill;
                empSkill.approvalStatus = employeeSkillDto.approvalStatus;

                _context.EmployeeSkill.Add(empSkill);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEmployeeSkill", new { id = empSkill.pkAuto }, employeeSkillDto);
            }
    */
            /// <summary>
            /// post API will create new employee who want to register with skills
            /// </summary>
            /// <param name="empSkillPostDTO"></param>
            /// <returns></returns>
            [HttpPost]
        public async Task<ActionResult<EmployeeSkill>> PostEmployeeSkill(EmpSkillPostDTO empSkillPostDTO)
        {
            EmployeeInfo emp = await _context.EmployeeInfo.FindAsync(Convert.ToInt32(empSkillPostDTO.empId));
            SkillMaster skill = await _context.SkillMaster.FindAsync(Convert.ToInt32(empSkillPostDTO.SkillId));


            if (emp == null || skill == null)
            {
                return NotFound();
            }

            var check = await _context.EmployeeSkill.Where(e => e.empId.empId == Convert.ToInt32(empSkillPostDTO.empId) && e.SkillId.skillId == Convert.ToInt32(empSkillPostDTO.SkillId)).Select(e => e).FirstOrDefaultAsync();
            if (check != null)
            {
                return BadRequest("Skill already exists !!");
            }

            EmployeeSkill empSkill = new EmployeeSkill();
            empSkill.primary = Convert.ToInt32(empSkillPostDTO.primary);
            empSkill.empId = emp;

            empSkill.empName = emp.empName;

            empSkill.rating = Convert.ToInt32(empSkillPostDTO.rating);

            empSkill.hccOrganization = emp.hccOrganization;

            empSkill.grade = emp.grade;

            empSkill.lastUpdatedDate = DateTime.Now;
            empSkill.skillStartDate = Convert.ToDateTime(empSkillPostDTO.skillStartDate);
            empSkill.skillEndDate = Convert.ToDateTime(empSkillPostDTO.skillEndDate);
            empSkill.group = empSkillPostDTO.group;
            empSkill.skillType = empSkillPostDTO.skillType;

            empSkill.approvedBy = null;

            empSkill.approvedDate = null;

            empSkill.SkillId = skill;

            //empSkill.approvalStatus = Convert.ToInt32(empSkillPostDTO.approvalStatus);
            empSkill.approvalStatus = 0;

            _context.EmployeeSkill.Add(empSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeSkill", new { id = empSkill.pkAuto }, empSkillPostDTO);
        }

        // DELETE: api/EmployeeSkills/5

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeSkill>> DeleteEmployeeSkill(int id, [FromQuery] EmpIdSkillIdDto es)
        {
            EmployeeSkill empSkill = await _context.EmployeeSkill.Where(d => d.empId.empId == es.empId && d.SkillId.skillId == es.skillId)
                .Select(d => d).FirstOrDefaultAsync();

            //var employeeSkill = await _context.EmployeeSkill.FindAsync(id);
            EmployeeInfo emp = await _context.EmployeeInfo.FindAsync(es.empId);
            SkillMaster skill = await _context.SkillMaster.FindAsync(es.skillId);
            empSkill.empId = emp;
            empSkill.SkillId = skill;

            if (empSkill == null || emp == null || skill == null)
            {
                return NotFound();
            }

            _context.EmployeeSkill.Remove(empSkill);
            await _context.SaveChangesAsync();

            return empSkill;
        }
        private bool EmployeeSkillExists(int id)
        {
            return _context.EmployeeSkill.Any(e => e.pkAuto == id);
        }
    }
}
