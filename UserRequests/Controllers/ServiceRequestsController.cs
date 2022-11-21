using CommonData.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRequests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsController: ControllerBase

    {
        //private readonly IServiceRequestsRepository _requestsRepository;

        //public ServiceRequestsController(IServiceRequestsRepository requestsRepository)
        //{
        //    _requestsRepository = requestsRepository;
        //}
        private readonly IBus bus;
        CustomerDBContext db = new CustomerDBContext();
       

       

        //***********************Insert/ Create method*****************//
        [HttpPost]
        public IActionResult Post([FromBody] TblUserRequest insert)
        {
            db.TblUserRequests.Add(insert);
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }

        //********************read/search method****************//
        [HttpPost]
        [Route("searchuserrequests")]
      
        public IEnumerable<TblUserRequest> Post(int id, string description, string type, string status, string date )
        {
            List<TblUserRequest> search = db.TblUserRequests.Where(x =>x.Id == id|| x.Description == description || x.Type == type || 
            x.Status == status || x.Date == date).ToList();
            return search;
        }

        //*****************   Update/Edit method****************//
        [HttpPut]
        [Route("updaterequestdatabyid")]
        public IActionResult Put(TblUserRequest update)
        {
            var data = db.TblUserRequests.Where(x=>x.Id==update.Id).FirstOrDefault();
            data.Description = update.Description;
            data.Status = update.Status;
            data.Date = update.Date;
            data.Type = update.Type;
            db.TblUserRequests.Update(data);
            db.SaveChanges();
            return Ok(data);

          
        }

        //*********** Delete method ****************************//
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = db.TblUserRequests?.Where(x => x.Id == id).FirstOrDefault();
            if (data!=null)
            {
                db.TblUserRequests?.Remove(data);
                db.SaveChanges();
            }          
            var response = new { Status = "Success" };
            return Ok(response);
        }

        //**********Get method ********************************//
        [HttpGet]
        public IEnumerable<TblUserRequest> Get()
        {
            List<TblUserRequest> get = db.TblUserRequests.ToList();
            return get.ToList();
        }

      
    }
}

            


