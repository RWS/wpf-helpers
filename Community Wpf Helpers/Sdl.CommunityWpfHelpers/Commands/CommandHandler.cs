﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Sdl.CommunityWpfHelpers.Commands
{
	/// <summary>
	/// Command without any parameters
	/// </summary>
	public class CommandHandler : ICommand, INotifyPropertyChanged
	{
		public event EventHandler CanExecuteChanged;
		public event PropertyChangedEventHandler PropertyChanged;
		private readonly Action _action;
		private readonly bool _canExecute;
		public CommandHandler(Action action, bool canExecute)
		{
			_action = action;
			_canExecute = canExecute;
		}

		public CommandHandler(bool canExecute)
		{
			_canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute;
		}

		public void Execute(object parameter)
		{
			_action();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
