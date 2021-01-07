using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using Tires1._01.Annotations;

namespace Tires1._01
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private ApplicationContext db;
        private IEnumerable<Tire> tires;
        public IEnumerable<Tire> Tires
        {
            get { return tires; }
            set
            {
                tires = value;
                OnPropertyChanged("Tires");
            }
        }

        public ApplicationViewModel()
        {
            db = new ApplicationContext();
            db.tires.Load();
            Tires = db.tires.Local.ToBindingList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}