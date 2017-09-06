using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreContext;
using EasyTodoCoreASP;

namespace EasyTodoCoreASP.Controllers
{
    [Produces("application/json")]
    [Route("api/TodoDetailDatas")]
    public class TodoDetailDatasController : Controller
    {
        private readonly testModel _context;

        public TodoDetailDatasController(testModel context)
        {
            _context = context;
        }

		// GET: api/TodoDetailDatas
		[HttpGet]
        public IEnumerable<TodoDetailData> GetTodoDetailDatas()
        {
            return _context.TodoDetailDatas;
        }

        // GET: api/TodoDetailDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoDetailData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoDetailData = await _context.TodoDetailDatas.SingleOrDefaultAsync(m => m.UserId == id);

            if (todoDetailData == null)
            {
                return NotFound();
            }

            return Ok(todoDetailData);
        }

        // PUT: api/TodoDetailDatas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoDetailData([FromRoute] int id, [FromBody] TodoDetailData todoDetailData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoDetailData.UserId)
            {
                return BadRequest();
            }

            _context.Entry(todoDetailData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoDetailDataExists(id))
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

        // POST: api/TodoDetailDatas
        [HttpPost]
        public async Task<IActionResult> PostTodoDetailData([FromBody] TodoDetailData todoDetailData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TodoDetailDatas.Add(todoDetailData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TodoDetailDataExists(todoDetailData.UserId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTodoDetailData", new { id = todoDetailData.UserId }, todoDetailData);
        }

        // DELETE: api/TodoDetailDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoDetailData([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoDetailData = await _context.TodoDetailDatas.SingleOrDefaultAsync(m => m.UserId == id);
            if (todoDetailData == null)
            {
                return NotFound();
            }

            _context.TodoDetailDatas.Remove(todoDetailData);
            await _context.SaveChangesAsync();

            return Ok(todoDetailData);
        }

        private bool TodoDetailDataExists(int id)
        {
            return _context.TodoDetailDatas.Any(e => e.UserId == id);
        }
    }
}