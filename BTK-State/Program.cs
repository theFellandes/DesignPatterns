using System;

namespace BTK_State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);

            Console.WriteLine(context.GetState());

            DeletedState deletedState = new DeletedState();
            deletedState.DoAction(context);

            Console.WriteLine(context.GetState());
        }
    }

    interface IState
    {
        //bizim bir nesnenin state'ini yönetebilmek için bir context'ten geçiyor olması lazım.
        void DoAction(Context context);
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State Modified.");
            //Design'ın can alıcı kısmı burası.
            context.SetState(this);
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State Deleted");
            context.SetState(this);
        }
    }
    
    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State Added");
            context.SetState(this);
        }
    }
    
    class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}