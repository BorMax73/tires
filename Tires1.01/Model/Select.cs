using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using Tires1._01.Annotations;

namespace Tires1._01
{
    public class Select 
    {
       
        private IEnumerable<Tire> _tires;

        public IEnumerable<Tire> Tires
        {
            get { return _tires; }
            set
            {
                _tires = value;
            }
        }

        private string CommandString(Tire tire)
        {
            string selectString = "";
            
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

            return selectString;
        }

        private async  void SelectRequest(string SelectCommand)
        {
            
            using (SQLiteConnection db = new SQLiteConnection("Data Source=.\\appDB.db"))
            {
                List<Tire> tiresList = new List<Tire>();
                SQLiteCommand selectCommand =
                   new SQLiteCommand($"SELECT * FROM tires WHERE {SelectCommand} LIMIT 100", db);
                db.Open();
                var reader = await selectCommand.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        Tire selectTire = new Tire(reader.GetInt32(0),
                                reader.GetString(1), reader.GetDouble(2),
                                reader.GetDouble(3), reader.GetString(4),
                                reader.GetString(5), reader.GetString(6),
                                reader.GetInt32(7));
                        tiresList.Add(selectTire);
                    }
                }

                Tires = tiresList;
            }
        }

        public  IEnumerable<Tire> SelectByParam(Tire tire)
        {
            SelectRequest(CommandString(tire));
            return _tires;
        }

       
    }
}