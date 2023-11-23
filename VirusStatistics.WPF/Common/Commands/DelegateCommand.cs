﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VirusStatistics.WPF.Common.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private Action<object> _execute;
        private Func<bool> _predicate;
        public DelegateCommand(Action<object> executeMethod, Func<bool> predicate = null)
        {
            _execute = executeMethod;
            _predicate = predicate;
        }
        public bool CanExecute(object? parameter)
        {
            if (_predicate == null)
                return true;
            return _predicate.Invoke();
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
