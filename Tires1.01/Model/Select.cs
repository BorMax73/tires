using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using Tires1._01.Annotations;

namespace Tires1._01
{
    public class Select : INotifyPropertyChanged
    {
       
        private IEnumerable<Tire> _tires;

        public IEnumerable<Tire> Tires
        {
            get { return _tires; }
            set
            {
                _tires = value;
                OnPropertyChanged("Tires");
            }
        }

        public IEnumerable<Tire> SelectByParam(Tire tire)
        {
            
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                string selectString = "";
                List<Tire> tiresList = new List<Tire>();
                if (tire.Width != 0)
                {
                    selectString += $"(width = {tire.Width})";
                }
                else
                {
                    selectString += "(width = width)";
                }

                if (tire.SideWall != 0)
                {
                    selectString += $"AND (sidewall = {tire.SideWall})";
                }
                else
                {
                    selectString += "and (sidewall = sidewall)";
                }
                if (tire.Diameter != null)
                {
                    selectString += $"AND (diameter = '{tire.Diameter}')";
                }
                else
                {
                    selectString += "and (diameter = diameter)";
                }
                if (tire.Season != null)
                {
                    selectString += $"AND (season = '{tire.Season}')";
                }
                else
                {
                    selectString += "and (season = season)";
                }
                if (tire.Brand != null)
                {
                    selectString += $"AND (brand = '{tire.Brand}')";
                }
                else
                {
                    selectString += "and (brand = brand)";
                }
                SQLiteCommand selectCommand = new SQLiteCommand($"SELECT * FROM tires WHERE {selectString}", db);
                db.Open();
                SQLiteDataReader reader = selectCommand.ExecuteReader();
                foreach (DbDataRecord record in reader)
                {
                    Tire selectTire = new Tire(Convert.ToInt32(record.GetValue(0)), Convert.ToString(record.GetValue(1)),  Convert.ToDouble(record.GetValue(2)), Convert.ToDouble(record.GetValue(3)), Convert.ToString(record.GetValue(4)), Convert.ToString(record.GetValue(5)), Convert.ToString(record.GetValue(6)), Convert.ToInt32(record.GetValue(7)));
                    tiresList.Add(selectTire);
                }


                _tires = tiresList;
            }

            
            return _tires;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}