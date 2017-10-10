using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CommonFirebase.Models
{
	public class FirebaseToken
	{
		public FirebaseToken()
		{
			using (StreamReader sr = new StreamReader(@"C:\Token\token.txt", Encoding.GetEncoding("Shift_JIS")))
			{
				_apiKey = sr.ReadLine();
				_authDomain = sr.ReadLine();
				_databaseUrl = sr.ReadLine();
				_storageBucket = sr.ReadLine();
			}
		}

		/// <summary>
		/// APIキー
		/// </summary>
		private  string _apiKey;
		public  string ApiKey { get { return _apiKey.Trim(); } }

		/// <summary>
		/// 認証ドメイン
		/// </summary>
		private  string _authDomain;
		public  string AuthDomain { get { return _authDomain.Trim(); } }

		/// <summary>
		/// データベースのURL
		/// </summary>
		private  string _databaseUrl;
		public  string DatabaseUrl { get { return _databaseUrl.Trim(); } }

		/// <summary>
		/// ストレージバケット
		/// </summary>
		private  string _storageBucket;
		public  string StorageBucket { get { return _storageBucket.Trim(); } }
	}

}
