using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Repository.Infrastructure;

namespace WFHMS.Services.Services
{
    public class NotificationServices : INotificationServices
    {
        private readonly IUnitOfWork unitOfWork;
        public NotificationServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
