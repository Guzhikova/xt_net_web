﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guzhikova.Task6.Entities
{
   public class Award
    {
        public Award()
        {
            UsersId = new HashSet<int>();
        }

        public Award(string title)
        {
            Title = title;
            UsersId = new HashSet<int>();
        }

        public Award(string title, byte[] image)
        {
            Title = title;
            Image = image;
            UsersId = new HashSet<int>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public byte[] Image { get; set; }
        public HashSet<int> UsersId { get; set; }

        public override string ToString()
        {
            return String.Format($"ID = {Id}. Award \"{Title}\".");
        }
    }
}
