using Android.Content;
using AndroidLib;
using Firebase.Database;

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
            loginView(savedInstanceState);

            Button? loginButton = FindViewById<Button>(Resource.Id.loginButton);
            if (loginButton != null)
            {
                // Associe um evento de clique
                loginButton.Click += (sender, e) =>
                {
                    // O botão foi clicado, execute o código desejado aqui
                    // Por exemplo, exiba uma mensagem
                    onLoginClickAsync();
                };
            }

            TextView? signupTextView = FindViewById<TextView>(Resource.Id.signupTextView);
            if (signupTextView != null)
            {
                // Associe um evento de clique
                signupTextView.Click += (sender, e) =>
                {
                    // O botão foi clicado, execute o código desejado aqui
                    // Por exemplo, exiba uma mensagem
                    onSignUpClick();
                };
            }
        }

        private void loginView(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
        }

        public void onForgotPasswordClick()
        {
            var intent = new Intent(this, typeof(CadastroUsuarioActivity));
            StartActivity(intent);
        }

        public void onSignUpClick()
        {
            var intent = new Intent(this, typeof(CadastroUsuarioActivity));
            StartActivity(intent);
        }

        public async void onLoginClickAsync()
        {
            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");

            var login = FindViewById<EditText>(Resource.Id.loginEditText)?.Text;
            var password = FindViewById<EditText>(Resource.Id.passwordEditText)?.Text;

            var usuario = (await firebase
              .Child("usuarios")
              .OnceAsync<Usuario>()).Select(item => new Usuario
              {
                  Nome = item.Object.Nome,
                  Email = item.Object.Email,
                  Senha = item.Object.Senha
              }).Where(item => item.Email == login && item.Senha == password).FirstOrDefault();


            if (usuario != null)
            {
                try
                {
                    Toast.MakeText(this, "Usuário logado com sucesso!", ToastLength.Short)?.Show();

                    Finish();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro de autenticação: {e.Message}");
                }
            }
            else
            {
                Toast.MakeText(this, "Usuário não encontrado!", ToastLength.Short)?.Show();
            }
        }
    }
}

