using System;
using System.Windows.Input;

namespace ViewModel
{
    public class CommandBasic : ICommand
    {
        private Action<object> execute;
        private Func<bool> canExecute;

        public CommandBasic(Action<object> execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute();
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
