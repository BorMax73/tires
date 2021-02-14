using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace Tires1._01.ViewModel
{
    public class FavoritePageViewModel : ViewModelBase, IPageViewModel, IBaseCommands
    {
        #region Fields

        
        private IEnumerable<Tire> _tires;
        private Tire _selectedTire;
        private RelayCommand _addToFavoriteCommand;
        private RelayCommand _webSearchCommand;

        #endregion

        #region Properties/Commands
        public string Name => "Favorite";

        public IEnumerable<Tire> Tires
        {
            get => _tires;
            set => SetProperty(ref _tires, value);
        }

        public Tire SelectedTire
        {
            get => _selectedTire;
            set => SetProperty(ref _selectedTire, value);
        }


        public RelayCommand AddCommand
        {
            get
            {
                return _addToFavoriteCommand ??= new RelayCommand(obj =>
                {
                    CheckElement();
                    DBrequest();
                          
                });
            }
        }
        public RelayCommand WebSearchCommand
        {
            get
            {
                return _webSearchCommand ??= new RelayCommand(obj =>
                {
                    Process.Start($"https://www.google.com/search?q={SelectedTire.Name}");
                });
            }
        }


        #endregion

        #region Methods

        public FavoritePageViewModel()
         {
             DBrequest();
         }

        public void DBrequest()
        {
            using (FavoriteContext db = new FavoriteContext())
            {
                db.favoriteTires.Load();
                Tires = db.favoriteTires.Local.ToBindingList();
            }
        }

        public void CheckElement()
        {
            using (FavoriteContext db = new FavoriteContext())
            {
                db.favoriteTires.Load();
                if (db.favoriteTires.Any(o => o.id == SelectedTire.id))
                {
                    Tire tire = db.favoriteTires
                        .FirstOrDefault(o => o.id == SelectedTire.id);
                    db.favoriteTires.Remove(tire);
                    db.SaveChanges();
                }
                else
                {
                    db.favoriteTires.Add(SelectedTire);
                }

            }
            
        }
        #endregion
    }
}