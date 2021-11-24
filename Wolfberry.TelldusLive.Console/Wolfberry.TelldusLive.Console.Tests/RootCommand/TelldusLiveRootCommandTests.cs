using Wolfberry.TelldusLive.Console.RootCommand;
using Xunit;
using Moq;
using Wolfberry.TelldusLive.Console.Configuration;

namespace Wolfberry.TelldusLive.Console.Tests.RootCommand
{
    public class TelldusLiveRootCommandTests
    {
        [Fact]
        public void TestCreate_ReturnsCommand()
        {
            var mockedConfiguration = new AuthConfiguration();
            var configurationManager = new Mock<IConfigurationManager>();
            configurationManager.Setup(x => x.GetAuthConfiguration())
                .Returns(mockedConfiguration);
            
            var command = TelldusLiveRootCommand.Create(configurationManager.Object);
            
            Assert.NotNull(command);
        }
    }
}