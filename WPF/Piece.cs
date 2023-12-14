namespace WPF;

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

    public override string ToString() => $"Típus: {Type}, Név: {Name}, Adatok: {Parameters}, Ár: {Cost} Ft";
    public override bool Equals(object? obj)
    {
        if (obj is not Piece piece) return false;
        return piece.Type == Type && piece.Name == Name && piece.Parameters == Parameters && piece.Cost == Cost;
    }
    public override int GetHashCode()
    {
        int result = 0;
        foreach (char character in Type) result += character;
        foreach (char character in Name) result += character;
        foreach (char character in Parameters) result += character;
        result += Cost;
        return result;
    }
}
