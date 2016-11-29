using System;
using System.ComponentModel.DataAnnotations;

namespace UIConfiguration.Models
{
    public class User
    {
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string EMail { get; set; }
        public bool Newsletter { get; set; }
        public string Thumbnail { get; set; }
        public string SpeechID { get; set; }

        //public virtual Dwarf Dwarf { get; set; }
    }

    public class Account
    {
        public Guid ID { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual User User { get; set; }
    }

    public class UserSettings
    {
        public string Tag { get; set; }
        public string Value { get; set; }

        public virtual User User { get; set; }
    }
}