using System;
using System.Windows.Input;

namespace Frontend.Helpers
{
    class ActionCommand : ICommand
    {
        private readonly Action<object> _exec;
        private readonly Predicate<object> _canExec;

        public ActionCommand(Action<object> exec) : this(exec, null) { }
        public ActionCommand(Action<object> exec, Predicate<object> canExec)
        {
            _exec = exec ?? throw new ArgumentNullException("execute");
            _canExec = canExec;
        }

        public bool CanExecute(object param)
        {
            return _canExec == null ? true : _canExec(param);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object param)
        {
            _exec(param);
        }
    }
}
