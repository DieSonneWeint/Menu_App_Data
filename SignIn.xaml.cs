using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Meta_Data_App
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        VM ViewModel;
        public SignIn(VM vM)
        {
            InitializeComponent();
            ViewModel = vM;
           
        }   

        private void Button_Click_1(object sender, RoutedEventArgs e) // кнопка авторизации
        {
            if (ViewModel.Check(TextBox_Login.Text, TextBox_Password.Text) == 1)
            {
                Label_Info.Content = "Авторизация прошла успешна";
                ViewModel.flag = 1;
                this.Close();               
            }
            else Label_Info.Content = "Неверный логин или пароль";
        }

        private void Button_Click(object sender, RoutedEventArgs e) // кнопка отмены
        {
            this.Close();
            
        }
    }
}
