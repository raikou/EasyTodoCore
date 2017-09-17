using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTodoCore2NewAsp.Models
{
	/*
	drop table user_list;

	CREATE TABLE user_list(
	id int
	, user_name varchar(100)
	, user_pass varchar(200)
	, user_id int
	, primary key(id)
	);

	alter table user_list add constraint user_list_unique unique(user_name, user_pass);	 
*/
	[Table("user_list")]
	public class UserList
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }
		[Column("user_name")]
		public int UserName { get; set; }
		[Column("user_pass")]
		public int UserPass { get; set; }
		[Column("user_id")]
		public int UserId { get; set; }
	}
}