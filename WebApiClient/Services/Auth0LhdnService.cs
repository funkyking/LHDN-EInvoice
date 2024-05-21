using WebApiClient.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Formats.Asn1.AsnWriter;
using System.Security.Cryptography;

namespace WebApiClient.Services
{
   
    public class Auth0LhdnService
    {
        
        #region [ Global ]

        private static readonly HttpClient client;
        public static HttpStatusCode Status;
        public enum enumMethod
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        static Auth0LhdnService()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            // Initialize HttpClient
            client = new HttpClient();
        }

        internal static async Task<string> PerformHTTPRequestAsync(string url, string token, string jsonStr, enumMethod eMethod, string onbehalfof = "")
        {

            // HTTP Request Method
            HttpMethod oMethod = eMethod switch
            {
                enumMethod.POST => HttpMethod.Post,
                enumMethod.PUT => HttpMethod.Put,
                enumMethod.DELETE => HttpMethod.Delete,
                _ => HttpMethod.Get,
            };

            var reqMsg = new HttpRequestMessage(oMethod, url);
            if (token != string.Empty)
            {
                reqMsg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            reqMsg.Content = !string.IsNullOrEmpty(onbehalfof) 
            ? new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonStr)) 
            : new StringContent(jsonStr, Encoding.UTF8, "application/json");
                       
