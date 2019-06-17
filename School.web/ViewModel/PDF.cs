using iTextSharp.text;
using iTextSharp.text.pdf;
using School.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace School.web.ViewModel
{
    public class StudentReport
    {
        #region Delaration
        int _totalColumn = 3;
        Document _documant;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell _pdfPCell;
        MemoryStream memoryStream = new MemoryStream();
        StudentDetail _student = new StudentDetail();
        #endregion

        public byte[] PrepareReport(StudentDetail student)
        {
            _student = student;

            #region
            _documant = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _documant.SetPageSize(PageSize.A4);
            _documant.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_documant, memoryStream);
            _documant.Open();
            _pdfTable.SetWidths(new float[] { 20f, 150f ,110f});
            #endregion

            this.ReportHeader();
            this.ReportBody();

            _pdfTable.HeaderRows = 2;
            _documant.Add(_pdfTable);
            _documant.Close();
            return memoryStream.ToArray();
        }

        public void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Student Report", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Student", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }
        public void ReportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(StudentInfo());
            _pdfPCell.Colspan = 2;
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            _pdfPCell = new PdfPCell(StudentInfoDetail());
            _pdfPCell.Border = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            #region Table Head


            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            _pdfPCell = new PdfPCell(new Phrase("S.No", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
           

            _pdfPCell = new PdfPCell(new Phrase("City Name", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
           

            _pdfPCell = new PdfPCell(new Phrase("Address", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();



            #endregion

            #region Table Body
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            int count = 1;
            foreach (Address item in _student.Address)
            {


                _pdfPCell = new PdfPCell(new Phrase(count++.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(item.City.Name, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(item.Details, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }


            #endregion
        }

        private PdfPTable StudentInfo()
        {
            PdfPTable oPdfPTable = new PdfPTable(2);
            oPdfPTable.SetWidths(new float[] { 100f, 100f });

            _pdfPCell = new PdfPCell(new Phrase("Id", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_student.Id.ToString(), _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            oPdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Name",_fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_student.Name, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            oPdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Gender", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_student.Gender, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            oPdfPTable.CompleteRow();
            return oPdfPTable;

        }

        private PdfPTable StudentInfoDetail()
        {
            PdfPTable oPdfPTable = new PdfPTable(2);
            oPdfPTable.SetWidths(new float[] { 100f, 100f });

            

            _pdfPCell = new PdfPCell(new Phrase("Date of Birth", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_student.date.ToShortDateString(), _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            oPdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Class", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_student.ClassName, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            oPdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("School", _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_student.SchoolName, _fontStyle));
            _pdfPCell.Border = 0;
            oPdfPTable.AddCell(_pdfPCell);
            oPdfPTable.CompleteRow();
            return oPdfPTable;

        }
    }
}