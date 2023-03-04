using System.Windows.Input;
using System;

namespace DemoLight.WpfView.ViewModels;

public class CommonCommand : ICommand
{
    private readonly Action _execute;

    public CommonCommand(Action execute) => _execute = execute;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => _execute?.Invoke();

    public event EventHandler? CanExecuteChanged;
}

public class CommonCommand<T> : ICommand
{
    private readonly Action<T?> _execute;

    public CommonCommand(Action<T?> execute) => _execute = execute;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter) => _execute?.Invoke((T?)parameter);

    public event EventHandler? CanExecuteChanged;
}