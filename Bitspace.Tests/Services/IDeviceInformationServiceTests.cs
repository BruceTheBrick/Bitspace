using Bitspace.Services.DeviceInformation;
using Bitspace.Tests.Base;
using Moq;
using Xunit;

namespace Bitspace.Tests.Services
{
    public class IDeviceInformationServiceTests : UnitTestBase<IDeviceInformationService> {

        [Fact]
        public void IsiOS_ShouldReturnTrue_WhenDeviceIsiOS()
        {
            //Arrange
            Mocker.GetMock<IDeviceInformationService>();

            //Act
            var isIos = Sut.IsiOS;

            //Assert
            //t.Should().BeTrue();

        }
    }
}