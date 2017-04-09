using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMyTravel.WebAPI.Model
{
    public class ResultSet
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public TodoItem Model { get; set; }

        public IEnumerable<TodoItem> List { get; set; }
    }
}
