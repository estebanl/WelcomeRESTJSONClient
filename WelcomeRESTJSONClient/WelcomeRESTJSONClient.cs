using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WelcomeRESTJSONClient.Properties;

namespace WelcomeRESTJSONClient
{
    public partial class WelcomeRESTJSONClient : Form
    {
        private HttpClient client = new HttpClient();
        TextMessage message;
        public WelcomeRESTJSONClient()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs ex)
        {
            string jsonString = await client.GetStringAsync(new Uri("http://localhost:52930/WelcomeRESTJSONService.svc/welcome/"+textBox1.Text));
            DataContractJsonSerializer jsonSerializaer = new DataContractJsonSerializer(typeof(TextMessage));
            message = (TextMessage)jsonSerializaer.ReadObject(new MemoryStream(Encoding.Unicode.GetBytes(jsonString)));
            Console.WriteLine(message.Message);
            textBox1.Text = message.Message;
        }

        

    }
    [Serializable]
    public class TextMessage
    {
        public string Message;
    }
}
