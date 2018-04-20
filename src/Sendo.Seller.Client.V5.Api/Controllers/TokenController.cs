using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sendo.Seller.Client.V5.Api.Constants;
using Sendo.Seller.Client.V5.Api.Constants.Configuration;
using Sendo.Seller.Client.V5.Api.Dtos.Authentication;
using Sendo.Seller.Client.V5.Api.Models.Authentication;
using Sendo.Seller.Client.V5.Api.Models.Response;
using ServiceStack;

namespace JWT.Controllers {
    /// <summary>
    /// https://auth0.com/blog/securing-asp-dot-net-core-2-applications-with-jwts/
    /// </summary>
    [Route ("api/[controller]")]
    public class TokenController : Controller {
        private IConfiguration _config;
        private readonly IMapper _mapper;

        public TokenController (
            IConfiguration config, IMapper mapper
        ) {
            _config = config;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken ([FromBody] LoginModel login) {
            if (ModelState.IsValid == false)
                return BadRequest (new ApiBadRequestResponse (ModelState));

            IActionResult response = Unauthorized ();
            var user = Authenticate (login);

            if (user != null) {
                var dateNow = DateTime.Now;
                JwtSecurityToken jwtSecurityToken = CreateJwtSecurityToken (user, dateNow);
                var tokenString = BuildToken (jwtSecurityToken);
                response = Ok (new {
                    token = tokenString, expires = GetExpireTime (dateNow)
                });
            }

            return response;
        }

        private DateTime GetExpireTime (DateTime dateTime) {
            return DateTime.Now.AddMinutes (Convert.ToInt32 (_config[JwtConfiguration.Timeout]));
        }

        private JwtSecurityToken CreateJwtSecurityToken (UserContext user, DateTime date) {
            var key = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (_config[JwtConfiguration.Key]));
            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);
            return new JwtSecurityToken (_config[JwtConfiguration.Issuer],
                _config[JwtConfiguration.Issuer],
                expires : GetExpireTime (date),
                claims : GetClaimsIdentityFromUserContext (user),
                signingCredentials : creds);
        }

        private string BuildToken (JwtSecurityToken token) {
            return new JwtSecurityTokenHandler ().WriteToken (token);
        }

        private UserContext Authenticate (LoginModel login) {
            UserContext user = null;

            if (login.Username.Equals (login.Password)) {
                //TO DO lấy api login về trả về UserContextDto
                user = _mapper.Map<UserContext> (GetSampleUserContextDto (login));
            }
            return user;
        }

