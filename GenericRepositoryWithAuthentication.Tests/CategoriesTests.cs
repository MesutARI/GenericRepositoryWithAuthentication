using AutoMapper;
using GenericRepositoryWithAuthentication.API.Controllers;
using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Services;
using GenericRepositoryWithAuthentication.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenericRepositoryWithAuthentication.Tests
{
    public class CategoriesTests
    {
        #region variables

        private readonly Mock<IUnitOfWork> mock= new Mock<IUnitOfWork>();
        private readonly CategoriesController controllerMOCK;
        private readonly IMapper _mapper;

        #endregion

        #region CategoriesTests
        public CategoriesTests()
        {
            controllerMOCK = new CategoriesController(mock.Object, _mapper);

        }
        #endregion

        #region Methods

        #region GetAll

        [Fact]
        public void GetAllAsync_ShouldReturnAllCategories_MOCK()
        {
            // Arrange
            var expected = GetAllCategories();

            mock.Setup(r => r.CategoryServices.GetAllAsync()).ReturnsAsync(expected);

            // Act
            var _actual = controllerMOCK.GetAllAsync().Result;


            // Assert
            Assert.IsType<OkObjectResult>(_actual);
            Assert.Equal(2, ((List<Category>)((OkObjectResult)_actual).Value).Count);

        }
        #endregion

        #region GetById

        #region GetbyIdAsync_ShouldReturnFilteredCategory_MOCK
        [Fact]
        public void GetbyIdAsync_ShouldReturnFilteredCategory_MOCK()
        {
            // Arrange
            int Id = 1;
            var expected = GetCategoryById();

            mock.Setup(r => r.CategoryServices.GetByIdAsync(Id)).ReturnsAsync(expected);

            // Act
            var _actual = controllerMOCK.GetbyIdAsync(Id).Result;

            // Assert
            Assert.IsType<OkObjectResult>(_actual);
            Assert.Equal("Category 1", ((Category)((OkObjectResult)_actual).Value).CategoryName);

        }
        #endregion

        #region GetbyIdAsync_ShouldReturnNotFound_MOCK
        [Fact]
        public void GetbyIdAsync_ShouldReturnNotFound_MOCK()
        {
            // Arrange
            int Id = 2;
            string message = "Unable to find any category...";
            GenericResponse<Category> expected = new GenericResponse<Category>(null)
            {
                Success = false,
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Tables = null,
                Message = message
            };

            mock.Setup(r => r.CategoryServices.GetByIdAsync(Id)).ReturnsAsync(expected);

            // Act
            var _actual = controllerMOCK.GetbyIdAsync(Id).Result;

            // Assert
            Assert.IsType<NotFoundObjectResult>(_actual);
            Assert.Equal(message, ((NotFoundObjectResult)_actual).Value.ToString());

        }
        #endregion

        #endregion

        #region Add_ShouldReturnAddedCategory_MOCK
        [Fact]
        public void Add_ShouldReturnAddedCategory_MOCK()
        {
            // Arrange
            var expected = GetCategoryById();

            mock.Setup(r => r.CategoryServices.AddAsync(expected.Tables)).ReturnsAsync(expected);

            // Act
            var _actual = controllerMOCK.AddAsync(expected.Tables).Result;

            // Assert
            Assert.IsType<OkObjectResult>(_actual);
            Assert.Equal("Category 1", ((Category)((OkObjectResult)_actual).Value).CategoryName);

        }
        #endregion

        #endregion



        #region getCategories
        GenericResponse<IEnumerable<Category>> GetAllCategories()
        {
            List<Category> list = new List<Category>()
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName ="Category 1",
                    Description ="Description 1"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName ="Category 2",
                    Description ="Description 2"
                }
            };

            GenericResponse<IEnumerable<Category>> expected = new GenericResponse<IEnumerable<Category>>(list)
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Tables = list
            };

            return expected;
        }

        GenericResponse<Category> GetCategoryById()
        {
            Category cat = new Category
            {
                CategoryId = 1,
                CategoryName = "Category 1",
                Description = "Description 1"
            };

            GenericResponse<Category> expected = new GenericResponse<Category>(cat)
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Tables = cat
            };

            return expected;
        }

        #endregion
    }
}
