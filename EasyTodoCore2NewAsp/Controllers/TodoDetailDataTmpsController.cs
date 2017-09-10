using System.Collections.Generic;
using System.Linq;
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
		public TodoDetailDataTmpsController()
		{
		}

		// GET: api/TodoDetailDatas
		[HttpGet]
		public IEnumerable<TodoDetailData> GetTodoDetailDatas()
		{
			using (var context = new PgContext())
			{
				var dataList = context.TodoDetailDataTmpPgs.ToList();
				var result = Clone.Convert<TodoDetailData, TodoDetailDataTmpPg>(dataList);
				return result;
			}
		}

		[HttpGet("{UserId}")]
		public IEnumerable<TodoDetailData> GetTodoDetailDataUsers([FromRoute]int UserId)
		{
			using (var context = new PgContext())
			{
				var dataList = context.TodoDetailDataTmpPgs.Where(x => x.UserId == UserId).ToList();
				var result = Clone.Convert<TodoDetailData, TodoDetailDataTmpPg>(dataList);
				return result;
			}
		}

		[HttpGet("{UserId}/{DataId}")]
		public TodoDetailData GetTodoDetailData([FromRoute]int UserId, [FromRoute] int DataId)
		{
			using (var context = new PgContext())
			{
				var data = context.TodoDetailDataTmpPgs.Where(x => x.UserId == UserId && x.DataId == DataId);
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
		public TodoDetailData TodoDetailDataAdd([FromBody] TodoDetailData requestData)
		{
			using (var context = new PgContext())
			{
				var addData = new TodoDetailDataTmpPg();
				Clone.Convert(requestData, addData);
				addData.Id = context.TodoDetailDataTmpPgs.Max(x => x.Id) + 1;//最大値に1増やす
				context.TodoDetailDataTmpPgs.Add(addData);
				context.SaveChanges();
				var data = context.TodoDetailDataTmpPgs.Where(x => x.UserId == requestData.UserId && x.DataId == requestData.DataId);
				var result = Clone.Convert<TodoDetailData>(data);
				return result;
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
			using (var context = new PgContext())
			{
				var data = context.TodoDetailDataTmpPgs.Where(x => x.UserId == requestData.UserId && x.DataId == requestData.DataId);
				foreach (TodoDetailDataTmpPg item in data)
				{
					Clone.Convert(requestData, item);
				}
				context.Entry(data).State = EntityState.Modified;
				context.SaveChanges();
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
			using (var context = new PgContext())
			{
				var removeData = context.TodoDetailDataTmpPgs.FirstOrDefault(x => x.UserId == UserId && x.DataId == DataId);
				if (removeData == null) return;
				context.TodoDetailDataTmpPgs.Remove(removeData);
				context.SaveChanges();
			}
		}
	}
}