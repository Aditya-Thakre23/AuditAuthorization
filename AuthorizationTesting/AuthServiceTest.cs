using NUnit.Framework;
using Moq;
using AuthorizationService.Repository;
using AuthorizationService.Service;

namespace AuthorizationTesting
{
    class AuthServiceTest
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
        public void GenerateJWT_ValidInput_Returnstoken()
        {
            Mock<IAuthRepo> mock = new Mock<IAuthRepo>();
            mock.Setup(p => p.GenerateJWT()).Returns(token1);
            AuthService res = new AuthService(mock.Object);
            var data = res.GetJsonWebToken();
            Assert.AreEqual(token1, data);
        }
        [Test]
        public void GenerateJWT_NullInput_ReturnsNull()
        {
            Mock<IAuthRepo> mock = new Mock<IAuthRepo>();
            mock.Setup(p => p.GenerateJWT()).Returns(token2);
            AuthService res = new AuthService(mock.Object);
            var data = res.GetJsonWebToken();
            Assert.AreEqual(null, data);
        }
    }
}
