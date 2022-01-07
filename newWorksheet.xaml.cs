using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DZ_5
{
    /// <summary>
    /// Логика взаимодействия для newWorksheet.xaml
    /// </summary>
    public partial class newWorksheet : Window
    {
       
        public newWorksheet()
        {
            InitializeComponent();
        }
        private void Sumbit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
        
    }
}
