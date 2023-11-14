using Android.Content;
using Android.Widget;
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroEventosActivity")]
    internal class CadastroEventosActivity : Activity
    {
        private EditText nomeAlunoEditText;
        private EditText nomeDisciplinaEditText;
        private Button btnCadastrar;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MostrarPage();

            nomeAlunoEditText = FindViewById<EditText>(Resource.Id.editTextNomeAluno);
            nomeDisciplinaEditText = FindViewById<EditText>(Resource.Id.editTextNomeDisciplina);
            btnCadastrar = FindViewById<Button>(Resource.Id.btnCadastrar);

            if (btnCadastrar != null)
            {
                btnCadastrar.Click += (sender, e) =>
                {
                    // Aqui você pode acessar os valores dos campos de entrada
                    string nomeAluno = nomeAlunoEditText.Text;
                    string nomeDisciplina = nomeDisciplinaEditText.Text;

                    // Faça algo com nomeAluno e nomeDisciplina, por exemplo, salvá-los no Firebase
                    CadastrarAlunoDisciplinaAsync(nomeAluno, nomeDisciplina);
                };
            }
        }

        private async Task CadastrarAlunoDisciplinaAsync(string nomeAluno, string nomeDisciplina)
        {
            // Crie um objeto com os dados que deseja salvar, por exemplo, em JSON
            var dados = new
            {
                NomeAluno = nomeAluno,
                NomeDisciplina = nomeDisciplina
            };

            string jsonDados = JsonConvert.SerializeObject(dados);

            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
            await firebase
                .Child("aluno_disciplina")
                .PostAsync(jsonDados);

            // Você pode adicionar lógica adicional, como exibir uma mensagem de sucesso
        }

        private void MostrarPage()
        {
            SetContentView(Resource.Layout.activity_cadastro_eventos);
        }
    }
}

