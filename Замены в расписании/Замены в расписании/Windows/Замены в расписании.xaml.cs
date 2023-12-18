using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
namespace Замены_в_расписании.Windows
{
    public sealed partial class Замены_в_расписании : Window
    {
        public static Frame Frame1 { get; set; }
        public Замены_в_расписании()
        {
            this.InitializeComponent();
            Frame1 = FrameNavigation;
            FrameNavigation.Navigate(typeof(Создание_замены));

        }
        private async void Menu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (sender.MenuItems[0] == sender.SelectedItem)
            {
                FrameNavigation.Navigate(typeof(Создание_замены));
            }
            if (sender.MenuItems[1] == sender.SelectedItem)
            {
                FrameNavigation.Navigate(typeof(Группы));
            }
            if (sender.MenuItems[2] == sender.SelectedItem)
            {
                FrameNavigation.Navigate(typeof(Специальности_и_профессии));
            }
            if (sender.MenuItems[3] == sender.SelectedItem)
            {
                FrameNavigation.Navigate(typeof(Дисциплины));
            }
        }
    }
}
