using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Meta_Data_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        VM ViewModel = new VM("Data.txt");
        SignIn signIn;
        public MainWindow()
        {    
           InitializeComponent();
            ViewModel.flag = 0;
            signIn = new SignIn(ViewModel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.flag == 0 ) // если пользователь не авторизован
            {
                signIn.Show();
            }
            else if (ViewModel.flag == 1 ) // если авторизован
            {
                But_aut.Visibility = Visibility.Collapsed;
                int count = 0;
                foreach (var item in ViewModel.model.menu) // отображение конструкции меню 
                {
                    MenuItem newMenuItem1 = new MenuItem();
                    newMenuItem1.Header = item.Header;
                    menu.Items.Add(newMenuItem1);
                    if (item.Number == "1")
                    {
                        MenuItem newMenuItem2 = new MenuItem();
                        MenuItem newExistMenuItem = (MenuItem)this.menu.Items[count];
                        newMenuItem2.Header = item.Header;
                        newExistMenuItem.Items.Add(newMenuItem2);
                    }
                    else count++;
                }
            }
        }
        
    }
}
