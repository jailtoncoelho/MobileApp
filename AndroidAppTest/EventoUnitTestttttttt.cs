﻿using AndroidLib;
using Firebase.Database;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidAppTest
{
    public class EventoUnitTestttttttt
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "usuario_testA";

        private const string NomeEvento = "SEPEX";
        private const string DescricaoEvento = "Apresentação de trabalhos do IFPR";
        private const string DataEvento = "06/10/2023";



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
                Data = DataEvento
            };

            string jsonDados = JsonConvert.SerializeObject(dataToSave);

            // Save data to the Firebase Realtime Database
            await firebaseClient.Child(DataPath).PostAsync(jsonDados);

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

            // Assert that the retrieved data matches the saved data

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

   

   
