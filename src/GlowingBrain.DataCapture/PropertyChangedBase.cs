using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GlowingBrain.DataCapture
{
	public abstract class PropertyChangedBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected PropertyChangedBase ()
		{
		}

		protected virtual bool Set<T> (ref T member, T newValue, [CallerMemberName] String propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals (member, newValue)) {
				return false;
			}

			member = newValue;
			NotifyPropertyChanged (propertyName);
			return true;
		}

		protected virtual void NotifyPropertyChanged ([CallerMemberName] String propertyName = "")
		{
			OnPropertyChanged (new PropertyChangedEventArgs (propertyName));	
		}

		protected virtual void OnPropertyChanged (PropertyChangedEventArgs e)
		{
			var handler = this.PropertyChanged;
			if (handler != null) {
				handler (this, e);
			}
		}
	}
}
