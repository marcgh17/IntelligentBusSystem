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
                        Student student = context.Students.Find(id);
                        School school = context.Schools.First();
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
                    AcroFields pdfFormFields = pdfStamper.AcroFields;
                    AcroFields.FieldPosition LogofieldPosition = pdfStamper.AcroFields.GetFieldPositions("SchoolLogoImageField")[0];
                    AcroFields.FieldPosition StudentPhotofieldPosition = pdfStamper.AcroFields.GetFieldPositions("StudentImageField")[0];
                    AcroFields.FieldPosition BarCodefieldPosition = pdfStamper.AcroFields.GetFieldPositions("BarCodeImageField")[0];
                    pdfFormFields.SetField("StudentNameTextField", student.StudentFirstName + " " + student.StudentLastName);
                    pdfFormFields.SetField("BirthdateTextField", Convert.ToDateTime(student.StudentBirthdate).ToShortDateString());
                    pdfFormFields.SetField("ClassTextField", student.Class.ClassName);
                    pdfFormFields.SetField("IDTextField", id);
                    pdfFormFields.SetField("SchoolNameTextField", school.SchoolName);
                    pdfFormFields.SetField("YearTextField", "2014-2015");
                    pdfFormFields.SetField("SchoolAddressField", "Latitude:" + school.SchoolLat + ", Longitude: " + school.SchoolLong);
                    iTextSharp.text.Image schoolLogo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(school.SchoolLogo));
                    schoolLogo.ScaleAbsolute(LogofieldPosition.position.Width, LogofieldPosition.position.Height);
                    schoolLogo.SetAbsolutePosition(LogofieldPosition.position.Left, LogofieldPosition.position.Bottom);
                    pdfStamper.GetOverContent(1).AddImage(schoolLogo);

                    iTextSharp.text.Image StudentPhoto = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(student.StudentPhoto));
                    StudentPhoto.ScaleAbsolute(StudentPhotofieldPosition.position.Width, StudentPhotofieldPosition.position.Height);
                    StudentPhoto.SetAbsolutePosition(StudentPhotofieldPosition.position.Left, StudentPhotofieldPosition.position.Bottom);
                    pdfStamper.GetOverContent(1).AddImage(StudentPhoto);

                   // to do barcode

                    iTextSharp.text.Image StudentBarecodePhoto = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/img/Barcodes/"+id+".png"));
                    StudentBarecodePhoto.ScaleAbsolute(BarCodefieldPosition.position.Width, BarCodefieldPosition.position.Height);
                    StudentBarecodePhoto.SetAbsolutePosition(BarCodefieldPosition.position.Left, BarCodefieldPosition.position.Bottom);
                    pdfStamper.GetOverContent(2).AddImage(StudentBarecodePhoto);

                    pdfStamper.FormFlattening = false;
                    pdfStamper.Writer.CloseStream = false;
                    pdfStamper.Close();
                    pdfReader.Close();

                    }
            }
        }
    }
}