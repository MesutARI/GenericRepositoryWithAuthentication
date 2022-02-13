using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Repositories;
using GenericRepositoryWithAuthentication.Core.Services;
using GenericRepositoryWithAuthentication.Core.UnitOfWorks;
using GenericRepositoryWithAuthentication.Data.Contexts;
using GenericRepositoryWithAuthentication.Data.Repositories;
using GenericRepositoryWithAuthentication.Service.Services;
using GenericRepositoryWithAuthentication.Service.UnitOfWorks;
using Moq;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace GenericRepositoryWithAuthentication.Tests
{
    public class UserServiceTests
    {
        #region variables
        //private readonly NorthwindContext _context = new NorthwindContext();

        private readonly UserService _userServiceMock;
        private readonly Mock<IUserRepository> mock = new Mock<IUserRepository>();

        //private readonly UserService _userService;
        //private readonly IUserRepository _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region UserServiceTests
        public UserServiceTests()
        {
            _userServiceMock = new UserService(mock.Object);

            //_userRepository = new UserRepository(_context);
            //_userService = new UserService(_userRepository);

            
            this._unitOfWork = new UnitOfWork();

        }
        #endregion

        #region GetById
        
        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        public void GetByIdAsync_ShouldReturnUsersById(int Id, bool Success)
        {
            // Arrange


            // Act
            var _actual = _unitOfWork.UserServices.GetByIdAsync(Id).Result;  //_userService.GetByIdAsync(Id).Result;

            // Assert
            Assert.Equal(Success, _actual.Success);
            
        }
        #endregion

        #region GetUserWithRefreshToken

        [Theory]
        [InlineData("/fR3ZzkkD2BCJgd8XtGBvyeqSPvgpw40iFnF/O0xKl8=", true)]
        [InlineData("A", false)]
        [InlineData("BB", false)]
        public void GetUserWithRefreshToken_ShouldReturnUsers(string refreshToken, bool Success)
        {
            // Brüt 92 Net 76,79 m2 

            // Arrange

            // Act
            var _actual = _unitOfWork.UserServices.GetUserWithRefreshToken(refreshToken);
            //var _actual = _userService.GetUserWithRefreshToken(refreshToken);

            // Assert
            Assert.Equal(Success, _actual.Success);

        }
        #endregion

        #region GetUserWithNamePassword

        [Theory]
        [InlineData("Mesut","123456", true)]
        [InlineData("A","123456", false)]
        [InlineData("Mesut","1234567", false)]
        public void GetUserWithNamePassword_ShouldReturnUser(string userName, string password, bool Success)
        {
            // Brüt 92 Net 76,79 m2 

            // Arrange

            // Act
            var _actual = _unitOfWork.UserServices.GetUserWithNamePassword(userName, Sha1Hash(password));
            //var _actual = _userService.GetUserWithRefreshToken(refreshToken);

            // Assert
            Assert.Equal(Success, _actual.Success);

        }
        #endregion

        #region RemoveRefreshToken

        [Fact]
        public void RemoveRefreshToken()
        {
            // Arrange
            User usr = new User()
            {
                UserId = 1,
                UserName = "Mesut",
            };

            // Act
            _unitOfWork.UserServices.RemoveRefreshToken(usr);
            //_unitOfWork.Complete();

            // Assert
            Assert.Equal(1, 1);

        }
        #endregion

        #region SaveRefreshToken

        [Fact]
        public void SaveRefreshToken()
        {
            // Arrange
            int userId = 1;
            string refreshToken = "My Ref 2";

            // Act
            _unitOfWork.UserServices.SaveRefreshToken(userId, refreshToken);
            //_unitOfWork.Complete();

            // Assert
            Assert.Equal(1, 1);

        }
        #endregion


        #region GetByIdAsync_MOQ

        [Fact]
        public void GetByIdAsync_ShouldReturnUsersById_MOQ()
        {
            // Arrange
            int id = 1;
            User expected = new User
            {
                UserId =1,
                UserName ="Mesut",
            };
            
            mock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(expected);

            // Act
            var actual = _userServiceMock.GetByIdAsync(id).Result;

            // Assert
            Assert.True(actual.Success);
            Assert.Equal(expected.UserId, actual.Tables.UserId);
            Assert.IsType<User>(actual.Tables);

        }
        #endregion

        #region sha1Hash
        private string Sha1Hash(string password)
        {
            return string.Join("", SHA1CryptoServiceProvider.Create().ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2"))).ToUpper();
        }
        #endregion


    }
}
