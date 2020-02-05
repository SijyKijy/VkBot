using System;

using MakaraBot.Models;

using Microsoft.AspNetCore.Mvc;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace MakaraBot.Controllers
{
    [Route("api/main")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IVkApi _vkApi;

        public MainController(IVkApi vkApi)
        {
            _vkApi = vkApi;
        }

        [HttpPost]
        public IActionResult CallBack([FromBody] Updates updates)
        {
            switch (updates.Type)
            {
                case "confirmation": return Ok(AppSettings.Confirmation);
                case "message_new":
                    {
                        VkResponse response = new VkResponse(updates.Object);
                        Message msg = response["message"];

                        switch (msg?.GetPayload().Value<string>("command"))
                        {
                            case "start":
                                {
                                    _vkApi.Messages.Send(new MessagesSendParams()
                                    {
                                        RandomId = (int)DateTime.Now.Ticks,
                                        UserId = msg.PeerId,
                                        Message = "Hello!"
                                    });
                                    break;
                                }
                        }
                        break;
                    }
            }
            return Ok("ok");
        }
    }
}