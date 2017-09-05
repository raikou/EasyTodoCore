using System;

namespace EasyTodoCoreConnectionClass
{
    public class TodoDetailData
	{
		public int UserId { get; set; }
		public int DataId { get; set; }
		public String Title { get; set; }
		public String Detail { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int State { get; set; }
		public int ColorId { get; set; }
	}
}
