using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EasyTodoCoreConnectionClass;
using EasyTodoCorePrism.Views;
using EasyTodoCorePrism.Models;
using Prism.Common;
using Prism.Regions;

namespace EasyTodoCorePrism.ViewModels
{
	public class ToDoDetailControlViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
	{
		#region Model情報
		ToDoList toDoList = new ToDoList();
		TodoDetailData SelectItem = new TodoDetailData();
		#endregion

		#region コマンド

		public DelegateCommand BackCommand { get; }

		#endregion

		#region パラメータ
		public IRegionManager RegionManager
		{
			get { return navigationService.Region.RegionManager; }
		}
		public bool KeepAlive { get; set; } = true;
		private IRegionNavigationService navigationService;

		#endregion

		#region コンストラクタ

		public ToDoDetailControlViewModel()
		{
			BackCommand = new DelegateCommand(() =>
			{
				this.KeepAlive = false;
				// find view by region
				var view = this.RegionManager.Regions["MainRegion"]
					.ActiveViews
					.First(x => MvvmHelpers.GetImplementerFromViewOrViewModel<ToDoDetailControlViewModel>(x) == this);
				// deactive view
				this.RegionManager.Regions["MainRegion"].Deactivate(view);

				this.RegionManager.RequestNavigate("MainRegion", nameof(ToDoListControlView));
			});

		}

		#endregion


		#region ナビゲーション
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			Debug.WriteLine("IsNavigationTarget");
			return true;
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Debug.WriteLine("OnNavigatedTo");
			TodoDetailData todoDetailData= navigationContext.Parameters["SelectItem"] as TodoDetailData;

			//画面遷移時のデータ取得（ここで良いのかな？）
			this.SelectItem = todoDetailData;

			this.navigationService = navigationContext.NavigationService;//公式参照するとこっちが書いてあるのでこっちでは？http://vdlz.xyz/Csharp/ToolKit/MVVM/Prism/Doc/DG50/DG50_005.html
		}

		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			Debug.WriteLine("OnNavigatedFrom");
		}

		#endregion
	}
}
