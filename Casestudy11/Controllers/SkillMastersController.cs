using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Casestudy11.Data;
using Casestudy11.Model;
using casestudy11.Data;
using SkillMgnt.Data;

/// <summary>
/// APis for skill master
/// </summary>
namespace Casestudy11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillMastersController : ControllerBase
    {
        //    private readonly WebApiContext _context;
        private readonly ISkillMgntContext _context;

        public SkillMastersController(ISkillMgntContext context)
        {
            _context = context;
        }

        // GET: api/SkillMasters
        /// <summary>
        /// Api will fetch all the skills in an organization
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillMaster>>> GetSkillMaster()
        {
            //return await _context.SkillMaster.ToListAsync();
            return  _context.SkillMaster.ToList();
        }
/*
        // GET: api/SkillMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillMaster>> GetSkillMaster(int id)
        {
            var skillMaster = await _context.SkillMaster.FindAsync(id);

            if (skillMaster == null)
            {
                return NotFound();
            }

            return skillMaster;
        }

                // PUT: api/SkillMasters/5
                // To protect from overposting attacks, enable the specific properties you want to bind to, for
                // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
                [HttpPut("{id}")]
                public async Task<IActionResult> PutSkillMaster(int id, SkillMaster skillMaster)
                {
                    if (id != skillMaster.skillId)
                    {
                        return BadRequest();
                    }

                    _context.Entry(skillMaster).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SkillMasterExists(id))
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

                // POST: api/SkillMasters
                // To protect from overposting attacks, enable the specific properties you want to bind to, for
                // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
                [HttpPost]
                public async Task<ActionResult<SkillMaster>> PostSkillMaster(SkillMaster skillMaster)
                {
                    _context.SkillMaster.Add(skillMaster);
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        if (SkillMasterExists(skillMaster.skillId))
                        {
                            return Conflict();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return CreatedAtAction("GetSkillMaster", new { id = skillMaster.skillId }, skillMaster);
                }

                // DELETE: api/SkillMasters/5
                [HttpDelete("{id}")]
                public async Task<ActionResult<SkillMaster>> DeleteSkillMaster(int id)
                {
                    var skillMaster = await _context.SkillMaster.FindAsync(id);
                    if (skillMaster == null)
                    {
                        return NotFound();
                    }

                    _context.SkillMaster.Remove(skillMaster);
                    await _context.SaveChangesAsync();

                    return skillMaster;
                }

                private bool SkillMasterExists(int id)
                {
                    return _context.SkillMaster.Any(e => e.skillId == id);
                }
*/

    }

}
