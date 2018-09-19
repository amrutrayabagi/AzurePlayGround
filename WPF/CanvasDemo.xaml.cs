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

namespace WPFSample
{
    /// <summary>
    /// Interaction logic for CanvasDemo.xaml
    /// </summary>
    public partial class CanvasDemo : Page
    {
        public CanvasDemo()
        {
            InitializeComponent();

            StackPanel panel = new StackPanel();
            Button newBUtton = new Button
            {
                Content = "Dropped Programatically",
                
            };
            panel.Children.Add(newBUtton);
            
            
            this.CanvasElement.Children.Add(panel);
            Canvas.SetTop(panel, 100);
        }

        private void Button_DragOver(object sender, DragEventArgs e)
        {

        }
    }
}
