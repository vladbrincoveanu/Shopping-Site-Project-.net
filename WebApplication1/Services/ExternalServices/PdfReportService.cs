﻿
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PdfReportService
    {
        public static ActionResult CreateReportPdfofIngredients(List<Ingredient> ingredients)
        {
            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;

            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);


            var data = "";
            foreach (var ingredient in ingredients)
            {
                data = data + "\n" + "Name"+ingredient.Name+" Quantity:"+ingredient.Quantity+" Discount"+ingredient.Discount;
            }

            //Draw the text
            graphics.DrawString(data, font, PdfBrushes.Black, new PointF(0, 0));

            //Saving the PDF to the MemoryStream
            MemoryStream stream = new MemoryStream();

            document.Save(stream);

            //Set the position as '0'.
            stream.Position = 0;

            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "ReportPDF.pdf";
            return fileStreamResult;
        }
       
    }
}
