using AndroidLib;
using Firebase.Database;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidAppTest
{

    public class EvandroeEventoUnitText
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "Evandro_evento_teste";

        private const string DescricaoEvento = "Hallowen";
        private const string NomeEvento = "Hallowen";
        private const string DataEvento = "06/11/2023";

        [SetUp]
        public void Setup()
        {
            // Conecta no firebase
            firebaseClient = new FirebaseClient(DatabaseUrl);
        }

        [Test]
        public async Task SaveAndRetrieveData()
        {
            //Data to saved
            var dataSave = new
            {
                Nome = NomeEvento,
                Descricao = DescricaoEvento,
                Data = DataEvento,
            };

            string jsonDados = JsonConvert.SerializeObject(dataSave);

            // Save data to the Firebase Realtime Database
            var saveResponse = await firebaseClient.Child(DataPath).PostAsync(jsonDados);


            // Retrieve data from the Firebase Realtime Database
            var evento = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Evento>()).Select(item => new Evento
              {
                  Nome = item.Object.Nome,
                  Descricao = item.Object.Descricao,
                  Data = item.Object.Data,

              }).Where(item => item.Nome == NomeEvento && item.Descricao == DescricaoEvento).FirstOrDefault();

            Assert.IsNotNull(evento);

            Assert.That((string)evento.Nome, Is.EqualTo(NomeEvento));
            Assert.That((string)evento.Descricao, Is.EqualTo(DescricaoEvento));
            Assert.That((string)evento.Data, Is.EqualTo(DataEvento));

        }


        [TearDown]
        public async Task TearDown()
        {
            // Remove the test data node after each test
            await firebaseClient.Child(DataPath).DeleteAsync();
        }
    }
}
