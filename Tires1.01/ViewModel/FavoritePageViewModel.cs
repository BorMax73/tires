using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;

namespace Tires1._01.ViewModel
{
    public class FavoritePageViewModel : ViewModelBase, IPageViewModel
    {
        #region Fields

        
        private IEnumerable<Tire> _tires;
        private Tire _selectedTire;
        private RelayCommand _addToFavoriteCommand;
        private RelayCommand _webSearchCommand;

        #endregion

        #region Properties/Commands
        public string Name
        {
            get { return "Favorite"; }
        }

        public IEnumerable<Tire> Tires
        {
            get
            {
                return _tires;
            }
            set
            {
                SetProperty(ref _tires, value);
            }
        }

        public Tire SelectedTire
        {
            get { return _selectedTire; }
            set
            {
                SetProperty(ref _selectedTire, value);
            }
        }


        public RelayCommand AddCommand
        {
            get
            {
                return _addToFavoriteCommand ??
                       (_addToFavoriteCommand = new RelayCommand(obj =>
                       {
                           DBrequest();
                          
                       }));
            }
        }
        public RelayCommand WebSearchCommand
        {
            get
            {
                return _webSearchCommand ??
                       (_webSearchCommand = new RelayCommand(obj =>
                       {
                           Process.Start($"https://www.google.com/search?q={SelectedTire.Name}");
                       }));
            }
        }


        #endregion

        #region Methods

        public FavoritePageViewModel()
         {
             DBrequest();
         }

        private void DBrequest()
        {
            using (FavoriteContext db = new FavoriteContext())
            {
                db.favoriteTires.Load();
                Tires = db.favoriteTires.Local.ToBindingList();
            }
        }
        #endregion
    }
}