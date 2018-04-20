using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sendo.Seller.Client.V5.Api.Models.Response
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(object result)
            : base(200)
        {
            Result = result;
        }
    }
}
