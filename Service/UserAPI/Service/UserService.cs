using System.Collections.Generic;
using AndreAirlinesDomain.Model;
using MongoDB.Driver;
using UserAPI.Utils;

namespace UserAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IUserUtilsDatabaseSettings settings)
        {
            var use = new MongoClient(settings.ConnectionString);
            var database = use.GetDatabase(settings.DatabaseName);
            _user = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<User> Get() =>
       _user.Find(user => true).ToList();
        public User Get(string id) =>
            _user.Find<User>(user => user.Id == id).FirstOrDefault();

        ///public static  User GetAuth(string Name, string Password) =>
         //  _user.Find<User>(user => user.Name == Name && user.Password == Password).FirstOrDefault();

        public User ExistCPF(string CPF) =>
            _user.Find<User>(user => user.CPF == CPF).FirstOrDefault();

        public User GetLogin(string Login) =>
         _user.Find<User>(user => user.Login == Login).FirstOrDefault();

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _user.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _user.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
           _user.DeleteOne(user => user.Id == id);


        public bool CheckCpf(string cpf)
        {
            int[] multiplierOne = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierTwo = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplierOne[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplierTwo[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }
    }

    
}

