using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICAO
{
    public class DelegateCommand : System.Windows.Input.ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;


        public DelegateCommand(Action<object> execute_)
        {
            _execute = execute_;
        }

        public DelegateCommand(Action<object> execute_, Predicate<object> canExecute_)
        {
            if (execute_ != null)
            {
                _execute = execute_;
                _canExecute = canExecute_;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute(parameter);
            }
        }
    }
}
