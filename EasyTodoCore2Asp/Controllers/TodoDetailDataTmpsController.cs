using System.Collections.Generic;
using System.Linq;
using EasyTodoCore2Asp.Models;
using EasyTodoCoreConnectionClass;
using Microsoft.AspNetCore.Mvc;

namespace EasyTodoCore2Asp.Controllers
{
	[Produces("application/json")]
	[Route("api/TodoDetailDataTmps")]
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
				var result = Clone.Convert<TodoDetailData, TodoDetailDataTmpPg >(dataList);
				return result;
			}
		}
	}
}