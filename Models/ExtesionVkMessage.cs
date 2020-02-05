using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace MakaraBot.Models
{
    public static class ExtesionVkMessage
    {
        public static JObject GetPayload(this Message msg) => JObject.Parse(msg.Payload ?? "{\"\":\"\"}");
    }
}
