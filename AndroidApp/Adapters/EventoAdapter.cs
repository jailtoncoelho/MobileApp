using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidLib;
using static Android.Content.ClipData;

namespace AndroidApp.Adapters
{
    public class EventoAdapter : BaseAdapter<Evento>
    {
        private readonly Context context;
        private readonly List<Evento> items;

        public EventoAdapter(Context context, List<Evento> items)
        {
            this.context = context;
            this.items = items;
        }

        public override Evento this[int position] => items[position];

        public override int Count => items.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            Evento evento = items[position];

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

                TextView nomeTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                TextView descricaoTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                TextView dataTextView = new TextView(context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(
                        LinearLayout.LayoutParams.WrapContent,
                        LinearLayout.LayoutParams.WrapContent
                    )
                };

                nomeTextView.Text = evento.Nome;
                descricaoTextView.Text = evento.Descricao;
                dataTextView.Text = evento.Data;
                dataTextView.Text = evento.Observacoes;

                ((LinearLayout)view).AddView(nomeTextView);
                ((LinearLayout)view).AddView(descricaoTextView);
                ((LinearLayout)view).AddView(dataTextView);

            }
            return view;
        }
    }
}
