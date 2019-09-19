using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unity;
using Prism.Navigation;
using CarList.ViewModels;
using Unity.Lifetime;
using Prism;
using CarList.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CarList
{
    public partial class App : PrismApplication
    {
        IPlatformInitializer _platformInitializer;
        IContainerRegistry _containerRegistry;

        IUnityContainer unityContainer = new UnityContainer();

        public App(IPlatformInitializer platformInitializer) :base(platformInitializer)
        { 
            _platformInitializer = platformInitializer;
            //_platformInitializer.RegisterTypes(_containerRegistry);
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _containerRegistry = containerRegistry;

            containerRegistry.RegisterForNavigation<Views.CarListPage>("CarListPage");
            containerRegistry.RegisterForNavigation<Views.CarDetailsPage>("CarDetailsPage");
            containerRegistry.RegisterForNavigation<Views.AddCarPage>("AddCarPage");

            containerRegistry.Register(typeof(ICarService), typeof(CarService));
            unityContainer.RegisterType<CarListPageViewModel>(new ContainerControlledLifetimeManager());
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var navigationParams = new NavigationParameters
            {
                { "UnityContainer", unityContainer }
            };
            MainPage = new NavigationPage(new CarListPage());

            var result = await NavigationService.NavigateAsync("CarListPage", navigationParams);

        }
    }
}   
