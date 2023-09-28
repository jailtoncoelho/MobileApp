﻿using Android.Content;

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
        }

        private void MostrarPage()
        {
            SetContentView(Resource.Layout.activity_cadastro_eventos);
        }
    }
}

