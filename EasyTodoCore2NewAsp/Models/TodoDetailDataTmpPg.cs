using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTodoCore2NewAsp.Models
{
	[Table("todo_detail_data_tmp")]
	public class TodoDetailDataTmpPg
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }
		[Column("user_id")]
		public int UserId { get; set; }
		[Column("data_id")]
		public int DataId { get; set; }
		[Column("title")]
		public string Title { get; set; }
		[Column("detail")]
		public string Detail { get; set; }
		[Column("start_date")]
		public DateTime? StartDate { get; set; }
		[Column("end_date")]
		public DateTime? EndDate { get; set; }
		[Column("state")]
		public int? State { get; set; }
		[Column("color_id")]
		public int? ColorId { get; set; }
	}
}