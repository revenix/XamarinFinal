using System;
using System.Windows.Input;

public class DelegateCommandExt<T> : ICommand
{
    public event EventHandler CanExecuteChanged;

    public DelegateCommandExt(Action<T> execute) : this(execute, null)
    {
    }

    public DelegateCommandExt(Action<T> execute, Predicate<T> canExecute)
    {
        m_execute = execute;
        m_canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        if (this.m_canExecute == null)
        {
            return true;
        }

        return m_canExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
        this.m_execute((T)parameter);
    }

    public void RaiseCanExecuteChanged()
    {
        var handler = this.CanExecuteChanged;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }

    readonly Predicate<T> m_canExecute;
    readonly Action<T> m_execute;
}
