using System.Collections.Generic;
using AndreAirlinesDomain.Model;
using MongoDB.Driver;
using PassengerAPI.Utils;

namespace PassengerAPI.Service
{
    public class PassengerService 
    {
        private readonly IMongoCollection<Passenger> _passenger;

        public PassengerService(IPassengerUtilsDatabaseSettings settings)
        {
            var passenge = new MongoClient(settings.ConnectionString);
            var database = passenge.GetDatabase(settings.DatabaseName);
            _passenger = database.GetCollection<Passenger>(settings.PassengerCollectionName);
        }

        public List<Passenger> Get() =>
       _passenger.Find(passenger => true).ToList();
        public Passenger Get(string id) =>
            _passenger.Find<Passenger>(passenger => passenger.Id == id).FirstOrDefault();

        public Passenger GetCode(string code) =>
            _passenger.Find<Passenger>(passenger => passenger.CodePassenger.ToUpper() == code.ToUpper()).FirstOrDefault();

        public Passenger ExistCPF(string CPF) =>
            _passenger.Find<Passenger>(passenger => passenger.CPF == CPF).FirstOrDefault();


        public Passenger Create(Passenger passenger)
        {

            _passenger.InsertOne(passenger);
            return passenger;
        }

        public void Update(string id, Passenger passengerIn) =>
            _passenger.ReplaceOne(passenger => passenger.Id == id, passengerIn);

        public void Remove(Passenger passengerIn) =>
            _passenger.DeleteOne(passenger => passenger.Id == passengerIn.Id);

        public void Remove(string id) =>
           _passenger.DeleteOne(passenger => passenger.Id == id);


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

