using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using PrivateAccountant.Model.Classes;

namespace PrivateAccountant.Model.PDFReader
{
    public class PDFReader
    {
        public PDFReader()
        {
            KeyValueWorks = new Dictionary<DateTime, Work>();
            KeyValueTravels = new Dictionary<DateTime, Travel>();
        }

        public IDictionary<DateTime, Work> KeyValueWorks { get; set; }
        public IDictionary<DateTime, Travel> KeyValueTravels { get; set; }


        public void ReadAcroFieldsFromPDF(string[] files)
        {
            CultureInfo ci = new CultureInfo("it-IT");
            DateTime dateTime = DateTime.MinValue;
            Work work = new Work();
            Travel travel = new Travel();
            DateTime currentDate = DateTime.MinValue;

            foreach (var file in files)
            {


                using (PdfReader pdfReader = new PdfReader(file))
                {
                    //            IList<KeyValuePair<int, AcroFields.Item>> listOfItems = new List<KeyValuePair<int, AcroFields.Item>>();


                    foreach (var item in pdfReader.AcroFields.Fields.Where(f => f.Key.Contains("data[0].#subform[0].Tabella1[0]")))
                    {

                        string textKey, textValue = string.Empty;
                        char dot = '.';
                        int indexofLastDot = 0;
                        textKey = item.Key.ToString();
                        indexofLastDot = textKey.LastIndexOf(dot) + 1;
                        textKey = textKey.Substring(indexofLastDot, textKey.Length - indexofLastDot);

                        var dvValue = item.Value.GetValue(0).GetAsString(PdfName.DV)?.ToString();
                        var vValue = item.Value.GetValue(0).GetAsString(PdfName.V)?.ToString();
                        vValue = vValue != null ? vValue.Contains("24:") ? vValue.Replace("24:", "00:") : vValue : null;
                        if (dvValue != null || vValue != null)
                            GetData(ref currentDate, ref dateTime, ref work, ref travel, item, vValue, vValue);

                        Console.WriteLine("---  {0},    {1}", textKey, textValue);

                    }
                }
            }
        }


        private void GetData(ref DateTime currentDate, ref DateTime dateTime, ref Work work, ref Travel travel, KeyValuePair<string, AcroFields.Item> item, string dvValue, string vValue)
        {

            if (item.Key.Contains("DATA"))
            {
                dateTime = DateTime.MinValue;
                work = new Work();
                travel = new Travel();

                if (dvValue != null)
                {
                    DateTime.TryParse(dvValue, CultureInfo.GetCultureInfo("it-IT"), DateTimeStyles.None, out dateTime);
                    currentDate = dateTime;
                }
            }
            else if (item.Key.Contains("ORAINIPM"))
            {
                if (vValue != null)
                {
                    travel.StartDateTime = currentDate.Add(TimeSpan.Parse(vValue));
                }
            }
            else if (item.Key.Contains("ORAINILM"))
            {
                if (vValue != null)
                {
                    work.StartDateTime = currentDate.Add(TimeSpan.Parse(vValue));
                }
            }
            else if (item.Key.Contains("ORAENDLM"))
            {
                if (vValue != null)
                {
                    work.BreakStartDateTime = currentDate.Add(TimeSpan.Parse(vValue));
                }
            }
            else if (item.Key.Contains("ORAENDAM"))
            {
                if (vValue != null)
                {
                    travel.BreakStartDateTime = currentDate.Add(TimeSpan.Parse(vValue));
                }
            }
            else if (item.Key.Contains("ORAINIPP"))
            {
                if (vValue != null)
                {
                    travel.BreakEndDateTime = currentDate.Add(TimeSpan.Parse(vValue));
                }
            }
            else if (item.Key.Contains("ORAINILP"))
            {
                if (vValue != null)
                {
                    work.BreakEndDateTime = currentDate.Add(TimeSpan.Parse(vValue));
                }
            }
            else if (item.Key.Contains("ORAENDLP"))
            {
                if (vValue != null)
                {
                    if (currentDate.Add(TimeSpan.Parse(vValue)) <= work.StartDateTime || (currentDate.Add(TimeSpan.Parse(vValue)).Hour < 12))
                        work.EndDateTime = currentDate.Add(TimeSpan.Parse(vValue)).AddDays(1);
                    else
                        work.EndDateTime = currentDate.Add(TimeSpan.Parse(vValue));
                }

                work.CalculateProperties();
                if (work.StartDateTime.Day == dateTime.Day)
                {
                    KeyValueWorks.Add(new KeyValuePair<DateTime, Work>(dateTime, work));
                }

            }
            else if (item.Key.Contains("ORAENDAP"))
            {
                if (vValue != null)
                {
                    if (currentDate.Add(TimeSpan.Parse(vValue)) <= travel.StartDateTime || (currentDate.Add(TimeSpan.Parse(vValue)).Hour<12))
                        travel.EndDateTime = currentDate.Add(TimeSpan.Parse(vValue)).AddDays(1);
                    else
                        travel.EndDateTime = currentDate.Add(TimeSpan.Parse(vValue));
                }

                travel.CalculateProperties();
                if (travel.StartDateTime.Day == dateTime.Day)
                {
                    KeyValueTravels.Add(new KeyValuePair<DateTime, Travel>(dateTime, travel));
                }
            }
        }
    }
}

