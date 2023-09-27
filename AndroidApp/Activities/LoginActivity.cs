using Android.Content;

namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.LoginActivity")]
    internal class LoginActivity : Activity
    {/// <summary>
    /// Metódo onCreate é chamado quando a atividade é iniciada.
    /// </summary>
    /// <param name="savedInstanceState"></param>
        
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
        }
    }
}

