using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2_UserEmployee
{
    internal class User
    {
        protected DateTime _today = DateTime.Today;
        protected Regex regexDate = new Regex(@"([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))");
        private Regex regexName = new Regex("^([А-Я]{1}[а-яё]{1,25}|[A-Z]{1}[a-z]{1,25})$");

        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private int _age;

        public User() { }
        public User(string firstName, string middleName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (!regexName.IsMatch(value))
                    throw new FormatException("ERROR! Incorrect format!");

                _firstName = value;
            }
        }
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (!regexName.IsMatch(value))
                    throw new FormatException("ERROR! Incorrect format.");

                _middleName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (!regexName.IsMatch(value))
                    throw new FormatException("ERROR! Incorrect format!");

                _lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (!regexDate.IsMatch(value.ToString("yyyy-MM-dd")))
                    throw new FormatException("Error! Incorrect format of date! Should be yyyy-MM-dd");

                if (value >= _today)
                    throw new ArgumentException("Error! Incorrect date of birth. Should be earlier than now");

                _dateOfBirth = value;
            }
        }


        public virtual int Age
        {
            get
            {
                _age = _today.Year - DateOfBirth.Year;
                return (DateOfBirth > _today.AddYears(-_age)) ? _age-- : _age;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}, {3}. Возраст: {4} полных лет. ",
                LastName, FirstName, MiddleName, DateOfBirth.ToString("dd.MM.yyyy"), Age);
        }
    }

}
