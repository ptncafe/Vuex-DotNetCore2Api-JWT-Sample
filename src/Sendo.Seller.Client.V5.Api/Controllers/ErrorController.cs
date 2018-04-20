using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sendo.Seller.Client.V5.Api.Constants;
using Sendo.Seller.Client.V5.Api.Dtos.Authentication;
using Sendo.Seller.Client.V5.Api.Models;
using Sendo.Seller.Client.V5.Api.Models.Authentication;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JWT.Controllers
{
    /// <summary>
    /// https://auth0.com/blog/securing-asp-dot-net-core-2-applications-with-jwts/
    /// </summary>
    //[Route("api/[controller]")]
    public class ErrorController : Controller
    {
        [Route("error/{code}")]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}