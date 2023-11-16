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

        public string Type { get => type; set => type = value ?? string.Empty; }
        public string Name { get => name; set => name = value ?? string.Empty; }
        public string Parameters { get => parameters; set => parameters = value ?? string.Empty; }
        public int Cost { get => cost; set => cost = value; }

        public Piece(string? type, string? name, string? parameters, int cost)
        {
            this.type = type ?? string.Empty;
            this.name = name ?? string.Empty;
            this.parameters = parameters ?? string.Empty;
            this.cost = cost;
        }
    }
}
