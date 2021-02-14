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

        private async void GetWidth()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {

                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT width FROM tires ORDER BY width", db);
                db.Open();
                var reader = await selectCommand.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    _listOfWidth.Add(reader["width"].ToString());
                }
            }
        }
        private async void GetDiameter()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT diameter FROM tires ORDER BY diameter", db);
                db.Open();
                var reader = await selectCommand.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                {
                    _listOfDiameter.Add(reader["diameter"].ToString());
                }
            }
        }
        private async void GetSideWall()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT sidewall FROM tires ORDER BY sidewall", db);
                db.Open();
                var reader = await selectCommand.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                {
                    _listOfSideWall.Add(reader["sidewall"].ToString());
                }
            }
        }
        private async void  GetSeason()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT season FROM tires ORDER BY season", db);
                db.Open();
                var reader = await selectCommand.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                {
                    _listOfSeason.Add(reader["season"].ToString());
                }
            }
        }
        private async void GetBrand()
        {
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                SQLiteCommand selectCommand = new SQLiteCommand("SELECT DISTINCT brand FROM tires ORDER BY brand", db);
                db.Open();
                var reader =  await selectCommand.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    _listOfBrand.Add(reader["brand"].ToString());
                }

            }
    
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