using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;
namespace Замены_в_расписании.Windows
{
    public sealed partial class Специальности_и_профессии : Page
    {
        public Специальности_и_профессии()
        {
            this.InitializeComponent();
            table.ItemsSource = App.model.Специалиности_и_профессии.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.model.Специалиности_и_профессии.Add(new Data.Специалиности_и_профессии { Специальность_профессия = New.Text });
            App.model.SaveChanges();
            table.ItemsSource = App.model.Специалиности_и_профессии.ToList();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.model.SaveChanges();
        }
    }
}
