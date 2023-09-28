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

            LinearLayout? buttonCadastroDisciplina = FindViewById<LinearLayout>(Resource.Id.linearLayoutCadastroDisciplinas);
            if (buttonCadastroDisciplina != null)
            {
                buttonCadastroDisciplina.Click += delegate
                {
                    var intent = new Intent(this, typeof(CadastroDisciplinasActivity));
                    StartActivity(intent);
                };
            }

            LinearLayout? buttonCadastroAluno = FindViewById<LinearLayout>(Resource.Id.linearLayoutCadastroAluno);
            if (buttonCadastroAluno != null)
            {
                buttonCadastroAluno.Click += delegate
                {
                    var intent = new Intent(this, typeof(CadastroAlunosActivity));
                    StartActivity(intent);
                };
            }

            LinearLayout? buttonSobre = FindViewById<LinearLayout>(Resource.Id.linearLayoutSobre);
            if (buttonSobre != null)
            {
                buttonSobre.Click += delegate
                {
                    var intent = new Intent(this, typeof(SobreActivity));
                    StartActivity(intent);
                };
            }
        }

        /// <summary>
        /// Procura pelo layout da tela de grupos e exibe sua respectiva activity.
        /// </summary>
        private void ExibeTelaCadastroGrupos()
        {
            LinearLayout? buttonCadastroGrupo = FindViewById<LinearLayout>(Resource.Id.linearLayoutCadastroGrupo);
            if (buttonCadastroGrupo != null)
            {
                buttonCadastroGrupo.Click += delegate
                {
                    var intent = new Intent(this, typeof(CadastroGrupoActivity));
                    StartActivity(intent);
                };
            }
        }
    }
}