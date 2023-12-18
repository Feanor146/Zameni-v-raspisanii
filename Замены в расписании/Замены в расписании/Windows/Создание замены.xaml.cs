using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using System.Linq;
using SelectPdf;
using System;
using System.IO;
using PdfSharp.Pdf.IO;
namespace Замены_в_расписании.Windows
{
    public sealed partial class Создание_замены : Microsoft.UI.Xaml.Controls.Page
    {
        public static List<DataItem> dataitem { get; set; }
        public Создание_замены()
        {
            InitializeComponent();
            groups.ItemsSource = App.model.Группы.ToList();
            groups.DisplayMemberPath = "Название_группы";
            groups.SelectionChanged += Groups_SelectionChanged;
            if (groups.Items.Count > 0)
            {
                groups.SelectedItem = groups.Items[0];
            }
            Predmet.DisplayMemberPath = "Название_дисциплины";
            Zpredmet.DisplayMemberPath = "Название_дисциплины";
            table.DataContext = this.DataContext;
        }
        private void Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Predmet.ItemsSource = App.model.Дисциплины.ToList().Where(x => x.Специальность_профессия == ((Data.Группы)groups.SelectedItem).Специальность_профессия);
            Zpredmet.ItemsSource = App.model.Дисциплины.ToList().Where(x => x.Специальность_профессия == ((Data.Группы)groups.SelectedItem).Специальность_профессия);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dataitem == null)
            {
                dataitem = new List<DataItem>();
            }
            table.ItemsSource = null;
            dataitem.Add(new DataItem { Кабинет = Nkabinet.Text, Группа = ((Data.Группы)groups.SelectedItem).Название_группы, Пара = Npars.Text, Урок = ((Data.Дисциплины)Predmet.SelectedItem).Название_дисциплины, За = ((Data.Дисциплины)Zpredmet.SelectedItem).Название_дисциплины });
            table.ItemsSource = dataitem;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string html= "";
            html += "<!DOCTYPE HTML><html lang=\"ru\"><head><meta charset=\"UTF-8\"><title></title></head><body>";      
            html += @"<h1 style=""text-align: center;"">";
            html += @"Изменение в расписании уроков на «";
            html += Convert.ToString(datee.Date).Substring(0,2);
            html += @"» ";
            switch (Convert.ToByte(Convert.ToString(datee.Date).Substring(3, 2)))
            {
                case 1:html += "января";break;
                case 2: html += "февраля"; break;
                case 3: html += "марта"; break;
                case 4: html += "апреля"; break;
                case 5: html += "мая"; break;
                case 6: html += "июня"; break;
                case 7: html += "июля"; break;
                case 8: html += "августа"; break;
                case 9: html += "сентября"; break;
                case 10: html += "октября"; break;
                case 11: html += "ноября"; break;
                case 12: html += "декабря"; break;
            }
            html += " ";
            switch (datee.Date.Value.DayOfWeek)
            {
               case DayOfWeek.Monday: html += @"(понедельник)";break;
               case DayOfWeek.Tuesday: html += @"(вторник)"; break;
               case DayOfWeek.Wednesday: html += @"(среда)"; break;
               case DayOfWeek.Thursday: html += @"(четверг)"; break;
               case DayOfWeek.Friday: html += @"(пятница)"; break;
               case DayOfWeek.Saturday: html += @"(суббота)"; break;
               case DayOfWeek.Sunday: html += @"(воскресенье)"; break;
            }
            html += @"</h1>";
            html += @"<table style=""font-size: 24px;text-align:center;"" border=""1"" cellpadding=""1"" cellspacing=""0"">";
            html += @"<tbody>";
            html += @"<tr>";
            html += @"<td><b>№ группы</b></td>";
            html += @"<td><b>№ пары</b></td>";
            html += @"<td><b>№ урока</b></td>";
            html += @"<td><b>Урок</b></td>";
            html += @"<td><b>№ кабинета</b></td>";
            html += @"<td><b>За</b></td>";
            html += @"</tr>";
            foreach (DataItem item in dataitem)
            {
                html += @"<tr>";
                html += @"<td>"+item.Группа+"</td>";
                html += @"<td>" + item.Пара + "</td>";
                if (item.Пара == "1")
                {
                    html += @"<td><p style=""border-bottom: 1px solid"">1</p><p>2</p></td>";
                }
                if (item.Пара == "2")
                {
                    html += @"<td><p style=""border-bottom: 1px solid"">3</p><p>4</p></td>";
                }
                if (item.Пара == "3")
                {
                    html += @"<td><p style=""border-bottom: 1px solid"">5</p><p>6</p></td>";
                }
                html += @"<td>" + item.Урок + "</td>";
                html += @"<td>" + item.Кабинет + "</td>";
                html += @"<td>" + item.За + "</td>";
                html += @"</tr>";
            }
            html += @"</tbody>";
            html += @"</table>";
            SelectPdf.HtmlToPdf htmlToPdf = new HtmlToPdf();
            SelectPdf.PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(html);
            pdfDocument.Save("C:\\Изменения в расписании\\Последняя замена.pdf");
            PdfSharp.Pdf.PdfDocument one = PdfReader.Open("C:\\Изменения в расписании\\Последняя замена.pdf", PdfDocumentOpenMode.Import);
            PdfSharp.Pdf.PdfDocument two = PdfReader.Open("C:\\Изменения в расписании\\Все замены.pdf", PdfDocumentOpenMode.Import);
            two.AddPage(one.Pages[0]);
            two.Save("C:\\Изменения в расписании\\Все замены.pdf");
            Замены_в_расписании.Frame1.Navigate(typeof(Визуальный_просмотр));
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Замены_в_расписании.Frame1.Navigate(typeof(Визуальный_просмотр));
        }
    }
    public class DataItem
    {
        public string Группа { get; set; }
        public string Пара { get; set; }
        public string Урок { get; set; }
        public string За { get; set; }
        public string Кабинет { get; set; }
    }
}
