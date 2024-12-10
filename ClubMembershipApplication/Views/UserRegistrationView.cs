using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class UserRegistrationView:IView
    {
        IFieldValidator _fieldValidator = null;
        IRegister _register = null;

        public IFieldValidator FieldValidator { get => _fieldValidator; }

        public IFieldValidator FielValidator => throw new NotImplementedException();

        public UserRegistrationView(IRegister register, IFieldValidator fieldValidator)
        {
            _fieldValidator = fieldValidator;
            _register = register;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegistrationHeading();

            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Email] = GetInputFromUser(FieldConstants.UserRegistrationField.Email,"Please enter your email address: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.FirstName] = GetInputFromUser(FieldConstants.UserRegistrationField.FirstName, "Please enter your first name: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.LastName] = GetInputFromUser(FieldConstants.UserRegistrationField.LastName, "Please enter your last name: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Password] = GetInputFromUser(FieldConstants.UserRegistrationField.Password, $"Please enter your password.{Environment.NewLine} Your password must cotaint a number, a capital letter, a special character. {Environment.NewLine} Should be between 6-10 characters: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PasswordCompare] = GetInputFromUser(FieldConstants.UserRegistrationField.PasswordCompare, "Please enter same password: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldConstants.UserRegistrationField.DateOfBirth, "Please enter your date of birth: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.Address] = GetInputFromUser(FieldConstants.UserRegistrationField.Address, "Please enter your address: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.City] = GetInputFromUser(FieldConstants.UserRegistrationField.City, "Please enter your city: ");
            _fieldValidator.FieldArray[(int)FieldConstants.UserRegistrationField.PostCode] = GetInputFromUser(FieldConstants.UserRegistrationField.PostCode, "Please enter your post code: ");

            RegisterUser();
        }

        private void RegisterUser()
        {
            _register.Register(_fieldValidator.FieldArray);
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine("You have successfully registered. Please press any key to login ");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
        }

        private string GetInputFromUser(FieldConstants.UserRegistrationField field, string promptText) 
        {
            string fieldVal = "";

            do
            {
                Console.Write(promptText);
                fieldVal = Console.ReadLine();
            }
            while (!FieldValid(field,fieldVal));

            return fieldVal;
        }

        private bool FieldValid(FieldConstants.UserRegistrationField field, string fieldValue)
        {
            if(!_fieldValidator.FieldValidatorDel((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine(invalidMessage);

                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                return false;
            }
            return true;

        }
    }
}
