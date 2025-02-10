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
            Payload payload = new Url(mdl.ImageUrl ?? "");

            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(payload);

            BitmapByteQRCode qRCode = new BitmapByteQRCode(qRCodeData);
            string base64String = Convert.ToBase64String(qRCode.GetGraphic(20));
            mdl.QrImageUrl = "data:image/png;base64," + base64String;

            return View("Index", mdl);
        }
    }
}
