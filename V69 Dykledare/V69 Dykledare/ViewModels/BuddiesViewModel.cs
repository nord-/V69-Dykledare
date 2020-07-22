using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using V69_Dykledare.Models;

namespace V69_Dykledare.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BuddiesViewModel
    {
        public ObservableCollection<Buddies> Buddies { get; set; }
    }
}
