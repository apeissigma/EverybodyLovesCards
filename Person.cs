using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Person
    {
        public string Name { get; set; }
        public int Points = 0;
        public List<Card> Hand = new List<Card>();

        public Person(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }
}
