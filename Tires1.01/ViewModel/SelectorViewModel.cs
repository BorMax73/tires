using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tires1._01.Annotations;
using Tires1._01.ViewModel;

namespace Tires1._01
{
    public class SelectorViewModel : ViewModelBase
    {
        private SearchParams _searchParams;
        private InputParams _inputParams;
        private Select _select;

        public Select Select
        {
            get => _select;
            set => SetProperty(ref _select, value);
        }
        public InputParams InputParams
        {
            get => _inputParams;
            set => SetProperty(ref _inputParams, value);
        }

        public SearchParams SearchParams
        {
            get => _searchParams;
            set => SetProperty(ref _searchParams, value);
        }
        public SelectorViewModel()
        {
            _searchParams = new SearchParams();
            _inputParams = new InputParams();
            _select = new Select();
        }

        
    }
}