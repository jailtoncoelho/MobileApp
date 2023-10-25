using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using static Android.Content.ClipData;

namespace AndroidApp.BaseClasses
{
    public class TurmaAdapter : BaseAdapter<Turma>
    {
        private readonly Context context;
        private readonly List<Turma> items;

        public TurmaAdapter(Context context, List<Turma> items)
        {
            this.context = context;
            this.items = items;
        }

        public override Turma this[int position] => items[position];

        public override int Count => items.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            Turma turma = items[position];

            if (view == null)
            {
                // Crie um layout personalizado diretamente em C#
                view = new LinearLayout(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.MatchParent,
                        LinearLayout.LayoutParams.WrapContent
                    ),
                    Orientation = Orientation.Vertical
                };

                TextView nomeTurmaTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                TextView cursoTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                TextView anoDeInicioTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                TextView campusTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                TextView numeroDeAlunosTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                TextView anoDeFormaturaTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                nomeTurmaTextView.Text = turma.NomeTurma;
                cursoTextView.Text = turma.Curso;
                anoDeInicioTextView.Text = turma.AnoDeInicio;
                campusTextView.Text = turma.Campus;
                numeroDeAlunosTextView.Text = turma.NumeroDeAlunos;
                anoDeFormaturaTextView.Text = turma.AnoPrevisaoFormatura;

                ((LinearLayout)view).AddView(nomeTurmaTextView);
                ((LinearLayout)view).AddView(cursoTextView);
                ((LinearLayout)view).AddView(anoDeInicioTextView);
                ((LinearLayout)view).AddView(campusTextView);
                ((LinearLayout)view).AddView(numeroDeAlunosTextView);
                ((LinearLayout)view).AddView(anoDeFormaturaTextView);

            }
            return view;
        }
    }
}
