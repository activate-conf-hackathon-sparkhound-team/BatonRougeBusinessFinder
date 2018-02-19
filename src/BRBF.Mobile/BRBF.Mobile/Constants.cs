using System;
using System.Collections.Generic;
using System.Text;

namespace BRBF.Mobile
{
    public class Constants
    {
        public struct ApiInfo
        {
            public struct GoogleInfo
            {
                public const string GoogleDroidClientId = "1052811891786-urod3ma4p4hs6slefuukmt3t48hm56js.apps.googleusercontent.com";
                public const string GoogleWebClientId = "1052811891786-l34a5va898dbobm4ht86md843dl79un2.apps.googleusercontent.com";
                public const string GoogleiOSClientId = "1052811891786-iuui5rc9fmhksm61kedm2dlu9lhs50vg.apps.googleusercontent.com";
                public const string GoogleClientSecret = "T7h6Xz_ieh0vMTLrd2S4jxe2";
                public const string GoogleAuthUrl = "https://accounts.google.com/o/oauth2/auth";
                public const string GoogleRedirectUrl = "com.googleusercontent.apps.1052811891786-urod3ma4p4hs6slefuukmt3t48hm56js:/oauth2redirect";
                public const string GoogleWebReidirectUrl = "apps.googleusercontent.com.1052811891786-l34a5va898dbobm4ht86md843dl79un2:/oauth2redirect";
                public const string GoogleTokenUrl = "https://accounts.google.com/o/oauth2/token";
                public static readonly string[] GoogleScopes = { "https://www.googleapis.com/auth/userinfo.profile", "https://www.googleapis.com/auth/userinfo.email" };
                public const string GoogleCustomUriSchema = "com.googleusercontent.apps.1052811891786-urod3ma4p4hs6slefuukmt3t48hm56js";
                public const string GoogleDataPath = "/oauth2redirect";
            }
            public struct MicrosoftInfo
            {
                public const string MicrosoftSecret = "ifjbXcWnPSWtqpgtwERMHjy";
                public const string MicrosoftNativeRedirect = "msaldbcef1e2-07d6-43e0-95cb-5fcbef886d55://auth";
                public const string MicrosoftAppId = "dbcef1e2-07d6-43e0-95cb-5fcbef886d55";
                public static readonly string[] MicrosoftScopes = { "https://graph.microsoft.com/user.read" };
            }
            public struct TwitterInfo
            {
                public const string TwitterSecret = "GfjNdtQ4lAFyjsnBQLQJnysnDeRqNlOliGP5rnyUEg9SOd20B9";
                public const string TwitterNativeRedirect = "msaldbcef1e2-07d6-43e0-95cb-5fcbef886d55://auth";
                public const string TwitterAppId = "3JYO3M9COTbnizsFYWaq67dJZ";
                //public static readonly string[] TwitterScopes = { "https://graph.Twitter.com/user.read" };
            }
            public struct FacebookInfo
            {
                public const string FacebookSecret = "5f1cf98e4012f64347ebf21824efc65a";
                public const string FacebookNativeRedirect = "msaldbcef1e2-07d6-43e0-95cb-5fcbef886d55://auth";
                public const string FacebookAppId = "1473035519454936";
                //public static readonly string[] FacebookScopes = { "https://graph.Facebook.com/user.read" };
            }

        }
        public struct Providers
        {
            public const string Google = "google";
            public const string Facebook = "facebook";
            public const string Twitter = "twitter";
            public const string Microsoft = "microsoft";
            public const string Local = "local";

        }
        public struct Storage
        {
            public const string Token = "Token";
        }
        public struct Pages
        {
            public const string BusinessList = "All Businesses";
            public const string Favorites = "Favorites";
        }
       public struct FavoritesItems
        {
            public const string NAIC = "Business Type:";
            public const string LocationDistance = "Within (miles):";
            public const string Open = "Opening:";
            public const string Close = "Closing:";
            public const string ABCStatus = "Serves Alcohol:";
            public const string OwnershipType = "Ownership Type:";
        }

        public struct Text
        {
            public const string Search = "Search";
        }
    }
}
