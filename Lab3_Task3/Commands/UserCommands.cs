using System;
using System.Windows.Input;

namespace Lab3_Task3.Commands
{
    internal class UserCommands : ICommand
    {
        Action commandFun;

        public event EventHandler CanExecuteChanged;
        public UserCommands(Action _myfun)
        {
            commandFun = _myfun;
        }
        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            commandFun();
        }
    }
}
