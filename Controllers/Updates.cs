using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MakaraBot.Controllers
{
    /// <summary>
    /// Callback event
    /// </summary>
    [Serializable]
    public class Updates
    {
        /// <summary>
        /// Event type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The object that triggered the event
        /// The structure of an object depends on the type of notification
        /// </summary>
        [JsonProperty("object")]
        public JObject Object { get; set; }

        /// <summary>
        /// Group ID where the event occurred
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// Secrey key
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
