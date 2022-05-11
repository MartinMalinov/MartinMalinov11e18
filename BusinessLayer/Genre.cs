using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Genre
    {
        [Key]
        public int Id { get; private set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; }

        private Genre()
        {

        }

        public Genre(string name)
        {
            Name = name;
        }
    }
}