using System;
using NUnit.Framework;
using IssueTracking.ServiceInterface;
using IssueTracking.ServiceModel;
using ServiceStack.Testing;
using ServiceStack;

namespace IssueTracking.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(ServicesProvider).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void TestMethod1()
        {
            var service = appHost.Container.Resolve<ServicesProvider>();

            var response = (AddIssueResponse)service.Any(new AddIssue { Description = "World" });

            Assert.That(response.Id, Is.EqualTo("AddIssue, World!"));
        }
    }
}
