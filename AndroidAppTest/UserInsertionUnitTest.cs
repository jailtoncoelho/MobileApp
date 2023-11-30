using AndroidLib;
using Firebase.Database;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AndroidAppTest
{
    [TestFixture]
    public class InsercaoUsuarioTest
    {
        private FirebaseClient firebaseClient;
        private const string DatabaseUrl = "https://ifpr-alerts-default-rtdb.firebaseio.com/";
        private const string DataPath = "usuario_teste";      
     
        private const string Campuss = "Telemaco Borba";
        private const string Name = "Lionel Messi";
        private const string Login = "messi@gmail.com";
        private const string DataNascimento = "00/00/0000";
        private const string Password = "E#5|£A2xu0sw";
        private const string CPF = "654.321.123-01";
        private const string Phone = "53 99124-3455";

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
                Nome = Name,
                Email = Login,
                Senha = Password,
                DataNasc = DataNascimento,
                Campus = Campuss,
                Cpf = CPF,
                Telefone = Phone
            };

            string jsonDados = JsonConvert.SerializeObject(dataToSave);

            // Save data to the Firebase Realtime Database
            var saveResponse = await firebaseClient.Child(DataPath).PostAsync(jsonDados);
            string key = saveResponse.Key;

            // Retrieve data from the Firebase Realtime Database
            var usuario = (await firebaseClient
              .Child(DataPath)
              .OnceAsync<Usuario>()).Select(item => new Usuario
              {
                  Nome = item.Object.Nome,
                  Email = item.Object.Email,
                  Senha = item.Object.Senha,
                  Campus = item.Object.Campus,
                  Telefone = item.Object.Telefone,
                  CPF = item.Object.CPF,
                  DataNasc = item.Object.DataNasc                    
              }).Where(item => item.Email == Login && item.Senha == Password && item.CPF == CPF).FirstOrDefault();                  


            Assert.IsNotNull(usuario);

            // Assert that the retrieved data matches the saved data
            Assert.That((string)usuario.Nome, Is.EqualTo(Name));
            Assert.That((string)usuario.Senha, Is.EqualTo(Password));
            Assert.That((string)usuario.Campus, Is.EqualTo(Campuss));
            Assert.That((string)usuario.Email, Is.EqualTo(Login));
            Assert.That((string)usuario.DataNasc, Is.EqualTo(DataNascimento));
            Assert.That((string)usuario.CPF, Is.EqualTo(CPF));
            Assert.That((string)usuario.Telefone, Is.EqualTo(Phone));
            Assert.Pass();
        }
    }
}