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
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;

namespace WpfApppers
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public List<string>justification = new List<string>();
        public Window1(string inv, string justif)
        {
            InitializeComponent();
            justification.Add(justif);
            lbl.Content = inv;
        }
        public void load_listbox(object sender, RoutedEventArgs e)
        {
            liste.ItemsSource = justification;
        }

        private void Liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(File.Exists("justif.csv"))
            Process.Start("justif.csv");
            
            
        }
    }
}
