using Android.Content;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase;
using Firebase.Database;
using Xamarin.Essentials;
using FirebaseOptions = Firebase.FirebaseOptions;
using Newtonsoft.Json;

namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroDisciplinasActivity")]
    internal class CadastroDisciplinasActivity : Activity
    {
        /// <summary>
        /// Metodo que chama a tela atraves do Id da Avtivity
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_cadastro_disciplinas);

            Button? btnEnviar = FindViewById<Button>(Resource.Id.btnEnviar);
            if (btnEnviar != null)
            {
                // Associe um evento de clique
                btnEnviar.Click += (sender, e) =>
                {
                    // O botão foi clicado, execute o código desejado aqui
                    // Por exemplo, exiba uma mensagem
                    CriaNoDisciplinasSeNaoExistirAsync();
                };
            }
        }
        private void Enviar_Click(object sender, System.EventArgs e)
        {
            // O botão foi clicado, execute o código desejado aqui
            // Por exemplo, exiba uma mensagem
            CriaNoDisciplinasSeNaoExistirAsync();
        }

        private async Task CriaNoDisciplinasSeNaoExistirAsync()
        {
            var nomeAluno = FindViewById<EditText>(Resource.Id.edtNomeAluno);
            var nomeDisciplina = FindViewById<EditText>(Resource.Id.edtNomeDisciplina);
            var dataDisciplina = FindViewById<DatePicker>(Resource.Id.datePickerDataDisciplina);

            // Crie um objeto com os dados que deseja salvar
            var dados = new
            {
                Nome = nomeAluno?.Text,
                Disciplina = nomeDisciplina?.Text,
                Data = dataDisciplina?.DateTime.ToShortDateString()
            };

            // Converta o objeto para JSON
            string jsonDados = JsonConvert.SerializeObject(dados);

            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
            var result = await firebase
                .Child("disciplinas")
                .PostAsync(jsonDados);

            if (result != null)
            {
                // reinicia valores dos campos da tela
                nomeAluno.Text = "";
                nomeDisciplina.Text = "";
                dataDisciplina.DateTime = DateTime.Now;

                Toast.MakeText(this, "Disciplina cadastrada com sucesso!", ToastLength.Short)?.Show();
            }
            else
            {
                Toast.MakeText(this, "A disciplina não pôde ser cadastrada!", ToastLength.Short)?.Show();
            }

        }
    }
}
