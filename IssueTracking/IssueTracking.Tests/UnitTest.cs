using System;
using System.Linq;
using NUnit.Framework;
using IssueTracking.ServiceInterface;
using IssueTracking.ServiceModel;
using ServiceStack.Testing;
using ServiceStack;
using IssueTracking.Common;

namespace IssueTracking.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost _appHost;

        public UnitTests()
        {
            _appHost = new BasicAppHost(typeof(ServicesProvider).Assembly)
            {
                ConfigureContainer = container =>
                {
                    container.Register<IModelContainer>(c => new ModelContainer());
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _appHost.Dispose();
        }

        [Test]
        public void TestAddIssue()
        {
            var service = _appHost.Container.Resolve<ServicesProvider>();
            var model = _appHost.Container.Resolve<IModelContainer>();

            var description = "My latest issue";

            var response = (AddIssueResponse)service.Any(new AddIssue { Description = description });
            var issue = model.GetIssue(response.Id);

            Assert.That(issue.Description, Is.EqualTo(description));
        }
    }
}
