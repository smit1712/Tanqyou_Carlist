using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Unity;
using Xamarin.Forms;

namespace CarList.ViewModels
{
    class CarListPageViewModel : BindableBase, INavigationAware, INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _DeviceType = "No type known";
        public string DeviceType
        {
            get { return _DeviceType; }
            set { SetProperty(ref _DeviceType, value); }
        }
        private DelegateCommand _navigateCommand;
        private INavigationService _navigationService;
        private ICarService _carService;
        private IDeviceService _deviceService;
        public ObservableCollection<Car> CarCollection { get; set; }
        public Car SelectedCar { get; set; }

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigationCommand));

        public CarListPageViewModel(INavigationService navigationService, ICarService carService, IDeviceService deviceService)
        {
            Title = "CarListPage";
            _navigationService = navigationService;
            CarCollection = new ObservableCollection<Car>();
            _carService = carService;
            _deviceService = deviceService;
        }
        async void ExecuteNavigationCommand()
        {
            var result = await _navigationService.NavigateAsync("CarDetailsPage");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            UnityContainer unity = parameters.GetValue<UnityContainer>("UnityContainer");
            _carService = unity.Resolve<CarService>();
            DeviceType = "Wat een mooie " + _deviceService.GetDeviceOS() + " telefoon heb jij! :)’";
            foreach (Car c in _carService.GetCars())
            {
                CarCollection.Add(c);
            }
        }

        public ICommand AddCarCommand => new Command(() =>
        {
            
            var result = _navigationService.NavigateAsync("AddCarPage");
        });

        public ICommand SelectCommand => new Command(() =>
            {
                NavigationParameters np = new NavigationParameters
                {
                { "ID", SelectedCar.Id },
                { "CarService", _carService}
                };
                var result = _navigationService.NavigateAsync("CarDetailsPage", np);
            });
    }
}
