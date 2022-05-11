using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Customer
    {
        [Key]
        public int Id { get; private set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required, Range(10, 80)]
        public int Age { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required, MaxLength(70)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Email { get; set; }

        public List<Customer> Friends { get; set; }
        public IEnumerable<Game> Games { get; set; }

        private Customer()
        {

        }

        public Customer(string firstName, string lastName, int age, string username, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
