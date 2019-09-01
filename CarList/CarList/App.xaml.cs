using Prism.Ioc;
using Prism.Unity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unity;
using Prism.Navigation;
using CarList.ViewModels;
using Unity.Lifetime;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CarList
{
    public partial class App : PrismApplication
    {
        IUnityContainer unityContainer = new UnityContainer();
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.CarListPage>("CarListPage");
            containerRegistry.RegisterForNavigation<Views.CarDetailsPage>("CarDetailsPage");

            unityContainer.RegisterType<ICarService, CarService>();
            unityContainer.RegisterType<CarListPageViewModel>(new ContainerControlledLifetimeManager());
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            var navigationParams = new NavigationParameters();
            navigationParams.Add("UnityContainer", unityContainer);
            var result = await NavigationService.NavigateAsync("CarListPage", navigationParams);

        }
    }
}   
