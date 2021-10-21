using System;
using System.Collections;
using System.Collections.Generic;

namespace BTK_Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee engin = new Employee {Name = "Engin Demiroğ"};
            Employee salih = new Employee {Name = "Salih Demiroğ"};
            engin.AddSubordinate(salih);
            Employee derin = new Employee {Name = "Derin Demiroğ"};
            engin.AddSubordinate(derin);
            Employee ahmet = new Employee {Name = "Ahmet"};
            salih.AddSubordinate(ahmet);

            Console.WriteLine(engin.Name);
            
            foreach (var person in engin)
            {
                var manager = (Employee) person;
                Console.WriteLine("  {0}", manager.Name);
                foreach (var employee in manager)
                {
                    Console.WriteLine("   {0}", employee.Name);
                }
            }
        }
    }

    interface IPerson
    {
        public string Name { get; set; }
    }

    //Biz buraya foreach'le gezebileceğimiz bir ortam yapmış olduk. IEnumerable ile.
    class Employee : IPerson, IEnumerable<IPerson>
    {
        private List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        
        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}