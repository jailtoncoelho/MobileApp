using Android.Content;
using Android.Widget;
using Firebase.Database;
using Newtonsoft.Json;
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
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroEventosActivity")]
    internal class CadastroEventosActivity : Activity
    {
        FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
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
                    // O botão foi clicado, execute o codigo desejado aqui
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
            SetContentView(Resource.Layout.activity_cadastro_disciplinas);

            Button? btnEnviar = FindViewById<Button>(Resource.Id.btnCadastrarDisciplina);
            if (btnEnviar != null)
            {
                // Associe um evento de clique
                btnEnviar.Click += (sender, e) =>
                {
                    // O botao foi clicado, execute o codigo desejado aqui
                    // Por exemplo, exiba uma mensagem
                    CriaNoDisciplinasSeNaoExistirAsync();
                };
            }
        }

        private async Task CriaNoDisciplinasSeNaoExistirAsync()
        {
            var nomeDisciplina = FindViewById<EditText>(Resource.Id.edtNomeDisciplina);
            var nomeProfessor = FindViewById<EditText>(Resource.Id.edtNomeProfessor);
            var dataDisciplina = FindViewById<DatePicker>(Resource.Id.datePickerDataDisciplina);

            // Crie um objeto com os dados que deseja salvar
            var dados = new
            {
                Disciplina = nomeDisciplina?.Text,
                Professor = nomeProfessor?.Text,
                Data = dataDisciplina?.DateTime.ToShortDateString()
            };

            // Converta o objeto para JSON
            string jsonDados = JsonConvert.SerializeObject(dados);

            var result = await firebase
                .Child("disciplinas")
                .PostAsync(jsonDados);

            if (result != null)
            {
                // reinicia valores dos campos da tela
                nomeDisciplina.Text = "";
                nomeProfessor.Text = "";
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

