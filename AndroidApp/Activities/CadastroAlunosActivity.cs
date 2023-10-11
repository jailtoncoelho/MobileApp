using Android.Content;
using Firebase.Database;
using Newtonsoft.Json;


namespace AndroidApp.Activities
{
    /// <summary>
    /// Criado Activity para a tela Cadastro de alunos
    /// </summary>
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroAlunosActivity")]
    internal class CadastroAlunosActivity : Activity
    {
        /// <summary>
        /// Metodo OnCreate é chamado quando a tela é criada e intancia o estado
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
                    CadastraUserAsync();
                };
            }
        }


        private async Task CadastraUserAsync()
        {

            // Crie um objeto com os dados que deseja salvar
            var dados = new
            {
                Nome = "@+id/editTextName",
                Senha = "@+id/editTextPassword",
                ConfirmSenha = "@+id/editTextConfirmPassword",
                ID = "@+id/editTextAlunoID"
            };

            // Converta o objeto para JSON
            string jsonDados = JsonConvert.SerializeObject(dados);



            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
            await firebase
                .Child("usuarios")
                .PostAsync(jsonDados);


        }
        private void MostrarPage()
        {
            SetContentView(Resource.Layout.activity_cadastro_alunos);
        }
    }
}