using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonData.Models;
using MassTransit;

namespace UserRequests.Consumers
{
    public class UserRequestsConsumer: IConsumer<TblUser>
    {
       

        public Task Consume(ConsumeContext<TblUser> context)
        {
            return Task.CompletedTask;
        }
    }
}
