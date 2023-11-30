using AndroidLib;
using Firebase.Database;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AndroidAppTest
{
    public class DisciplinaUnitTest
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "disciplina_teste";

        private const string NomeDisciplina = "Banco de Dados I";
        private const string ProfessorDisciplina = "Jailton";
        private const string DescricaoDisciplina = "Disciplina de banco de dados";
        private const string CargaHorariaDisciplina = "80h";

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
                Nome = NomeDisciplina,
                Professor = ProfessorDisciplina,
                Descricao = DescricaoDisciplina,
                CargaHoraria = CargaHorariaDisciplina
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
                  Descricao = item.Object.Descricao,
                  CargaHoraria = item.Object.CargaHoraria,
              }).Where(item => item.Nome == NomeDisciplina && item.Professor == ProfessorDisciplina && item.Descricao == DescricaoDisciplina && item.CargaHoraria == CargaHorariaDisciplina).FirstOrDefault();

            Assert.IsNotNull(disciplina);

            // Assert that the retrieved data matches the saved data

            Assert.That((string)disciplina.Nome, Is.EqualTo(NomeDisciplina));
            Assert.That((string)disciplina.Professor, Is.EqualTo(ProfessorDisciplina));
            Assert.That((string)disciplina.Descricao, Is.EqualTo(DescricaoDisciplina));
            Assert.That((string)disciplina.CargaHoraria, Is.EqualTo(CargaHorariaDisciplina));
        }
    }
}

