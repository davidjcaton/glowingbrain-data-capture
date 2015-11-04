using System;
using System.Windows.Input;

namespace GlowingBrain.DataCapture
{
	public abstract class CommandBase : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute (object parameter)
		{
			return OnCanExecute (parameter);
		}

		public void Execute (object parameter)
		{
			OnExecute (parameter);
		}

		public virtual void RaiseCanExecuteChanged ()
		{
			var handler = CanExecuteChanged;
			if (handler != null) {
				handler (this, new EventArgs ());
			}
		}

		protected abstract bool OnCanExecute (object parameter);

		protected abstract void OnExecute (object parameter);
	}

	public class DelegateCommand : DelegateCommand<object>
	{
		public DelegateCommand (Action<object> executeDelegate, Func<object, bool> canExecuteDelegate = null)
			: base (executeDelegate, canExecuteDelegate)
		{
		}
	}

	public class DelegateCommand<T> : CommandBase
	{
		readonly Action<T> _executeDelegate;
		readonly Func<T, bool> _canExecuteDelegate;

		public DelegateCommand (Action<T> executeDelegate, Func<T, bool> canExecuteDelegate = null)
		{
			_executeDelegate = executeDelegate;
			_canExecuteDelegate = canExecuteDelegate ?? (_ => true);
		}

		protected override void OnExecute (object parameter)
		{
			_executeDelegate ((T)parameter);
		}

		protected override bool OnCanExecute (object parameter)
		{
			return _canExecuteDelegate ((T)parameter);
		}
	}
}

