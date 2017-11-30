using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Ship
    {
        public Ship(string info)
        {
            Info = info;
        }
        public Ship() { }
        public int Id { get; set; }
        public string NameShip { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Capacity { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }

        public List<Ship> Ships = new List<Ship>();
    }
}