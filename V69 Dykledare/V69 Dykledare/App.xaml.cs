using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using V69_Dykledare.Services;
using V69_Dykledare.ViewModels;
using V69_Dykledare.Views;

namespace V69_Dykledare
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            DependencyService.Register<BuddiesViewModel>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
