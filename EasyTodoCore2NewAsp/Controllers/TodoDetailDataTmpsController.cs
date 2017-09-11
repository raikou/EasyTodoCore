using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyTodoCore2NewAsp.Models;
using EasyTodoCoreConnectionClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyTodoCore2NewAsp.Controllers
{
	[Produces("application/json")]
	[Route("api/TodoDetailDatas")]
	public class TodoDetailDataTmpsController : Controller
	{
		private PgContext _context = new PgContext();

		public TodoDetailDataTmpsController()
		{
		}

		//TODO:全取得はないはず…
		//// GET: api/TodoDetailDatas
		//[HttpGet]
		//public IEnumerable<TodoDetailData> GetTodoDetailDatas()
		//{
		//	{
		//		var dataList = _context.TodoDetailDataTmpPgs.ToList();
		//		var result = Clone.Convert<TodoDetailData, TodoDetailDataTmpPg>(dataList);
		//		return result;
		//	}
		//}

		[HttpGet("{UserId}")]
		public async Task<IActionResult> GetTodoDetailDataUsers([FromRoute]int UserId)
		{
			{
				List<TodoDetailData> result;
				var dataList =  _context.TodoDetailDataTmpPgs.Where(x => x.UserId == UserId).ToList();
				 result = Clone.Convert<TodoDetailData, TodoDetailDataTmpPg > (dataList);
				return Ok(result);
			}
		}

		[HttpGet("{UserId}/{DataId}")]
		public TodoDetailData GetTodoDetailData([FromRoute]int UserId, [FromRoute] int DataId)
		{
			{
				var data = _context.TodoDetailDataTmpPgs.Where(x => x.UserId == UserId && x.DataId == DataId);
				var result = Clone.Convert<TodoDetailData>(data);
				return result;
			}
		}

		/// <summary>
		/// 追加
		/// </summary>
		/// <param name="requestData"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> TodoDetailDataAdd([FromBody] TodoDetailData requestData)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			{
				var addData = new TodoDetailDataTmpPg();
				Clone.Convert(requestData, addData);
				addData.Id = _context.TodoDetailDataTmpPgs.Max(x => x.Id) + 1;//最大値に1増やす
				_context.TodoDetailDataTmpPgs.Add(addData);
				_context.SaveChangesAsync();

				return Ok(requestData);
			}
		}


		/// <summary>
		/// 上書き
		/// </summary>
		/// <param name="requestData"></param>
		/// <returns></returns>
		[HttpPut]
		public TodoDetailData TodoDetailDataUpdate([FromBody] TodoDetailData requestData)
		{
			{
				var data = _context.TodoDetailDataTmpPgs.Where(x => x.UserId == requestData.UserId && x.DataId == requestData.DataId);
				foreach (TodoDetailDataTmpPg item in data)
				{
					Clone.Convert(requestData, item);
				}
				_context.Entry(data).State = EntityState.Modified;
				_context.SaveChanges();
				var result = Clone.Convert<TodoDetailData>(data);
				return result;
			}
		}


		/// <summary>
		/// 削除
		/// ユーザー削除は想定していない
		/// </summary>
		[HttpDelete("{UserId}/{DataId}")]
		public void TodoDetailDataDelete([FromRoute]int UserId, [FromRoute] int DataId)
		{
			{
				var removeData = _context.TodoDetailDataTmpPgs.FirstOrDefault(x => x.UserId == UserId && x.DataId == DataId);
				if (removeData == null) return;
				_context.TodoDetailDataTmpPgs.Remove(removeData);
				_context.SaveChanges();
			}
		}
	}
}