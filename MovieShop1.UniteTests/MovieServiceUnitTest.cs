using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieShop1.Data;
using MovieShop1.Entities;
using MovieShop1.Services;
using System.Linq;
using Moq;

namespace MovieShop1.UniteTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieService _sut;
        // sut = System Under Test
        private List<Movie> _fakeMovies;
        private readonly Mock<IMovieRepository> _mockMovieRepository;
        

        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _sut = new MovieService(_mockMovieRepository.Object);
        }

        [TestInitialize]
        //Triggered before every test case
        public void TestInitialize()
        {
            _fakeMovies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "TestMovie1",
                    Budget = 290000000,
                },
                new Movie
                {
                    Id = 2,
                    Title = "TestMovie2",
                    Budget = 65000000,
                },
                new Movie
                {
                    Id = 3,
                    Title = "TestMovie3",
                    Budget = 26098000000,
                },
                new Movie
                {
                    Id = 4,
                    Title = "TestMovie4",
                    Budget = 345300000,
                },
                new Movie
                {
                    Id = 5,
                    Title = "TestMovie5",
                    Budget = 46560000,
                }
            };
            //return _fakeMovies;

            //using Moq we are going to setup mock methods for IMovieRepository
            _mockMovieRepository.Setup(m => m.GetTopGrossingMovies()).Returns(_fakeMovies);
            _mockMovieRepository.Setup(m => m.GetById(It.IsAny<int>())).Returns((int m) => _fakeMovies.FirstOrDefault(x=>x.Id == m));
            //means could be any integer

        }

        [TestMethod]
        public void Test_For_TopGrossingMovies_From_fakeData()
        {
            //_sut = new MovieService();

            //Act, which means we need to call the actual method
            var topMovies = _sut.GetTopGrossingMovies();

            //Assert
            //you can do multiple asserts in one unit test method
            //checking topMovies is not null 
            Assert.IsNotNull(topMovies);

            //check totalnumber of movies equal to 5
            Assert.AreEqual(5, topMovies.Count());

            //check the returned type
            CollectionAssert.AllItemsAreInstancesOfType(topMovies.ToList(), typeof(Movie));
        }

        //new unit test method for testing getMovieDetails method in Movie Service
        //Movie GetMovieDetails(int id);
        //Assert, check movie name, id, type, is not null

        [TestMethod]
        public void Test_For_GetMovieDetails_From_fakeData()
        {
            int IdTest = 1;
            //_sut = new MovieService();

            //Act, which means we need to call the actual method
            var topMovies = _sut.GetMovieDetails(IdTest);

            //Assert
            //you can do multiple asserts in one unit test method
            //checking topMovies is not null 
            Assert.IsNotNull(topMovies);

            Assert.AreEqual("TestMovie1", topMovies.Title);
            Assert.AreEqual(1, topMovies.Id);
            Assert.IsInstanceOfType(topMovies, typeof(Movie));

        }

    }

    /*
    public class FakeMovieRepository : IMovieRepository
    {
        private List<Movie> _fakeMovies;
        public void Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<Movie, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Movie Get(Expression<Func<Movie, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMany(Expression<Func<Movie, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            //instead of using Database we need to return fake movies from memory
            _fakeMovies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "TestMovie1",
                    Budget = 290000000,
                },
                new Movie
                {
                    Id = 2,
                    Title = "TestMovie2",
                    Budget = 65000000,
                },
                new Movie
                {
                    Id = 3,
                    Title = "TestMovie3",
                    Budget = 26098000000,
                },
                new Movie
                {
                    Id = 4,
                    Title = "TestMovie4",
                    Budget = 345300000,
                },
                new Movie
                {
                    Id = 5,
                    Title = "TestMovie5",
                    Budget = 46560000,
                }
            };
            return _fakeMovies;

        }

        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
    */

}
