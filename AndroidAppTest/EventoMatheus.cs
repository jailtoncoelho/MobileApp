using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndroidLib;
using Firebase.Database;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Xml.Linq;

namespace AndroidAppTest
{
    internal class EventoUnitTeste
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "Matheus_teste";

        private const string NomeEvento = "Uma noite no Museu";
        private const string DescricaoEvento = "Publicações dos projetos do IFPR";
        private const string DataEvento = "14/11/2023";

        [SetUp]
        public void Setup()
        {
            // Conecta no firebase
            firebaseClient = new FirebaseClient(DatabaseUrl);
        }

        [Test]
        public async Task SaveAndRetrieveData()
        {
            // Data to be saved
            var dataToSave = new
            {
                Nome = NomeEvento,
                Descricao = DescricaoEvento,
                Data = DataEvento,

            };
                string jsonDados = JsonConvert.SerializeObject(dataToSave);

            // Save data to the Firebase Realtime Database
            var saveResponse = await firebaseClient.Child(DataPath).PostAsync(jsonDados);

            // Retrieve data from the Firebase Realtime Database
            var Evento = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Evento>()).Select(item => new Evento
              {
                  Nome = item.Object.Nome,
                  Descricao = item.Object.Descricao,
                  Data = item.Object.Data,
              }).Where(item => item.Nome == NomeEvento && item.Descricao == DescricaoEvento).FirstOrDefault();

            Assert.IsNotNull(Evento);

            // Assert that the retrieved data matches the saved data

            Assert.That((string)Evento.Nome, Is.EqualTo(NomeEvento));
            Assert.That((string)Evento.Descricao, Is.EqualTo(DescricaoEvento));
            Assert.That((string)Evento.Data, Is.EqualTo(DataEvento));

        }

            [TearDown]
        public async Task TearDown()
        { 
        // Remove the test data node after each test
            await firebaseClient.Child(DataPath).DeleteAsync();
        }

        
     }
}
