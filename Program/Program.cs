namespace Program
{
    internal class Program
    {
        private static void WriteToFile(List<string> lines, string fileName)
        {
            File.WriteAllLines(fileName + ".txt", lines, System.Text.Encoding.UTF8);
            GenerateJSfile(lines, fileName);
        }
        private static void GenerateJSfile(List<string> lines, string fileName)
        {
            List<string> builder = new() { "export const PIECES = [\n" };
            builder.AddRange(lines.Select(line => '\"' + line.Trim() + "\","));
            builder.Add("\n]");
            lines = builder;
            File.WriteAllLines($"{fileName}.js", lines, System.Text.Encoding.UTF8);
        }
        private static void Main(string[] args)
        {
            List<Piece> InputPieces = new();
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("A bevitelből való kilépéshez írd be, hogy 'quit'.\nVálaszd ki, milyen típusú alkatrészt szeretnél eltárolni, és írd be a sorszámát:\n  1. Alaplap\n  2. Processzor\n  3. Memória\n  4. Grafikus kártya\n  5. HDD / SSD\n  6. Monitor\n  7. Egér\n  8. Billentyűzet\nA választott sorszám: ");

                int result = 0;
                while (result <= 0 || result > 8)
                {
                    var answer = Console.ReadLine();
                    if (answer?.ToLower() == "quit")
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
                string? name = Console.ReadLine();

                Console.Write("  Részletek: ");
                string? parameters = Console.ReadLine();

                Console.Write("  Ára: ");
                int cost = 0;
                while (cost == 0)
                {
                    if (!int.TryParse(Console.ReadLine(), out cost))
                    {
                        Console.WriteLine("Helytelen bevitel. A választott alkatrész árát írd be!");
                    }
                }

                InputPieces.Add(new Piece(type, name, parameters, cost));
            }

            //Random r = new();
            //Pieces = new();
            //for (int i = 0; i < 200; i++)
            //{
            //    Pieces.Add(($"type{r.Next(1, 9)}", $"name{r.Next(1, 1000)}", $"parameters{r.Next(1, 10000)}", r.Next(1, 1000000)));
            //}

            List<string> builder = new();
            builder.AddRange(InputPieces.Select(piece => $"{piece.Type};{piece.Name};{piece.Parameters};{piece.Cost}"));

            WriteToFile(builder, "data");

            Piece[] Pieces = InputPieces.ToArray();

            while (true)
            {
                Console.WriteLine("Most kereshetsz a bevitt adatok között!\n  1. Keresés típusra\n  2. Keresés névre\n  3. Keresés paraméterek között\n  4. Keresés árra\n  5. Statisztika készítése a típusokról\n  6. Adott termékkategória összes árának csökkentése adott százalékkal\n  7. Egy alkatrész adatainak módosítása\n  8. Pontos keresés (az összes adat szükséges)");

                int result = 0;
                while (result <= 0 || result > 8)
                {
                    var answer = Console.ReadLine();
                    if (answer?.ToLower() == "quit")
                    {
                        stop = true;
                        break;
                    }
                    if (!int.TryParse(answer, out result))
                    {
                        Console.WriteLine("Helytelen bevitel. A választott metódus sorszámát írd be!");
                    }
                }

                switch (result)
                {
                    case 1: // Keresés típusra

                        Console.Write("Keresendő típus: ");
                        string typeToFind = Console.ReadLine() ?? string.Empty;
                        if (typeToFind == string.Empty) break;

                        Piece[]? matches = Pieces.Where(x => x.Type.Contains(typeToFind)).ToArray();

                        if (matches == null || !matches.Any())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The type you searched for ({typeToFind}) was not found.");
                            Console.ResetColor();
                            break;
                        }

                        Console.WriteLine("Matches:");
                        foreach (var piece in matches)
                        {
                            Console.WriteLine("Type: " + piece.Type + ", Name: " + piece.Name + ", Data: " + piece.Parameters + ", Cost: " + piece.Cost + "Ft");
                        }

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                }
            }

        }
    }
}