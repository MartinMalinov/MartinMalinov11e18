using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GameContext : IDB<Game, int>
    {
        private MartinMalinov11e18DbContext _context;

        public GameContext(MartinMalinov11e18DbContext context)
        {
            _context = context;
        }

        public void Create(Game item)
        {
            try
            {
                List<Genre> genres = new List<Genre>();

                foreach (var genre in item.Genres)
                {
                    Genre genreFromDb = _context.Genres.Find(genre.Id);

                    if (genreFromDb != null)
                    {
                        genres.Add(genreFromDb);
                    }

                    else
                    {
                        genres.Add(genre);
                    }
                }

                item.Genres = genres;

                _context.Games.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Game Read(int key, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games;

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Genres).Include(g => g.Customers);
                }

                return query.SingleOrDefault(g => g.Id == key);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Game> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Game> query = _context.Games.AsNoTracking();

                if (useNavigationProperties)
                {
                    query = query.Include(g => g.Genres).Include(g => g.Customers);
                }

                return query.ToList(); ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Game item, bool useNavigationProperties = false)
        {
            try
            {
                Game gameFromDb = Read(item.Id, useNavigationProperties);

                if (useNavigationProperties)
                {
                    List<Genre> genres = new List<Genre>();

                    foreach (Genre genre in item.Genres)
                    {
                        Genre genreFromDb = _context.Genres.Find(genre.Id);

                        if (genreFromDb != null)
                        {
                            genres.Add(genreFromDb);
                        }

                        else
                        {
                            genres.Add(genre);
                        }
                    }

                    gameFromDb.Genres = genres;
                }

                _context.Entry(gameFromDb).CurrentValues.SetValues(item);
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
                _context.Games.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}