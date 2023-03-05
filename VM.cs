using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Meta_Data_App
{  
   public class VM
    {
        public Model model = new Model();
        public int flag { get; set; }// flag_s = 0 не авторизован
                                     // flag_s = 1 авторизован
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
                Menu menu = new Menu();
                line = streamReader.ReadLine();
                string[] splitline = line.Split(' ');
                menu.Number = splitline[0];
                menu.Header = splitline[1];
                model.menu.Add(menu);
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
