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
using windowfollower.view;

namespace windowfollower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point childpos;
        public MainWindow()
        {
            InitializeComponent();
            childpos = new Point();
            createChildWindow();
        }

        void createChildWindow()
        {
            var child = new childWindow();
            
            // Move child before we attach event handler
            child.Top = this.Top;
            child.Left = this.Left + this.Width + 10;
            child.Show();

            child.LocationChanged += Child_LocationChanged;
            childpos.X = child.Left;
            childpos.Y = child.Top;
        }

        private void Child_LocationChanged(object sender, EventArgs e)
        {
            var child = sender as childWindow;
            // Calculate how far child window moved and move parent (this) the same distance;
            
            var currentChildPos= new Point(child.Left, child.Top);
            var distance = childpos - currentChildPos ;
            childpos = currentChildPos;
            this.Top -= distance.Y;
            this.Left -= distance.X;
        }
    }
}
