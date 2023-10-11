using Firebase;
using Firebase.Database;
using Google.Android.Material.BottomNavigation;
using Newtonsoft.Json;

namespace AndroidApp.Activities
{
    /// <summary>
    /// Criado Activity para a tela Cadastro de EVENTOS
    /// </summary>
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroEventosActivity")]
    internal class CadastroEventosActivity : Activity
    {
        /// <summary>
        /// Metodo OnCreate é chamado quando a tela é criada e intancia o estado
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            MostrarPage();

            Button? btnEnviar = FindViewById<Button>(Resource.Id.btnEnviar);
            if (btnEnviar != null)
            {
                // Associe um evento de clique
                btnEnviar.Click += (sender, e) =>
                {
                    // O botão foi clicado, execute o código desejado aqui
                    // Por exemplo, exiba uma mensagem
                    CriaNoEventosSeNaoExistirAsync();
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

        private async Task CriaNoEventosSeNaoExistirAsync()
        {

            // Crie um objeto com os dados que deseja salvar
            var dados = new
            {
                Nome = "SEPEX",
                Data = "04/10/2023"
            };

            // Converta o objeto para JSON
            string jsonDados = JsonConvert.SerializeObject(dados);



            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
            await firebase
                .Child("eventos")
                .PostAsync(jsonDados);


        }

        private void MostrarPage()
        {
            SetContentView(Resource.Layout.activity_cadastro_eventos);
        }


    }
}

