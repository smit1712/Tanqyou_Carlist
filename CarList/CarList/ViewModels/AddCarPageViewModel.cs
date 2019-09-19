using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace CarList.ViewModels
{
    class AddCarPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private bool _IsValid;
        public bool IsValid
        {
            get { return _IsValid; }
            set
            {
                SetProperty(ref _IsValid, !value);
                RaisePropertyChanged("IsValid"); ;
            }
        }
        private DelegateCommand _navigateCommand;
        private INavigationService _navigationService;
        private CarService carService;

        private string _Kentekenbord;
        public string Kentekenbord
        {
            get { return _Kentekenbord; }
            set { SetProperty(ref _Kentekenbord, value); }
        }
        public AddCarPageViewModel(INavigationService navigationService)
        {
            Title = "CarDetailsPage";
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
