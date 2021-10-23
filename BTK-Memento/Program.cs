using System;

namespace BTK_Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Isbn = "12345",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            
            book.ShowBook();

            //Değişiklikler geçmeden careTaker ile bir Memento almamız gerekiyor.
            CareTaker careTaker = new CareTaker();
            careTaker.Memento = book.CreateUndo();
            
            book.Isbn = "33333";
            book.Title = "asdf";
            book.Author = "ffff";
            
            book.ShowBook();
            
            book.RestoreFromUndo(careTaker.Memento);
            
            book.ShowBook();
        }
    }

    //Bu class'ta encapsulation'dan faydalanacağız.
    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;

        public string Title
        {
            //Değeri okuma
            get => _title;
            //Değeri yazma
            set
            {
                _title = value;
                SetLastEdited();
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                SetLastEdited();
            }
        }

        public string Isbn
        {
            get => _isbn;
            set
            { 
                _isbn = value;
                SetLastEdited();
            } 
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        //Hafıza
        public Memento CreateUndo()
        {
            return new Memento(_title, _author, _isbn, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("ISBN = {0}, Title = {1}, Author = {2}, Last Edited = {3}", Isbn, Title, Author, _lastEdited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string author, string isbn, DateTime lastEdited)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            LastEdited = lastEdited;
        }
    }

    //Mementonun eski halini tutabilmek için oluşturulmuş nesne
    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}