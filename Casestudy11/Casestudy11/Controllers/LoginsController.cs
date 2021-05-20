using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Casestudy11.Model;
using casestudy11.Data;
using SkillMgnt.Data;

namespace Casestudy11uep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        // private readonly WebApiContext _context;

        private readonly ISkillMgntContext _context;

        public LoginsController(ISkillMgntContext context)
        {
            _context = context;
        }
        [HttpGet("{empid}&&{pass}")]
        public async Task<ActionResult<Login>> GetLogin(string empid, string pass)
        {
            var login =  _context.Login.Find(empid);

            if (login == null)
            {
                return NotFound("login is null");
            }

            var epass =  _context.Login.Where(e => e.empid == empid).Select(e => e.pass).FirstOrDefault();
            if (pass == epass)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //    // GET: api/Logins
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<Login>>> GetLogin()
        //    {
        //        return await _context.Login.ToListAsync();
        //    }

        //    // GET: api/Logins/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Login>> GetLogin(string id)
        //    {
        //        var login = await _context.Login.FindAsync(id);

        //        if (login == null)
        //        {
        //            return NotFound();
        //        }

        //        return login;
        //    }

        //    // PUT: api/Logins/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutLogin(string id, Login login)
        //    {
        //        if (id != login.empid)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(login).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LoginExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Logins
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPost]
        //    public async Task<ActionResult<Login>> PostLogin(Login login)
        //    {
        //        _context.Login.Add(login);
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (LoginExists(login.empid))
        //            {
        //                return Conflict();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtAction("GetLogin", new { id = login.empid }, login);
        //    }

        //    // DELETE: api/Logins/5
        //    [HttpDelete("{id}")]
        //    public async Task<ActionResult<Login>> DeleteLogin(string id)
        //    {
        //        var login = await _context.Login.FindAsync(id);
        //        if (login == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Login.Remove(login);
        //        await _context.SaveChangesAsync();

        //        return login;
        //    }

        //    private bool LoginExists(string id)
        //    {
        //        return _context.Login.Any(e => e.empid == id);
        //    }
        //}
    }
}
