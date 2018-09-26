using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KasperskyTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowViewModel();
            SetDefaults();
        }

        private void SetDefaults()
        {

        }

        private void TitleGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Implemented");
        }

        private void CustomScan_Click(object sender, RoutedEventArgs e)
        {
            ScanButtonPressed(sender);
        }
        private void CustomScan_MouseEnter(object sender, MouseEventArgs e)
        {
            popUp(sender);
        }
        private void CustomScan_MouseLeave(object sender, MouseEventArgs e)
        {
            popDown(sender);
        }

        private void ComputerScan_Click(object sender, RoutedEventArgs e)
        {
            ScanButtonPressed(sender);
        }
        private void ComputerScan_MouseEnter(object sender, MouseEventArgs e)
        {
            popUp(sender);
        }
        private void ComputerScan_MouseLeave(object sender, MouseEventArgs e)
        {
            popDown(sender);
        }

        private void SoftwareScan_Click(object sender, RoutedEventArgs e)
        {
            ScanButtonPressed(sender);
        }
        private void SoftwareScan_MouseEnter(object sender, MouseEventArgs e)
        {
            popUp(sender);
        }
        private void SoftwareScan_MouseLeave(object sender, MouseEventArgs e)
        {
            popDown(sender);
        }




        private bool flagScanInProcess = false;
        private void ScanButtonPressed(object sender)
        {
            ((MainWindowViewModel)this.DataContext).ErrorCounter = 0;
            ScanButtonControl btnW = sender as ScanButtonControl;

            if (flagScanInProcess) //if no one started
            {
                MessageBox.Show("Scanning already in progress...");
                return;
            }
            flagScanInProcess = true; //set started flag
            btnW.PictureVisiblity = "Hidden";   //hide image on button
            //btnW.ProgressBarValue = 0;
            btnW.ProgressVisiblity = "Visible"; //sjow progress bar
            ProgressBarTest(btnW);  //start 'scanning' process
        }
        AutoResetEvent handle;
        private void ProgressBarTest(ScanButtonControl btnW)
        {
            handle = new AutoResetEvent(false);
            ThreadPool.QueueUserWorkItem((o) =>
            {
                int err=0;
                List<int> steps = new List<int>();  //steps where problems would be found
                for (int i=0; i<3; i++) //  max 3
                    steps.Add((new Random()).Next(i, 100)); //random step number
                for (int i = 0; i <= 100; i++)
                {
                    this.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        btnW.ProgressBarValue = i;
                        if (steps.Contains(i))
                        {
                            Thread.Sleep(200);  //very hard processnig
                            err += (new Random()).Next(0, 2);   // 50/50 decigion
                        }
                    }));
                    Thread.Sleep(100);
                }
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (err > 0) ((MainWindowViewModel)this.DataContext).ErrorCounter += err;
                    else ((MainWindowViewModel)this.DataContext).ErrorCounter = -1; //no errors flag
                    ScanFinished(btnW);                    
                }));
            });
        }

        private void ScanFinished(ScanButtonControl btnW)
        {
                //restore all values
                flagScanInProcess = false;
                btnW.PictureVisiblity = "Visible";
                btnW.ProgressVisiblity = "Hidden";
                MessageBox.Show(btnW.Name + "ing succsesfully finished!");
        }

        private void popUp(object sender)
        {
            //animation for scan button
            ScanButtonControl btnW = sender as ScanButtonControl;
            const double time = 0.5;
            DoubleAnimation wa = new DoubleAnimation(135, 225, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.WidthProperty, wa);
            DoubleAnimation ha = new DoubleAnimation(175, 256, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.HeightProperty, ha);
            DoubleAnimation esa = new DoubleAnimation(1, 2, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.ElStrokeThicknessProperty, esa);
            DoubleAnimation ia = new DoubleAnimation(50, 100, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.ImgSizeProperty, ia);
            DoubleAnimation pfa = new DoubleAnimation(25, 30, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.PersentFontSizeProperty, pfa);
            DoubleAnimation psa = new DoubleAnimation(13, 15, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.PercentSignSizeProperty, psa);
            DoubleAnimation sha = new DoubleAnimation(0, 105, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.VerticalShiftProperty, sha);

        }
        private void popDown(object sender)
        {
            //restore
            ScanButtonControl btnW = sender as ScanButtonControl;
            const double time = 0.5;
            DoubleAnimation wa = new DoubleAnimation(225, 135, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.WidthProperty, wa);
            DoubleAnimation ha = new DoubleAnimation(256, 175, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.HeightProperty, ha);
            DoubleAnimation esa = new DoubleAnimation(2, 1, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.ElStrokeThicknessProperty, esa);
            DoubleAnimation ia = new DoubleAnimation(100, 50, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.ImgSizeProperty, ia);
            DoubleAnimation pfa = new DoubleAnimation(30, 25, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.PersentFontSizeProperty, pfa);
            DoubleAnimation psa = new DoubleAnimation(15, 14, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.PercentSignSizeProperty, psa);
            DoubleAnimation sha = new DoubleAnimation(105, 0, TimeSpan.FromSeconds(time));
            btnW.BeginAnimation(ScanButtonControl.VerticalShiftProperty, sha);
        }

    }
}
