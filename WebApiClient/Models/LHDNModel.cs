using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WebApiClient.Models
{

    #region [ Global Declaration ]

    [StructLayout(LayoutKind.Sequential)]
    public struct DocumentTypes
    {
        [JsonProperty(PropertyName = "id")]
        [MarshalAs(UnmanagedType.I4)]
        public int Id;

        [JsonProperty(PropertyName = "invoiceTypeCode")]
        [MarshalAs(UnmanagedType.I4)]
        public int Invoice_Type_Code;

        [JsonProperty(PropertyName = "description")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Description;

        [JsonProperty(PropertyName = "activeFrom")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_From;

        [JsonProperty(PropertyName = "activeTo")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_To;

        [JsonProperty(PropertyName = "documentTypeVersions")]
        public DocTypeVersionSummary[] Document_Type_Versions;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DocTypeVersionSummary
    {
        [JsonProperty(PropertyName = "id")]
        [MarshalAs(UnmanagedType.I4)]
        public int Id;

        [JsonProperty(PropertyName = "name")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Name;

        [JsonProperty(PropertyName = "description")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Description;

        [JsonProperty(PropertyName = "activeFrom")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_From;

        [JsonProperty(PropertyName = "activeTo")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_To;

        [JsonProperty(PropertyName = "versionNumber")]
        //[MarshalAs(UnmanagedType.I4)]
        public double Version_No;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WorkFlowParam
    {
        [JsonProperty(PropertyName = "id")]
        [MarshalAs(UnmanagedType.I4)]
        public int Id;

        [JsonProperty(PropertyName = "parameter")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Parameter;

        [JsonProperty(PropertyName = "value")]
        [MarshalAs(UnmanagedType.I4)]
        public int Value;

        [JsonProperty(PropertyName = "activeFrom")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_From;

        [JsonProperty(PropertyName = "activeTo")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_To;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DeliveryAttempt
    {

        [JsonProperty(PropertyName = "attemptDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Attempt_Datetime;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "statusDetails")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status_Details;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Notification
    {
        [JsonProperty(PropertyName = "notificationId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Notification_Id;

        [JsonProperty(PropertyName = "receivedDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Received_Datetime;

        [JsonProperty(PropertyName = "deliveredDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Delivered_Datetime;

        [JsonProperty(PropertyName = "typeId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Id;

        [JsonProperty(PropertyName = "typeName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Name;

        [JsonProperty(PropertyName = "finalMessage")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Final_Message;

        [JsonProperty(PropertyName = "channel")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Channel;

        [JsonProperty(PropertyName = "address")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Address;

        [JsonProperty(PropertyName = "language")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Language;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "deliveryAttempts")]
        public DeliveryAttempt[] Delivery_Attempts;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Metadata
    {
        [JsonProperty(PropertyName = "totalPages")]
        [MarshalAs(UnmanagedType.I4)]
        public int Total_Pages;

        [JsonProperty(PropertyName = "totalCount")]
        [MarshalAs(UnmanagedType.I4)]
        public int Total_Count;

    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct Document
    {
        [JsonProperty(PropertyName = "format")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Format;

        [JsonProperty(PropertyName = "document")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Doc;

        [JsonProperty(PropertyName = "documentHash")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Doc_Hash;

        [JsonProperty(PropertyName = "codeNumber")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Code_No;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AcceptedDocuments
    {
        [JsonProperty(PropertyName = "uuid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Uuid;

        [JsonProperty(PropertyName = "invoiceCodeNumber")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Invoice_Code_No;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RejectedDocuments
    {
        [JsonProperty(PropertyName = "invoiceCodeNumber")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Invoice_Code_No;

        [JsonProperty(PropertyName = "error")]
        public Error_Resp error;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Doc_Summary
    {
        [JsonProperty(PropertyName = "uuid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Uuid;

        [JsonProperty(PropertyName = "submissionUID")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Submission_Uid;

        [JsonProperty(PropertyName = "longId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Long_Id;

        [JsonProperty(PropertyName = "internalId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Internal_Id;

        [JsonProperty(PropertyName = "typeName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Name;

        [JsonProperty(PropertyName = "typeVersionName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Version_Name;

        [JsonProperty(PropertyName = "issuerTin")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Issuer_Tin;

        [JsonProperty(PropertyName = "issuerName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Issuer_Name;

        [JsonProperty(PropertyName = "receiverId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Id;

        [JsonProperty(PropertyName = "receiverName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Name;

        [JsonProperty(PropertyName = "dateTimeIssued")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Issued;

        [JsonProperty(PropertyName = "dateTimeReceived")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Received;

        [JsonProperty(PropertyName = "dateTimeValidated")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Validated;

        [JsonProperty(PropertyName = "totalSales")]
        public double Total_Sales;

        [JsonProperty(PropertyName = "totalDiscount")]
        public double Total_Discount;

        [JsonProperty(PropertyName = "netAmount")]
        public double Net_Amt;

        [JsonProperty(PropertyName = "total")]
        public double Total;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "cancelDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Cancel_Datetime;

        [JsonProperty(PropertyName = "rejectRequestDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Reject_Req_Datetime;

        [JsonProperty(PropertyName = "documentStatusReason")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Doc_Status_Reason;

        [JsonProperty(PropertyName = "createdByUserId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string CreatedBy_UserId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct DocumentDetails
    {
        [JsonProperty(PropertyName = "uuid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Uuid;

        [JsonProperty(PropertyName = "submissionUid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Submission_Uid;

        [JsonProperty(PropertyName = "longId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Long_Id;

        [JsonProperty(PropertyName = "internalId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Internal_Id;

        [JsonProperty(PropertyName = "typeName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Name;

        [JsonProperty(PropertyName = "typeVersionName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Version_Name;

        [JsonProperty(PropertyName = "issuerTin")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Issuer_Tin;

        [JsonProperty(PropertyName = "issuerName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Issuer_Name;

        [JsonProperty(PropertyName = "receiverId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Id;

        [JsonProperty(PropertyName = "receiverName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Name;

        [JsonProperty(PropertyName = "dateTimeIssued")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Issued;

        [JsonProperty(PropertyName = "dateTimeReceived")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Received;

        [JsonProperty(PropertyName = "dateTimeValidated")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Validated;

        [JsonProperty(PropertyName = "totalSales")]
        public double Total_Sales;

        [JsonProperty(PropertyName = "totalDiscount")]
        public double Total_Discount;

        [JsonProperty(PropertyName = "netAmount")]
        public double Net_Amt;

        [JsonProperty(PropertyName = "total")]
        public double Total;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "cancelDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Cancel_Datetime;

        [JsonProperty(PropertyName = "rejectRequestDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Reject_Req_Datetime;

        [JsonProperty(PropertyName = "documentStatusReason")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Doc_Status_Reason;

        [JsonProperty(PropertyName = "createdByUserId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string CreatedBy_UserId;

        [JsonProperty(PropertyName = "validationResults")]
        public Doc_Validation_Results Validation_Results;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SearchDocument
    {
        [JsonProperty(PropertyName = "uuid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Uuid;

        [JsonProperty(PropertyName = "submissionUID")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Submission_Uid;

        [JsonProperty(PropertyName = "longId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Long_Id;

        [JsonProperty(PropertyName = "internalId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Internal_Id;

        [JsonProperty(PropertyName = "typeName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Name;

        [JsonProperty(PropertyName = "typeVersionName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Version_Name;

        [JsonProperty(PropertyName = "issuerTin")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Issuer_Tin;

        [JsonProperty(PropertyName = "issuerName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Issuer_Name;

        [JsonProperty(PropertyName = "receiverId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Id;

        [JsonProperty(PropertyName = "receiverIdType")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Id_Type;

        [JsonProperty(PropertyName = "receiverName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Name;

        [JsonProperty(PropertyName = "dateTimeIssued")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Issued;

        [JsonProperty(PropertyName = "dateTimeReceived")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Received;

        [JsonProperty(PropertyName = "dateTimeValidated")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Validated;

        [JsonProperty(PropertyName = "totalSales")]
        public double Total_Sales;

        [JsonProperty(PropertyName = "totalDiscount")]
        public double Total_Discount;

        [JsonProperty(PropertyName = "netAmount")]
        public double Net_Amt;

        [JsonProperty(PropertyName = "total")]
        public double Total;

        [JsonProperty(PropertyName = "totalOriginalSales")]
        public double Total_Ori_Sales;

        [JsonProperty(PropertyName = "totalOriginalDiscount")]
        public double Total_Ori_Disc;

        [JsonProperty(PropertyName = "netOriginalAmount")]
        public double Net_Ori_Amt;

        [JsonProperty(PropertyName = "totalOriginal")]
        public double Total_Ori;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "cancelDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Cancel_Datetime;

        [JsonProperty(PropertyName = "rejectRequestDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Reject_Req_Datetime;

        [JsonProperty(PropertyName = "documentStatusReason")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Doc_Status_Reason;

        [JsonProperty(PropertyName = "createdByUserId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string CreatedBy_UserId;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Validation_Step_Result
    {
        [JsonProperty(PropertyName = "name")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Name;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "error")]
        public Error_Resp Error;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Error_Resp
    {
        [JsonProperty(PropertyName = "code")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Code;

        [JsonProperty(PropertyName = "message")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Message;

        [JsonProperty(PropertyName = "propertyPath")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Property_Path;

        [JsonProperty(PropertyName = "details")]
        public Error_Resp[] Details;

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Doc_Validation_Results
    {
        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "validationSteps")]
        public Validation_Step_Result[] Validation_Steps;
    }

    #endregion

    #region [ Login Intermediary System ]

    #region [ Request ]

    public struct LoginIntermediarySys_REQ
    {
        [JsonProperty(PropertyName = "client_id")]
        public string Client_Id;

        [JsonProperty(PropertyName = "client_secret")]
        public string Client_Secret;

        [JsonProperty(PropertyName = "grant_type")]
        public string Grant_Type;

        [JsonProperty(PropertyName = "scope")]
        public string Scope;
               
    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct LoginIntermediarySys_RESP
    {
        [JsonProperty(PropertyName = "access_token")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Access_Token;

        [JsonProperty(PropertyName = "token_type")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Token_Type;

        [JsonProperty(PropertyName = "expires_in")]
        [MarshalAs(UnmanagedType.I4)]
        public int Expires_In;

        [JsonProperty(PropertyName = "scope")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Scope;

    }

    #endregion

    #endregion

    #region [ Get All Document Types ]

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct GetAllDocTypes_RESP
    {
        [JsonProperty(PropertyName = "result")]
        public DocumentTypes[] result;

    }

    #endregion

    #endregion

    #region [ Get Document Type ]

    #region [ Request ]
    public struct GetDocType_REQ
    {
        //URL Parameter
        [JsonProperty(PropertyName = "id")]
        [MarshalAs(UnmanagedType.I4)]
        public int Id;

    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct GetDocType_RESP
    {
        [JsonProperty(PropertyName = "id")]
        [MarshalAs(UnmanagedType.I4)]
        public int Id;

        [JsonProperty(PropertyName = "invoiceTypeCode")]
        [MarshalAs(UnmanagedType.I4)]
        public int Invoice_Type_Code;

        [JsonProperty(PropertyName = "description")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Description;

        [JsonProperty(PropertyName = "activeFrom")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_From;

        [JsonProperty(PropertyName = "activeTo")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_To;

        [JsonProperty(PropertyName = "documentTypeVersions")]
        public DocTypeVersionSummary[] Document_Type_Versions;

        [JsonProperty(PropertyName = "workflowParameters")]
        public WorkFlowParam[] Work_Flow_Parameters;

    }

    #endregion

    #endregion

    #region [ Get Document Type Version ]

    #region [ Request ]
    public struct GetDocTypeVersion_REQ
    {
        //URL Parameter
        [JsonProperty(PropertyName = "id")]
        [MarshalAs(UnmanagedType.I4)]
        public int Id;

        //URL Parameter
        [JsonProperty(PropertyName = "vid")]
        [MarshalAs(UnmanagedType.I4)]
        public int VId;

    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct GetDocTypeVersion_RESP
    {
        [JsonProperty(PropertyName = "invoiceTypeCode")]
        [MarshalAs(UnmanagedType.I4)]
        public int Invoice_Type_Code;

        [JsonProperty(PropertyName = "name")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Name;

        [JsonProperty(PropertyName = "description")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Description;

        [JsonProperty(PropertyName = "versionNumber")]
        public double Version_No;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "activeFrom")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_From;

        [JsonProperty(PropertyName = "activeTo")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Active_To;

        [JsonProperty(PropertyName = "jsonSchema")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Json_Schema;

        [JsonProperty(PropertyName = "xmlSchema")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Xml_Schema;

    }

    #endregion

    #endregion

    #region [ Get Notifications ]

    #region [ Request ]
    public struct GetNotifications_REQ
    {
        //URL Parameter
        [JsonProperty(PropertyName = "dateFrom")]
        public string Date_From;

        //URL Parameter
        [JsonProperty(PropertyName = "dateTo")]
        public string Date_To;

        //URL Parameter
        [JsonProperty(PropertyName = "type")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type;

        //URL Parameter
        [JsonProperty(PropertyName = "language")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Language;

        //URL Parameter
        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        //URL Parameter
        [JsonProperty(PropertyName = "channel")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Channel;

        //URL Parameter
        [JsonProperty(PropertyName = "pageNo")]
        [MarshalAs(UnmanagedType.I4)]
        public int Page_No;

        //URL Parameter
        [JsonProperty(PropertyName = "pageSize")]
        [MarshalAs(UnmanagedType.I4)]
        public int Page_Size;

    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct GetNotifications_RESP
    {
        [JsonProperty(PropertyName = "result")]
        public Notification[] Result;

        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata;

    }

    #endregion

    #endregion

    #region [ Validate Taxpayer's TIN ]

    #region [ Request ]

    public struct ValidateTaxpayerTIN_REQ
    {
        [JsonProperty(PropertyName = "tin")]
        public int TIN;

        //URL Parameter
        [JsonProperty(PropertyName = "idType")]
        public string ID_Type;

        //URL Parameter
        [JsonProperty(PropertyName = "idValue")]
        public string ID_Value;

    }

    #endregion

    #endregion

    #region [ Submit Documents ]

    #region [ Request ]

    public struct SubmitDocs_REQ
    {

        [JsonIgnore]
        public string Content_Type;

        [JsonProperty(PropertyName = "Content_Type")]
        public string ContentTypeHeader => Content_Type;

        [JsonProperty(PropertyName = "documents")]
        public Document[] Documents;

    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct SubmitDocs_RESP
    {
        [JsonProperty(PropertyName = "submissionUID")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Submission_Uid;

        [JsonProperty(PropertyName = "acceptedDocuments")]
        public AcceptedDocuments[] Accepted_Docs;

        [JsonProperty(PropertyName = "rejectedDocuments")]
        public RejectedDocuments[] Rejected_Docs;

    }

    #endregion

    #endregion

    #region [ Cancel Documents ]

    #region [ Request ]

    public struct CancelDocs_REQ
    {
        //URL Parameter
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid;

        //Body Parameter
        [JsonProperty(PropertyName = "status")]
        public string Status;

        //Body Parameter
        [JsonProperty(PropertyName = "reason")]
        public string Reason;
    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct CancelDocs_RESP
    {
        [JsonProperty(PropertyName = "uuid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Uuid;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "error")]
        public Error_Resp Error;

    }

    #endregion

    #endregion

    #region [ Reject Documents ]

    #region [ Request ]

    public struct RejectDocs_REQ
    {
        //URL Parameter
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid;

        //Body Parameter
        [JsonProperty(PropertyName = "status")]
        public string Status;

        //Body Parameter
        [JsonProperty(PropertyName = "reason")]
        public string Reason;
    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct RejectDocs_RESP
    {
        [JsonProperty(PropertyName = "uuid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Uuid;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "error")]
        public Error_Resp Error;

    }

    #endregion

    #endregion

    #region [ Get Recent Documents ]

    #region [ Request ]

    public struct GetRecentDocs_REQ
    {

        //URL Parameter

        [JsonProperty(PropertyName = "pageNo")]
        public int Page_No;

        [JsonProperty(PropertyName = "pageSize")]
        public int Page_Size;

        [JsonProperty(PropertyName = "submissionDateFrom")]
        public string Submission_DateFrom;

        [JsonProperty(PropertyName = "submissionDateTo")]
        public string Submission_DateTo;

        [JsonProperty(PropertyName = "issueDateFrom")]
        public string Issue_DateFrom;

        [JsonProperty(PropertyName = "issueDateTo")]
        public string Issue_DateTo;

        [JsonProperty(PropertyName = "direction")]
        public string Direction;

        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "documentType")]
        public string Document_Type;

        [JsonProperty(PropertyName = "receiverId")]
        public string Receiver_Id;

        [JsonProperty(PropertyName = "receiverIdType")]
        public string Receiver_Id_Type;

        [JsonProperty(PropertyName = "issuerIdType")]
        public string Issuer_Id_Type;

        [JsonProperty(PropertyName = "receiverTin")]
        public string Receiver_Tin;

        [JsonProperty(PropertyName = "issuerTin")]
        public string Issuer_Tin;

        [JsonProperty(PropertyName = "issuerId")]
        public string Issuer_Id;
    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct GetRecentDocs_RESP
    {
        [JsonProperty(PropertyName = "result")]
        public Doc_Summary[] Result;

    }

    #endregion

    #endregion

    #region [ Get Submission ]

    #region [ Request ]

    public struct GetSubmission_REQ
    {
        //URL Parameter
        [JsonProperty(PropertyName = "submissionUid")]
        public string Submission_Uid;
    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct GetSubmission_RESP
    {
        [JsonProperty(PropertyName = "submissionUid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Submission_Uid;

        [JsonProperty(PropertyName = "documentCount")]
        [MarshalAs(UnmanagedType.I4)]
        public string Document_Cnt;

        [JsonProperty(PropertyName = "dateTimeReceived")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Received;

        [JsonProperty(PropertyName = "overallStatus")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Overall_Status;

        [JsonProperty(PropertyName = "documentSummary")]
        public Doc_Summary[] Document_Summary;

    }

    #endregion

    #endregion

    #region [ Get Document ]

    #region [ Request ]

    public struct GetDocument_REQ
    {
        //URL Parameter
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid;
    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct GetDocument_RESP
    {
        [JsonProperty(PropertyName = "uuid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Uuid;

        [JsonProperty(PropertyName = "submissionUid")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Submission_Uid;

        [JsonProperty(PropertyName = "longId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Long_Id;

        [JsonProperty(PropertyName = "internalId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Internal_Id;

        [JsonProperty(PropertyName = "typeName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Name;

        [JsonProperty(PropertyName = "typeVersionName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Type_Version_Name;

        [JsonProperty(PropertyName = "issuerTin")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Issuer_Tin;

        [JsonProperty(PropertyName = "issuerName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Issuer_Name;

        [JsonProperty(PropertyName = "receiverId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Id;

        [JsonProperty(PropertyName = "receiverName")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Receiver_Name;

        [JsonProperty(PropertyName = "dateTimeIssued")]
        [MarshalAs(UnmanagedType.BStr)] 
        public string Datetime_Issued;

        [JsonProperty(PropertyName = "dateTimeReceived")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Received;

        [JsonProperty(PropertyName = "dateTimeValidated")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Datetime_Validated;

        [JsonProperty(PropertyName = "totalSales")]
        public double Total_Sales;

        [JsonProperty(PropertyName = "totalDiscount")]
        public double Total_Discount;

        [JsonProperty(PropertyName = "netAmount")]
        public double Net_Amt;

        [JsonProperty(PropertyName = "total")]
        public double Total;

        [JsonProperty(PropertyName = "status")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Status;

        [JsonProperty(PropertyName = "cancelDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Cancel_Datetime;

        [JsonProperty(PropertyName = "rejectRequestDateTime")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Reject_Req_Datetime;

        [JsonProperty(PropertyName = "documentStatusReason")]
        [MarshalAs(UnmanagedType.BStr)]
        public string Doc_Status_Reason;

        [JsonProperty(PropertyName = "createdByUserId")]
        [MarshalAs(UnmanagedType.BStr)]
        public string CreatedBy_UserId;

        [JsonProperty(PropertyName = "document")]
        [MarshalAs(UnmanagedType.Struct)]
        public object Doc;

    }

    #endregion

    #endregion

    #region [ Get Document Details ]

    #region [ Request ]

    public struct GetDocumentDtl_REQ
    {
        //URL Parameter
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid;
    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct GetDocumentDtl_RESP
    {
        [JsonProperty(PropertyName = "DocumentDetails")]
        public DocumentDetails[] DocumentDetails;

    }

    #endregion

    #endregion

    #region [ Search Document ]

    #region [ Request ]

    public struct SearchDoc_REQ
    {

        //URL Parameter

        [JsonProperty(PropertyName = "uuid")]
        public string Uuid;

        [JsonProperty(PropertyName = "submissionDateFrom")]
        public string Submission_DateFrom;

        [JsonProperty(PropertyName = "submissionDateTo")]
        public string Submission_DateTo;

        [JsonProperty(PropertyName = "continuationToken")]
        public string Continuation_Token;

        [JsonProperty(PropertyName = "pageSize")]
        public int Page_Size;

        [JsonProperty(PropertyName = "issueDateFrom")]
        public string Issue_DateFrom;

        [JsonProperty(PropertyName = "issueDateTo")]
        public string Issue_DateTo;

        [JsonProperty(PropertyName = "direction")]
        public string Direction;

        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "documentType")]
        public string Document_Type;

        [JsonProperty(PropertyName = "receiverId")]
        public string Receiver_Id;

        [JsonProperty(PropertyName = "receiverIdType")]
        public string Receiver_Id_Type;

        [JsonProperty(PropertyName = "issuerTin")]
        public string Issuer_Tin;

    }

    #endregion

    #region [ Response ]

    [StructLayout(LayoutKind.Sequential)]
    public struct SearchDoc_RESP
    {
        [JsonProperty(PropertyName = "result")]
        public SearchDocument[] Result;
    }

    #endregion

    #endregion

}
