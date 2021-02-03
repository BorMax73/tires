using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Tires1._01.ViewModel
{
    public class MainPageViewModel : ViewModelBase, IPageViewModel
    {
        #region Fields
        private SelectorViewModel _selectorViewModel = new SelectorViewModel();
        private IEnumerable<Tire> _tires;
        private Tire _selectedTire;
        private RelayCommand _selectCommand;
        private RelayCommand _addToFavoriteCommand;
        private RelayCommand _webSearchCommand;

        #endregion


        #region Properties/Commands
        public string Name
        {
            get { return "Main"; }
        }
        public SelectorViewModel SelectorViewModel
        {
            get { return _selectorViewModel; }
            set
            {
                _selectorViewModel = value;
                SetProperty(ref _selectorViewModel, value);
            }
        }


        public IEnumerable<Tire> Tires
        {
            get { return _tires; }
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
                           using (FavoriteContext db = new FavoriteContext())
                           {
                               db.favoriteTires.Load();
                               db.favoriteTires.Add(SelectedTire);
                               db.SaveChanges();
                           }
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
        public RelayCommand SelectCommand
        {
            get
            {
                return _selectCommand ??
                       (_selectCommand = new RelayCommand(obj =>
                       {
                           Tires = null;
                           Tires = _selectorViewModel.Select.SelectByParam(_selectorViewModel.InputParams.GiveParams());
                       }));
            }
        }

       
        #endregion

        public MainPageViewModel()
        {
        }


        

        
    }
}