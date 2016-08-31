using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using iFlota.Forms.Util;

namespace iFlota.Forms.Droid
{
    [Activity(Label = "iFlota.Forms", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IAutenticar
    {
        public async Task<bool> Autenticar(MobileServiceAuthenticationProvider servicio)
        {
            var success = false;
            var message = string.Empty;
            MobileServiceUser user;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await LoginManager.Instancia.MobileClient.LoginAsync(this,
                    servicio);
                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.",
                        user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return success;

        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoginManager.Init(this);

            LoadApplication(new App());
        }
    }
}

