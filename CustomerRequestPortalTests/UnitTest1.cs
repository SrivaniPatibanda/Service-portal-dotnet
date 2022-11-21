using CommonData.Models;
using Microsoft.IdentityModel.Protocols;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using UserRequests.Controllers;
using User.Controllers;

namespace CustomerRequestPortalTests
{
    public class Tests
    {
        private HttpClient client;
        private HttpResponseMessage response;
        Mock<ServiceRequestsController> mockdata;
        ServiceRequestsController serviceRequests;
        LoginController loginreq;

        [SetUp]
        public void Setup()
        {
            client = new HttpClient();
            //client.BaseAddress = new System.Uri("https://localhost:44385/api/gateway/");
            //response = client.GetAsync("ServiceRequests/get").Result;
            mockdata = new Mock<ServiceRequestsController>();
            serviceRequests = new ServiceRequestsController();
           // loginreq = new LoginController();
            
        }

        [Test]
        public void GetResponseIsSuccess()
        {
            dynamic res = "success";
            //mockdata.Setup(x => x.Delete(It.IsAny<int>())).Returns(res);
            dynamic result = serviceRequests.Delete(1);
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void Get_Test()
        {
            dynamic res = "success";
            //mockdata.Setup(x => x.Delete(It.IsAny<int>())).Returns(res);
            dynamic result = serviceRequests.Get();
            Assert.IsNotNull(result);
        }

        [Test]
        public void Post_Test()
        {
            //dynamic res = "success";
            //mockdata.Setup(x => x.Delete(It.IsAny<int>())).Returns(res);

            TblUserRequest obj = new TblUserRequest() {Description = "abc", Type = "IT Request", Status = "Completed" , Date = "02-02-2002"};
            dynamic result = serviceRequests.Post(obj);
            Assert.IsNotNull(result);
        }

    

     





    }
}


