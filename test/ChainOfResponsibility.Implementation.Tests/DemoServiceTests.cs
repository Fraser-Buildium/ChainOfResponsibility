using ChainOfResponsibility.Implementation.Services.Interfaces;
using ChainOfResponsibility.Implementation.Services.Parameters;
using Core;
using FluentAssertions;
using Lamar;
using Tests.Core;

namespace ChainOfResponsibility.Implementation.Tests
{
    public class DemoServiceTests
    {
        private Container? m_container;
        private MoqInjector? m_injector;
        
        protected IContainer Container => m_container ?? throw new AssertionException("Container not set.");
        protected MoqInjector Injector => m_injector ?? throw new AssertionException("MoqInjector not set.");
        
        [SetUp]
        public void Setup()
        {
            m_container = new Container(new ImplementationRegistry());
            m_injector = new MoqInjector(m_container);
        }

        [Test]
        public void DemoService_Instantiation_Succeeds()
        {
            // GIVEN ...
            
            // WHEN we try to instantiate an instance of IDemoService
            var demoService = Container.GetInstance<IDemoService>();
            
            // THEN it exists
            demoService.Should().NotBeNull();
        }

        [Test]
        public void DemoService_Create_ReturnsSuccess()
        {
            // GIVEN a user with a parameter.
            var userContext = new UserContext(1, 1, "winner", Guid.NewGuid());
            var parameter = new CreateDemoParameter();
            
            // AND a demo service.
            var demoService = Container.GetInstance<IDemoService>();
            
            // WHEN the Create() method is called
            var result = demoService.Create(userContext, parameter);
            
            // THEN the result should exist
            result.Should().NotBeNull();
            
            // AND the message should be null
            result.Message.Should().BeNullOrEmpty();
            
            // AND the result is successful
            result.StatusCode.IsSuccessful.Should().Be(true);
            
            // AND the status code is OK
            result.StatusCode.Value.Should().Be(ResultCode.OK);
        }
    }
}