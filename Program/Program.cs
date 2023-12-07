namespace Program
{
    internal class Program
    {
        private const string StartHTML = "<!doctype html>\r\n<html lang=\"en\">\r\n  <head>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <title>Bootstrap demo</title>\r\n    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN\" crossorigin=\"anonymous\">\r\n  </head>\r\n  <body>\r\n    <h1>Adatok:</h1>\n";
        private const string EndHTML = "\n\r\n    <script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL\" crossorigin=\"anonymous\"></script>\r\n  </body>\r\n</html>";

        /// <summary>
        /// Write all contents of a string list to a txt file
        /// </summary>
        /// <param name="lines">The strings to write into the file</param>
        /// <param name="fileName">The name of the file (excluding .txt)</param>
        private static void WriteToFile(List<string> lines, string fileName)
        {
            File.WriteAllLines($"{fileName}.txt", lines, System.Text.Encoding.UTF8);

            GenerateJSfile();
            GenerateHTMLfile();

            void GenerateJSfile()
            {
                List<string> js = ["export const PIECES = [\n", .. lines.Select(line => $"\"{line.Trim()}\","), "\n]"];
                File.WriteAllLines($"{fileName}.js", js, System.Text.Encoding.UTF8);
            }

            void GenerateHTMLfile()
            {
                List<string> html = [StartHTML, .. lines.Select(line => $"<p>{line.Trim()}</p>"), EndHTML];
                File.WriteAllLines($"{fileName}.html", html, System.Text.Encoding.UTF8);
            }
        }
        /// <summary>
        /// Handles the process of inputting pieces by the user
        /// </summary>
        /// <returns>A list of pieces added by the user</returns>
        private static List<Piece> InputPiecesByUser()
        {
            List<Piece> InputPieces = [];
            //bool stop = false;
            //while (!stop)
            //{
            //    Console.WriteLine("A bevitelből való kilépéshez írd be, hogy 'quit'.\nVálaszd ki, milyen típusú alkatrészt szeretnél eltárolni, és írd be a sorszámát:\n  1. Alaplap\n  2. Processzor\n  3. Memória\n  4. Grafikus kártya\n  5. HDD / SSD\n  6. Monitor\n  7. Egér\n  8. Billentyűzet\nA választott sorszám: ");

            //    int result = 0;
            //    while (result <= 0 || result > 8)
            //    {
            //        var answer = Console.ReadLine();
            //        if (answer?.ToLower() == "quit")
            //        {
            //            stop = true;
            //            break;
            //        }
            //        if (!int.TryParse(answer, out result))
            //        {
            //            Console.WriteLine("Helytelen bevitel. A választott alkatrész sorszámát írd be!");
            //        }
            //    }

            //    if (stop) break;

            //    string type = result switch
            //    {
            //        1 => "Motherboard",
            //        2 => "CPU",
            //        3 => "Memory",
            //        4 => "GraphicCard",
            //        5 => "HDD/SSD",
            //        6 => "Monitor",
            //        7 => "Mouse",
            //        8 => "Keyboard",
            //        _ => string.Empty,
            //    };

            //    Console.WriteLine();

            //    Console.Write("Add meg az alkatrész adatait:\n  Neve: ");
            //    string? name = Console.ReadLine();

            //    Console.Write("  Részletek: ");
            //    string? parameters = Console.ReadLine();

            //    Console.Write("  Ára: ");
            //    int cost = 0;
            //    while (cost == 0)
            //    {
            //        if (!int.TryParse(Console.ReadLine(), out cost))
            //        {
            //            Console.WriteLine("Helytelen bevitel. A választott alkatrész árát írd be!");
            //        }
            //    }

            //    InputPieces.Add(new Piece(type, name, parameters, cost));
            //}

            Random r = new();
            InputPieces = [];
            for (int i = 0; i < 200; i++)
            {
                InputPieces.Add(new Piece($"type{r.Next(1, 9)}", $"name{r.Next(1, 1000)}", $"parameters{r.Next(1, 10000)}", r.Next(1, 1000000)));
            }

            return InputPieces;
        }
        private static void Main()
        {
            var InputPieces = InputPiecesByUser();

            List<string> builder = [.. InputPieces.Select(piece => $"{piece.Type};{piece.Name};{piece.Parameters};{piece.Cost}")];

            WriteToFile(builder, "data");

            Piece[] Pieces = [.. InputPieces];

            while (true)
            {
                Console.WriteLine("Most kereshetsz a bevitt adatok között!\n  1. Keresés típusra\n  2. Keresés névre\n  3. Keresés paraméterek/adatok között\n  4. Keresés árra\n  5. Statisztika készítése a típusokról\n  6. Adott termékkategória összes árának csökkentése adott százalékkal\n  7. Egy alkatrész adatainak módosítása\n  8. Pontos keresés (az összes adat szükséges)");

                int result = 0;
                while (result <= 0 || result > 8)
                {
                    var answer = Console.ReadLine();
                    if (!int.TryParse(answer, out result))
                    {
                        Console.WriteLine("Helytelen bevitel. A választott metódus sorszámát írd be!");
                    }
                }

                Piece[]? matches = [];

                switch (result)
                {
                    case 1: // Keresés típusra

                        Console.Write("Keresendő típus: ");
                        string typeToFind = Console.ReadLine() ?? string.Empty;
                        if (typeToFind == string.Empty) break;

                        Piece[]? typeMatches = Pieces.Where(x => x.Type.Contains(typeToFind)).ToArray();

                        if (typeMatches == null || typeMatches.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A típus, amire rákerestél ({typeToFind}), nem található.");
                            Console.ResetColor();
                            break;
                        }

                        Console.WriteLine("Találatok:");
                        foreach (var piece in typeMatches)
                        {
                            Console.WriteLine("Típus: " + piece.Type + ", Név: " + piece.Name + ", Adatok: " + piece.Parameters + ", Ár: " + piece.Cost + " Ft");
                        }

                        break;

                    case 2: // Keresés névre

                        Console.Write("Keresendő név: ");
                        string nameToFind = Console.ReadLine() ?? string.Empty;
                        if (nameToFind == string.Empty) break;

                        Piece[]? nameMatches = Pieces.Where(x => x.Name.Contains(nameToFind)).ToArray();

                        if (nameMatches == null || nameMatches.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A név, amire rákerestél ({nameToFind}), nem található.");
                            Console.ResetColor();
                            break;
                        }

                        Console.WriteLine("Találatok:");
                        foreach (var piece in nameMatches)
                        {
                            Console.WriteLine("Típus: " + piece.Type + ", Név: " + piece.Name + ", Adatok: " + piece.Parameters + ", Ár: " + piece.Cost + " Ft");
                        }

                        break;

                    case 3: // Keresés paraméterek között

                        Console.Write("Keresendő paraméter/adat: ");
                        string parameterToFind = Console.ReadLine() ?? string.Empty;
                        if (parameterToFind == string.Empty) break;

                        Piece[]? parameterMatches = Pieces.Where(x => x.Name.Contains(parameterToFind)).ToArray();

                        if (parameterMatches == null || parameterMatches.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Az adat, amire rákerestél ({parameterToFind}), nem található.");
                            Console.ResetColor();
                            break;
                        }

                        Console.WriteLine("Találatok:");
                        foreach (var piece in parameterMatches)
                        {
                            Console.WriteLine("Típus: " + piece.Type + ", Név: " + piece.Name + ", Adatok: " + piece.Parameters + ", Ár: " + piece.Cost + " Ft");
                        }

                        break;

                    case 4: // Keresés árak között

                        Console.Write("Alsó és felső határ:\n  Formátum: [alsó határ] [felső határ]\nPélda: '6500 13900'\n  ");
                        int upperLimit = -1;
                        int lowerLimit = -1;
                        try
                        {
                            var limits = Console.ReadLine()?.Split(' ');
                            if (limits == null || limits.Length != 2) break;

                            if (!int.TryParse(limits[0], out lowerLimit)) break;
                            if (!int.TryParse(limits[1], out upperLimit)) break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid format.");
                            break;
                        }
                        if (upperLimit < 0 || lowerLimit < 0) break;

                        var costMatches = Pieces.Where(x => x.Cost >= lowerLimit && x.Cost <= upperLimit).ToArray();

                        if (costMatches == null || costMatches.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Nem található egy alkatrész sem, amelynek az ára a két megadott határ között van ({lowerLimit} - {upperLimit}).");
                            Console.ResetColor();
                            break;
                        }

                        Console.WriteLine("Találatok:");
                        foreach (var piece in costMatches)
                        {
                            Console.WriteLine("Típus: " + piece.Type + ", Név: " + piece.Name + ", Adatok: " + piece.Parameters + ", Ár: " + piece.Cost + " Ft");
                        }

                        break;

                    case 5: // Statisztika készítése a típusokról

                        Dictionary<string, List<Piece>> types = [];
                        foreach (var piece in Pieces)
                        {
                            if (types.TryGetValue(piece.Type, out var n))
                            {
                                n.Add(piece);
                            }
                            else
                            {
                                types[piece.Type] =
                                [
                                    piece
                                ];
                            }
                        }

                        foreach (var type in types)
                        {
                            Console.WriteLine($"\n\n\"{type.Key}\":\n");
                            WriteMatchesToConsole([.. type.Value], resultText: false);
                            foreach (var piece in type.Value)
                            {
                                Console.WriteLine(piece.OutputText);
                            }
                        }

                        break;

                    case 6: // Adott termékkategória összes árának csökkentése adott százalékkal

                        Console.Write("Az árcsökkentett típus: ");
                        string typeToLower = Console.ReadLine() ?? string.Empty;
                        Console.Write("Az árak hány százalékkal legyenek csökkentve? ");
                        string input = Console.ReadLine() ?? string.Empty;
                        if (!int.TryParse(input, out var lowerWithPercent)) break;

                        var percentage = (int)Math.Round((1 - (lowerWithPercent / 100f)) * 100);
                        Console.WriteLine($"New percentage: {percentage}%");

                        foreach (var piece in Pieces.Where(x => x.Type == typeToLower).ToArray())
                        {
                            Console.Write($"Cost before: {piece.Cost}");
                            piece.Cost = (int)Math.Round(piece.Cost - (float)(piece.Cost * (percentage / 100f)));
                            Console.WriteLine($", Cost after: {piece.Cost}");
                        }

                        break;

                    case 7: // Egy alkatrész adatainak módosítása

                        break;

                    case 8: // Pontos keresés (az összes adat szükséges)

                        break;
                }
                void WriteMatchesToConsole(Piece[]? output = null, bool resultText = true)
                {
                    if (output != null) matches = output;
                    if (matches == null) return;

                    if (resultText) Console.WriteLine("Találatok:");

                    foreach (Piece piece in matches) Console.WriteLine(piece.OutputText);
                }
            }

        }
    }
}