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

namespace VirusStatistics.WPF.CustomControls
{
    /// <summary>
    /// Interaction logic for TextBoxWithTopTooltip.xaml
    /// </summary>
    public partial class TextBoxWithTopTooltip : UserControl
    {
        public TextBoxWithTopTooltip()
        {
            InitializeComponent();
        }
        public string _ToolTip
        {
            get { return (string)GetValue(_ToolTipProperty); }
            set { SetValue(_ToolTipProperty, value); }
        }
        public static readonly DependencyProperty _ToolTipProperty =
            DependencyProperty.Register("_ToolTip", typeof(string), typeof(TextBoxWithTopTooltip), new PropertyMetadata(string.Empty));
        public string _Text
        {
            get { return (string)GetValue(_TextProperty); }
            set { SetValue(_TextProperty, value); }
        }
        public static readonly DependencyProperty _TextProperty =
            DependencyProperty.Register("_Text", typeof(string), typeof(TextBoxWithTopTooltip), new PropertyMetadata(string.Empty));

    }
}
