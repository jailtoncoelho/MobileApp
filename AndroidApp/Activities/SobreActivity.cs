using Android.Content;

namespace AndroidApp.Activities
{
    /// <summary>
    /// Explica sobre o desenvolvimento do app e seu incentivo e os envolvidos
    /// </summary>
    [Activity(Name = "com.ifpr_telemacoborba.alerts.SobreActivity")]
    internal class SobreActivity : Activity
    {
        /// <summary>
        /// No metódo OnCreate é executado a lógica basica da inicialização do app. Isso deve acontecer somente uma vez durante todo o periodo que a atividade durar.
        /// </summary>
        /// <param name="savedInstanceState"></param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_sobre);
            
        }
    }
}

