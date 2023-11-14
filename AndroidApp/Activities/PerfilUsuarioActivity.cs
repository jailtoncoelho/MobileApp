using Android.Content;
using Android.Views;
using Firebase.Database.Core.View;

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

            Button? btnCancelar = FindViewById<Button>(Resource.Id.cancelEditProfileButton);
            Button? btnEnviar = FindViewById<Button>(Resource.Id.editPerfil);
            if (btnEnviar != null)
            {
                // Associe um evento de clique
                btnEnviar.Click += (sender, e) =>
                {
                    /*
                    var intent = new Intent(this, typeof(EditarPerfilActivity));
                    StartActivity(intent);*/
                    
                    if (btnCancelar.Visibility == ViewStates.Visible)
                    {
                        btnCancelar.Visibility = ViewStates.Invisible;
                        btnEnviar.Text = "Editar Perfil";
                    }
                    else
                    {
                        btnCancelar.Visibility = ViewStates.Visible;
                        btnEnviar.Text = "Salvar";
                    }
                };
            }
        }


    }
}

