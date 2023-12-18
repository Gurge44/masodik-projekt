using System.Linq;

namespace Program
{
    internal class Program
    {
        private const string StartHTML = """
            <!doctype html>
            <html lang="en">
              <head>
                <meta charset="utf-8">
                <meta name="viewport" content="width=device-width, initial-scale=1">
                <title>Adatok</title>
                <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
                <link rel="stylesheet" href="style.css">
              </head>
              <body>
                <h1>Adatok:</h1>
                    <div class="flex-container">
            """;
        private const string EndHTML = """
                    </div>
                <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
              </body>
            </html>
            """;

        private const bool Test = true;

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
                List<string> html = [StartHTML, .. lines.Select(line =>
                {
                    string[] splitted = line.Split(';');
                    if (splitted.Length < 2) return string.Empty;
                    return $"""
                        <div class='flex-item'>
                            <div>{splitted[0]}</div>
                            <div>{splitted[1]}</div>
                            <div>{splitted[2]}</div>
                            <div>{splitted[3]} Ft</div>
                        </div>
                        """;
                }), EndHTML];
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
            if (!Test)
            {
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
                            break;
                        }
                        if (!int.TryParse(answer, out result))
                        {
                            Console.WriteLine("Helytelen bevitel. A választott alkatrész sorszámát írd be!");
                        }
                    }

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

                    var (NAME, PARAMETERS, COST) = InputDetails();

