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

namespace AndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private List<Evento> lstEventos;

        protected override void OnCreate(Bundle? savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            BottomNavigationView? navigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation_view);
            navigationView?.SetOnNavigationItemSelectedListener(this);

            showsEventos();
        }

        protected async void showsEventos()
        {
            var allPersons = await GetAllEvents(); ;
            lstEventos = allPersons;

            ListView? listView = FindViewById<ListView>(Resource.Id.listViewEventos);

            EventoAdapter adapter = new EventoAdapter(this, lstEventos);
            listView.Adapter = adapter;

        }

        public async Task<List<Evento>> GetAllEvents()
        {
            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");

            var eventos = (await firebase
              .Child("eventos")
              .OnceAsync<Evento>()).Select(item => new Evento
              {
                  Nome = item.Object.Nome,
                  Descricao = item.Object.Descricao,
                  Data = item.Object.Data
              }).ToList();

            

            return eventos;
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
