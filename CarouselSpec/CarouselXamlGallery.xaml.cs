﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CarouselSpec
{
	[Xamarin.Forms.Internals.Preserve(AllMembers = true)]
	public partial class CarouselXamlGallery : ContentPage
	{
		public CarouselXamlGallery()
		{
			InitializeComponent();
			BindingContext = new CarouselViewModel(CarouselXamlSampleType.Peek);
			carouselNormal.BindingContext = new CarouselViewModel(CarouselXamlSampleType.Normal);
		}
	}

	[Xamarin.Forms.Internals.Preserve(AllMembers = true)]
	public enum CarouselXamlSampleType
	{
		Normal,
		Peek
	}

	[Xamarin.Forms.Internals.Preserve(AllMembers = true)]
	internal class CarouselViewModel : ViewModelBase
	{
		int _count;
		int _position;
		ObservableCollection<CarouselItem> _items;
		CarouselXamlSampleType _type;
		public CarouselViewModel(CarouselXamlSampleType type, int intialItems = 5)
		{
			_type = type;

			var items = new List<CarouselItem>();
			for (int i = 0; i < intialItems; i++)
			{
				switch (_type)
				{
					case CarouselXamlSampleType.Peek:
						items.Add(new CarouselItem(i, "cardBackground"));
						break;
					default:
						items.Add(new CarouselItem(i));
						break;
				}
			}

			MessagingCenter.Subscribe<ExampleTemplateCarousel>(this, "remove", (obj) => Items.Remove(obj.BindingContext as CarouselItem));

			Items = new ObservableCollection<CarouselItem>(items);
			Items.CollectionChanged += ItemsCollectionChanged;
			Count = Items.Count - 1;
		}

		void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			Count = Items.Count - 1;
		}

		public int Count
		{
			get { return _count; }
			set { SetProperty(ref _count, value); }
		}

		public int Position
		{
			get { return _position; }
			set { SetProperty(ref _position, value); }
		}

		public ObservableCollection<CarouselItem> Items
		{
			get { return _items; }
			set { SetProperty(ref _items, value); }
		}
	}

	[Xamarin.Forms.Internals.Preserve(AllMembers = true)]
	internal class CarouselItem
	{
		public CarouselItem(int index, string image = null)
		{
			if (!string.IsNullOrEmpty(image))
				FeaturedImage = image;
			Index = index;
			Image = "https://placeimg.com/700/300/any";
		}

		public int Index { get; set; }

		public string Image { get; set; }

		public string FeaturedImage { get; set; }
	}
}
