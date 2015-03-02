using IntelligentBusSystem.Models;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace IntelligentBusSystem
{
    public class IDCardGenerator
    {
        public void GetIDCard(string id)
        {
            
                string newFile = HttpContext.Current.Server.MapPath("\\PdfIDCards\\" + id + ".pdf");
                PdfReader pdfReader = new PdfReader(HttpContext.Current.Server.MapPath("\\PdfIDCards\\IDCardPDF.pdf"));
                using (MemoryStream stream = new MemoryStream())
                {
                    using(var context=new IntelligentBusSystemEntities()){

                    PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
                    AcroFields pdfFormFields = pdfStamper.AcroFields;
                    AcroFields.FieldPosition LogofieldPosition = pdfStamper.AcroFields.GetFieldPositions("SchoolLogoImageField")[0];
                    AcroFields.FieldPosition StudentPhotofieldPosition = pdfStamper.AcroFields.GetFieldPositions("StudentImageField")[0];
                    AcroFields.FieldPosition BarCodefieldPosition = pdfStamper.AcroFields.GetFieldPositions("BarCodeImageField")[0];
                    pdfFormFields.SetField("StudentNameTextField", context.Students.Find(id).StudentFirstName + " "+context.Students.Find(id).StudentLastName);
                    pdfFormFields.SetField("BirthdateTextField",Convert.ToDateTime(context.Students.Find(id).StudentBirthdate).ToShortDateString());
                    pdfFormFields.SetField("ClassTextField", context.Students.Find(id).Class.ClassName);
                    pdfFormFields.SetField("IDTextField", context.Students.Find(id).StudentID);
                    pdfFormFields.SetField("SchoolNameTextField", context.Schools.First().SchoolName);
                    pdfFormFields.SetField("YearTextField", "2014-2015");
                    pdfFormFields.SetField("SchoolAddressField", "Latitude:" + context.Schools.First().SchoolLat + ", Longitude: " + context.Schools.First().SchoolLong);
                    iTextSharp.text.Image schoolLogo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(context.Schools.First().SchoolLogo));
                    schoolLogo.ScaleAbsolute(LogofieldPosition.position.Width, LogofieldPosition.position.Height);
                    schoolLogo.SetAbsolutePosition(LogofieldPosition.position.Left, LogofieldPosition.position.Bottom);
                    pdfStamper.GetOverContent(1).AddImage(schoolLogo);

                    iTextSharp.text.Image StudentPhoto = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(context.Students.Find(id).StudentThumbPhoto));
                    StudentPhoto.ScaleAbsolute(StudentPhotofieldPosition.position.Width, StudentPhotofieldPosition.position.Height);
                    StudentPhoto.SetAbsolutePosition(StudentPhotofieldPosition.position.Left, StudentPhotofieldPosition.position.Bottom);
                    pdfStamper.GetOverContent(1).AddImage(StudentPhoto);

                   // to do barcode
                    pdfStamper.FormFlattening = false;
                    pdfStamper.Writer.CloseStream = false;
                    pdfStamper.Close();
                    pdfReader.Close();

                    }
            }
        }
    }
}