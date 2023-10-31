using AndroidLib;
using Firebase.Database;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AndroidAppTest
{
    [TestFixture]
    public class disciplinaInsertUnitTest
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "disciplina_teste";

        private const string Description = "GERENCIAMENTO DE PROJETOS";
        private const string Code = "TBTADS23";
        private const string WorkLoad = "80";

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
                Descricao = Description,
                Codigo = Code,
                Carga_horaria = WorkLoad
            };

            string jsonDados = JsonConvert.SerializeObject(dataToSave);

            // Save data to the Firebase Realtime Database
            var saveResponse = await firebaseClient.Child(DataPath).PostAsync(jsonDados);
            string key = saveResponse.Key;

            // Retrieve data from the Firebase Realtime Database
            var disciplina = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Disciplina>()).Select(item => new Disciplina
              {
                  Descricao = item.Object.Descricao,
                  Codigo = item.Object.Codigo,
                  Carga_horaria = item.Object.Carga_horaria
              }).Where(item => item.Codigo == Code && item.Carga_horaria == WorkLoad).FirstOrDefault();

            Assert.IsNotNull(disciplina);

            // Assert that the retrieved data matches the saved data
            Assert.That((string)disciplina.Descricao, Is.EqualTo(Description));
            Assert.That((string)disciplina.Carga_horaria, Is.EqualTo(WorkLoad));
            Assert.That((string)disciplina.Codigo, Is.EqualTo(Code));
            Assert.Pass();
        }
    }
}