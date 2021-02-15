using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tires1._01.ViewModel
{
    public class MainPageViewModel :  ViewModelBase, IPageViewModel, IBaseCommands
    {
        #region Fields
        private SelectorViewModel _selectorViewModel = new SelectorViewModel();
        private IEnumerable<Tire> _tires;
        private Tire _selectedTire;
        private RelayCommand _selectCommand;
        private RelayCommand _addToFavoriteCommand;
        private RelayCommand _webSearchCommand;
        private RelayCommand _sortByPriceLow;
        private RelayCommand _sortByPriceHigh;
        #endregion


        #region Properties/Commands
        public string Name => "Main";

        public SelectorViewModel SelectorViewModel
        {
            get => _selectorViewModel;
            set => SetProperty(ref _selectorViewModel, value);
        }


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
        public RelayCommand SortByPriceLow
        {
            get
            {
                return _sortByPriceLow ??= new RelayCommand(obj =>
                {
                    Tires = Tires?.ToList().OrderBy(tire => tire.Price);
                });
            }
        }
        public RelayCommand SortByPriceHigh
        {
            get
            {
                return _sortByPriceHigh ??= new RelayCommand(obj =>
                {
                    Tires = Tires?.ToList().OrderByDescending(tire => tire.Price);
                });
            }
        }
        public  RelayCommand SelectCommand
        {
            get
            {
                return _selectCommand ??= new RelayCommand(obj =>
                {
                    Tires = null;
                    Tires = _selectorViewModel.Select.SelectByParam(_selectorViewModel.InputParams.GiveParams());
                });
            }
        }


        #endregion


        public MainPageViewModel()
        {
        }


        public void CheckElement()
        {
            using (FavoriteContext db = new FavoriteContext())
            {
                db.favoriteTires.Load();
                if (db.favoriteTires.Any(o => o.id == SelectedTire.id))
                {
                    
                }
                else
                {
                    db.favoriteTires.Add(SelectedTire);
                }

                db.SaveChanges();
            }
        }
    }
}