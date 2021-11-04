
using System.ComponentModel;
using TODOList.Model;
using TODOList.Service;
using Xamarin.Forms;

namespace TODOList.ViewModel
{
    public class NameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        INameService _rest = DependencyService.Get<INameService>();

        public NameViewModel()
        {
            GetName();
        }

        public async void GetName()
        {
            var result = await _rest.getName();

            if (result != null)
            {
                //nameStats = result;
            }
        }

        private NameStat nameStats;

        public NameStat NameStats
        {
            get { return nameStats; }
            set
            { nameStats = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameStats"));
            }
        }
    }
}
