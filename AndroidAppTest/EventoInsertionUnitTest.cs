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
    public class EventoInsertionUnitTest
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "evento_test";

        private const string NomeEvento = "SEPEX";
        private const string DescricaoEvento = "Publicações IFPR";
        private const string DataEvento = "06/11/2023";

        [SetUp]
        public void Setup()
        {
            // Conecta no firebase
            firebaseClient = new FirebaseClient(DatabaseUrl);
        }

        [TearDown]
        public async Task TearDown()
        {
            // Remove the test data node after each test
            await firebaseClient.Child(DataPath).DeleteAsync();
        }

        [Test]
        public async Task SaveAndRetrieveData()
        {
            var dataToSave = new
            {
                Nome = NomeEvento,
                Descricao = DescricaoEvento,
                Data = DataEvento
            };

            string jsonDados = JsonConvert.SerializeObject(dataToSave);

            var saveResponse = await firebaseClient.Child(DataPath).PostAsync(jsonDados);

            // Retrieve data from the Firebase Realtime Database
            var evento = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Evento>()).Select(item => new Evento
              {
                  Nome = item.Object.Nome,
                  Descricao = item.Object.Descricao,
                  Data = item.Object.Data,
              }).Where(item => item.Nome == NomeEvento && item.Data == DataEvento).FirstOrDefault();

            Assert.IsNotNull(evento);

            // Assert that the retrieved data matches the saved data

            Assert.That((string)evento.Nome, Is.EqualTo(NomeEvento));
            Assert.That((string)evento.Descricao, Is.EqualTo(DescricaoEvento));
            Assert.That((string)evento.Data, Is.EqualTo(DataEvento));
            Assert.Pass();

        }
    }
}
