using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SQLite;
using System.Runtime.CompilerServices;
using Tires1._01.Annotations;

namespace Tires1._01
{
    public class SearchParams : INotifyPropertyChanged
    {
        #region Fields
        private List<string> _listOfWidth = new List<string>();
        private List<string> _listOfDiameter = new List<string>();
        private List<string> _listOfSideWall = new List<string>();
        private List<string> _listOfSeason = new List<string>();
        private List<string> _listOfBrand = new List<string>();
        #endregion

        #region Properties/Commands
        public List<string> ListWidth
        {
            get { return _listOfWidth; }
            set
            {
                _listOfWidth = value;
                OnPropertyChanged("ListWidth");
            }
        }

        public List<string> ListDiameter
        {
            get { return _listOfDiameter; }
            set
            {
                _listOfWidth = value;
                OnPropertyChanged("ListDiameter");
            }
        }

        public List<string> ListSideWall
        {
            get { return _listOfSideWall; }
            set
            {
                _listOfSideWall = value;
                OnPropertyChanged("ListSideWall");
            }
        }
        public List<string> ListSeason
        {
            get { return _listOfSeason; }
            set
            {
                _listOfSeason = value;
                OnPropertyChanged("ListSeason");
            }
        }
        public List<string> ListBrand
        {
            get { return _listOfBrand; }
            set
            {
                _listOfBrand = value;
                OnPropertyChanged("ListBrand");
            }
        }

        #endregion


        #region Methods
        public SearchParams()
        {
            GetWidth();
            GetDiameter();
            GetSideWall();
            GetSeason();
            GetBrand();
        }

        private List<string> GetWidth()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {

                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT width FROM tires ORDER BY width", db);
                db.Open();
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    _listOfWidth.Add(record["width"].ToString());
                }
            }

            return _listOfWidth;
        }

        private List<string> GetDiameter()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT diameter FROM tires ORDER BY diameter", db);
                db.Open();
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    _listOfDiameter.Add(record["diameter"].ToString());
                }

            }

            return _listOfDiameter;
        }

        private List<string> GetSideWall()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT sidewall FROM tires ORDER BY sidewall", db);
                db.Open();
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    _listOfSideWall.Add(record["sidewall"].ToString());
                }

            }

            return _listOfSideWall;
        }
        private List<string> GetSeason()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT season FROM tires ORDER BY season", db);
                db.Open();
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    _listOfSeason.Add(record["season"].ToString());
                }

            }

            return _listOfSideWall;
        }
        private List<string> GetBrand()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT brand FROM tires ORDER BY brand", db);
                db.Open();
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    _listOfBrand.Add(record["brand"].ToString());
                }

            }

            return _listOfBrand;
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}