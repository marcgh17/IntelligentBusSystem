using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spire.Barcode;
using Spire.Barcode.WebUI;
using System.Drawing.Imaging;

namespace IntelligentBusSystem
{
    public class BarcodeImageGenerator
    {

        public void GenerateBarcodeImage(string id,string type)
        {
            BarCodeControl b = new BarCodeControl();
           b.Data = id;
           b.Data2D = id;
           b.ShowText = false;
           System.Drawing.Image g = b.GenerateImage();
           g.Save(HttpContext.Current.Server.MapPath("/img/Barcodes/"+id+".png"), ImageFormat.Png);
        }
    }
}