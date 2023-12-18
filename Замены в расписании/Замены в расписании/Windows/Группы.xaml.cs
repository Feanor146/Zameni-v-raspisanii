using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;
namespace Замены_в_расписании.Windows
{
    public sealed partial class Группы : Page
    {
        public Группы()
        {
            this.InitializeComponent();
            specprof.ItemsSource = App.model.Специалиности_и_профессии.ToList();
            specprof.DisplayMemberPath = "Специальность_профессия";
            specprof.SelectedItem = specprof.Items.FirstOrDefault();
            this.table.ItemsSource = App.model.Группы.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.model.Группы.Add(new Data.Группы { Название_группы = New.Text, Специальность_профессия = ((Data.Специалиности_и_профессии)specprof.SelectedItem).ID });
            App.model.SaveChanges();
            this.table.ItemsSource = App.model.Группы.ToList();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.model.SaveChanges();
        }
    }
}
