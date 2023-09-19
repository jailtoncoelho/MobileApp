using Android.Content;

namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.SettingsActivity")]
    internal class SettingsActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_settings);

            BindingClickEvents();
        }

        private void BindingClickEvents()
        {
            LinearLayout? buttonSettings = FindViewById<LinearLayout>(Resource.Id.linearLayoutCadastroTurma);
            if (buttonSettings != null)
            {
                buttonSettings.Click += delegate
                {
                    var intent = new Intent(this, typeof(CadastroTurmaActivity));
                    StartActivity(intent);
                };
            }
        }
    }
}

