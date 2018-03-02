using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Playtika.NETSummit.Problem1;

namespace Playtika.NETSummit.Tests.Problem1
{
    // Problem 1.
    // CUT is correct. Tests should be fixed.
    [TestOf(typeof(Controller))]
    public class ControllerTests
    {
        protected AutoMocker Mocker { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Mocker = new AutoMocker();
            // Remove Returns()
            Mocker.GetMock<IUiFactory>().Setup(x => x.Create<IView>()).Returns(Mocker.Get<IView>());
        }

        [Test]
        public void Initialize_Calls_ViewIsCreated()
        {
            var controller = Mocker.CreateInstance<Controller>();

            controller.Initialize();

            // Times.Exactly(2)
            Mocker.GetMock<IUiFactory>().Verify(x => x.Create<IView>(), Times.Once);
        }

        [Test]
        public void ViewOnClicked_Calls_TemperatureIsRequested()
        {
            var controller = Mocker.CreateInstance<Controller>();
            controller.Initialize();
            controller.Start();

            Mocker.GetMock<IView>().Raise(x => x.Clicked += null);

            Mocker.GetMock<IApi>().Verify(x => x.GetTemperature(), Times.Once);
        }

        [Test]
        public void ViewOnClicked_TemperatureIsReceived_TemperatureIsSet()
        {
            Mocker.GetMock<IApi>()
                .Setup(x => x.GetTemperature())
                .Returns(() =>
                {
                    //Add await Task.Delay(10)
                    return Task.FromResult(1);
                });
            var controller = Mocker.CreateInstance<Controller>();
            controller.Initialize();
            controller.Start();

            Mocker.GetMock<IView>().Raise(x => x.Clicked += null);

            Mocker.GetMock<IView>().VerifySet(x => x.Temperature = 1);
        }
    }
}