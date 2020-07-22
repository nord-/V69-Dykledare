using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Timers;
using Acr.UserDialogs;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using V69_Dykledare.Models;

namespace V69_Dykledare.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BuddiesViewModel
    {
        private Timer _timer = new Timer(1000);
        private RelayCommand<Buddy> _startStopCommand;

        public BuddiesViewModel()
        {
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        public ObservableCollection<Buddy> Buddies { get; set; }
        public Buddy SelectedBuddy { get; set; }

        public bool BuddyIsSelected => SelectedBuddy != null;

        public RelayCommand<Buddy> StartStopCommand => _startStopCommand ?? new RelayCommand<Buddy>(async b => await StartStopBuddy(b));

        private async Task StartStopBuddy(Buddy buddy)
        {
            if (buddy.DiveActive)
            {
                // stop dive
                buddy.DiveEnd = DateTime.Now;
                return;
            }

            // start dive
            if (buddy.DiveStart.HasValue)
            {
                var reset = await UserDialogs.Instance.ConfirmAsync("Återställ dyktid?", "Reset", "Ja", "Nej");
                if (reset)
                {
                    buddy.DiveStart = DateTime.Now;
                }
                buddy.DiveEnd = null;
            }
            else
            {
                buddy.DiveStart = DateTime.Now;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var dt = DateTime.Now;
            foreach (var buddy in Buddies)
                buddy.CurrentTime = dt;
        }
    }
}
