using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyTodoCoreConnectionClass
{
	public static class Clone
	{
		/// <summary>
		/// from から to に同名のフィールドの値をコピーする
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static T Convert<T>(Object from, T to)
		{
			Type toType = to.GetType();
			Type fromType = from.GetType();
			var fields = fromType.GetRuntimeFields();
			foreach (FieldInfo info in fields)
			{
				var data = toType.GetRuntimeProperty(info.Name);
				info.SetValue(info, data);
			}

			return to;
		}
	}
}