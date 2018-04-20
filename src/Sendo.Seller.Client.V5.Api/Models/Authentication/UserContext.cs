using System;
using System.Collections.Generic;

namespace Sendo.Seller.Client.V5.Api.Models.Authentication
{
    /// <summary>
    /// nguyenpt8 kế thừa từ UserContext Source cũ
    /// </summary>
    public class UserContext
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public int? StoreId { get; set; }

        public bool? SentSMS { get; set; }

        public int? StoreStatus { get; set; }

        public string StoreUrl { get; set; }

        public bool RegisterSecureShop { get; set; }

        public bool IsCertified { get; set; }

        public int? NotifyId { get; set; }

        public string NotifyHash { get; set; }

        public int? Score { get; set; }

        public bool? IsBrandShop { get; set; }

        public bool IsReview { get; set; }

        public bool IsFresh { get; set; }

        public string Token { get; set; }

        public string StoreName { get; set; }

        public bool? IsOwner { get; set; }

        public List<string> Roles { get; set; }

        public List<SendoMenu> Menus { get; set; }

        public List<StoreAccess> StoreAccess { get; set; }

        public List<StoreFunctions> StoreFunctions { get; set; }

        public bool EmptyWHAddress { get; set; }

        //public InfoVasShop InfoVasShop { get; set; }
        /// <summary>
        /// nguyenpt8 flag khi login = mobile app
        /// </summary>

        public bool IsLoginFromMobileApp { get; set; }
        /// <summary>
        /// nguyenpt8 flag tự vận chuyển
        /// </summary>

        public bool IsSelfShipping { get; set; }

        /// <summary>
        /// nguyenpt8 số tiền đặt cọc
        /// </summary>

        public double DepositAmount { get; set; }

        /// <summary>
        /// nguyenpt8  level shop
        /// </summary>

        public Nullable<int> StoreLevel { get; set; }

        public string SenpayId { get; set; }

        /// <summary>
        /// hungln8 Điểm hoạt động
        /// </summary>
        ///

        public decimal ActivityPoint { get; set; }

        /// <summary>
        /// chế tài điểm hoạt động
        /// </summary>
        ///

        public decimal ActivityPointStatus { get; set; }

        /// <summary>
        /// IsAffiliate
        /// </summary>

        public Nullable<bool> IsAffiliate { get; set; }

        /// <summary>
        /// Customer phone number.
        /// </summary>

        public string PhoneNumber { set; get; }

        /// <summary>
        /// Kiểm tra chế tài shop
        /// </summary>

        public bool IsSanctioned { set; get; }

        /// <summary>
        /// Số ngày còn lại trước khi chế tài
        /// </summary>

        public int? SanctionRemainingDays { set; get; }

        /// <summary>
        /// Loại chế tài của shop
        /// </summary>

        public Nullable<int> StoreSanctionType { set; get; }
    }

    public class SendoMenu
    {
        public string MenuName { get; set; }

        public string MenuCode { get; set; }

        public string MenuTypeInfo { get; set; }

        public string MenuUrl { get; set; }

        public string MenuUrlSpa { get; set; }

        public int MenuID { get; set; }

        public int Order { get; set; }

        public bool Visible { get; set; }

        public string Styles { get; set; }

        public string StylesV3 { get; set; }

        public List<SendoMenu> Menus { get; set; }
    }

    public class StoreFunctions
    {
        public int Id { get; set; }

        public string FunctionName { get; set; }

        public string FunctionCode { get; set; }

        public int ExternalId { get; set; }
    }

    public class StoreAccess
    {
        public int StoreId { get; set; }

        public string Name { get; set; }

        public string ShopLogo { get; set; }

        public bool IsOwner { get; set; }
    }
}