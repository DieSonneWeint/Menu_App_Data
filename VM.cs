using Menu_App_Lib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Meta_Data_App
{  
   public class VM 
    {
        MenuItemClick itemClick;
        public Model model = new Model();
        Menu_DLL dLL = new Menu_DLL();
        private int flag = 0; 
        public int Flag { get { return flag; } set { flag = value; } }
        // flag = 0 не авторизован
        // flag = 1 авторизован
        public VM(string path_users) 
        {
            ReadUserInfo(path_users);
        }
        
        public int Check (string user_name , string user_password) // проверка логина и пароля 
        {
             foreach( var user in model.users) 
            {
                if (user.User_Password== user_password && user.User_Name == user_name) 
                {
                    ReadMenuInfo(user.path);
                    return 1;
                }
            }
            return 0;
        }
        public void  ReadMenuInfo(string path_menu) // загружается конструктор меню
        {
            string line;
            StreamReader streamReader= new StreamReader(path_menu);
            while (!streamReader.EndOfStream) 
            {
                MenuHeader menu = new MenuHeader();
                line = streamReader.ReadLine();
                string[] splitline = line.Split(' ');
                menu.Number = splitline[0];
                menu.Header = splitline[1];
                model.menuHeaders.Add(menu);
            }
        }
        private void  ReadUserInfo( string path_users) // считывается с файла вся информация о пользователях
        {   
            string line;
            StreamReader streamReader = new StreamReader(path_users);
            while (!streamReader.EndOfStream)
            {
                User user = new User();
                line = streamReader.ReadLine();
                string[] splitline = line.Split(' ');
                user.User_Name = splitline[0];
                user.User_Password = splitline[1];
                user.path = splitline[2];
                model.users.Add(user);
            }
        }
    }
}
