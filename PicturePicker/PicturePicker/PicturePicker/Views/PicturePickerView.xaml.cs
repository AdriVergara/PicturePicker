using PicturePicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicturePicker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PicturePickerView : ContentPage
	{
		public PicturePickerView ()
		{
            BindingContext = new PicturePickerViewModel();

            InitializeComponent();
        }
    }
}