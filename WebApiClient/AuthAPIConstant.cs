using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    class AuthAPIConstant
    {
        #region [ LHDN URL ]

        private static string _auth0LhdnLoginIntermediarySysUrl = null;
        private static string _auth0LhdnGetAllDocTypesUrl = null;
        private static string _auth0LhdnGetDocTypeUrl = null;
        private static string _auth0LhdnGetDocTypeVersionUrl = null;
        private static string _auth0LhdnGetNotificationUrl = null;
        private static string _auth0LhdnValidateTaxpayerUrl = null;
        private static string _auth0LhdnSubmitDocsUrl = null;
        private static string _auth0LhdnCancelDocUrl = null;
        private static string _auth0LhdnRejectDocUrl = null;
        private static string _auth0LhdnGetRecentDocsUrl = null;
        private static string _auth0LhdnGetSubmissionUrl = null;
        private static string _auth0LhdnGetDocumentUrl = null;
        private static string _auth0LhdnGetDocumentDetailsUrl = null;
        private static string _auth0LhdnSearchDocumentsUrl = null;

        #endregion

        #region [ LHDN API ]

        public static string Auth0LhdnLoginIntermediarySysUrl
        {
            set
            {
                _auth0LhdnLoginIntermediarySysUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnLoginIntermediarySysUrl)) return _auth0LhdnLoginIntermediarySysUrl;
                _auth0LhdnLoginIntermediarySysUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnLoginIntermediarySysUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/connect/token";
                return _auth0LhdnLoginIntermediarySysUrl;
            }
        }

        public static string Auth0LhdnGetAllDocTypesUrl
        {
            set
            {
                _auth0LhdnGetAllDocTypesUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnGetAllDocTypesUrl)) return _auth0LhdnGetAllDocTypesUrl;
                _auth0LhdnGetAllDocTypesUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnGetAllDocTypesUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documenttypes";
                return _auth0LhdnGetAllDocTypesUrl;
            }
        }

        public static string Auth0LhdnGetDocTypeUrl
        {
            set
            {
                _auth0LhdnGetDocTypeUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnGetDocTypeUrl)) return _auth0LhdnGetDocTypeUrl;
                _auth0LhdnGetDocTypeUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnGetDocTypeUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documenttypes/{0}";
                return _auth0LhdnGetDocTypeUrl;
            }
        }

        public static string Auth0LhdnGetDocTypeVersionUrl
        {
            set
            {
                _auth0LhdnGetDocTypeVersionUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnGetDocTypeVersionUrl)) return _auth0LhdnGetDocTypeVersionUrl;
                _auth0LhdnGetDocTypeVersionUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnGetDocTypeVersionUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documenttypes/{0}/versions/{1}";
                return _auth0LhdnGetDocTypeVersionUrl;
            }
        }

        public static string Auth0LhdnGetNotificationUrl
        {
            set
            {
                _auth0LhdnGetNotificationUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnGetNotificationUrl)) return _auth0LhdnGetNotificationUrl;
                _auth0LhdnGetNotificationUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnGetNotificationUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/notifications/taxpayer";
                return _auth0LhdnGetNotificationUrl;
            }
        }

        public static string Auth0LhdnValidateTaxpayerUrl
        {
            set
            {
                _auth0LhdnValidateTaxpayerUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnValidateTaxpayerUrl)) return _auth0LhdnValidateTaxpayerUrl;
                _auth0LhdnValidateTaxpayerUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnValidateTaxpayerUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/taxpayer/validate/{0}";
                return _auth0LhdnValidateTaxpayerUrl;
            }
        }

        public static string Auth0LhdnSubmitDocsUrl
        {
            set
            {
                _auth0LhdnSubmitDocsUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnSubmitDocsUrl)) return _auth0LhdnSubmitDocsUrl;
                _auth0LhdnSubmitDocsUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnSubmitDocsUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/taxpayer/validate/{0}";
                return _auth0LhdnSubmitDocsUrl;
            }
        }

        public static string Auth0LhdnCancelDocUrl
        {
            set
            {
                _auth0LhdnCancelDocUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnCancelDocUrl)) return _auth0LhdnCancelDocUrl;
                _auth0LhdnCancelDocUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnCancelDocUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documents/state/{0}/state";
                return _auth0LhdnCancelDocUrl;
            }
        }

        public static string Auth0LhdnRejectDocUrl
        {
            set
            {
                _auth0LhdnRejectDocUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnRejectDocUrl)) return _auth0LhdnRejectDocUrl;
                _auth0LhdnRejectDocUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnRejectDocUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documents/state/{0}/state";
                return _auth0LhdnRejectDocUrl;
            }
        }

        public static string Auth0LhdnGetRecentDocsUrl
        {
            set
            {
                _auth0LhdnGetRecentDocsUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnGetRecentDocsUrl)) return _auth0LhdnGetRecentDocsUrl;
                _auth0LhdnGetRecentDocsUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnGetRecentDocsUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documents/recent";
                return _auth0LhdnGetRecentDocsUrl;
            }
        }

        public static string Auth0LhdnGetSubmissionUrl
        {
            set
            {
                _auth0LhdnGetSubmissionUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnGetSubmissionUrl)) return _auth0LhdnGetSubmissionUrl;
                _auth0LhdnGetSubmissionUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnGetSubmissionUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documentsubmissions/{0}";
                return _auth0LhdnGetSubmissionUrl;
            }
        }

        public static string Auth0LhdnGetDocumentUrl
        {
            set
            {
                _auth0LhdnGetDocumentUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnGetDocumentUrl)) return _auth0LhdnGetDocumentUrl;
                _auth0LhdnGetDocumentUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnGetDocumentUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documents/{0}/raw";
                return _auth0LhdnGetDocumentUrl;
            }
        }

        public static string Auth0LhdnGetDocumentDetailsUrl
        {
            set
            {
                _auth0LhdnGetDocumentDetailsUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnGetDocumentDetailsUrl)) return _auth0LhdnGetDocumentDetailsUrl;
                _auth0LhdnGetDocumentDetailsUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnGetDocumentDetailsUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documents/{0}/details";
                return _auth0LhdnGetDocumentDetailsUrl;
            }
        }

        public static string Auth0LhdnSearchDocumentsUrl
        {
            set
            {
                _auth0LhdnSearchDocumentsUrl = value;
            }
            get
            {
                if (!string.IsNullOrEmpty(_auth0LhdnSearchDocumentsUrl)) return _auth0LhdnSearchDocumentsUrl;
                _auth0LhdnSearchDocumentsUrl = ConfigurationManager.AppSettings.Get("Auth0LhdnSearchDocumentsUrl") ?? @"https://preprod-api.myinvois.hasil.gov.my/api/v1.0/documents/search";
                return _auth0LhdnSearchDocumentsUrl;
            }
        }

        #endregion

    }
}
