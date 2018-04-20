using Sendo.Seller.Client.V5.Api.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sendo.Seller.Client.V5.Api.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class AuthenticationHelper
    {
        /// <summary>
        /// nguyenpt8 lấy cho nhanh Get the claim string value.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="claimSendoSellerTypes">The claimSendoSellerTypes.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetDefaultClaimStringValue(this ClaimsPrincipal user, string claimSendoSellerTypes)
        {
            return user.Claims.FirstOrDefault(x => x.Type == claimSendoSellerTypes).Value;
        }

        /// <summary>
        /// nguyenpt8 lấy cho nhanh
        /// </summary>
        /// <param name="user"></param>
        /// <param name="claimSendoSellerTypes"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetListClaimStringValue(this ClaimsPrincipal user, string claimSendoSellerTypes)
        {
            return user.Claims.Where(x => x.Type == claimSendoSellerTypes).Select(x=>x.Value);
        }
    }
}
