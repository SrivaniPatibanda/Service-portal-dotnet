using FakeItEasy;
using System;
using System.Collections.Generic;
using UserRequests.Controllers;
using Xunit;

namespace CustomerServicePortal.Tests
{
    public class ServiceRequestsControllerTests
    {
        [Fact]
        public void Update_ServiceRequests()
        {
            //Arrange
            var dataStore = A.Fake<>();
            var controller = new ServiceRequestsController();
            //Act
            //Assert

        }

       // private List<ServiceRequests> ServiceRequests()
     
    }
}
