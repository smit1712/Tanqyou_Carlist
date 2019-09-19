using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;

namespace CarList.ViewModels
{
    class CarDetailsPageViewModel : BindableBase, INavigationAware
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
        private Guid CarId;
        private Car _DetailedCar;
        public Car DetailedCar
        {
            get { return _DetailedCar; }
            set
            {
                SetProperty(ref _DetailedCar, value);
            }
        }
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigationCommand));

        public CarDetailsPageViewModel(INavigationService navigationService)
        {
            Title = "CarDetailsPage";
            _navigationService = navigationService;


        }
        async void ExecuteNavigationCommand()
        {
            var result = await _navigationService.NavigateAsync("CarListPage");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            CarId = parameters.GetValue<Guid>("ID");
            carService = parameters.GetValue<CarService>("CarService");
            DetailedCar = carService.GetCarDetails(CarId);
        }
    }
}
