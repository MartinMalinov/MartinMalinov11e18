using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Game
    {
        [Key]
        public int Id { get; private set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        private Game()
        {

        }

        public Game(string name, IEnumerable<Genre> genres)
        {
            Name = name;
            Genres = genres;
        }
    }
}