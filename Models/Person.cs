using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListObjectSerialization.Models
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"======================== \n" +
                $"Id: {Id} \n" +
                $"Name: {Name} \n" +
                $"Email: {Email} \n";
        }
    }
}
