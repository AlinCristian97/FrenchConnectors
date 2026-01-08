namespace FrenchConnectors;

public class Exercise
{
    public string Text { get; set; } = string.Empty;
    public string[] Options { get; set; } = new string[Constants.TotalNumberOfOptions];
    
    // The index of the correct option (0, 1, or 2)
    public string CorrectOption { get; set; }
    public string Explanation { get; set; }
}
