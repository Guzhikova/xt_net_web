using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Users.Entities
{
    public class User
    {
        protected DateTime _today = DateTime.Today;
        private DateTime _dateOfBirth;
        private int _age;

        public User()
        {

        }
        public User(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value >= _today)
                    throw new ArgumentException("Error! Incorrect date of birth. Should be earlier than now");

                _dateOfBirth = value;
            }
        }
        public int Age
        {
            get
            {
                if (DateOfBirth == default(DateTime))
                {
                    return 0;
                }
                _age = _today.Year - DateOfBirth.Year;
                return (DateOfBirth > _today.AddYears(-_age)) ? _age-- : _age;
            }
        }

        public override string ToString()
        {
            return String.Format($"{Name}. Дата рождения: {DateOfBirth:D} Полных лет: {Age}. ID = {Id}");
        }

    }
}
