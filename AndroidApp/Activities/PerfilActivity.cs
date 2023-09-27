using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;
using Android.Content;


namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.PerfilActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class PerfilActivity : AppCompatActivity,  NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_perfil);

            NavigationView? navigationView = FindViewById<NavigationView>(Resource.Id.perfil_nav_view);
            if (navigationView != null)
            {
                navigationView.SetNavigationItemSelectedListener(this);
            }
        }


        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            goToPage(id);

            return true;
        }

        /// <summary>
        /// set the selected page by the selected button id
        /// </summary>
        /// <param name="itemId"></param>
        public void goToPage(int itemId){
            if (itemId == Resource.Id.navigation_login)
            {
                var intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
            }
            else if (itemId == Resource.Id.navigation_meus_dados)
            {
                var intent = new Intent(this, typeof(PerfilUsuarioActivity));
                StartActivity(intent);
            }
            else if (itemId == Resource.Id.navigation_meus_grupos)
            {

            }
            else if (itemId == Resource.Id.navigation_sair)
            {
                Finish();
            }
        }

        public override void OnBackPressed()
        {
            Finish();
        }
    }
}