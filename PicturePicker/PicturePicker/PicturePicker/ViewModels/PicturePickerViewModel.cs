using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

//FilePicker
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using PicturePicker.Models;

namespace PicturePicker.ViewModels
{
    public class PicturePickerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddImage { get; set; }

        public PicturePickerViewModel()
        {
            AddImage = new Command(async () => await AddImageCommand());
        }

        private byte[] _imageData { get; set; }
        public byte[] ImageData
        {
            get
            {
                return _imageData;
            }
            set
            {
                _imageData = value;
                OnPropertyChanged("ImageData");
            }
        }

        public object _imgSource { get; set; }
        public object ImgSource
        {
            get
            {
                return _imgSource;
            }
            set
            {
                _imgSource = value;
                OnPropertyChanged("ImgSource");
            }
        }

        private string _fileName { get; set; }
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public async Task AddImageCommand()
        {
            FileData filedata = await CrossFilePicker.Current.PickFile();

            //Getting the filename and the data info from the image picked
            FileName = filedata.FileName;
            _imageData = filedata.DataArray;

            //Convert from data info to image 
            ByteArrayToImageSourceConverter converter = new ByteArrayToImageSourceConverter();

            //Image that will be displayed
            ImgSource = converter.Convert(_imageData, null, null, culture: System.Globalization.CultureInfo.CurrentCulture);
        }
    }
}
