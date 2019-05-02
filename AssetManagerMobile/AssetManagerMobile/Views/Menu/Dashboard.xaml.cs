using AssetManagerMobile.Data;
using AssetManagerMobile.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetManagerMobile.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Dashboard : ContentPage
	{
        readonly IList<CItem> items = new ObservableCollection<CItem>();
        readonly CItemManager manager = new CItemManager();
        public Dashboard ()
		{
           BindingContext = items;
            InitializeComponent();
            Init();
            Refresh();
           
		}

        void Init()
        {
            BackgroundColor = CConstants.BackgroundColor;
      
        }
       public  void Scan_Clicked(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Android)
            {
                 DependencyService.Register<IQrScanner>();
                 DependencyService.Get<IQrScanner>().StartNativeActivity();
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
               //TODO: Craete IOS Scan Page
            }
            
        }

        async void Refresh()
        {
            this.IsBusy = true;
            try
            {
                var ItemCollection = await manager.GetAll();
                foreach (CItem item in ItemCollection)
                {
                    items.Add(item);
                }
            }
            finally
            {

                this.IsBusy = false;
            }
        }
    }
}