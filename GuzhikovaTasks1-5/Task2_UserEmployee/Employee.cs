using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_UserEmployee
{
    internal class Employee : User
    {
        private DateTime _dateOfBirth;
        private DateTime _startWorkDate;
        private int _workExperience;

        public Employee() : base()
        {
        }

        public Employee(DateTime startWorkDate, EmployeeTypes post, string firstName, string middleName, string lastName, DateTime dateOfBirth)
            : base(firstName, middleName, lastName, dateOfBirth)
        {
            StartWorkDate = startWorkDate;
            Post = post;
        }

        public DateTime StartWorkDate
        {
            get => _startWorkDate;
            set
            {
                if (!regexDate.IsMatch(value.ToString("yyyy-MM-dd")))
                    throw new FormatException("Error! Incorrect format of date! Should be yyyy-MM-dd");

                if (value >= _today)
                    throw new ArgumentException("Error! Incorrect date of birth. Should be earlier than now");

                if (value <= DateOfBirth)
                    throw new ArgumentException("Error! Work experience can't be more than employee age");

                _startWorkDate = value;
            }
        }

        public override int Age
        {
            get
            {
                if (base.Age < 18)
                    throw new ArgumentException("Error! Employee must be over 18 years old.");

                return base.Age;
            }
        }

        public int WorkExperience
        {
            get
            {
                _workExperience = _today.Year - StartWorkDate.Year;

                return (StartWorkDate > _today.AddYears(-_workExperience)) ?
                    _workExperience-- :
                    _workExperience;
            }
        }

        public EmployeeTypes Post { get; set; }

        public override string ToString()
        {
            string employeeInfo = string.Format($"{Environment.NewLine}Должность: {Post}. Стаж работы: {WorkExperience} полных лет. ");

            return base.ToString() + employeeInfo;
        }
    }

    public enum EmployeeTypes
    {
        None,
        Разнорабочий,
        Оператор,
        Менеджер,
        Администратор,
        Управляющий,
        Директор
    }
}
