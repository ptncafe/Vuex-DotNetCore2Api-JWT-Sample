using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sendo.Seller.Client.V5.Api.Constants;
using Sendo.Seller.Client.V5.Api.Infrastructure;
using Sendo.Seller.Client.V5.Api.Models.Response;

namespace Sendo.Seller.Client.V5.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("getstoreid")]
        [HttpGet]
        public string GetStoreId()
        {
            return User.GetDefaultClaimStringValue(ClaimSendoSellerTypes.StoreId);
        }

        [Route("testgeterror500")]
        [HttpGet]
        public IActionResult TestGetError500()
        {
            throw new Exception("TestGetError500");
        }

        [Route("testgeterror400")]
        [HttpGet]
        public IActionResult TestGetError400()
        {
            return BadRequest();
        }

        [Route("testgetok")]
        [HttpGet]
        public IActionResult TestGetOk()
        {
            return Ok(new ApiOkResponse(User.GetDefaultClaimStringValue(ClaimSendoSellerTypes.StoreId)));
        }

        [Route("testgetbadrequest")]
        [HttpGet]
        public IActionResult TestGetBadRequest()
        {
            //if (!ModelState.IsValid)
            return BadRequest(new ApiBadRequestResponse(ModelState));
        }
    }
}
