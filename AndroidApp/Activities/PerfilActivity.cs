using Android.Views;
using Android.Content;
using Google.Android.Material.Navigation;

namespace AndroidApp.Activities
{
    [Activity(Label = "com.ifpr_telemacoborba.alerts.PerfilActivity")]
    public class PerfilActivity : Activity, NavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            /*RelativeLayout? buttonPerfil = FindViewById<RelativeLayout>(Resource.Id.main_content);
            if(buttonPerfil != null)
            {
            }*/
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

            if (id == Resource.Id.navigation_meus_dados)
            {
                var intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.navigation_meus_grupos)
            {

            }
            else if (id == Resource.Id.navigation_sair)
            {
                Finish();
            }

            return true;
        }

        public override void OnBackPressed()
        {
            Finish();
        }
    }
}