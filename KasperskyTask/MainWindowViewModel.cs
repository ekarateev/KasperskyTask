using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KasperskyTask
{
    class MainWindowViewModel : DependencyObject
    {        
        public string ColorTheme
        {
            get { return (string)GetValue(ColorThemeProperty); }
            set { SetValue(ColorThemeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ColorTheme.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorThemeProperty =
            DependencyProperty.Register("ColorTheme", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata("White"));


        public string Logo
        {
            get { return (string)GetValue(LogoProperty); }
            set { SetValue(LogoProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Logo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LogoProperty =
            DependencyProperty.Register("Logo", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata("img/logowhite.png"));


        public string Background
        {
            get { return (string)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata("img/unknown.jpg"));



        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(null));


        public string SubMessage
        {
            get { return (string)GetValue(SubMessageProperty); }
            set { SetValue(SubMessageProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SubMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubMessageProperty =
            DependencyProperty.Register("SubMessage", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(null));


        public string ReportButtonVisiblity
        {
            get { return (string)GetValue(ReportButtonVisiblityProperty); }
            set { SetValue(ReportButtonVisiblityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ShowReportButton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReportButtonVisiblityProperty =
            DependencyProperty.Register("ReportButtonVisiblity", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata("Visible"));




        public int ErrorCounter
        {
            get { return (int)GetValue(ErrorCounterProperty); }
            set { SetValue(ErrorCounterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorCounter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorCounterProperty =
            DependencyProperty.Register("ErrorCounter", typeof(int), typeof(MainWindowViewModel), new PropertyMetadata(0, ErrorCounter_Changed));

        private static void ErrorCounter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindowViewModel currentWindow = d as MainWindowViewModel;
            if (currentWindow.ErrorCounter > 0)
                CurrentState = StateList.Where(x => x.Name == "Warning").FirstOrDefault();
            else if (currentWindow.ErrorCounter == 0)
                CurrentState = StateList.Where(x => x.Name == "Unknown").FirstOrDefault();  //counter was reset
            else
                CurrentState = StateList.Where(x => x.Name == "Ok").FirstOrDefault();   //errors not found
            ((MainWindowViewModel)d).RefreshState();
        }

        private static StateModel[] StateList;
        private static StateModel CurrentState;
        public MainWindowViewModel()
        {
            StateList = StateModel.GetDefaultStateModelList();
            CurrentState = StateList.Where(x => x.Name == "Unknown").FirstOrDefault();
            RefreshState();
        }
        private void RefreshState()
        {
            ColorTheme = CurrentState.ColorTheme;
            Logo = CurrentState.Logo;
            Background = CurrentState.Background;
            Message = CurrentState.Message.Replace("#", ErrorCounter.ToString());
            SubMessage = CurrentState.SubMessage;
            ReportButtonVisiblity = CurrentState.ReportVisible ? "Visible":"Hidden";
        }
    }
}
