using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.CognitiveServices.Speech;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Media;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.IO;
using System.Web.Services.Description;
using RestSharp;
using RestSharp.Serializers;
using System.Xml.Linq;
using System.Xml;
using System.Data.SqlClient;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System.Net.PeerToPeer;


namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        private static readonly string key = "1915c0e5c5e241399644214d21effbc6";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com";
        private string connectionString = "Server=tcp:team9-server.database.windows.net,1433;Initial Catalog=team9;Persist Security Info=False;User ID=sqladmin;Password=Team9Sql;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // location, also known as region.
        // required if you're using a multi-service or regional (not global) resource. It can be found in the Azure portal on the Keys and Endpoint page.
        private static readonly string location = "eastus";

        private async void Speech(string text, string language)
        {

            // The language of the voice that speaks.
            string voice;

            switch (language)
            {
                case "de":
                    voice = "de-DE-RalfNeural";
                    break;
                case "en":
                    voice = "en-US-JennyNeural";
                    break;
                case "tr":
                    voice = "tr-TR-AhmetNeural";
                    break;
                case "sq":
                    voice = "sq-AL-AnilaNeural";
                    break;
                case "ar":
                    voice = "ar-DZ-AminaNeural";
                    break;
                case "el":
                    voice = "el-GR-AthinaNeural";
                    break;
                case "id":
                    voice = "id-ID-ArdiNeural";
                    break;
                case "it":
                    voice = "it-IT-BenignoNeural";
                    break;
                case "ko":
                    voice = "ko-KR-BongJinNeural";
                    break;
                case "mk":
                    voice = "mk-MK-AleksandarNeural";
                    break;
                case "nb":
                    voice = "nb-NO-FinnNeural";
                    break;
                case "pl":
                    voice = "pl-PL-AgnieszkaNeural";
                    break;
                case "pt":
                    voice = "pt-BR-AntonioNeural";
                    break;
                case "es":
                    voice = "es-ES-AbrilNeural";
                    break;
                case "th":
                    voice = "th-TH-NiwatNeural";
                    break;
                default:
                    voice = "en-US-JennyNeural";
                    break;
            }


            // to get the authentification token
            string route = "https://eastus.api.cognitive.microsoft.com/sts/v1.0/issuetoken";
            string key = "cafbaf25ce5a44ba8cd8ecd6c2ced04e";
            string bearer = "Bearer ";
            string bearerToken;

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(route);
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                bearerToken = await response.Content.ReadAsStringAsync();
                bearer = bearer + bearerToken;
                Debug.WriteLine(bearerToken);
            }


            using (var client = new HttpClient())
            {
                // Build the request.

                client.DefaultRequestHeaders.Add("Authorization", bearer);
                client.DefaultRequestHeaders.Add("X-Microsoft-OutputFormat", "riff-24khz-16bit-mono-pcm");

                var productValue = new ProductInfoHeaderValue("Translator", "1.0");
                var commentValue = new ProductInfoHeaderValue("(+https://webapp-dotnet-service.azurewebsites.net)");
                client.DefaultRequestHeaders.UserAgent.Add(productValue);
                client.DefaultRequestHeaders.UserAgent.Add(commentValue);

                var payload = "<speak version='1.0' xml:lang='en-US'>" +
                                "<voice xml:lang='en-US' xml:gender='Female' name='" + voice + "'>" +
                                    TextBox2.Text +
                                "</voice>" +
                              "</speak>";
                var content = new StringContent(payload, Encoding.UTF8, "application/ssml+xml");

                // Send the request and get response.
                HttpResponseMessage response = await client.PostAsync("https://eastus.tts.speech.microsoft.com/cognitiveservices/v1", content);

                if (response.IsSuccessStatusCode)
                {
                    // Get the audio data from the response
                    var audioData = await response.Content.ReadAsByteArrayAsync();
                    Debug.WriteLine("Succeded");

                    // Assemble path for the audio file to save
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string fileName = Path.Combine(path, "translated.wav");

                    Debug.WriteLine(path);

                    // Save the audio file
                    System.IO.File.WriteAllBytes(fileName, audioData);

                    Response.Redirect("PlayTranslation.aspx");

                }
                else
                {
                    Debug.WriteLine("Not succeeded");
                }
            }



        }


        private async void Translate()
        {
            // Input and output languages are defined as parameters.
            string from = DropDownList1.SelectedValue;
            string to = DropDownList2.SelectedValue;
            string route = "/translate?api-version=3.0&from=" + from + "&to=" + to;
            string textToTranslate = TextBox1.Text;
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                // Build the request.
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);
                // location required if you're using a multi-service or regional (not global) resource.
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                // Send the request and get response.
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                // Read response as a string.
                string result = await response.Content.ReadAsStringAsync();

                int start = 27;
                int end = result.Length - 15 - start;
                string trimmedtext = result.Substring(start, end);


                TextBox2.Text = trimmedtext;

            }

        }

        protected void ImgToTxt(string path)
        {
            var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials("a1d3dff9250c43a3b0ab90cc13311f82"));
            client.Endpoint = "https://computer-vision-cmpe363-team9.cognitiveservices.azure.com/";

            var myfile = System.IO.File.OpenRead(path);
            var result = client.RecognizePrintedTextInStreamAsync(false, myfile);
            result.Wait();

            var rst = result.Result;
            string text = "";
            foreach (var r in rst.Regions)
            {
                foreach (var t in r.Lines)
                {
                    foreach (var w in t.Words)
                    {
                        text += w.Text + " ";
                    }
                }
            }
            TextBox1.Text = text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Login.loggedInUserId != 0)
            {
                // Provide the query string with a parameter placeholder.
                string queryString =
                "SELECT * from dbo.user_t where username = '" + Login.userName + "' ;";

                // Specify the parameter value.
                int paramValue = 5;

                // Create and open the connection in a using block. This
                // ensures that all resources will be closed and disposed
                // when the code exits.
                using (SqlConnection connection =
                    new SqlConnection(connectionString))
                {
                    // Create the Command and Parameter objects.
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@pricePoint", paramValue);

                    // Open the connection in a try/catch block.
                    // Create and execute the DataReader, writing the result
                    // set to the console window.

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            lblTranslate2.Text = reader[4].ToString();
                            lblSpeech2.Text = reader[5].ToString();
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }

                DropDownList1.SelectedValue = Login.prefferedLanguage;
                Button3.Visible = false;
                Button4.Visible = false;
                Button5.Visible = true;

                lblLoggedIn1.Visible = true;
                lblLoggedIn2.Visible = true;
                lblLoggedIn2.Text = Login.userName;

                lblTranslate1.Visible = true;
                lblTranslate2.Visible = true;

                lblSpeech1.Visible = true;
                lblSpeech2.Visible = true;

                lblPrefLang1.Visible = true;
                lblPrefLang2.Visible = true;
                lblPrefLang2.Text = Login.prefferedLanguage.ToString();

            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Translate();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Translate();
            UpdateTranslateCount();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Speech(TextBox2.Text, DropDownList2.SelectedValue);
            UpdateSpeechCount();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Login.loggedInUserId = 0;
            Login.prefferedLanguage = "en";
            Login.userName = "";
            Login.translateCount = 0;
            Login.speechCount = 0;
            Response.Redirect("Default.aspx");
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string strFileName;
            string strFilePath;
            string strFolder;
            strFolder = Server.MapPath("./");
            // Get the name of the file that is posted.
            strFileName = oFile.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (oFile.Value != "")
            {
                // Create the directory if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;

                //TextBox2.Text = strFileName + " already exists on the server!";
                oFile.PostedFile.SaveAs(strFilePath);
                ImgToTxt(strFilePath);
                Translate();
            }
            else
            {
                TextBox2.Text = "Click 'Browse' to select the file to upload.";
            }
        }

        private void UpdateSpeechCount()
        {
            if (Login.loggedInUserId != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE user_t SET speech_count = speech_count + 1 WHERE username = @username", connection))
                    {
                        command.Parameters.AddWithValue("@username", Login.userName);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }

        private void UpdateTranslateCount()
        {
            if (Login.loggedInUserId != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE user_t SET translate_count = translate_count + 1 WHERE username = @username", connection))
                    {
                        command.Parameters.AddWithValue("@username", Login.userName);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
        }
    }
}