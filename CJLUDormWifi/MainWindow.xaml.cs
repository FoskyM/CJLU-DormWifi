﻿using System.Windows;
using System.Configuration;
using CJLUDormWifi.Utils;

namespace CJLUDormWifi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Intranet_User.Text = ConfigurationManager.AppSettings["Intranet-User"];
            Intranet_Pass.Password = ConfigurationManager.AppSettings["Intranet-Pass"];
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            Btn_Login.IsEnabled = false;
            Btn_Login.Content = "登录中";

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Intranet-User"].Value = Intranet_User.Text;
            config.AppSettings.Settings["Intranet-Pass"].Value = Intranet_Pass.Password;
            config.Save();

            if (Intranet.Login(Intranet_User.Text, Intranet_Pass.Password))
            {
                MessageBox.Show("登录成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                Btn_Login.Content = "登录成功";
            } else
            {
                MessageBox.Show("登录失败", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                Btn_Login.IsEnabled = true;
                Btn_Login.Content = "登录";

            }
        }
    }
}