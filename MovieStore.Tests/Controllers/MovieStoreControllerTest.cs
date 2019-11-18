using System;

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Moq;

using MovieStore.Controllers;
using MovieStore.Models;

namespace MovieStore.Tests.Controllers
{
    using System.Web.Mvc;

    [TestClass]
    public class MovieStoreControllerTest
    {
        [TestMethod]
        public void MovieStore_Index_TestView()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_ListOfMovies()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            List<Movie> result = controller.ListOfMovies();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Alien", actual:result[0].Title);
            Assert.AreEqual("Aliens", actual:result[1].Title);
            Assert.AreEqual("Alien 3", actual:result[2].Title);

        }

        [TestMethod]
        public void MovieStore_IndexRedirect_Success()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            RedirectToRouteResult result = controller.IndexRedirect(1) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Create", actual: result.RouteValues["Action"]);
            Assert.AreEqual("HomeController", actual: result.RouteValues["controller"]);
        }

        [TestMethod]
        public void MovieStore_IndexRedirect_BadRequest()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            HttpStatusCodeResult result = controller.IndexRedirect(0) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.BadRequest, actual: (HttpStatusCode)result.StatusCode);

        }

        [TestMethod]
        public void MovieStore_ListFromDb()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            ViewResult result = controller.ListFromDb() as ViewResult;
            List<Movie> resultMovies = result.Model as List<Movie>;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Details_Success()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void MovieStore_Details_IdIsNull()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.BadRequest, actual: (HttpStatusCode)result.StatusCode);
        }
        [TestMethod]
        public void MovieStore_Details_MovieIsNull()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);

            Movie movie = null;

            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(movie);


            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            HttpStatusCodeResult result = controller.Details(0) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.NotFound, actual: (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Create_TestView()
        {
            // Arrange
            MoviesController controller = new MoviesController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Create_AddMovie()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            Movie movie = new Movie() { MovieId = 1, Title = "Good Burger", YearRelease = 1990 };

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            RedirectToRouteResult result = controller.Create(movie) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", actual: result.RouteValues["Action"]);
         
        }

        [TestMethod]
        public void MovieStore_Edit_Success()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            ViewResult result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Edit_IdIsNull()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act

            int? intNullTest = null;

            HttpStatusCodeResult result = controller.Edit(intNullTest) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.BadRequest, actual: (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Edit_MovieIsNull()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);

            Movie movie = null;

            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(movie);

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            HttpStatusCodeResult result = controller.Edit(0) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.NotFound, actual: (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Delete_Success()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            ViewResult result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MovieStore_Delete_IdIsNull()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);
            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(list.First());

            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act

            int? intNullTest = null;

            HttpStatusCodeResult result = controller.Delete(intNullTest) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.BadRequest, actual: (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void MovieStore_Delete_MovieIsNull()
        {
            // Goal: query from our own list instead of the database.

            // Step 1
            var list = new List<Movie>
            {
                new Movie() {MovieId = 1, Title = "Rambo II" },
                new Movie() {MovieId = 2, Title = "Rambo III"}
            }.AsQueryable();

            // Step 2
            Mock<MovieStoreDbContext> mockContext = new Mock<MovieStoreDbContext>();
            Mock<DbSet<Movie>> mockSet = new Mock<DbSet<Movie>>();

            // Step 3
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.GetEnumerator()).Returns(list.GetEnumerator());
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.Provider).Returns(list.Provider);
            mockSet.As<IQueryable<Movie>>().Setup(expression: m => m.ElementType).Returns(list.ElementType);

            Movie movie = null;

            mockSet.Setup(expression: m => m.Find(It.IsAny<Object>())).Returns(movie);


            // Step 4
            mockContext.Setup(expression: db => db.Movies).Returns(mockSet.Object);

            // Arrange
            MoviesController controller = new MoviesController(mockContext.Object);

            // Act
            HttpStatusCodeResult result = controller.Delete(0) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(expected: HttpStatusCode.NotFound, actual: (HttpStatusCode)result.StatusCode);
        }
    }
}
