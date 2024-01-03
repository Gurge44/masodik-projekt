using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Piece> Pieces = [];
        private const string fileName = "data";

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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            List<string> lines = Pieces.Select(x => x.ToString()).ToList();

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

            MessageBox.Show("Data exported successfully!");
        }

        private void AddNewPiece_Click(object sender, RoutedEventArgs e)
        {
            // Get details from text boxes
            string type = textBoxType.Text;
            string name = textBoxName.Text;
            string parameters = textBoxParameters.Text;

            if (!int.TryParse(textBoxCost.Text, out int cost))
            {
                MessageBox.Show("Invalid cost. Please enter a valid number.");
                return;
            }

            // Create and add a new piece to the list
            Piece newPiece = new(type, name, parameters, cost);
            Pieces.Add(newPiece);

            // Display a message or update UI as needed
            MessageBox.Show("New piece added successfully!");

            // Optionally, clear the form after adding a new piece
            ClearForm();
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            textBoxType.Clear();
            textBoxName.Clear();
            textBoxParameters.Clear();
            textBoxCost.Clear();
        }

        private void PerformSearch_Click(object sender, RoutedEventArgs e)
        {
            // Get selected search method
            string? selectedMethod = (comboBoxSearchMethod?.SelectedItem as ComboBoxItem)?.Content?.ToString();

            // Get search argument
            string searchArgument = textBoxSearchArgument.Text;

            // Perform search based on the selected method
            switch (selectedMethod)
            {
                case "Search by Type":
                    DisplaySearchResult(Pieces.Where(x => x.Type.Contains(searchArgument, StringComparison.CurrentCultureIgnoreCase)).ToList());
                    break;

                case "Search by Name":
                    DisplaySearchResult(Pieces.Where(x => x.Name.Contains(searchArgument, StringComparison.CurrentCultureIgnoreCase)).ToList());
                    break;

                case "Search by Parameters":
                    DisplaySearchResult(Pieces.Where(x => x.Parameters.Contains(searchArgument, StringComparison.CurrentCultureIgnoreCase)).ToList());
                    break;

                // Add more cases for additional search methods

                default:
                    MessageBox.Show("Invalid search method selected.");
                    break;
            }
        }

        private void DisplaySearchResult(List<Piece> searchResult)
        {
            // Clear existing items in the ListBox
            listBoxSearchResult.Items.Clear();

            // Add search result items to the ListBox
            foreach (Piece piece in searchResult)
            {
                listBoxSearchResult.Items.Add(piece.ToString());
            }
        }
    }
}
