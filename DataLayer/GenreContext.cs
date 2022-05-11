using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GenreContext : IDB<Genre, int>
    {
        private MartinMalinov11e18DbContext _context;

        public GenreContext(MartinMalinov11e18DbContext context)
        {
            _context = context;
        }

        public void Create(Genre item)
        {
            try
            {
                _context.Genres.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Genre Read(int key, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> query = _context.Genres;

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Games);
                }

                return query.SingleOrDefault(g => g.Id == key);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Genre> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Genre> query = _context.Genres.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Games);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Genre item, bool useNavigationProperties = false)
        {
            try
            {
                Genre genreFromDb = Read(item.Id);

                _context.Entry(genreFromDb).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Genres.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}