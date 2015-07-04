using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Constants
/// </summary>
/// 
namespace MFO.Constants
{
    public static class Constant
    {
        public static class Application
        {
            
            public const String INDEX_BANAR_DT = "INDEX_BANAR_DT";
            public const String WOMEN_CAT_DT = "WOMEN_CAT_DT";
            public const String MEN_CAT_DT = "MEN_CAT_DT";
            public const String HOME_DECOR_CAT_DT = "HOME_DECOR_CAT_DT";
            public const String SHOP_BY_BAGS = "SHOP_BY_BAGS";
            public const String SHOP_BY_CLOTHING = "SHOP_BY_CLOTHING";
            public const String SHOP_BY_FOOTWEAR = "SHOP_BY_FOOTWEAR";
            public const String SHOP_BY_ACCESSORIES = "SHOP_BY_ACCESSORIES";
            public const String BRAND_MENU = "BRAND_MENU";
            public const String PIN_DT = "PIN_DT";
            
        }
        public static class Table
        {
            public const String VIEW_IMAGE_NEW_MASTER = "VIEW_IMAGE_NEW_MASTER";
        }
        public static class Sorting
        {
            public const String ABOVE = "Above";
            public const String BELOW = "Below";
            public const Int32 HIGH_TO_LOW = 2;
            public const Int32 LOW_TO_HIGH = 1;
        }
        public static class Columns
        {
            public const String SKU_BRAND = "SKUBrand";
            public const String PRODUCT_TYPE_ID = "ProductTypeID";
            
        }
        public static class Session
        {
            public const String PRODUCT_COUNT = "PRODUCT_COUNT";
            public const String SIGN_UP_EMAIL = "SignUpEmail";
            public const String SIGN_UP_PWD = "SIGN_UP_PWD";
            public const String LOGED_IN_EMAIL = "EmailID";
            public const String LOGED_IN_USER_ID = "UserID";
            public const String FAV_LIST = "FAV_LIST";
            public const String CART_ITEMS = "CART_ITEMS";
            public const String TOTAL = "TOTAL";
            public const String CURRENT_ORDER = "CURRENT_ORDER";
            public const String SHIPING_EMAIL = "SHIPING_EMAIL";
            
        }
        public static class ColumnValue
        {
            
            public const String WOMEN = "Women";
            public const String MEN = "Men";
            public const String HOME_DECOR = "Home & Decor";
            public const String BAGS = "Bags";
            public const String CLOTHING = "Clothing";
            public const String FOOTWEAR = "Footwear";
            public const String ACCESSORIES = "Accessories";
            
        }
        public static class AccountLinks
        {
            public const String ORDER = "ORDER";
            public const String RETURN_EXCHANGE = "RETURN_EXCHANGE";
            public const String WHISH_LIST = "WHISH_LIST";
            public const String ACCOUNT_SETTING = "ACCOUNT_SETTING";
            public const String BILLING_SHIPPING_ADDRESS = "BILLING_SHIPPING_ADDRESS";
            public const String INVITE_FRIEND = "INVITE_FRIEND";
            public const String FB_SHARING = "FB_SHARING";
            public const String CREADIT = "CREADIT";
            public const String EMAIL_PREF = "EMAIL_PREF";

        }
        public static class Request
        {
            public const String SIGN_UP_EMAIL_PARAM = "SIGN_UP_EMAIL_PARAM";
        }
        public static class ResponseType
        {
            public const String SUCCESS = "SUCCESS";
            public const String FAIL = "FAIL";
            public const String INVALID_EMAIL = "Please Enter The Valid Email-Id (e.g. example@domain.com)";
            public const String ALREADY_EXIST_EMAIL = "EmailID already registerd";
            public const String EMPTY_EMAIL = "Please Fill The Email-ID";
            public const String REQUIRD_PASSWORD = "Password is required";
            public const String PWD_5_CHAR_LENGTH = "Password must be at least 5 characters.";
            public const String REQUIRD_GENDER = "Gender is requird.";
            public const String NOT_A_MEMBER = "Not A Member";
            
        
        }
    }
}