using AssetManagerMobile.Models;
using AssetManagerMobile.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssetManagerMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            Init();
		}

        private void Init()
        {
            BackgroundColor = CConstants.BackgroundColor;
            ActivitySpinner.IsVisible = false;
            txtUserName.Completed += (s, e) => txtPassword.Focus();
            txtPassword.Completed += async (s, e) => await Login_ClickedAsync(s, e);
            
        }

        private async Task Login_ClickedAsync(object sender, EventArgs e)
        {
            CUser user = new CUser();
            user.SetUser(txtPassword.Text, txtUserName.Text);
            if (user.ValidateText())
            {
                await DisplayAlert("Login", "Login was successful.", "OK");
                //var result = await App.RestService.Login(user);
                var result = new CToken();
                result.AccessToken = "";
                if (result.AccessToken != null)
                {
                    //App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);
                    if (Device.OS == TargetPlatform.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new Dashboard());
                    }else if (Device.OS == TargetPlatform.iOS)
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));
                    }
                }
            }
            else
              await DisplayAlert("Login", "Login was unsuccessful, empty username or password.", "OK");
        }
	}
}