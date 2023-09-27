using Android.Content;

namespace AndroidApp.Activities
{
    /// <summary>
    /// Criado Activity para a tela Cadastro de Grupos
    /// </summary>
    [Activity(Name = "com.ifpr_telemacoborba.alerts.CadastroGrupoActivity")]
    internal class CadastroGrupoActivity : Activity
    {
        /// <summary>
        /// Metodo OnCreate é chamado quando a tela é criada e intancia o estado
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_criacao_grupos);

        }
    }
}