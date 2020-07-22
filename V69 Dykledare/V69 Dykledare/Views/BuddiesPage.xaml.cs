using System.Collections.ObjectModel;
using System.Linq;
using V69_Dykledare.Models;
using V69_Dykledare.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace V69_Dykledare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuddiesPage : ContentPage
    {
        private BuddiesViewModel _viewModel;

        public BuddiesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = DependencyService.Get<BuddiesViewModel>();
            _viewModel.Buddies = new ObservableCollection<Buddy>(new[]
                                                                 {
                                                                     new Buddy
                                                                     {
                                                                         MaxDepth = 20, MaxTime  = 1, Index = 1,
                                                                         Divers = new ObservableCollection<Diver>(new[]
                                                                                                                  {
                                                                                                                      new Diver {Name = "Rickard Nord"},
                                                                                                                      new Diver {Name = "Peter Mattsson"}
                                                                                                                  })
                                                                     },
                                                                     new Buddy
                                                                     {
                                                                         MaxDepth = 30, MaxTime  = 70, Index = 2,
                                                                         Divers = new ObservableCollection<Diver>(new[]
                                                                                                                  {
                                                                                                                      new Diver {Name = "Rickard Larsson"},
                                                                                                                      new Diver {Name = "Jonas Stenström"}
                                                                                                                  })
                                                                     }
                                                                 });


        }
    }
}