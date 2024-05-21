using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using WebApiClient.Models;
using WebApiClient.Services;

namespace WebApiClient
{
    public partial class Form1 : Form
    {
        public static string accessToken = string.Empty;

        public Form1()
        {
            InitializeComponent();

            var items = new[]
            {
                new ComboBoxItem(1, "Login as Intermediary System"),
                new ComboBoxItem(2, "Get All Document Types"),
                new ComboBoxItem(3, "Get Document Type"),
                new ComboBoxItem(4, "Get Document Type Version"),
                new ComboBoxItem(5, "Get Notifications"),
                new ComboBoxItem(6, "Validate Taxpayer's TIN"),
                new ComboBoxItem(7, "Submit Documents"),
                new ComboBoxItem(8, "Cancel Document"),
                new ComboBoxItem(9, "Reject Document"),
                new ComboBoxItem(10, "Get Recent Documents"),
                new ComboBoxItem(11, "Get Submission"),
                new ComboBoxItem(12, "Get Document"),
                new ComboBoxItem(13, "Get Document Details"),
                new ComboBoxItem(14, "Search Documents")
            };

            // Bind the ComboBox to the list of items
            cmbAPI.DataSource = items;
            cmbAPI.DisplayMember = "Name";
            cmbAPI.ValueMember = "Id";
        }

