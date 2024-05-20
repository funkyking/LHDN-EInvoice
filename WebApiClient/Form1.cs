using Newtonsoft.Json;
using System.Text.Json;
using WebApiClient.Models;
using WebApiClient.Services;

namespace WebApiClient
{
    public partial class Form1 : Form
    {
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
            ComboBoxItem selectedItem = cmbAPI.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                switch (selectedItem.Id)
                {
                    case 1:
                        LoginIntermediarySys_RESP result = Auth0LhdnService.LoginIntermediarySys(AuthAPIConstant.Auth0LhdnLoginIntermediarySysUrl, 
                            "5a38f454-9747-4598-843b-b840c0b10047", "9a9c0b44-e04e-4d0e-89c2-b8430e976da4", "client_credentials", "InvoicingAPI", "C25845632020");
                        string responseFilePath = @"D:\Test\Response\LoginIntermediarySys_response.json";
                        jsonString = JsonConvert.SerializeObject(result);
                        File.WriteAllText(responseFilePath, jsonString);

                        break;
                    case 2:
                        
                    case 3:
                        
                        break;
                    default:
                        MessageBox.Show("Invalid selection.");
                        break;
                }

                rtResponse.Text = jsonString;
            }
        }
    }
}
