using Android.Content;
using AndroidApp.Activities;
using System.ComponentModel;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            BindingClickEvents();
        }

        private void BindingClickEvents()
        {
            ImageButton? buttonHome = FindViewById<ImageButton>(Resource.Id.imageButtonHome);
            if (buttonHome != null)
            {
                buttonHome.Click += delegate
                {
                    Recreate();
                };
            }

            ImageButton? buttonEvents = FindViewById<ImageButton>(Resource.Id.imageButtonEvents);
            if (buttonEvents != null)
            {
                buttonEvents.Click += delegate
                {

                };
            }

            ImageButton? buttonPerfil = FindViewById<ImageButton>(Resource.Id.imageButtonPerfil);
            if (buttonPerfil != null)
            {
                buttonPerfil.Click += delegate
                {
                    var intent = new Intent(this, typeof(LoginActivity));
                    StartActivity(intent);
                };
            }

            ImageButton? buttonSettings = FindViewById<ImageButton>(Resource.Id.imageButtonSettings);
            if (buttonSettings != null)
            {
                buttonSettings.Click += delegate
                {
                    var intent = new Intent(this, typeof(SettingsActivity));
                    StartActivity(intent);
                };
            }
        }


    }
}
