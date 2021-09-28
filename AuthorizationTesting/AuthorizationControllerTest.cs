using AuthorizationService.Controllers;
using AuthorizationService.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AuthorizationTesting
{
    public class AuthorizationControllerTest
    {
        public string token1;
        public string token2;
        [SetUp]
        public void Setup()
        {
            token1 = "xhagssbmfbdmsdjfbkalalasknasncjafh";
            token2 = null;

        }

        [Test]
        public void GetJsonWebToken_HasValidData_ReturnsToken()
        {
            Mock<IAuthService> mock = new Mock<IAuthService>();
            mock.Setup(p => p.GetJsonWebToken()).Returns(token1);
            TokenController tc = new TokenController(mock.Object);
            var res = tc.GenerateJSONWebToken() as OkObjectResult;
            Assert.AreEqual(200, res.StatusCode);
        }
        [Test]
        public void GetJsonWebToken_HasInvalidData_ReturnsNull()
        {
            Mock<IAuthService> mock = new Mock<IAuthService>();
            mock.Setup(p => p.GetJsonWebToken()).Returns(token2);
            TokenController tc = new TokenController(mock.Object);
            var res = tc.GenerateJSONWebToken() as BadRequestObjectResult;
            Assert.AreEqual(400, res.StatusCode);
        }

    }
}