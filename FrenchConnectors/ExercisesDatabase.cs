using System.Text.Json;

namespace FrenchConnectors;

public class ExercisesDatabase
{
    #region Private Methods

    public static List<Exercise> GetExercisesForConnector(Connector connector)
    {
        var projectRoot = Path.Combine(AppContext.BaseDirectory, "..", "..", ".."); // goes from bin\Debug\net10.0 up to project folder
        var filePath = Path.Combine(projectRoot, "Sentences", connector.Type, connector.JsonFileName + ".json");
        filePath = Path.GetFullPath(filePath);

        if (!File.Exists(filePath))
        {
            // throw new FileNotFoundException($"No JSON file found for connector '{connectorName}'", filePath);
            return new List<Exercise>();
        }

        return LoadExercisesFromJson(filePath, connector);
    }

    private static List<Exercise> LoadExercisesFromJson(string filePath, Connector correctConnector)
    {
        var sentences = JsonSerializer.Deserialize<string[]>(File.ReadAllText(filePath))!;

        var connector = Connectors.All.First(c => c.Name == correctConnector.Name);

        var exercises = new List<Exercise>();

        foreach (var sentence in sentences)
        {
            Connector[] distractors = Connectors.All
                .Where(c => c.Name != correctConnector.Name)
                .OrderBy(_ => Guid.NewGuid())
                .Take(Constants.TotalNumberOfOptions - 1)
                .ToArray();

            Connector[] options = distractors
                .Append(correctConnector)
                .OrderBy(_ => Guid.NewGuid())
                .ToArray();

            exercises.Add(new Exercise
            {
                Text = sentence,
                Options = options,
                CorrectOption = correctConnector,
                Explanation = connector.Explanation
            });
        }

        return exercises;
    }

    #endregion

}