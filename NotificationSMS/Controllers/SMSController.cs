using Microsoft.AspNetCore.Mvc;
using NotificationSMS.DTOs;
using NotificationSMS.Service.AWSSMS;

namespace NotificationSMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISmsService _smsService;

        public SMSController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] SMSSenderWriteDTO model)
        {
            var r = new SmsMessage()
            {
                Date = DateTime.Now,
                DateSent = DateTime.Now,
                Retries = 0,
                SenderName = model.SenderName,
                Text = model.Text,
                To = model.To,
            };
            await _smsService.Send(r);

            return Ok(r);
        }
    }
}
