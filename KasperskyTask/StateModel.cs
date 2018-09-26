using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KasperskyTask
{
    class StateModel
    {
        public string Name { get; set; }
        //color b/w
        public string ColorTheme { get; set; }
        //logo img
        public string Logo { get; set; }
        //background img
        public string Background { get; set; }
        //Message Label
        public string Message { get; set; }
        public string SubMessage { get; set; }
        //button report
        public bool ReportVisible { get; set; }


        public static StateModel[] GetDefaultStateModelList()
        {
            return new StateModel[]
            {
                new StateModel
                {
                    Name = "Unknown",
                    ColorTheme = "White",
                    Logo = "img/logowhite.png",
                    Background = "img/unknown.jpg",
                    Message = "Scanning Required",
                    SubMessage = "Scanning has not been run yet",
                    ReportVisible = false
                },
                new StateModel
                {
                    Name = "Ok",
                    ColorTheme = "White",
                    Logo = "img/logowhite.png",
                    Background = "img/ok.jpg",
                    Message = "Great news! No problem found, but we"+Environment.NewLine+"recommend to install an anti-virus solutioin",
                    SubMessage = null,
                    ReportVisible = true
                },
                new StateModel
                {
                    Name = "Warning",
                    ColorTheme = "Black",
                    Logo = "img/logoblack.png",
                    Background = "img/warning.jpg",
                    Message = "Scan result indicate # problems found",
                    SubMessage = null,
                    ReportVisible = true
                }
            };
        }
    }
}
