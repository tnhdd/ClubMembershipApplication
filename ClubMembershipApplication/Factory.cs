﻿using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication
{
    public static  class Factory
    {
        public static IView GetMainViewObject()
        {
            Ilogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IFieldValidator userRegistrationValidator = new UserRegistrationValidator(register);

            userRegistrationValidator.InitialiseValidatorDelegates();

            IView registerView = new UserRegistrationView(register, userRegistrationValidator);
            IView loginView = new UserLoginView(login);
            IView mainView = new MainView(registerView, loginView); 
            return mainView;
        }
    }
}
