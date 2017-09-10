using Microsoft.EntityFrameworkCore;

namespace EasyTodoCore2NewAsp.Models
{
	public class PgContext :DbContext
	{
		public DbSet<TodoDetailDataTmpPg> TodoDetailDataTmpPgs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=192.168.24.77;Username=ruser;Password=raikou;Database=todo_data");
		}
	}
}