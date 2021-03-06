﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using EasyTodoCoreConnectionClass;
using EasyTodoCorePrism.Models;
using EasyTodoCorePrism.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Common;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;

namespace EasyTodoCorePrism.ViewModels
{
	public class ToDoListControlViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
	{
		public string HeaderText { get; } = "ToDoListCommand";

		#region Model情報
		ToDoList toDoList = new ToDoList();
		#endregion

		#region パラメータ
		public IRegionManager RegionManager
		{
			get { return navigationService.Region.RegionManager; }
		}
		public bool KeepAlive { get; set; } = true;
		private IRegionNavigationService navigationService;
		#endregion

		#region 通知ダイアログ
		/// <summary>
		/// メッセージ用（OKのみ）
		/// </summary>
		public InteractionRequest<Notification> NotificationRequest { get; } = new InteractionRequest<Notification>();
		#endregion
		#region コマンドリスト
		public DelegateCommand GetMainListCommand { get; }
		public DelegateCommand AddCommand { get; }
		public DelegateCommand UpdCommand { get; }
		public DelegateCommand DelCommand { get; }
		public DelegateCommand DetailCommand { get; }
		#endregion

		#region コマンドで利用する画面情報

		private List<TodoDetailData> gridItem = new List<TodoDetailData>();
		public List<TodoDetailData> GridItem
		{
			get { return this.gridItem; }
			set { this.SetProperty(ref this.gridItem, value); }
		}

		private TodoDetailData selectedItem = new TodoDetailData();
		public TodoDetailData SelectedItem
		{
			get { return this.selectedItem; }
			set { this.SetProperty(ref this.selectedItem, value); }
		}

		#endregion

		#region コンストラクタ

		public ToDoListControlViewModel()
		{
			//初期データ取得
			//GridItem = toDoList.GetUserList().Result;
			var list = new List<TodoDetailData>()
			{
				new TodoDetailData()
				{
					UserId = 0
					, DataId = 0
				}
			};

			GridItem = list;

			//コマンド生成
			this.GetMainListCommand = new DelegateCommand(() =>
			{
				GetUserDataList();

			});
			this.AddCommand = new DelegateCommand(() =>
			{
				var baseData = GridItem.FirstOrDefault();
				int userId = baseData?.UserId ?? 0;
				int dataId = baseData?.DataId + 1 ?? 0;

				var data = new TodoDetailData()
				{
					UserId = userId
					, DataId = dataId
				};
				
				 var result = toDoList.Post(data, GridItem).Result;

				ToDetail(result);


			});
			this.UpdCommand = new DelegateCommand(() =>
			{
				this.NotificationRequest.Raise(new Notification { Title = "Alert", Content = "未実装です" });
			});
			this.DelCommand = new DelegateCommand(() =>
			{
				this.NotificationRequest.Raise(new Notification { Title = "Alert", Content = "未実装です" });
			});
			this.DetailCommand = new DelegateCommand(() =>
			{
				ToDetail(SelectedItem);
			});
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

			GetUserDataList();

			this.navigationService = navigationContext.NavigationService;//公式参照するとこっちが書いてあるのでこっちでは？http://vdlz.xyz/Csharp/ToolKit/MVVM/Prism/Doc/DG50/DG50_005.html
		}

		#region 処理関数

		private void GetUserDataList()
		{
			GridItem = toDoList.GetById(0).Result;
		}

		private void ToDetail(TodoDetailData detailInfo)
		{
			this.KeepAlive = false;
			//TODO:情報残るようなら以下のコメントを消す
			// find view by region
			var view = RegionManager.Regions["MainRegion"]
				.ActiveViews
				.First(x => MvvmHelpers.GetImplementerFromViewOrViewModel<ToDoListControlViewModel>(x) == this);
			// deactive view
			this.RegionManager.Regions["MainRegion"].Deactivate(view);
			NavigationParameters param = new NavigationParameters();
			param.Add("SelectedDetailItem", detailInfo);

			this.RegionManager.RequestNavigate("MainRegion", nameof(ToDoDetailControlView), param);
		}

		#endregion

		#endregion
	}
}
