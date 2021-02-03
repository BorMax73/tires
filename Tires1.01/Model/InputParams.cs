using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using Tires1._01.Annotations;

namespace Tires1._01
{
    public class InputParams : INotifyPropertyChanged
    {
        #region Fields
        private string _selectWidth;
        private string _selectDiameter;
        private string _selectSideWall;
        private string _selectSeason;
        private string _selectBrand;
        #endregion


        #region Properties/Commands
        public string SelectWidth
        {
            get { return _selectWidth; }
            set
            {
                _selectWidth = value;
                OnPropertyChanged("SelectWidth");
            }
        }
        
        public string SelectDiameter
        {
            get { return _selectDiameter; }
            set
            {
                _selectDiameter = value;
                OnPropertyChanged("SelectDiameter");
            }
        }
        public string SelectSideWall
        {
            get { return _selectDiameter; }
            set
            {
                _selectSideWall = value;
                OnPropertyChanged("SelectSideWall");
            }
        }
        public string SelectSeason
        {
            get { return _selectSeason; }
            set
            {
                _selectSeason = value;
                OnPropertyChanged("SelectSeason");
            }
        }
        public string SelectBrand
        {
            get { return _selectBrand; }
            set
            {
                _selectBrand = value;
                OnPropertyChanged("SelectBrand");
            }
        }
        #endregion



        public Tire GiveParams()
        {
            return new Tire(Convert.ToDouble(_selectWidth), Convert.ToDouble(_selectSideWall), _selectDiameter, _selectSeason, _selectBrand); ;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}