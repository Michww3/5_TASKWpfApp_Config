using System;
using System.Collections.Generic;
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
using System.Configuration;

namespace _5_TASKWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void Save_button_Click(object sender, RoutedEventArgs e)
        {
            string textColor = textcolor.Text;
            string backgroundColor = backgroundcolor.Text;
            string fontStyle = fontstyle.Text;
            string fontSize = fontsize.Text;

            try
            {

                TEXTBLOCK.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColor));
                Pref_Window.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
                TEXTBLOCK.FontSize = int.Parse(fontSize);
                TEXTBLOCK.FontFamily = new FontFamily(fontStyle);

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["TextColor"].Value = textColor;
                config.AppSettings.Settings["BackgroundColor"].Value = backgroundColor;
                config.AppSettings.Settings["FontStyle"].Value = fontStyle;
                config.AppSettings.Settings["FontSize"].Value = fontSize;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadSettings()
        {
            try
            {
                string textColor = ConfigurationManager.AppSettings["TextColor"];
                string backgroundColor = ConfigurationManager.AppSettings["BackgroundColor"];
                string fontStyle = ConfigurationManager.AppSettings["FontStyle"];
                string fontSize = ConfigurationManager.AppSettings["FontSize"];

                TEXTBLOCK.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(textColor));
                Pref_Window.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
                TEXTBLOCK.FontSize = int.Parse(fontSize);
                TEXTBLOCK.FontFamily = new FontFamily(fontStyle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
    
