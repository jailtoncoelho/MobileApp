using Android.Content;
using Android.Views;
using AndroidApp.Activities;
using Google.Android.Material.BottomNavigation;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            BottomNavigationView? navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation_view);
            navigationView?.SetOnNavigationItemSelectedListener(this);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            goToPage(id);

            return true;
        }

        /// <summary>
        /// Set the selected page by the button clicked
        /// </summary>
        /// <param name="id"></param>
        private void goToPage(int id)
        {
            if (id == Resource.Id.imageButtonHome)
            {
                Recreate();
            }
            else if (id == Resource.Id.imageButtonEvents)
            {
                //  var intent = new Intent(this, typeof(EventsActivity));
                //  StartActivity(intent);

            }
            else if (id == Resource.Id.imageButtonPerfil)
            {
                var intent = new Intent(this, typeof(PerfilActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.imageButtonSettings)
            {
                var intent = new Intent(this, typeof(SettingsActivity));
                StartActivity(intent);
            }
        }

    }
}
