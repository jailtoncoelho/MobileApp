using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace SeuApp.Views
{
    [Activity(Label = "Alunos")]
    public class StudentsView : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // SetContentView(Resource.Layout.students_layout);
            // Adicione lógica específica para a visualização de alunos aqui
        }
    }
}