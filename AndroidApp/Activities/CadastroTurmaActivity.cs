using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroTurmaActivity")]
    internal class CadastroTurmaActivity : Activity
    {
        /// <summary>
        /// Metodo que chama a tela atraves do Id da Avtivity
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_cadastro_turma);
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
    }
}
