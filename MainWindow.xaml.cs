using Menu_App_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        Menu_DLL dll = new Menu_DLL();
        public MainWindow()
        {    
          InitializeComponent();  
          ViewModel.Flag = 0;
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Flag == 0 ) // если пользователь не авторизован
            {
                signIn = new SignIn(ViewModel);   
                this.Hide();
                signIn.Closing += CloseEvent;
                signIn.Show();
            }
            else if (ViewModel.Flag == 1) // если авторизован
            {
                But_aut.Visibility = Visibility.Collapsed;
                int count = -1;
                int countprom = -1;
                foreach (var item in ViewModel.model.menuHeaders) // отображение конструкции меню 
                {   
                    MenuItem newMenuItem1 = new MenuItem();
                    if (item.Number == "1") newMenuItem1.IsEnabled = false;
                    else
                    {
                        newMenuItem1.Click += NewMenuItem1_Click;
                    }

                    if (item.TreeStruct == "0")
                        {
                        count++;
                        countprom = -1;
                        newMenuItem1.Header = item.Header;
                        menu.Items.Add(newMenuItem1);
                        }

                    if (item.TreeStruct == "1")
                    { 
                        countprom++;
                        MenuItem newExistMenuItem = (MenuItem)this.menu.Items[count];
                        newMenuItem1.Header = item.Header;
                        newExistMenuItem.Items.Add(newMenuItem1);
                    }
                    if (item.TreeStruct == "2")
                    {                      
                        MenuItem newExistMenuItem = (MenuItem)this.menu.Items[count];
                        var newExistMenuItem2 = (MenuItem)newExistMenuItem.Items[countprom];
                        newMenuItem1.Header = item.Header;
                        newExistMenuItem2.Items.Add(newMenuItem1);

                    }


                }
            }
        }
        private void CloseEvent(object sender, EventArgs e)
        {
            this.Show();
        }
        private void NewMenuItem1_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = e.OriginalSource as MenuItem;
            dll.Menu_Item_Click(menuItem.Header.ToString(), TextBox);
        }

    }
}
