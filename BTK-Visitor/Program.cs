using System;
using System.Collections.Generic;

namespace BTK_Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager {Name = "Engin", Salary = 1000};

            Manager manager2 = new Manager {Name = "Salih", Salary = 900};

            Worker worker = new Worker {Name = "Derin", Salary = 800};

            Worker worker2 = new Worker {Name = "Ali", Salary = 800};
            
            manager.Subordinates.Add(manager2);
            manager2.Subordinates.Add(worker);
            manager2.Subordinates.Add(worker2);

            OrganizationalStructure organizationalStructure = new OrganizationalStructure(manager);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payrise = new Payrise();
            //Prim ödeme gibi başka bir şey eklenirse bu şekilde eklenecek.
            organizationalStructure.Accept(payrollVisitor);
            organizationalStructure.Accept(payrise);
        }
    }

    class OrganizationalStructure
    {
        public EmployeeBase Employee;

        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        //Visit işlemlerini yapacak function
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; } 
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);

    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    //Bu da visitor
    class Payrise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary * (decimal) 1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal) 1.2);
        }
    }
}