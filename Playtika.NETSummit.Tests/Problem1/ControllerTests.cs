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
            Mocker.GetMock<IUiFactory>().Setup(x => x.Create<IView>());
        }

        [Test]
        public void Initialize_Calls_ViewIsCreated()
        {
            var controller = Mocker.CreateInstance<Controller>();

            controller.Initialize();

            Mocker.GetMock<IUiFactory>().Verify(x => x.Create<IView>(), Times.Exactly(2));
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
                .Returns(async () =>
                {
                    await Task.Delay(10);
                    return 1;
                });
            var controller = Mocker.CreateInstance<Controller>();
            controller.Initialize();
            controller.Start();

            Mocker.GetMock<IView>().Raise(x => x.Clicked += null);

            Mocker.GetMock<IView>().VerifySet(x => x.Temperature = 1);
        }
    }
}