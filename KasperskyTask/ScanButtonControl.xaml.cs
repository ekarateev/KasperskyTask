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

namespace KasperskyTask
{
    /// <summary>
    /// Логика взаимодействия для ScanButtonControl.xaml
    /// </summary>
    public partial class ScanButtonControl : Button
    {


        public object LabelContent
        {
            get { return (object)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }
        // Using a DependencyProperty as the backing store for LabelContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(object), typeof(ScanButtonControl), new PropertyMetadata(null));


        public string ImgPath
        {
            get { return (string)GetValue(ImgPathProperty); }
            set { SetValue(ImgPathProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImgPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgPathProperty =
            DependencyProperty.Register("ImgPath", typeof(string), typeof(ScanButtonControl), new PropertyMetadata(null));


        public double ImgSize
        {
            get { return (double)GetValue(ImgSizeProperty); }
            set { SetValue(ImgSizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImgSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSizeProperty =
            DependencyProperty.Register("ImgSize", typeof(double), typeof(ScanButtonControl), new PropertyMetadata(50.0));


        public double ElStrokeThickness
        {
            get { return (double)GetValue(ElStrokeThicknessProperty); }
            set { SetValue(ElStrokeThicknessProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ElStrokeThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ElStrokeThicknessProperty =
            DependencyProperty.Register("ElStrokeThickness", typeof(double), typeof(ScanButtonControl), new PropertyMetadata(1.0));


        public double PersentFontSize    
        {
            get { return (double)GetValue(PersentFontSizeProperty); }
            set { SetValue(PersentFontSizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for LabelFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PersentFontSizeProperty =
            DependencyProperty.Register("PersentFontSize", typeof(double), typeof(ScanButtonControl), new PropertyMetadata(45.0));

        public double PercentSignSize
        {
            get { return (double)GetValue(PercentSignSizeProperty); }
            set { SetValue(PercentSignSizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for LabelFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentSignSizeProperty =
            DependencyProperty.Register("PercentSignSize", typeof(double), typeof(ScanButtonControl), new PropertyMetadata(20.0));


        public double VerticalShift
        {
            get { return (double)GetValue(VerticalShiftProperty); }
            set { SetValue(VerticalShiftProperty, value); }
        }
        // Using a DependencyProperty as the backing store for VerticalShift.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerticalShiftProperty =
            DependencyProperty.Register("VerticalShift", typeof(double), typeof(ScanButtonControl), new PropertyMetadata(0.0));


        public string PictureVisiblity
        {
            get { return (string)GetValue(PictureVisiblityProperty); }
            set { SetValue(PictureVisiblityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for PictureVisiblity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PictureVisiblityProperty =
            DependencyProperty.Register("PictureVisiblity", typeof(string), typeof(ScanButtonControl), new PropertyMetadata("Visible"));

        public string ProgressVisiblity
        {
            get { return (string)GetValue(ProgressVisiblityProperty); }
            set { SetValue(ProgressVisiblityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ProgressVisiblity.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressVisiblityProperty =
            DependencyProperty.Register("ProgressVisiblity", typeof(string), typeof(ScanButtonControl), new PropertyMetadata("Hidden"));


        public double ProgressBarValue
        {
            get { return (double)GetValue(ProgressBarValueProperty); }
            set { SetValue(ProgressBarValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ProgressBarValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressBarValueProperty =
            DependencyProperty.Register("ProgressBarValue", typeof(double), typeof(ScanButtonControl), new PropertyMetadata(0.0));



        public string ProgressBarBGimg
        {
            get { return (string)GetValue(ProgressBarBGimgProperty); }
            set { SetValue(ProgressBarBGimgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgressBarBGimg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgressBarBGimgProperty =
            DependencyProperty.Register("ProgressBarBGimg", typeof(string), typeof(ScanButtonControl), new PropertyMetadata(null));



        public ScanButtonControl()
        {
            InitializeComponent();
        }
    }
}
