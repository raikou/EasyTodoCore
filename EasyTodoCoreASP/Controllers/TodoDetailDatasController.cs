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
	    private readonly CoreContext.tododataModel _context;

        public TodoDetailDatasController()
        {
            _context = new CoreContext.tododataModel();
		}

		// GET: api/TodoDetailDatas
		[HttpGet]
        public IEnumerable<TodoDetailData> GetTodoDetailDatas()
        {
			return _context.TodoDetailDatas;
        }

        // GET: api/TodoDetailDatas/5
        [HttpGet("{UserId}/{DataId}")]
        public async Task<IActionResult> GetTodoDetailData([FromRoute] int UserId, [FromRoute] int DataId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoDetailData = await _context.TodoDetailDatas.SingleOrDefaultAsync(m => m.UserId == UserId && m.DataId == DataId);

            if (todoDetailData == null)
            {
                return NotFound();
            }

            return Ok(todoDetailData);
        }

        // PUT: api/TodoDetailDatas/5
        [HttpPut("{UserId}/{DataId}")]
        public async Task<IActionResult> PutTodoDetailData([FromRoute] int UserId, [FromRoute] int DataId, [FromBody] TodoDetailData todoDetailData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (UserId != todoDetailData.UserId)
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
                if (!TodoDetailDataExists(UserId, DataId))
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
                if (TodoDetailDataExists(todoDetailData.UserId, todoDetailData.DataId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTodoDetailData", new { UserId = todoDetailData.UserId, DataId = todoDetailData.DataId }, todoDetailData);
        }

        // DELETE: api/TodoDetailDatas/5
        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteTodoDetailData([FromRoute] int UserId, [FromRoute] int DataId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoDetailData = await _context.TodoDetailDatas.SingleOrDefaultAsync(m => m.UserId == UserId && m.DataId == DataId);
            if (todoDetailData == null)
            {
                return NotFound();
            }

            _context.TodoDetailDatas.Remove(todoDetailData);
            await _context.SaveChangesAsync();

            return Ok(todoDetailData);
        }

        private bool TodoDetailDataExists(int UserId, int DataId)
        {
            return _context.TodoDetailDatas.Any(e => e.UserId == UserId && e.DataId == DataId);
        }
    }
}