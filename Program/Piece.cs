using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    internal class Piece(string? type, string? name, string? parameters, int cost)
    {
        private string type = type ?? string.Empty;
        private string name = name ?? string.Empty;
        private string parameters = parameters ?? string.Empty;
        private int cost = cost;

        public string Type { get => type; set => type = value ?? string.Empty; }
        public string Name { get => name; set => name = value ?? string.Empty; }
        public string Parameters { get => parameters; set => parameters = value ?? string.Empty; }
        public int Cost { get => cost; set => cost = value; }

        public string OutputText => $"Típus: {Type}, Név: {Name}, Adatok: {Parameters}, Ár: {Cost} Ft";
    }
}
