using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VirusStatistics.WPF.Common;
using VirusStatistics.WPF.Common.Commands;

namespace VirusStatistics.WPF.ViewModels
{
    internal class LoginVM : BaseVM
    {
        public ICommand CommandCloseApplication { get; }
        public LoginVM()
        {
            CommandCloseApplication = new DelegateCommand(x => Application.Current.Shutdown());
        }
    }
}
