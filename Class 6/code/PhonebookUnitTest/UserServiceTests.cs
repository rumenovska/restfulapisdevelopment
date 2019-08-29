using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Microsoft.Extensions.Options;
using PhonebookUnitTest.FakeRepositories;
using DataModels;

namespace PhonebookUnitTest
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        public UserServiceTests()
        {
            var settings= new JwtSettings() { Secret= "some secret"};
            var jwtSettings = Options.Create(settings);
            var fakeUserRepo = new FakeUserRepository();
            _userService = new UserService(fakeUserRepo, jwtSettings);
        }
        [TestMethod]
        public void Authecicate_UsernameExists_Exception()
        {
            //Arrange
            var newUser = new RegisterModel
            {
                Username= "igor.mitkovski"
            };
            var expectedMessage = "Username already exists!";

            //Act
            Action action = () => _userService.Register(newUser);

            //Assert
            var exception = Assert.ThrowsException<Exception>(action);
            Assert.AreEqual(expectedMessage,exception.Message);
        }
    }
}
