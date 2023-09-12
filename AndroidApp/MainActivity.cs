using Android.Content;
using Android.Views;

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //HM. COMENTEI
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // comentario para branchhh
        }




        public override bool OnCreateOptionsMenu(IMenu? menu)
        {
            MenuInflater.Inflate(Resource.Layout.activity_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            // Handle item selection
            switch (item.ItemId)
            {
                case Resource.Id.cadastro_turma:
                    ShowsCadastroTurma();
                    return true;
                case Resource.Id.sobre:
                    //showsSobre();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);

            }
        }

        private void ShowsCadastroTurma()
        {
            Intent myIntent = new(this, typeof(CadastroTurma));
            StartActivity(myIntent);
        }
    }
}
