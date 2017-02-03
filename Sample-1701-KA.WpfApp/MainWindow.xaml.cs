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

namespace Sample_1701_KA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SampleParser Parser = new SampleParser();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnMainWindow_Loaded;
        }

        private void OnMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = Parser;
            tbInput.Text = "Type or paste your text here. Your text will automatically analyzed.";
        }

        private void tbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Parser.Input = tbInput.Text;
        }

        private void OnReqButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(CodeRequirements.ToString(), "Sample Code Requirements.",MessageBoxButton.OK);
        }
    }
}
