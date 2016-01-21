using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DomainPCL
{
    public class ExcelExport
    {
        public const string ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public byte[] ExportWins(int xWins, int yWins)
        {
          var export = new byte[0];
            //ExcelEngine excelEngine = new ExcelEngine();
            //IApplication application = excelEngine.Excel;
            //IWorkbook workbook = application.Workbooks.Create(1);
            //workbook.Version = ExcelVersion.Excel2013;
            //var sheet = workbook.Worksheets[0];
            //sheet[1,1].Text="X Wins";
            //sheet[1, 2].Text = xWins.ToString();
            //sheet[2, 1].Text = "Y Wins";
            //sheet[2, 2].Text = yWins.ToString();
            //var stream = new MemoryStream();
            //workbook.SaveAsAsync(stream);

            //    workbook.SetCellValue("A2", xWins);
            //    workbook.SetCellValue("B1", "Y Wins");
            //    workbook.SetCellValue("B2", yWins);

            //using (var workbook = new ())
            //{
            //    workbook.SetCellValue("A1", "X Wins");
            //    workbook.SetCellValue("A2", xWins);
            //    workbook.SetCellValue("B1", "Y Wins");
            //    workbook.SetCellValue("B2", yWins);
            //    using (var stream = new MemoryStream())
            //    {
            //        workbook.SaveAs(stream);
            //        export = stream.ToArray();
            //    }                    
            //}        

            return export;
        }
    }
}
