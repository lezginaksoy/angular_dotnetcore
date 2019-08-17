using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment_Transactions.Model;
using Payment_Transactions.Model.Interface;

namespace Payment_Transactions.Controllers
{
    [Produces("application/json")]
    [Route("api/Terminals")]
    public class TerminalsController : Controller
    {
       
        private readonly ITerminalRepository _TermRepo;

        public TerminalsController(ITerminalRepository Repository)
        {
            _TermRepo = Repository;
        }

        // GET: api/Terminals
        [HttpGet]
        public IEnumerable<Terminal> GetTerminal()
        {
            var term= _TermRepo.GetAll();

            return _TermRepo.GetAll(); 
        }

        // POST: api/Terminals
        [HttpPost]
        public IActionResult PostTerminal([FromBody] Terminal terminal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int res = _TermRepo.Create(terminal);
            if (res != 0)
            {
                return Ok(res);
            }
            return NotFound();
        }
        

        // GET: api/Terminals/5
        [HttpGet("{id}")]
        public IActionResult GetTerminal([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var term =_TermRepo.GetById(id);
            if (term == null)
            {
                return NotFound();
            }
            return Ok(term);          
        }

        // GET: api/Terminals/5
        [HttpGet("{termId}")]
        [HttpGet("TermId")]
        public IActionResult GetTerminal([FromRoute] string TermId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var term = _TermRepo.GetAll();
            if (term == null)
            {
                return NotFound();
            }
            return Ok(term);
        }


        // PUT: api/Terminals/5
        [HttpPut("{id}")]
        public IActionResult PutTerminal([FromRoute] int id, [FromBody] Terminal terminal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != terminal.ID)
            {
                return BadRequest();
            }

            try
            {
                int res = _TermRepo.Update(terminal);
                if (res != 0)
                {
                    return Ok(res);
                }

            }
            catch (Exception)
            {

                if (!TerminalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           
            return NotFound();

        }
        

        // DELETE: api/Terminals/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTerminal([FromBody]Terminal value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                int res = _TermRepo.Delete(value);
                if (res != 0)
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                if (!TerminalExists(value.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;

                }
            }

            return NotFound();
        }

        private bool TerminalExists(int id)
        {
           return _TermRepo.Any(e => e.ID == id);
        }


    }
}