using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Piece
    {
        private string type;
        private string name;
        private string parameters;
        private int cost;

        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string Parameters { get => parameters; set => parameters = value; }
        public int Cost { get => cost; set => cost = value; }

        public Piece(string type, string name, string parameters, int cost)
        {
            this.type = type;
            this.name = name;
            this.parameters = parameters;
            this.cost = cost;
        }
    }
}
