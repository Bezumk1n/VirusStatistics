using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VirusStatistics.Application.Users.Queries.GetUserById;
using VirusStatistics.WPF.Common;
using VirusStatistics.WPF.Common.Commands;

namespace VirusStatistics.WPF.ViewModels
{
    internal class LoginVM : BaseVM
    {
        public bool IsSignInView
        {
            get => _isSignInView;
            set
            {
                _isSignInView = value;
                OnPropertyChanged();
                OnPropertyChanged(() => IsSignUpView);
            }
        }
        private bool _isSignInView = true;
        public bool IsSignUpView => !IsSignInView;
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand CommandCloseApplication { get; }
        public ICommand CommandSignUp { get; }
        public LoginVM()
        {
            CommandCloseApplication = new DelegateCommand(x => System.Windows.Application.Current.Shutdown());
            CommandSignUp = new DelegateCommand(x => IsSignInView = !IsSignInView);
        }
    }
}
