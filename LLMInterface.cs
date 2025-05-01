using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SPC_Chart_Generator
{
    public class ChatRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }
        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }
        [JsonPropertyName("stream")]
        public bool Stream { get; set; }
    }

    public class Message
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class LLMInterface
    {
        string ServerURL;
        HttpClient Client = new HttpClient();
        ChatRequest chatRequest = new ChatRequest { Model = "deepseek-math-7b-instruct", Messages = [], Stream = false };
        public int ModelConnected;

        public async Task PingServer(string url)
        {
            HttpResponseMessage Response;
            try
            {
                Response = await Client.GetAsync(url);
                if (Response.IsSuccessStatusCode)
                {
                    ServerURL = url;
                    var userMessage = new Message { Role = "system", Content = "You are a helpful mathematican" };
                    chatRequest.Messages.Add(userMessage);
                    ModelConnected = 1;
                }
                else
                {
                    ModelConnected = (int)Response.StatusCode;
                }
                
            }
            catch (Exception ex)
            {
                ModelConnected = -1;
            }
        }
        public async Task<string> SendMessageToModel(string NewMessage)
        {
            var userMessage = new Message { Role = "user", Content = NewMessage };
            chatRequest.Messages.Add(userMessage);
            var Content = new StringContent
                (
                    JsonSerializer.Serialize(chatRequest),
                    Encoding.UTF8,
                    "application/json"
                );
            try
            {
                var Response = await Client.PostAsync(ServerURL, Content);
                var ResponseBody = await Response.Content.ReadAsStringAsync();
                using var Document = JsonDocument.Parse(ResponseBody);
                var Choices = Document.RootElement.GetProperty("choices");

                if (Choices.GetArrayLength() > 0)
                {
                    var Message = Choices[0].GetProperty("message");
                    var Reply = Message.GetProperty("content").GetString();
                    return Reply;
                }
                else
                {
                    return "None";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
