using System;

namespace BTK_ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vp = new VicePresident();
            President president = new President();
            
            manager.SetSuccessor(vp);
            vp.SetSuccessor(president);

            Expense expense = new Expense {Detail = "Training", Amount = 98};
            Expense expense2 = new Expense {Detail = "", Amount = 1003};
            Expense expense3 = new Expense {Detail = "", Amount = 103};
            
            manager.HandleExpense(expense);
            manager.HandleExpense(expense2);
            manager.HandleExpense(expense3);
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        //Bizim burada bir üstüne aktaracağımız bir nesneye ihtiyacımız var.
        //Müdür de expensehandler, başkan yardımcısı da, başkan da
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);

        //bizim object'in successor'ünü yani üstünü belirlemeyi sağlayan kod.
        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager handled the expense");
            }

            //100 liradan büyükse successor'ü bunu handle'lasın
            //burada hemen set etmiyoruz çünkü iş kurallarına göre değişebilir, bazen manager'dan doğrudan
            // president'a gitmek isteyebiliriz.
            else
            {
                Successor?.HandleExpense(expense);
            }
        }
    }
    
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount is > 100 and <= 1000)
            {
                Console.WriteLine("Vice President handled the expense");
            }
            
            else
            {
                Successor?.HandleExpense(expense);
            }
        }
    }
    
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense");
            }
            
            //İş kurallarına göre burası değişebilir.
            else
            {
                Successor?.HandleExpense(expense);
            }
        }
    }
}