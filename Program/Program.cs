namespace Program
{
    internal class Program
    {
        private static readonly List<Piece> Pieces = new();
        private static void WriteToFile(List<string> lines, string fileName)
        {
            File.WriteAllLines(fileName + ".txt", lines, System.Text.Encoding.UTF8);
            GenerateJSfile(lines, fileName);
        }
        private static void GenerateJSfile(List<string> lines, string fileName)
        {
            List<string> builder = new() { "export const PIECES = [\n" };
            builder.AddRange(lines.Select(line => line + ",\n"));
            builder.Add("\n]");
            lines = builder;
            File.WriteAllLines($"{fileName}.js", lines, System.Text.Encoding.UTF8);
        }
        private static void Main(string[] args)
        {
            bool stop = false;
            while (!stop)
            {
                Pieces.Clear();
                Console.WriteLine("A bevitelből való kilépéshez írd be, hogy 'quit'.\nVálaszd ki, milyen típusú alkatrészt szeretnél eltárolni, és írd be a sorszámát:\n  1. Alaplap\n  2. Processzor\n  3. Memória\n  4. Grafikus kártya\n  5. HDD / SSD\n  6. Monitor\n  7. Egér\n  8. Billentyűzet\nA választott sorszám: ");

                int result = 0;
                while (result == 0)
                {
                    var answer = Console.ReadLine();
                    if (answer == "quit")
                    {
                        stop = true;
                        break;
                    }
                    if (!int.TryParse(answer, out result))
                    {
                        Console.WriteLine("Helytelen bevitel. A választott alkatrész sorszámát írd be!");
                    }
                }

                if (stop) break;

                string type = result switch
                {
                    1 => "Motherboard",
                    2 => "CPU",
                    3 => "Memory",
                    4 => "GraphicCard",
                    5 => "HDD/SSD",
                    6 => "Monitor",
                    7 => "Mouse",
                    8 => "Keyboard",
                    _ => string.Empty,
                };

                Console.WriteLine();

                Console.Write("Add meg az alkatrész adatait:\n  Neve: ");
                string name = Console.ReadLine();

                Console.Write("  Részletek: ");
                string parameters = Console.ReadLine();

                Console.Write("  Ára: ");
                int cost = 0;
                while (cost == 0)
                {
                    if (!int.TryParse(Console.ReadLine(), out cost))
                    {
                        Console.WriteLine("Helytelen bevitel. A választott alkatrész árát írd be!");
                    }
                }

                Pieces.Add(new Piece(type, name, parameters, cost));
            }

            List<string> builder = new();
            builder.AddRange(Pieces.Select(piece => piece.Type + ';' + piece.Name + ';' + piece.Parameters + ';' + piece.Cost + '\n'));

            WriteToFile(builder, "data");
        }
    }
}