            try
            {
                HttpResponseMessage respMsg = await client.SendAsync(reqMsg);
                string result = await respMsg.Content.ReadAsStringAsync();

                return result;

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }

        }

        #endregion

        #region [ Login Intermediary System ]

        internal static async Task<LoginIntermediarySys_RESP> LoginIntermediarySys(string url, string ClientId, string clientSecret, string GrantType, string Scope, string OnBehalfOf)
        {
            var loginReq = new LoginIntermediarySys_REQ
            {
                Client_Id = ClientId,
                Client_Secret = clientSecret,
                Grant_Type = GrantType,
                Scope = Scope
            };

            string jsonContent = JsonConvert.SerializeObject(loginReq);

            string result = await PerformHTTPRequestAsync(url, "", jsonContent, enumMethod.POST, OnBehalfOf);
            var resp = JsonConvert.DeserializeObject<LoginIntermediarySys_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get All Document Types ]

        internal static async Task<GetAllDocTypes_RESP> GetAllDocTypes(string url, string token)
        {

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<GetAllDocTypes_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Document Type ]

        internal static async Task<GetDocType_RESP> GetDocType(string url, string token, string sId)
        {

            url = string.Format(url, sId);

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<GetDocType_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Document Type Version ]

        internal static async Task<GetDocTypeVersion_RESP> GetDocTypeVersion(string url, string token, string sId, string sVId)
        {

            url = string.Format(url, sId, sVId);

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<GetDocTypeVersion_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Notifications ]

        internal static async Task<GetNotifications_RESP> GetNotifications(string url, string token, string dateFrom = "", string dateTo = "", string sType = "",
                                                                string sLanguage = "", string sStatus = "", string sChannel = "", int iPageNo = 0, int iPageSize = 0)
        {

            var notiReq = new GetNotifications_REQ();
            if (dateFrom != string.Empty)
            {
                notiReq.Date_From = dateFrom;
            }
            if (dateTo != string.Empty)
            {
                notiReq.Date_To = dateTo;
            }
            if (sType != string.Empty)
            {
                notiReq.Type = sType;
            }
            if (sLanguage != string.Empty)
            {
                notiReq.Language = sLanguage;
            }
            if (sStatus != string.Empty)
            {
                notiReq.Status = sStatus;
            }
            if (sChannel != string.Empty)
            {
                notiReq.Channel = sChannel;
            }
            if (iPageNo > 0)
            {
                notiReq.Page_No = iPageNo;
            }
            if (iPageSize > 0)
            {
                notiReq.Page_Size = iPageSize;
            }

            string sData = string.Empty;
            foreach (var p in notiReq.GetType().GetProperties())
            {
                PropertyInfo oField = typeof(GetNotifications_REQ).GetProperty(p.Name);
                if (oField != null)
                {
                    var value = oField.GetValue(notiReq);
                    if (value != null)
                    {
                        sData += string.IsNullOrWhiteSpace(sData) ? "?" : "&";
                        sData += p.Name + "=" + HttpUtility.UrlEncode(oField.GetValue(notiReq)?.ToString());
                    }
                }
            }

            url = url + sData;

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<GetNotifications_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Validate Taxpayer's TIN ]

        internal static async Task<String> ValidateTaxpayerTin(string url, string token, string sTin, string sIdType, string sIdValue)
        {
            url = string.Format(url, sTin, sIdType, sIdValue);

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);

            return result;
        }

        #endregion

        //TODO recheck
        #region [ Submit Document ]

        internal static async Task<SubmitDocs_RESP> SubmitDocument(string url, string token, string sContentType)
        {
            url = string.Format(url);

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.POST);
            var resp = JsonConvert.DeserializeObject<SubmitDocs_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Cancel Document ]

        internal static async Task<CancelDocs_RESP> CancelDocument(string url, string token, string sUuid, string sStatus, string sReason)
        {
            url = string.Format(url, sUuid);
            var oReq = new CancelDocs_REQ
            {
                Status = sStatus,
                Reason = sReason
            };
            string jsonContent = JsonConvert.SerializeObject(oReq);

            string result = await PerformHTTPRequestAsync(url, token, jsonContent, enumMethod.PUT);
            var resp = JsonConvert.DeserializeObject<CancelDocs_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Reject Document ]

        internal static async Task<RejectDocs_RESP> RejectDocument(string url, string token, string sUuid, string sStatus, string sReason)
        {
            url = string.Format(url, sUuid);
            var oReq = new RejectDocs_REQ
            {
                Status = sStatus,
                Reason = sReason
            };

            string jsonContent = JsonConvert.SerializeObject(oReq);

            string result = await PerformHTTPRequestAsync(url, token, jsonContent, enumMethod.PUT);
            var resp = JsonConvert.DeserializeObject<RejectDocs_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Recent Documents ]

        internal static async Task<GetRecentDocs_RESP> GetRecentDocs(string url, string token, int iPageNo = 0, int iPageSize = 0, string submissiondateFrom = "", string submissiondateTo = "",
                                                         string issueDateFrom = "", string issueDateTo = "", string sDirection = "", string sStatus = "", string sDocumentType = "", string receiverId = "",
                                                         string receiverIdType = "", string issuerIdType = "", string sReceiverTin = "", string sIssuerTin = "", string sIssuerId = "")
        {

            var req = new GetRecentDocs_REQ();
            if (iPageNo > 0)
            {
                req.Page_No = iPageNo;
            }
            if (iPageSize > 0)
            {
                req.Page_Size = iPageSize;
            }
            if (submissiondateFrom != string.Empty)
            {
                req.Submission_DateFrom = submissiondateFrom;
            }
            if (submissiondateTo != string.Empty)
            {
                req.Submission_DateTo = submissiondateTo;
            }
            if (issueDateFrom != string.Empty)
            {
                req.Issue_DateFrom = issueDateFrom;
            }
            if (issueDateTo != string.Empty)
            {
                req.Issue_DateTo = issueDateTo;
            }
            if (sDirection != string.Empty)
            {
                req.Direction = sDirection;
            }
            if (sStatus != string.Empty)
            {
                req.Status = sStatus;
            }
            if (sDocumentType != string.Empty)
            {
                req.Document_Type = sDocumentType;
            }
            if (receiverId != string.Empty)
            {
                req.Receiver_Id = receiverId;
            }
            if (receiverIdType != string.Empty)
            {
                req.Receiver_Id_Type = receiverIdType;
            }
            if (issuerIdType != string.Empty)
            {
                req.Issuer_Id_Type = issuerIdType;
            }
            if (sReceiverTin != string.Empty)
            {
                req.Receiver_Tin = sReceiverTin;
            }
            if (sIssuerTin != string.Empty)
            {
                req.Issuer_Tin = sIssuerTin;
            }
            if (sIssuerId != string.Empty)
            {
                req.Issuer_Id = sIssuerId;
            }


            string sData = string.Empty;
            foreach (var p in req.GetType().GetProperties())
            {
                PropertyInfo oField = typeof(GetRecentDocs_REQ).GetProperty(p.Name);
                if (oField != null)
                {
                    var value = oField.GetValue(req);
                    if (value != null)
                    {
                        sData += string.IsNullOrWhiteSpace(sData) ? "?" : "&";
                        sData += p.Name + "=" + HttpUtility.UrlEncode(oField.GetValue(req)?.ToString());
                    }
                }
            }

            url = url + sData;

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<GetRecentDocs_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Submission ]

        internal static async Task<GetSubmission_RESP> GetSubmission(string url, string token, string sSubmissionUid)
        {

            url = string.Format(url, sSubmissionUid);

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<GetSubmission_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Document ]

        internal static async Task<GetDocument_RESP> GetDocument(string url, string token, string sUuid)
        {

            url = string.Format(url, sUuid);

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<GetDocument_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Document Details ]

        internal static async Task<GetDocumentDtl_RESP> GetDocumentDetails(string url, string token, string sUuid)
        {

            url = string.Format(url, sUuid);

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<GetDocumentDtl_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Search Documents ]

        internal static async Task<SearchDoc_RESP> SearchDocuments(string url, string token, string uuid = "", string submissiondateFrom = "", string submissiondateTo = "", string continuationToken = "",
                                                       int iPageSize = 0, string issueDateFrom = "", string issueDateTo = "", string sDirection = "", string sStatus = "", string sDocumentType = "",
                                                       string receiverId = "", string receiverIdType = "", string sIssuerTin = "")
        {

            var req = new SearchDoc_REQ();
            if (uuid != string.Empty)
            {
                req.Uuid = uuid;
            }
            if (submissiondateFrom != string.Empty)
            {
                req.Submission_DateFrom = submissiondateFrom;
            }
            if (submissiondateTo != string.Empty)
            {
                req.Submission_DateTo = submissiondateTo;
            }
            if (continuationToken != string.Empty)
            {
                req.Continuation_Token = continuationToken;
            }
            if (iPageSize > 0)
            {
                req.Page_Size = iPageSize;
            }
            if (issueDateFrom != string.Empty)
            {
                req.Issue_DateFrom = issueDateFrom;
            }
            if (issueDateTo != string.Empty)
            {
                req.Issue_DateTo = issueDateTo;
            }
            if (sDirection != string.Empty)
            {
                req.Direction = sDirection;
            }
            if (sStatus != string.Empty)
            {
                req.Status = sStatus;
            }
            if (sDocumentType != string.Empty)
            {
                req.Document_Type = sDocumentType;
            }
            if (receiverId != string.Empty)
            {
                req.Receiver_Id = receiverId;
            }
            if (receiverIdType != string.Empty)
            {
                req.Receiver_Id_Type = receiverIdType;
            }
            if (sIssuerTin != string.Empty)
            {
                req.Issuer_Tin = sIssuerTin;
            }

            string sData = string.Empty;
            foreach (var p in req.GetType().GetProperties())
            {
                PropertyInfo oField = typeof(SearchDoc_REQ).GetProperty(p.Name);
                if (oField != null)
                {
                    var value = oField.GetValue(req);
                    if (value != null)
                    {
                        sData += string.IsNullOrWhiteSpace(sData) ? "?" : "&";
                        sData += p.Name + "=" + HttpUtility.UrlEncode(oField.GetValue(req)?.ToString());
                    }
                }
            }

            url = url + sData;

            string result = await PerformHTTPRequestAsync(url, token, "", enumMethod.GET);
            var resp = JsonConvert.DeserializeObject<SearchDoc_RESP>(result);

            return resp;
        }

        #endregion

    }
}
