using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text.Json;
using ListObjectSerialization.Models;

namespace ListObjectSerialization
{
    internal class Program
    {
        static string file = ConfigurationManager.AppSettings["filePath"]!.ToString();
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { Id = 101, Name = "Ramesh", Email = "ramesh@gmail.com" });
            persons.Add(new Person() { Id = 102, Name = "Suresh", Email = "suresh@gmail.com" });
            persons.Add(new Person() { Id = 103, Name = "Mahesh", Email = "mahesh@gmail.com" });
            persons.Add(new Person() { Id = 104, Name = "Ajesh",  Email = "ajesh@gmail.com" });
            persons.Add(new Person() { Id = 105, Name = "Rakesh", Email = "rakesh@gmail.com" });

          //  SerializeObject(persons);


            DeserializeObject();
            
        }
        static void SerializeObject(List <Person> persons)
        {
            int count = 0;
            foreach (Person person in persons) { 
                using(StreamWriter sw = new StreamWriter(file,true))
                {
                    sw.WriteLine(JsonSerializer.Serialize(person));
                    count++;
                    Console.WriteLine($"Object {count} has been serialized");
                }
            }
        }

        static void DeserializeObject()
        {
            List<Person> persons = new List<Person>();

            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                    Person person = JsonSerializer.Deserialize<Person>(line)!;
                    persons.Add(person);
                }
            }

            Console.WriteLine("Deserialized Persons:");
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine(persons.Count);
        }

    }
}
