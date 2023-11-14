using Android.Content;

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
           
            ///Metodo que puxa as informaçoes na tela 
            
            MostrarPage();
<<<<<<< Updated upstream
=======

            ConfigurarBtnEnviar();
            ConfigurarBtnCancelar();
        }

        private void ConfigurarBtnEnviar()
        {
            Button? btnEnviar = FindViewById<Button>(Resource.Id.btnEnviar);
            if (btnEnviar != null)
            {
                // Associe um evento de clique
                btnEnviar.Click += BtnEnviar_Click;
            }
        }

        private void ConfigurarBtnCancelar()
        {
            Button? btnCancelar = FindViewById<Button>(Resource.Id.btnCancelar);
            if (btnCancelar != null)
            {
                // Associe um evento de clique
                btnCancelar.Click += BtnCancelar_Click;
            }
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            // O botão foi clicado, execute o código desejado aqui
            CriaNoEventosSeNaoExistirAsync();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // O botão foi clicado, execute o código desejado aqui
            Finish();
        }


        private async Task CriaNoEventosSeNaoExistirAsync()
        {
            var nomeEvento = FindViewById<EditText>(Resource.Id.edtNomeEvento);
            var descricaoevento = FindViewById<EditText>(Resource.Id.edtDescricaoEvento);
            var dataEvento = FindViewById<DatePicker>(Resource.Id.datePickerDataEvento);

            // Crie um objeto com os dados que deseja salvar
            var dados = new
            {
                Nome = nomeEvento?.Text,
                Descricao = descricaoevento?.Text,
                Data = dataEvento?.DateTime.ToShortDateString()
            };

            // Converta o objeto para JSON
            string jsonDados = JsonConvert.SerializeObject(dados);




            var result = await firebase
                .Child("eventos")
                .PostAsync(jsonDados);

            if (result != null)
            {
                // reinicia valores dos campos da tela
                nomeEvento.Text = "";
                descricaoevento.Text = "";
                dataEvento.DateTime = DateTime.Now;

                Toast.MakeText(this, "Evento cadastrado com sucesso!", ToastLength.Short)?.Show();

                Finish();
            }
            else
            {
                Toast.MakeText(this, "O evento não pôde ser cadastrado!", ToastLength.Short)?.Show();
            }

>>>>>>> Stashed changes
        }

        private void MostrarPage()
        {
            SetContentView(Resource.Layout.activity_cadastro_eventos);
        }
    }
}

