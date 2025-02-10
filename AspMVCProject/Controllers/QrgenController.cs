using AspMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using static QRCoder.PayloadGenerator;

namespace AspMVCProject.Controllers
{
    public class QrgenController : Controller
    {
        public IActionResult Index()
        {
            mdlQrCoder mdl = new mdlQrCoder();
            return View(mdl);
        }

        [HttpPost]
        public IActionResult Index(mdlQrCoder mdl)
        {
            Payload? payload = null;

            switch (mdl.QrCodeType)
            {
                case 1: //url
                    payload = new Url(mdl.ImageUrl ?? "");
                    break;
                case 2: //sms
                    payload = new SMS(mdl.smsPhoneNumber!, mdl.smsBody!);
                    break;
                case 3: //waap
                    payload = new WhatsAppMessage(mdl.wapNumber!, mdl.wapMessage!);
                    break;
                case 4: //mail
                    payload = new Mail(mdl.Email, mdl.EmailSubject!, mdl.EmailBody);
                    break;
                case 5: //wifi
                    payload = new WiFi(mdl.wifiName!, mdl.wifiPassword!, WiFi.Authentication.WPA);
                    break;
            }

            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(payload);

            BitmapByteQRCode qRCode = new BitmapByteQRCode(qRCodeData);
            string base64String = Convert.ToBase64String(qRCode.GetGraphic(20));
            mdl.QrImageUrl = "data:image/png;base64," + base64String;

            return View("Index", mdl);
        }
    }
}
