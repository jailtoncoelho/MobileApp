using AndroidLib;
using Firebase.Database;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Xml.Linq;

namespace AndroidAppTest
{
    [TestFixture]
    public class InsercaoTurmaTest
    {
        /*private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "usuario_teste";

        private const string Name = "Lionel Messi";
        private const string Login = "messi@gmail.com";
        private const string Password = "E#5|£A2xu0sw";*/

        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "turma_teste";

        private const string NomeTurma = "TADS2050";
        private const string Curso = "Ciencia da Computação";
        private const string AnoDeInicio = "2050";
        private const string Campus = "IFPRTB";
        private const string NumeroDeAlunos = "40";
        private const string AnoPrevisaoFormatura = "2054";

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
                NomeTurma = NomeTurma,
                Curso = Curso,
                AnoDeInicio = AnoDeInicio,
                Campus = Campus,
                NumeroDeAlunos = NumeroDeAlunos,
                AnoPrevisaoFormatura = AnoPrevisaoFormatura
    };

            string jsonDados = JsonConvert.SerializeObject(dataToSave);

            // Save data to the Firebase Realtime Database
            var saveResponse = await firebaseClient.Child(DataPath).PostAsync(jsonDados);
            string key = saveResponse.Key;

            // Retrieve data from the Firebase Realtime Database
            var usuario = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Turma>()).Select(item => new Turma
              {
                  NomeTurma = item.Object.NomeTurma,
                  Curso = item.Object.Curso,
                  AnoDeInicio = item.Object.AnoDeInicio,
                  Campus = item.Object.Campus,
                  NumeroDeAlunos = item.Object.NumeroDeAlunos,
                  AnoPrevisaoFormatura = item.Object.AnoPrevisaoFormatura
              }).Where(item => item.NomeTurma == NomeTurma && item.Campus == Campus).FirstOrDefault();

            Assert.IsNotNull(usuario);

            // Assert that the retrieved data matches the saved data
            
            Assert.That((string)usuario.NomeTurma, Is.EqualTo(NomeTurma));
            Assert.That((string)usuario.Curso, Is.EqualTo(Curso));
            Assert.That((string)usuario.AnoDeInicio, Is.EqualTo(AnoDeInicio));
            Assert.That((string)usuario.Campus, Is.EqualTo(Campus));
            Assert.That((string)usuario.NumeroDeAlunos, Is.EqualTo(NumeroDeAlunos));
            Assert.That((string)usuario.AnoPrevisaoFormatura, Is.EqualTo(AnoPrevisaoFormatura));
            Assert.Pass();
        }
    }
}