        /// <summary>
        /// nguyenpt8 add Claim vào tolen jwt
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private List<Claim> GetClaimsIdentityFromUserContext (UserContext user) {
            // Here we can save some values to token.
            // For example we are storing here user id and email
            var claims = new List<Claim> {
                new Claim (ClaimSendoSellerTypes.ActivityPoint, user.ActivityPoint.ToString ()),
                new Claim (ClaimSendoSellerTypes.ActivityPointStatus, user.ActivityPointStatus.ToString ()),
                new Claim (ClaimSendoSellerTypes.AvatarUrl, user.AvatarUrl),
                new Claim (ClaimSendoSellerTypes.DepositAmount, user.DepositAmount.ToString ()),
                new Claim (ClaimSendoSellerTypes.Email, user.Email),
                new Claim (ClaimSendoSellerTypes.EmptyWHAddress, user.EmptyWHAddress.ToString ()),
                new Claim (ClaimSendoSellerTypes.FullName, user.FullName),
                new Claim (ClaimSendoSellerTypes.IsAffiliate, user.IsAffiliate.ToString ()),
                new Claim (ClaimSendoSellerTypes.IsBrandShop, user.IsBrandShop.ToString ()),
                new Claim (ClaimSendoSellerTypes.IsCertified, user.IsCertified.ToString ()),
                new Claim (ClaimSendoSellerTypes.IsFresh, user.IsFresh.ToString ()),
                new Claim (ClaimSendoSellerTypes.IsLoginFromMobileApp, user.IsLoginFromMobileApp.ToString ()),
                new Claim (ClaimSendoSellerTypes.IsOwner, user.IsOwner.ToString ()),
                new Claim (ClaimSendoSellerTypes.IsReview, user.IsReview.ToString ()),
                new Claim (ClaimSendoSellerTypes.IsSanctioned, user.IsSanctioned.ToString ()),
                new Claim (ClaimSendoSellerTypes.IsSelfShipping, user.IsSelfShipping.ToString ()),
                //new Claim(ClaimSendoSellerTypes.Menus, user.Menus.ToJson()),//
                new Claim (ClaimSendoSellerTypes.NotifyHash, user.NotifyHash.ToString ()),
                new Claim (ClaimSendoSellerTypes.NotifyId, user.NotifyId.ToString ()),
                new Claim (ClaimSendoSellerTypes.PhoneNumber, user.PhoneNumber),
                new Claim (ClaimSendoSellerTypes.RegisterSecureShop, user.RegisterSecureShop.ToString ()),
                //new Claim(ClaimSendoSellerTypes.Roles, user.Roles.ToJson()),
                new Claim (ClaimSendoSellerTypes.SanctionRemainingDays, user.SanctionRemainingDays.ToString ()),
                new Claim (ClaimSendoSellerTypes.Score, user.Score.ToString ()),
                new Claim (ClaimSendoSellerTypes.SenpayId, user.SenpayId),
                new Claim (ClaimSendoSellerTypes.SentSMS, user.SentSMS.ToString ()),
                new Claim (ClaimSendoSellerTypes.StoreAccess, user.StoreAccess.ToJson ()),
                //new Claim(ClaimSendoSellerTypes.StoreFunctions, user.StoreFunctions.ToJson()),
                new Claim (ClaimSendoSellerTypes.StoreId, user.StoreId.ToString ()),
                new Claim (ClaimSendoSellerTypes.StoreLevel, user.StoreLevel.ToString ()),
                new Claim (ClaimSendoSellerTypes.StoreName, user.StoreName),
                new Claim (ClaimSendoSellerTypes.StoreSanctionType, user.StoreSanctionType.ToString ()),
                new Claim (ClaimSendoSellerTypes.StoreStatus, user.StoreStatus.ToString ()),
                new Claim (ClaimSendoSellerTypes.StoreUrl, user.StoreUrl),
                new Claim (ClaimSendoSellerTypes.Token, user.Token),
                new Claim (ClaimSendoSellerTypes.UserName, user.UserName),
            };
            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

            // Adding roles code
            // Roles property is string collection but you can modify Select code if it it's not
            foreach (var item in user.Roles)
                claims.Add (new Claim (ClaimSendoSellerTypes.Roles, item));

            foreach (var item in user.Menus)
                claims.Add (new Claim (ClaimSendoSellerTypes.Menus, item.ToJson ()));

            foreach (var item in user.StoreFunctions)
                claims.Add (new Claim (ClaimSendoSellerTypes.StoreFunctions, item.ToJson ()));

            return claims;
        }

        /// <summary>
        /// nguyenpt8 example thôi
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private UserContextDto GetSampleUserContextDto (LoginModel login) {
            return new UserContextDto () {
                ActivityPoint = 10,
                    ActivityPointStatus = 1,
                    AvatarUrl = "",
                    DepositAmount = 200000,
                    Email = $"{login.Username}@gmail.com",
                    EmptyWHAddress = false,
                    FullName = login.Username,
                    IsAffiliate = false,
                    IsBrandShop = true,
                    IsCertified = true,
                    IsFresh = false,
                    IsLoginFromMobileApp = false,
                    IsOwner = true,
                    IsReview = false,
                    IsSanctioned = false,
                    IsSelfShipping = true,
                    Menus = new List<SendoMenuDto> (),
                    PhoneNumber = "090xxxxxxxxx",
                    NotifyHash = string.Empty,
                    NotifyId = 0,
                    RegisterSecureShop = false,
                    Roles = new List<string> (),
                    SanctionRemainingDays = 0,
                    Score = 0,
                    SenpayId = "200012331",
                    SentSMS = false,
                    StoreAccess = new List<StoreAccessDto> (),
                    StoreFunctions = new List<StoreFunctionsDto> (),
                    StoreId = 12345,
                    StoreLevel = 1,
                    StoreName = $"shop {login.Username}",
                    StoreSanctionType = 0,
                    StoreStatus = 2,
                    StoreUrl = $"https://sendo.vn/shop/{login.Username}",
                    Token = "12312312",
                    UserName = "200012331",
            };
        }
    }
}