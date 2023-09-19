using Android.Content;
using AndroidApp.Activities;

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
