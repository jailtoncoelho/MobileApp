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

            CadastroTurma();

            Button? btnEnviar = FindViewById<Button>(Resource.Id.btnEnviar);
            if (btnEnviar != null)
            {
                // Associe um evento de clique
                btnEnviar.Click += (sender, e) =>
                {
                    // O botão foi clicado, execute o código desejado aqui
                    // Por exemplo, exiba uma mensagem
                    CriaNoTurmaSeNaoExistirAsync();
                };
            }

        }
        // Manipulador de evento para o clique do botão
        private void Enviar_Click(object sender, System.EventArgs e)
        {
            // O botão foi clicado, execute o código desejado aqui
            // Por exemplo, exiba uma mensagem
            CriaNoEventosSeNaoExistirAsync();
        }

    }
}
