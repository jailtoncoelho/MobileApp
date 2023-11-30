using Android.Content;
using Android.Widget;
using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AndroidApp.Activities
{
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroTurmaActivity")]
    internal class CadastroTurmaActivity : Activity
    {
        /// <summary>
        /// Metodo que chama a tela atraves do Id da Activity
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
                    // O botao foi clicado, execute o codigo desejado aqui
                    // Por exemplo, exiba uma mensagem
                    CriaNoEventosSeNaoExistirAsync();
                };
            }

            Button? btnCancelar = FindViewById<Button>(Resource.Id.btnCancelar);
            if (btnCancelar != null)
            {
                // Associe um evento de clique
                btnCancelar.Click += (sender, e) =>
                {
                    // O botao foi clicado, execute o codigo desejado aqui
                    Finish();
                };
            }

            Button? btnExibirTurmas = FindViewById<Button>(Resource.Id.btnExibirTurmas);
            if (btnExibirTurmas != null)
            {
                // Associe um evento de clique
                btnExibirTurmas.Click += (sender, e) =>
                {
                    // O botao foi clicado, execute o codigo desejado aqui
                    var intent = new Intent(this, typeof(TurmasActivity));
                    StartActivity(intent);
                };
            }
        }


        // Manipulador de evento para o clique do botao
        private void Enviar_Click(object sender, System.EventArgs e)
        {
            // O botao foi clicado, execute o codigo desejado aqui
            // Por exemplo, exiba uma mensagem
            CriaNoEventosSeNaoExistirAsync();
        }

        private async Task CriaNoEventosSeNaoExistirAsync()
        {
            var nomeTurma = FindViewById<EditText>(Resource.Id.edtNomeTurma);
            var nomeCursoTurma = FindViewById<EditText>(Resource.Id.edtNomeCurso);
            var anoIngresso = FindViewById<EditText>(Resource.Id.edtAnoIngressão);
            var campusTurma = FindViewById<EditText>(Resource.Id.edtCampusDaTurma);
            var numeroDeAlunos = FindViewById<EditText>(Resource.Id.edtNumeroDeAlunos);
            var previsãoFormatura = FindViewById<EditText>(Resource.Id.edtAnoFormatura);
            var mascoteTurma = FindViewById<EditText>(Resource.Id.edtMascoteTurma);
            // Crie um objeto com os dados que deseja salvar
            var dados = new
            {
                NomeTurma = nomeTurma?.Text,
                Curso = nomeCursoTurma?.Text,
                AnoDeInicio = anoIngresso?.Text,
                Campus = campusTurma?.Text,
                NumeroDeAlunos = numeroDeAlunos?.Text,
                AnoPrevisaoFormatura = previsãoFormatura?.Text,
                MascoteTurma = mascoteTurma ?.Text
            };

            // Converta o objeto para JSON
            string jsonDados = JsonConvert.SerializeObject(dados);

            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
            var result = await firebase
                .Child("turmas")
                .PostAsync(jsonDados);

            if (result != null)
            {
                // reinicia valores dos campos da tela
                nomeTurma.Text = "";
                nomeCursoTurma.Text = "";
                anoIngresso.Text = "";
                campusTurma.Text = "";
                numeroDeAlunos.Text = "";
                previsãoFormatura.Text = "";

                Toast.MakeText(this, "Turma cadastrada com sucesso!", ToastLength.Short)?.Show();
            }
            else
            {
                Toast.MakeText(this, "A Turma nao pode ser cadastrada!", ToastLength.Short)?.Show();
            }

        }
        private void MostrarPage()
        {
            SetContentView(Resource.Layout.activity_cadastro_turma);
        }

    }
}
