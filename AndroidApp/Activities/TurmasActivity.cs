using Android.Content;
using Android.Views;
using Android.Widget;
using AndroidApp.Activities;
using AndroidApp.BaseClasses;
using AndroidX.AppCompat.View.Menu;
using Firebase;
using Firebase.Database;
using Google.Android.Material.BottomNavigation;
using Xamarin.Essentials;
using FirebaseOptions = Firebase.FirebaseOptions;

namespace AndroidApp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class TurmasActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private List<Turma> lstTurmas;

        protected override void OnCreate(Bundle? savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_turmas);

            BottomNavigationView? navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation_view);
            navigationView?.SetOnNavigationItemSelectedListener(this);

            showsTurmas();
        }

        protected override void OnResume()
        {
            base.OnResume();
            showsTurmas();
        }

        protected async void showsTurmas()
        {
            var allPersons = await GetAllTurmas(); ;
            lstTurmas = allPersons;

            ListView? listView = FindViewById<ListView>(Resource.Id.listViewTurmas);

            TurmaAdapter adapter = new TurmaAdapter(this, lstTurmas);
            listView.Adapter = adapter;
        }

        public async Task<List<Turma>> GetAllTurmas()
        {
            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");

            var turmas = (await firebase
              .Child("turmas")
              .OnceAsync<Turma>()).Select(item => new Turma
              {
                  /*Nome = item.Object.Nome,
                  Descricao = item.Object.Descricao,
                  Data = item.Object.Data
                  */
                  NomeTurma = item.Object.NomeTurma,
                  Curso = item.Object.Curso,
                  AnoDeInicio = item.Object.AnoDeInicio,
                  Campus = item.Object.Campus,
                  NumeroDeAlunos = item.Object.NumeroDeAlunos,
                  AnoPrevisaoFormatura = item.Object.AnoPrevisaoFormatura
              }).ToList();

            

            return turmas;
        }

    
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            goToPage(id);

            return true;
        }

        /// <summary>
        /// Set the selected page by the button clicked
        /// </summary>
        /// <param name="id"></param>
        private void goToPage(int id)
        {
            if (id == Resource.Id.imageButtonHome)
            {
                Recreate();
            }
            else if (id == Resource.Id.imageButtonEvents)
            {
                var intent = new Intent(this, typeof(CadastroEventosActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.imageButtonPerfil)
            {
                var intent = new Intent(this, typeof(PerfilActivity));
                StartActivity(intent);
            }
            else if (id == Resource.Id.imageButtonSettings)
            {
                var intent = new Intent(this, typeof(SettingsActivity));
                StartActivity(intent);
            }
        }

    }
}
