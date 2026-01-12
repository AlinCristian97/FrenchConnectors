namespace FrenchConnectors;

public class Exercise
{
    public string Text { get; set; } = string.Empty;
    public Connector[] Options { get; set; } = new Connector[Constants.TotalNumberOfOptions];
    
    // The index of the correct option (0, 1, or 2)
    public Connector CorrectOption { get; set; }
    public string Explanation { get; set; }
}
