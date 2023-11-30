using Firebase.Database;
using Newtonsoft.Json;
using Xamarin.Kotlin;

namespace AndroidApp.Activities
{
    /// <summary>
    /// Criado Activity para a tela Cadastro de alunos
    /// </summary>
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroUsuarioActivity")]
    internal class CadastroUsuarioActivity : Activity
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

            var nomeUser = FindViewById<EditText>(Resource.Id.editTextName);
            var senhaUser = FindViewById<EditText>(Resource.Id.editTextPassword);
            var confSenhaUser = FindViewById<EditText>(Resource.Id.editTextConfirmPassword);
            var emailUser = FindViewById<EditText>(Resource.Id.editTextEmail);
            var campusUser = FindViewById<EditText>(Resource.Id.editTextCampus);
            var CPFUser = FindViewById<EditText>(Resource.Id.editTextCPF);
            var telefoneUser = FindViewById<EditText>(Resource.Id.editTextTelefone);
            var tpUser = FindViewById<EditText>(Resource.Id.userTypeSpinner);
            
            if (senhaUser?.Text == confSenhaUser?.Text)
            {
                // Crie um objeto com os dados que deseja salvar
                var dados = new
                {
                    Nome = nomeUser?.Text,
                    Senha = senhaUser?.Text,
                    Email = emailUser?.Text,
                    Campus = campusUser?.Text,
                    CPF = CPFUser?.Text,
                    Telefone = telefoneUser?.Text,
                    Tipo_User = tpUser?.Text
                };

                try
                {
                    string jsonDados = JsonConvert.SerializeObject(dados);

                    FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
                    var result = await firebase
                        .Child("usuarios")
                        .PostAsync(jsonDados);

                    if (result != null)
                    {
                        // reinicia valores dos campos da tela
                        nomeUser.Text = "";
                        senhaUser.Text = "";
                        campusUser.Text = "";
                        emailUser.Text = "";
                        confSenhaUser.Text = "";
                        CPFUser.Text = "";
                        telefoneUser.Text = "";
                        tpUser.Text = "";

                        Toast.MakeText(this, "Usuário cadastrado com sucesso!", ToastLength.Short)?.Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "O usuário não pôde ser cadastrado!", ToastLength.Short)?.Show();
                    }

                    Toast.MakeText(this, "Usuário logado com sucesso!", ToastLength.Short)?.Show();

                    Finish();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro: {e.Message}");
                }
            }
            else
            {
                Toast.MakeText(this, "A senha está invalida!", ToastLength.Short)?.Show();
            }
        }

        private void MostrarPage()
        {
            SetContentView(Resource.Layout.activity_cadastro_usuario);
        }
    }
}