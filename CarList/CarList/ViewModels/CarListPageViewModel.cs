using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Unity;
using Xamarin.Forms;

namespace CarList.ViewModels
{
    class CarListPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private DelegateCommand _navigateCommand;
        private INavigationService _navigationService;
        private CarService carService;
        public ObservableCollection<Car> CarCollection { get; set; }
        public Car SelectedCar { get; set; }
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigationCommand));

        public CarListPageViewModel(INavigationService navigationService)
        {

            Title = "CarListPage";
            _navigationService = navigationService;
            CarCollection = new ObservableCollection<Car>();

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
            carService = unity.Resolve<CarService>();

            foreach (Car c in carService.GetCars())
            {
                CarCollection.Add(c);
            }
        }
        public ICommand SelectCommand => new Command(() =>
        {
            Console.WriteLine(SelectedCar);
            NavigationParameters np = new NavigationParameters
            {
                { "ID", SelectedCar.Id },
                { "CarService", carService}
            };
            var result = _navigationService.NavigateAsync("CarDetailsPage", np);
        });
    }
}
