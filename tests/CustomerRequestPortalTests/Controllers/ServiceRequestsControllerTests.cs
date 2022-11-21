using System;
using Xunit;
using Moq;
using AutoFixture;
using FluentAssertions;
using UserRequests.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using CommonData.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRequestPortalTests.Controllers
{
    public class ServiceRequestsControllerTests
    {
        private readonly IFixture _fixture;
        private readonly ServiceRequestsController _sut;
        private readonly Mock<ServiceRequestsController> _req;
        public ServiceRequestsControllerTests()
        {
            _fixture = new Fixture();
            _req = _fixture.Freeze<Mock<ServiceRequestsController>>();
            _sut = new ServiceRequestsController(); // Creates the implementation in-memory

        }



        [Fact]
        public void GetRequests_ShouldReturnOkresponse_WhenDataFound()
        {
            //Arrange
            var requestsMock = _fixture.Create<IEnumerable<TblUserRequest>>();
            _req.Setup(x => x.Get()).Returns(requestsMock);


            //Act
            var result = _sut.Get();

            //Assert
            result.Should().NotBeNull();
          
           
        }



    }
}
