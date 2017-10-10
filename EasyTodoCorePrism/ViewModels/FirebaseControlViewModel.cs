using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommonFirebase.Common;
using CommonFirebase.Models;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;

namespace EasyTodoCorePrism.ViewModels
{
	public class FirebaseControlViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
	{
		public string HeaderText { get; } = "Login";

		private readonly FirebaseModel _firebaseModel = new FirebaseModel();

		#region パラメータ
		public IRegionManager RegionManager
		{
			get { return navigationService.Region.RegionManager; }
		}
		public bool KeepAlive { get; set; } = true;
		private IRegionNavigationService navigationService;
		#region プロパティ（FirebaseModel）

		/// <summary>
		/// 認証に使うメールアドレス
		/// </summary>
		public string Email
		{
			get
			{
				return this._firebaseModel.Email;
			}
			set
			{
				this._firebaseModel.Email = value;
			}
		}

		/// <summary>
		/// 認証に使うパスワード
		/// </summary>
		public string Password
		{
			get
			{
				return this._firebaseModel.Password;
			}
			set
			{
				this._firebaseModel.Password = value;
			}
		}

		/// <summary>
		/// 認証結果
		/// </summary>
		public string AuthMessage
		{
			//get
			//{
			//	return this._firebaseModel.AuthMessage;
			//}
			get;
			set;
		}

		#endregion
		#endregion

		#region コマンドリスト
		private RelayCommand _signInCommand;
		public RelayCommand SignInCommand
		{
			get
			{
				return this._signInCommand = this._signInCommand ?? new RelayCommand(async () =>
				{
					await this._firebaseModel.SignInAsync();
					MessageBox.Show(_firebaseModel.AuthMessage);
				});
			}
		}

		/// <summary>
		/// サインアップ
		/// </summary>
		public RelayCommand SignUpCommand
		{
			get
			{
				return this._signUpCommand = this._signUpCommand ?? new RelayCommand(async () =>
				{
					await this._firebaseModel.SignUpAsync();
					MessageBox.Show(_firebaseModel.AuthMessage);
				});
			}
		}
		private RelayCommand _signUpCommand;
		#endregion
		#region コンストラクタ

		public FirebaseControlViewModel()
		{

		}


		#endregion

		#region INavigationAware

		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			Debug.WriteLine("NavigatedFrom");
		}

		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Debug.WriteLine("NavigatedTo");

			this.navigationService = navigationContext.NavigationService;//公式参照するとこっちが書いてあるのでこっちでは？http://vdlz.xyz/Csharp/ToolKit/MVVM/Prism/Doc/DG50/DG50_005.html
		}

		#endregion

	}
}
