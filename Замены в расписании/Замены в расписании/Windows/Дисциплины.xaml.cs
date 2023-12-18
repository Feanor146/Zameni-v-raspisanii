using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Linq;
using Замены_в_расписании.Data;
namespace Замены_в_расписании.Windows
{
    public sealed partial class Дисциплины : Page
    {
        public Дисциплины()
        {
            this.InitializeComponent();
            specprof.SelectionChanged += Specprof_SelectionChanged;
            specprof.ItemsSource = App.model.Специалиности_и_профессии.ToList();
            specprof.DisplayMemberPath = "Специальность_профессия";
            specprof.SelectedItem = specprof.Items.FirstOrDefault();
            table.ItemsSource = App.model.Дисциплины.ToList().Where(x => x.Специальность_профессия == ((Специалиности_и_профессии)specprof.SelectedItem).ID);
        }
        private void Specprof_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            table.ItemsSource = App.model.Дисциплины.ToList().Where(x => x.Специальность_профессия == ((Специалиности_и_профессии)specprof.SelectedItem).ID);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.model.Дисциплины.Add(new Data.Дисциплины { Название_дисциплины = New.Text, Специальность_профессия = ((Специалиности_и_профессии)specprof.SelectedItem).ID });
            App.model.SaveChanges();
            table.ItemsSource = App.model.Дисциплины.ToList().Where(x => x.Специальность_профессия == ((Специалиности_и_профессии)specprof.SelectedItem).ID);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.model.SaveChanges();
        }
    }
}
