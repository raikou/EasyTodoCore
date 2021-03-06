﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyTodoCore2NewAsp.Models
{
	public static class Clone
	{
		/// <summary>
		/// from から 指定した型のデータ に同名のフィールドの値をコピーする（リストで返す）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="from"></param>
		/// <returns></returns>
		public static List<T> Convert<T, E>(List<E> from) where T : new()
		{
			var result = new List<T>();
			foreach (var data in from)
			{
				result.Add(Convert<T>(data));
			}
			return result;
		}


		/// <summary>
		/// from から 指定した型のデータ に同名のフィールドの値をコピーする
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="from"></param>
		/// <returns></returns>
		public static T Convert<T>(object from) where T : new()
		{
			return Convert<T>(from, new T());
		}

		/// <summary>
		/// from から 指定した型のデータ に同名のフィールドの値をコピーする
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="from"></param>
		/// <returns></returns>
		public static T Convert<T>(object from, T to) where T : new()
		{
			var result = to;
			Type toType = result.GetType();
			Type fromType = from.GetType();
			var toInfoList = toType.GetProperties();

			foreach (PropertyInfo info in toInfoList)
			{
				var pro = fromType.GetProperty(info.Name);
				if (pro != null)
				{
					info.SetValue(result, pro.GetValue(from));
				}
			}

			return result;
		}

	}
}