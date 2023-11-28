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
    public class CursoTest
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "curso_teste";

        private const string NomeCurso = "TADS";
        private const string DescricaoCurso = "aaa";

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
                Nome = NomeCurso,
                Descricao = DescricaoCurso,
            };

            string jsonDados = JsonConvert.SerializeObject(dataToSave);

            // Save data to the Firebase Realtime Database
            var saveResponse = await firebaseClient.Child(DataPath).PostAsync(jsonDados);
            var curso = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Curso>()).Select(item => new Curso
              {
                  Nome = item.Object.Nome,
                  Descricao = item.Object.Descricao,
              }).Where(item => item.Nome == NomeCurso && item.Descricao == DescricaoCurso).FirstOrDefault();

            Assert.IsNotNull(curso);

            // Assert that the retrieved data matches the saved data

            Assert.That((string)curso.Nome, Is.EqualTo(NomeCurso));
            Assert.That((string)curso.Descricao, Is.EqualTo(DescricaoCurso));
        }
    }
}

