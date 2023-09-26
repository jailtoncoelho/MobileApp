using Android.Content;
using Android.Widget;
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

            BindingClickEvents(Resource.Id.linearLayoutCadastroTurma, typeof(CadastroTurmaActivity));
            BindingClickEvents(Resource.Id.linearLayoutSobre, typeof(SobreActivity));
        }


        /// <summary>
        /// Metodo que chama a tela atraves da Id da Activity e da clase da tela.
        /// </summary>
        /// <param name="buttonId"> Id da Activity </param>
        /// <param name="activityType"> clase da tela </param>
        private void BindingClickEvents(int buttonId, Type activityType)
        {
            LinearLayout? button = FindViewById<LinearLayout>(buttonId);
            if (button != null)
            {
                button.Click += delegate
                {
                    var intent = new Intent(this, activityType);
                    StartActivity(intent);
                };
            }
        }
    }
}
