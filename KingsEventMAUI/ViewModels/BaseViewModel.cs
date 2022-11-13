using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingsEventMAUI.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(isNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool isNotBusy => !isBusy;
        public BaseViewModel()
        {

        }
    }
}
