using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFHMS.Repository.Infrastructure;

namespace WFHMS.Services.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly IUnitOfWork unitOfWork;
        public RequestServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
