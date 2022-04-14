using System;
using System.Text.Json;
using AndreAirlinesDomain.Model.Base;

namespace AndreAirlinesDomain.Model
{
    public class Log : Entity
    {
        public string EntityBefore { get; set; }
        public string EntityAfter { get; set; }
        public string Operation { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public Log(string loginUser, string entityBefore, string entityAfter, string operation)
        {
            LoginUser = loginUser;
            EntityBefore = entityBefore;
            EntityAfter = entityAfter;
            Operation = operation;
            CreationDate = DateTime.Now;
        }

        public Log()
        {

        }
   

    }
}