                    InputPieces.Add(new Piece(type, NAME, PARAMETERS, COST));
                }
            }
            else
            {
                InputPieces = [
                    new("Monitor", "Brand 1 Monitor", "NA", 1985),
                    new("Keyboard", "Brand 8 Keyboard", "NA", 3469),
                    new("HDD/SSD", "Brand 7 HDD/SSD", "2 TB", 2717),
                    new("Memory", "Brand 4 Memory", "16 GB", 4512),
                    new("CPU", "Brand 5 CPU", "2.84 GHz", 3991),
                    new("Keyboard", "Brand 6 Keyboard", "NA", 2548),
                    new("Motherboard", "Brand 10 Motherboard", "NA", 4982),
                    new("CPU", "Brand 7 CPU", "3.52 GHz", 2774),
                    new("GraphicCard", "Brand 9 GraphicCard", "8 GB", 4722),
                    new("Memory", "Brand 8 Memory", "32 GB", 1904),
                    new("Monitor", "Brand 4 Monitor", "NA", 1614),
                    new("GraphicCard", "Brand 2 GraphicCard", "4 GB", 451),
                    new("HDD/SSD", "Brand 2 HDD/SSD", "512 GB", 3907),
                    new("CPU", "Brand 4 CPU", "3.26 GHz", 4503),
                    new("Motherboard", "Brand 2 Motherboard", "NA", 2041),
                    new("Mouse", "Brand 7 Mouse", "NA", 1907),
                    new("GraphicCard", "Brand 6 GraphicCard", "6 GB", 3561),
                    new("Memory", "Brand 9 Memory", "8 GB", 4321),
                    new("Mouse", "Brand 2 Mouse", "NA", 2214),
                    new("HDD/SSD", "Brand 10 HDD/SSD", "1 TB", 1255),
                    new("Monitor", "Brand 9 Monitor", "NA", 3771),
                    new("Keyboard", "Brand 1 Keyboard", "NA", 3345),
                    new("CPU", "Brand 3 CPU", "2.37 GHz", 1584),
                    new("Mouse", "Brand 4 Mouse", "NA", 4566),
                    new("Motherboard", "Brand 4 Motherboard", "NA", 2346),
                    new("GraphicCard", "Brand 3 GraphicCard", "6 GB", 1100),
                    new("Memory", "Brand 7 Memory", "16 GB", 4713),
                    new("HDD/SSD", "Brand 5 HDD/SSD", "2 TB", 4899),
                    new("Monitor", "Brand 6 Monitor", "NA", 3270),
                    new("Mouse", "Brand 3 Mouse", "NA", 1236),
                    new("Keyboard", "Brand 4 Keyboard", "NA", 4544),
                    new("GraphicCard", "Brand 4 GraphicCard", "8 GB", 4916),
                    new("Memory", "Brand 1 Memory", "32 GB", 1531),
                    new("Motherboard", "Brand 6 Motherboard", "NA", 3155),
                    new("CPU", "Brand 2 CPU", "3.09 GHz", 2874),
                    new("Monitor", "Brand 3 Monitor", "NA", 4667),
                    new("HDD/SSD", "Brand 9 HDD/SSD", "512 GB", 2928),
                    new("Mouse", "Brand 5 Mouse", "NA", 3640),
                    new("Keyboard", "Brand 3 Keyboard", "NA", 2102),
                    new("GraphicCard", "Brand 8 GraphicCard", "4 GB", 3184),
                    new("CPU", "Brand 10 CPU", "2.61 GHz", 1999),
                    new("Motherboard", "Brand 1 Motherboard", "NA", 3625)
                ];
            }

            return InputPieces;
        }
        private static (string? NAME, string? PARAMETERS, int COST) InputDetails()
        {
            Console.Write("Add meg az alkatrész adatait:\n  Neve: ");
            string? name = Console.ReadLine();

            Console.Write("  Részletek: ");
            string? parameters = Console.ReadLine();

            Console.Write("  Ára: ");
            int cost = 0;
            while (cost <= 0)
            {
                if (!int.TryParse(Console.ReadLine(), out cost))
                {
                    Console.WriteLine("Helytelen bevitel. A választott alkatrész árát írd be!");
                }
            }

            return (name, parameters, cost);
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

                        string typeToFind = SearchForType();

                        matches = Pieces.Where(x => x.Type.Contains(typeToFind)).ToArray();

                        if (matches == null || matches.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A típus, amire rákerestél ({typeToFind}), nem található.");
                            Console.ResetColor();
                            break;
                        }

                        WriteMatchesToConsole();

                        break;

                    case 2: // Keresés névre

                        string nameToFind = SearchForName();

                        matches = Pieces.Where(x => x.Name.Contains(nameToFind, StringComparison.CurrentCultureIgnoreCase)).ToArray();

                        if (matches == null || matches.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"A név, amire rákerestél ({nameToFind}), nem található.");
                            Console.ResetColor();
                            break;
                        }

                        WriteMatchesToConsole();

                        break;

                    case 3: // Keresés paraméterek között

                        Console.Write("Keresendő paraméter/adat: ");
                        string parameterToFind = Console.ReadLine() ?? string.Empty;
                        if (parameterToFind == string.Empty) break;

                        matches = Pieces.Where(x => x.Parameters.Contains(parameterToFind, StringComparison.CurrentCultureIgnoreCase)).ToArray();

                        if (matches == null || matches.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Az adat, amire rákerestél ({parameterToFind}), nem található.");
                            Console.ResetColor();
                            break;
                        }

                        WriteMatchesToConsole();

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

                        matches = Pieces.Where(x => x.Cost >= lowerLimit && x.Cost <= upperLimit).ToArray();

                        if (matches == null || matches.Length == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Nem található egy alkatrész sem, amelynek az ára a két megadott határ között van ({lowerLimit} - {upperLimit}).");
                            Console.ResetColor();
                            break;
                        }

                        WriteMatchesToConsole();

                        break;

                    case 5: // Statisztika készítése a típusokról

                        Dictionary<string, Dictionary<string, List<Piece>>> types = [];

                        foreach (var piece in Pieces)
                        {
                            if (types.TryGetValue(piece.Type, out var type))
                            {
                                if (type.TryGetValue(piece.Name[..5], out var name))
                                {
                                    name.Add(piece);
                                }
                                else
                                {
                                    type[piece.Name[..5]] =
                                    [
                                        piece
                                    ];
                                }
                            }
                            else
                            {
                                types[piece.Type] = new()
                                {
                                    { piece.Name[..5], [ piece ] }
                                };
                            }
                        }

                        foreach (var type in types)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine($"\n\n\"{type.Key}\":\n");
                            Console.ResetColor();
                            foreach (var name in type.Value)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"\n\"{name.Key}\":");
                                Console.ResetColor();
                                WriteMatchesToConsole([.. name.Value], resultText: false);
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

                        foreach (var piece in Pieces.Where(x => x.Type.Contains(typeToLower, StringComparison.CurrentCultureIgnoreCase) || typeToLower == "all").ToArray())
                        {
                            Console.Write($"Cost before: {piece.Cost}");
                            piece.Cost = (int)Math.Round(piece.Cost - (float)(piece.Cost * ((100 - percentage) / 100f)));
                            Console.WriteLine($", Cost after: {piece.Cost}");
                        }

                        WriteToFile([.. Pieces.Select(piece => $"{piece.Type};{piece.Name};{piece.Parameters};{piece.Cost}")], "data");

                        break;

                    case 7: // Egy alkatrész adatainak módosítása

                        string pieceName = SearchForName();

                        Dictionary<int, Piece> nameMatches = [];

                        int index = 1;
                        foreach (var piece in Pieces.Where(piece => piece.Name.Contains(pieceName, StringComparison.CurrentCultureIgnoreCase)).ToArray())
                        {
                            nameMatches.Add(index, piece);

                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(index);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(". ");
                            Console.ResetColor();
                            Console.WriteLine(piece.ToString());

                            index++;
                        }

                        Console.Write("Írd be annak az alkatrésznek a sorszámát,\namelyiknek az adatait módosítani szeretnéd: ");

                        int lineNum = 0;
                        while (lineNum <= 0 || !nameMatches.ContainsKey(lineNum))
                        {
                            var answer = Console.ReadLine();
                            if (answer?.ToLower() == "quit")
                            {
                                break;
                            }
                            if (!int.TryParse(answer, out lineNum))
                            {
                                Console.WriteLine("Helytelen bevitel. A választott alkatrész sorszámát írd be!");
                            }
                        }

                        var (NAME, PARAMETERS, COST) = InputDetails();

                        foreach (var piece in Pieces.Where(piece => piece == nameMatches[lineNum]).ToArray())
                        {
                            piece.Name = NAME ?? piece.Name;
                            piece.Parameters = PARAMETERS ?? piece.Parameters;
                            piece.Cost = COST;

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"\nMódosított alkatrész:\n  {piece}");
                            Console.ResetColor();
                        }

                        Piece modifiedPiece = new(nameMatches[lineNum].Type, NAME, PARAMETERS, COST);

                        Console.WriteLine();

                        foreach (var piece in Pieces)
                        {
                            if (piece.Equals(modifiedPiece)) Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(piece.ToString());
                            if (piece.Equals(modifiedPiece)) Console.ResetColor();
                        }

                        WriteToFile([.. Pieces.Select(piece => $"{piece.Type};{piece.Name};{piece.Parameters};{piece.Cost}")], "data");

                        break;

                    case 8: // Pontos keresés (az összes adat szükséges)

                        var Type = SearchForType();
                        var details = InputDetails();
                        Piece search = new(Type, details.NAME ?? string.Empty, details.PARAMETERS ?? string.Empty, details.COST);

                        matches = Pieces.Where(search.Equals).ToArray();

                        WriteMatchesToConsole();

                        break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nParancs sikeresen végrehajtva\n\n");
                Console.ResetColor();

                void WriteMatchesToConsole(Piece[]? output = null, bool resultText = true, bool sortByCost = false)
                {
                    if (output != null) matches = output;
                    if (matches == null) return;

                    if (sortByCost) _ = matches.OrderBy(x => x.Cost);
                    if (resultText) Console.WriteLine("Találatok:");

                    foreach (Piece piece in matches) Console.WriteLine(piece.ToString());
                }

                string SearchForName()
                {
                    Console.Write("Keresendő név: ");
                    string nameToFind = Console.ReadLine() ?? string.Empty;
                    if (nameToFind == string.Empty) return string.Empty;

                    return nameToFind;
                }

                string SearchForType()
                {
                    Console.Write("Keresendő típus: ");
                    string typeToFind = Console.ReadLine() ?? string.Empty;
                    if (typeToFind == string.Empty) return string.Empty;

                    return typeToFind;
                }
            }
        }
    }
}