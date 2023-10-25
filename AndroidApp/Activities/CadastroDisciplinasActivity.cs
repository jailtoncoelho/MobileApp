using Android.Content;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Newtonsoft.Json;

namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroDisciplinasActivity")]
    internal class CadastroDisciplinasActivity : Activity
    {
        /// <summary>
        /// Metodo que chama a tela atraves do Id da Activity
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource

            ///Metodo puxa pagina na main 

            MostrarPage();
            Button? btnEnviar = FindViewById<Button>(Resource.Id.btnConfirm);
            if (btnEnviar != null)
            {
                // Associe um evento de clique
                btnEnviar.Click += (sender, e) =>
                {
                    // O botão foi clicado, execute o código desejado aqui
                    // Por exemplo, exiba uma mensagem
                    CadastraDisciplinaAsync();
                };
            }
        }
        private async Task CadastraDisciplinaAsync()
        {

            // Crie um objeto com os dados que deseja salvar
            var dados = new
            {
                Nome = "@+id/textView1",
                Disciplina = "@+id/textView2"
            };

            // Converta o objeto para JSON
            string jsonDados = JsonConvert.SerializeObject(dados);



            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
            await firebase
                .Child("disciplinas")
                .PostAsync(jsonDados);


        }
        private void MostrarPage()
        {
            SetContentView(Resource.Layout.activity_cadastro_usuario);
        }
    }
}
