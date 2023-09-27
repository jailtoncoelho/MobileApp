using Android.Content;

namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.PerfilUsuarioActivity")]
    internal class PerfilUsuarioActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_perfilUsuario);

        }

    }
}

