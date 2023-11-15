using AndroidLib;
using Firebase.Database;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidAppTest
{
    public class UserGetUnitTest
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "getUser_teste";
        private const string NomeClasse = "teste";
        private const string PasswordClasse = "passwordTest";
        private const string EmailClasse = "email@email.com";

        [SetUp]
        public void Setup()
        {
            // Conecta no firebase
            firebaseClient = new FirebaseClient(DatabaseUrl);

        }
        [Test]
        public async Task SaveAndRetrieveData()
        {
            var dataToSave = new
            {
                Nome = NomeClasse,
                Email = EmailClasse,
                Senha = PasswordClasse,
            };
            string jsonDados = JsonConvert.SerializeObject(dataToSave);

            // Save data to the Firebase Realtime Database
            await firebaseClient.Child(DataPath).PostAsync(jsonDados);

            var usuario = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Usuario>()).Select(item => new Usuario
              {
                  Nome = item.Object.Nome,
                  Email = item.Object.Email,
                  Senha = item.Object.Senha,
              }).Where(item => item.Nome == NomeClasse && item.Email == EmailClasse).FirstOrDefault();

            Assert.IsNotNull(usuario);
            Assert.That((string)usuario.Nome, Is.EqualTo(NomeClasse));
            Assert.That((string)usuario.Email, Is.EqualTo(EmailClasse));
            Assert.That((string)usuario.Senha, Is.EqualTo(PasswordClasse));
        }

        [TearDown]
        public async Task TearDown()
        {
            // Remove the test data node after each test
            await firebaseClient.Child(DataPath).DeleteAsync();
        }
    }
}