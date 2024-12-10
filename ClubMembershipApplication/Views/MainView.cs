using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    class MainView : IView
    {
        public IFieldValidator FielValidator => null;

        IView _registerView;
        IView _loginView;

        public MainView(IView registerView, IView loginView) 
        {
            _registerView = registerView;
            _loginView = loginView;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            Console.WriteLine("Please press L to login or R to register");

            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.R)
            {
                RunUserRegistrationView();
                RunLoginView();
            }
            else if (key == ConsoleKey.L) 
            {
                RunLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Goodbye");
                Console.ReadKey();
            }
        }

        private void RunUserRegistrationView()
        {
            _registerView.RunView();

        }

        private void RunLoginView()
        {
            _loginView.RunView();
        }
    }
}
