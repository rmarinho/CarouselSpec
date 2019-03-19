using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarouselSpec
{
	[Xamarin.Forms.Internals.Preserve(AllMembers = true)]
	public class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual ViewModelBase SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			field = value;
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
			return this;
		}
	}
}
