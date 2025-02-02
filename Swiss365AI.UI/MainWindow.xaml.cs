using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;

namespace Swiss365AI
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BexioButton_Click(object sender, RoutedEventArgs e)
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5000/api/bexio/getContacts");
            var contacts = JArray.Parse(response);
            ResultsList.Items.Clear();
            foreach (var contact in contacts)
            {
                ResultsList.Items.Add(contact["name"].ToString());
            }
        }
    }
}