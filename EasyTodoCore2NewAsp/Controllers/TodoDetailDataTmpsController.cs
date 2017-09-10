using System.Collections.Generic;
using System.Linq;
using EasyTodoCore2NewAsp.Models;
using EasyTodoCoreConnectionClass;
using Microsoft.AspNetCore.Mvc;

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
				var result = Clone.Convert<TodoDetailData, TodoDetailDataTmpPg >(dataList);
				return result;
			}
		}
	}
}