using NUnit.Framework;
using BusinessLayer;
using DataLayer;
using NUnit.Framework;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TestingLayer
{
    public class GenreContextUnitTest
    {
        private MartinMalinov11e18DbContext dbContext;
        private GenreContext genreContext;
        DbContextOptionsBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new MartinMalinov11e18DbContext(builder.Options);
            genreContext = new GenreContext(dbContext);
        }

        [Test]
        public void TestCreateGenre()
        {
            int genresBefore = genreContext.ReadAll().Count();
            genreContext.Create(new Genre("action"));

            int genresAfter = genreContext.ReadAll().Count();

            Assert.IsTrue(genresBefore != genresAfter);
        }

        [Test]
        public void TestReadGenre()
        {
            genreContext.Create(new Genre("sci-fi"));
            Genre genre = genreContext.Read(1);

            Assert.That(genre != null, "There is no record with id 1");
        }

        [Test]
        public void TestUpdateGenre()
        {
            genreContext.Create(new Genre("ThirdPersonShooter"));
            Genre genre = genreContext.Read(1);

            genre.Name = "FPS";
            genreContext.Update(genre);

            Genre genre1 = genreContext.Read(1);

            Assert.IsTrue(genre1.Name == "FPS", "Genre Update() does not change the name!");
        }

        [Test]
        public void TestDeleteGenre()
        {
            genreContext.Create(new Genre("Platformer"));
            int genresBeforeDelete = genreContext.ReadAll().Count();

            genreContext.Delete(1);

            int genresAfterDelete = genreContext.ReadAll().Count();

            Assert.AreNotEqual(genresBeforeDelete, genresAfterDelete);
        }
    }
}