﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guzhikova.Task6.Entities
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

        public User(string name, DateTime dateOfBirth, byte[] image)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Image = image;
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

        public byte[] Image { get; set; }
        public override string ToString()
        {
            string dateOfBirth = DateOfBirth.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
            return String.Format($"ID = {Id}. {Name}. Date of birth: {dateOfBirth}. Age: {Age}. ");
        }

    }
}
