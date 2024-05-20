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

namespace WebApiClient.Services
{
   
    public class Auth0LhdnService
    {
        public static HttpStatusCode Status;
        public enum enumMethod
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        #region [ Global ]

        internal static string PerformHTTPRequest(string url, string token, string jsonStr, enumMethod eMethod, string onbehalfof = "")
        {
            Status = 0;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback +=
        (sender, certificate, chain, sslPolicyErrors) => true;
            
            // HTTP Request Method
            HttpMethod oMethod = HttpMethod.Get;
            switch (eMethod)
            {
                case enumMethod.GET:
                    oMethod = HttpMethod.Get;
                    break;
                case enumMethod.POST:
                    oMethod = HttpMethod.Post;
                    break;
                case enumMethod.PUT:
                    oMethod = HttpMethod.Put;
                    break;
                case enumMethod.DELETE:
                    oMethod = HttpMethod.Delete;
                    break;
            }

            var reqMsg = new HttpRequestMessage(oMethod, url);
            if (token != string.Empty)
            {
                reqMsg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            if (!string.IsNullOrEmpty(onbehalfof))
            {
                reqMsg.Headers.Add("onbehalfof", onbehalfof);
                reqMsg.Content = new StringContent(jsonStr, Encoding.UTF8, "application/x-www-form-urlencoded");
            }
            else
            {
                reqMsg.Content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            }

            var client = new HttpClient();
            var resMsg = new HttpResponseMessage();

            try
            {
                resMsg = client.SendAsync(reqMsg).Result;
            }
            catch (HttpRequestException ex)
            {
                Status = HttpStatusCode.NotFound;
            }
            catch (Exception ex)
            {
                throw;
            }

            Status = resMsg.StatusCode;

            string result = resMsg.Content.ReadAsStringAsync().Result;

            return result;

        }

        #endregion

        #region [ Login Intermediary System ]

        internal static LoginIntermediarySys_RESP LoginIntermediarySys(string url, string ClientId, string clientSecret, string GrantType, string Scope, string OnBehalfOf)
        {
            LoginIntermediarySys_RESP resp;
            var loginReq = new LoginIntermediarySys_REQ
            {
                Client_Id = ClientId,
                Client_Secret = clientSecret,
                Grant_Type = GrantType,
                Scope = Scope
            };

            string jsonContent = JsonConvert.SerializeObject(loginReq);

            string result = Auth0LhdnService.PerformHTTPRequest(url, "", jsonContent, enumMethod.POST, OnBehalfOf);
            resp = JsonConvert.DeserializeObject<LoginIntermediarySys_RESP>(result);

            return resp;

        }

        #endregion

        #region [ Get All Document Types ]

        internal static GetAllDocTypes_RESP GetAllDocTypes(string url, string token)
        {

            GetAllDocTypes_RESP resp;

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<GetAllDocTypes_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Document Type ]

        internal static GetDocType_RESP GetDocType(string url, string token, string sId)
        {

            GetDocType_RESP resp;

            url = string.Format(url, sId);

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<GetDocType_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Document Type Version ]

        internal static GetDocTypeVersion_RESP GetDocTypeVersion(string url, string token, string sId, string sVId)
        {

            GetDocTypeVersion_RESP resp;

            url = string.Format(url, sId, sVId);

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<GetDocTypeVersion_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Notifications ]

        internal static GetNotifications_RESP GetNotifications(string url, string token, string dateFrom, string dateTo, string sType, 
                                                                string sLanguage, string sStatus, string sChannel, int iPageNo, int iPageSize)
        {

            GetNotifications_RESP resp;
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

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<GetNotifications_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Validate Taxpayer's TIN ]

        //TODO later

        #endregion

        //TODO recheck
        #region [ Submit Document ]

        internal static SubmitDocs_RESP SubmitDocument(string url, string token, string sContentType)
        {
            SubmitDocs_RESP resp;

            url = string.Format(url);

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.POST);
            resp = JsonConvert.DeserializeObject<SubmitDocs_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Cancel Document ]

        internal static CancelDocs_RESP CancelDocument(string url, string token, string sUuid, string sStatus, string sReason)
        {
            CancelDocs_RESP resp;

            url = string.Format(url, sUuid);
            var oReq = new CancelDocs_REQ
            {
                Status = sStatus,
                Reason = sReason
            };

            string jsonContent = JsonConvert.SerializeObject(oReq);

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, jsonContent, enumMethod.PUT);
            resp = JsonConvert.DeserializeObject<CancelDocs_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Reject Document ]

        internal static RejectDocs_RESP RejectDocument(string url, string token, string sUuid, string sStatus, string sReason)
        {
            RejectDocs_RESP resp;

            url = string.Format(url, sUuid);
            var oReq = new RejectDocs_REQ
            {
                Status = sStatus,
                Reason = sReason
            };

            string jsonContent = JsonConvert.SerializeObject(oReq);

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, jsonContent, enumMethod.PUT);
            resp = JsonConvert.DeserializeObject<RejectDocs_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Recent Documents ]

        internal static GetRecentDocs_RESP GetRecentDocs(string url, string token, int iPageNo, int iPageSize, string submissiondateFrom, string submissiondateTo,
                                                         string issueDateFrom, string issueDateTo, string sDirection, string sStatus, string sDocumentType, string receiverId, 
                                                         string receiverIdType, string issuerIdType, string sReceiverTin, string sIssuerTin, string sIssuerId)
        {

            GetRecentDocs_RESP resp;
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

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<GetRecentDocs_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Submission ]

        internal static GetSubmission_RESP GetSubmission(string url, string token, string sSubmissionUid)
        {

            GetSubmission_RESP resp;

            url = string.Format(url, sSubmissionUid);

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<GetSubmission_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Document ]

        internal static GetDocument_RESP GetDocument(string url, string token, string sUuid)
        {

            GetDocument_RESP resp;

            url = string.Format(url, sUuid);

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<GetDocument_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Get Document Details ]

        internal static GetDocumentDtl_RESP GetDocumentDetails(string url, string token, string sUuid)
        {

            GetDocumentDtl_RESP resp;

            url = string.Format(url, sUuid);

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<GetDocumentDtl_RESP>(result);

            return resp;
        }

        #endregion

        #region [ Search Documents ]

        internal static SearchDoc_RESP SearchDocuments(string url, string token, string uuid, string submissiondateFrom, string submissiondateTo, string continuationToken,
                                                       int iPageSize, string issueDateFrom, string issueDateTo, string sDirection, string sStatus, string sDocumentType, 
                                                       string receiverId, string receiverIdType, string sIssuerTin)
        {

            SearchDoc_RESP resp;
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

            string result = Auth0LhdnService.PerformHTTPRequest(url, token, "", enumMethod.GET);
            resp = JsonConvert.DeserializeObject<SearchDoc_RESP>(result);

            return resp;
        }

        #endregion

    }
}
