using AndroidLib;
using Firebase.Database;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AndroidAppTest
{
    public class DisciplinaTest
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "disciplina_teste";

        private const string Nome = "Jailton";
        private const string Professor = "Jailton";
        private const string Descricao = "28/11/2024";
        private const string Nascimento = "20/02/2002";
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

            // Data to be saved
            var dataToSave = new
            {
                NomePessoa = Nome,
                ProfessorPessoa = Professor,
                DescricaoData = Descricao,
                NascimentoData = Nascimento

            };

            string jsonDados = JsonConvert.SerializeObject(dataToSave);

            // Save data to the Firebase Realtime Database
            var saveResponse = await firebaseClient.Child(DataPath).PostAsync(jsonDados);
            var disciplina = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Disciplina>()).Select(item => new Disciplina
              {
                  Nome = item.Object.Nome,
                  Professor = item.Object.Professor,
                  Descricao = item.Object.Nome,
                  Nascimento = item.Object.Nascimento,
              }).Where(item => item.Nome == Nome && item.Professor == Professor && item.Descricao == Descricao && item.Nascimento == Nascimento).FirstOrDefault();

            Assert.IsNotNull(disciplina);

            // Assert that the retrieved data matches the saved data

            Assert.That((string)disciplina.Nome, Is.EqualTo(Nome));
            Assert.That((string)disciplina.Professor, Is.EqualTo(Professor));
            Assert.That((string)disciplina.Descricao, Is.EqualTo(Descricao));
            Assert.That((string)disciplina.Nascimento, Is.EqualTo(Nascimento));
        }
    }
}