        private async void cmdSend_Click(object sender, EventArgs e)
        {

            string jsonString = string.Empty;
            string responseFilePath = string.Empty;
            ComboBoxItem selectedItem = cmbAPI.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {

                if (string.IsNullOrEmpty(accessToken) && selectedItem.Id != 1 ) 
                {
                    string tokenFilePath = @"D:\Test\Response\LoginIntermediarySys_response.json";
                    accessToken = ReadAccessTokenFromFile(tokenFilePath);
                }

                switch (selectedItem.Id)
                {
                    case 1:
                        LoginIntermediarySys_RESP result = await Auth0LhdnService.LoginIntermediarySys(AuthAPIConstant.Auth0LhdnLoginIntermediarySysUrl, 
                            "5a38f454-9747-4598-843b-b840c0b10047", "9a9c0b44-e04e-4d0e-89c2-b8430e976da4", "client_credentials", "InvoicingAPI", "C25845632020");
                        responseFilePath = @"D:\Test\Response\LoginIntermediarySys_response.json";
                        jsonString = JsonConvert.SerializeObject(result);
                        File.WriteAllText(responseFilePath, jsonString);
                        accessToken = result.Access_Token;

                        break;

                    case 2:
                        GetAllDocTypes_RESP result1 = await Auth0LhdnService.GetAllDocTypes(AuthAPIConstant.Auth0LhdnGetAllDocTypesUrl, accessToken);
                        responseFilePath = @"D:\Test\Response\GetAllDocTypes_response.json";
                        jsonString = JsonConvert.SerializeObject(result1);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 3:
                        GetDocType_RESP result2 = await Auth0LhdnService.GetDocType(AuthAPIConstant.Auth0LhdnGetDocTypeUrl, accessToken, "45");
                        responseFilePath = @"D:\Test\Response\GetDocType_response.json";
                        jsonString = JsonConvert.SerializeObject(result2);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 4:
                        GetDocTypeVersion_RESP result3 = await Auth0LhdnService.GetDocTypeVersion(AuthAPIConstant.Auth0LhdnGetDocTypeVersionUrl, accessToken, "45", "41235");
                        responseFilePath = @"D:\Test\Response\GetDocTypeVersion_response.json";
                        jsonString = JsonConvert.SerializeObject(result3);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 5:
                        GetNotifications_RESP result4 = await Auth0LhdnService.GetNotifications(AuthAPIConstant.Auth0LhdnGetNotificationUrl, accessToken);
                        responseFilePath = @"D:\Test\Response\GetNotifications_response.json";
                        jsonString = JsonConvert.SerializeObject(result4);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 6: //to check response
                        string statusCode = await Auth0LhdnService.ValidateTaxpayerTin(AuthAPIConstant.Auth0LhdnValidateTaxpayerUrl, accessToken, "C20775766060",
                                                                                                "BRN", "200901025000");
                        responseFilePath = @"D:\Test\Response\ValidateTaxpayerTin_response.json";
                        File.WriteAllText(responseFilePath, statusCode);

                        break;

                    case 7:
                        SubmitDocs_RESP result5 = await Auth0LhdnService.SubmitDocument(AuthAPIConstant.Auth0LhdnSubmitDocsUrl, accessToken, "");
                        responseFilePath = @"D:\Test\Response\SubmitDocument_response.json";
                        jsonString = JsonConvert.SerializeObject(result5);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 8:
                        CancelDocs_RESP result6 = await Auth0LhdnService.CancelDocument(AuthAPIConstant.Auth0LhdnCancelDocUrl, accessToken, "F9D425P6DS7D8IU", "cancelled", "Wrong buyer details");
                        responseFilePath = @"D:\Test\Response\CancelDocument_response.json";
                        jsonString = JsonConvert.SerializeObject(result6);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 9:
                        RejectDocs_RESP result7 = await Auth0LhdnService.RejectDocument(AuthAPIConstant.Auth0LhdnRejectDocUrl, accessToken, "F9D425P6DS7D8IU", "Rejected", "Wrong buyer details");
                        responseFilePath = @"D:\Test\Response\RejectDocument_response.json";
                        jsonString = JsonConvert.SerializeObject(result7);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 10:
                        GetRecentDocs_RESP result8 = await Auth0LhdnService.GetRecentDocs(AuthAPIConstant.Auth0LhdnGetRecentDocsUrl, accessToken);
                        responseFilePath = @"D:\Test\Response\GetRecentDocs_response.json";
                        jsonString = JsonConvert.SerializeObject(result8);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 11:
                        GetSubmission_RESP result9 = await Auth0LhdnService.GetSubmission(AuthAPIConstant.Auth0LhdnGetSubmissionUrl, accessToken, "HJSD135P2S7D8IU");
                        responseFilePath = @"D:\Test\Response\GetSubmission_response.json";
                        jsonString = JsonConvert.SerializeObject(result9);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 12:
                        GetDocument_RESP result10 = await Auth0LhdnService.GetDocument(AuthAPIConstant.Auth0LhdnGetDocumentUrl, accessToken, "F9D425P6DS7D8IU");
                        responseFilePath = @"D:\Test\Response\GetDocument_response.json";
                        jsonString = JsonConvert.SerializeObject(result10);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 13:
                        GetDocumentDtl_RESP result11 = await Auth0LhdnService.GetDocumentDetails(AuthAPIConstant.Auth0LhdnGetDocumentDetailsUrl, accessToken, "F9D425P6DS7D8IU");
                        responseFilePath = @"D:\Test\Response\GetDocumentDtl_response.json";
                        jsonString = JsonConvert.SerializeObject(result11);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    case 14:
                        SearchDoc_RESP result12 = await Auth0LhdnService.SearchDocuments(AuthAPIConstant.Auth0LhdnSearchDocumentsUrl, accessToken);
                        responseFilePath = @"D:\Test\Response\SearchDocument_response.json";
                        jsonString = JsonConvert.SerializeObject(result12);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;

                    default:
                        MessageBox.Show("Invalid selection.");
                        break;
                }

                rtResponse.Text = jsonString;
            }
        }


        private static string ReadAccessTokenFromFile(string filePath)
        {
            try
            {
                var jsonContent = File.ReadAllText(filePath);
                var tokenResponse = JsonConvert.DeserializeObject<LoginIntermediarySys_RESP>(jsonContent);
                return tokenResponse.Access_Token;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading access token from file: {ex.Message}");
                throw;
            }
        }

    }
}
