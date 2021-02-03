using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tires1._01.Annotations;

namespace Tires1._01
{
    [Table("favoriteTires")]
    public class Tire
    {
        [Key]
        public int id { get; set; }

        private string name;
        private double width;
        private double sidewall;
        private string diameter;
        private string brand;
        private string season;
        private int price;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
            }
        }
        public double SideWall
        {
            get { return sidewall; }
            set
            {
                sidewall = value;

            }
        }
        public string Diameter
        {
            get { return diameter; }
            set
            {
                diameter = value;
            }
        }
        public string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
            }
        }
        public string Season
        {
            get { return season; }
            set
            {
                season = value;
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                price = value;
               
            }
        }

        public Tire()
        {

        }

        public Tire(double width, double sidewall, string diameter, string season, string brand)
        {
            this.width = width;
            this.sidewall = sidewall;
            this.diameter = diameter;
            this.season = season;
            this.brand = brand;
        }

        public Tire(int id, string name,  double width, double sidewall, string diameter, string brand, string season, int price)
        {
            this.id = id;
            this.name = name;
            this.width = width;
            this.sidewall = sidewall;
            this.diameter = diameter;
            this.brand = brand;
            this.season = season;
            this.price = price;

        }

    }
}
