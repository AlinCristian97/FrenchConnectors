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

        return LoadExercisesFromJson(filePath, connector.Name);
    }

    private static List<Exercise> LoadExercisesFromJson(string filePath, string correctConnector)
    {
        var sentences = JsonSerializer.Deserialize<string[]>(File.ReadAllText(filePath))!;

        var connector = Connectors.All.First(c => c.Name == correctConnector);

        var exercises = new List<Exercise>();

        foreach (var sentence in sentences)
        {
            var distractors = Connectors.All
                .Where(c => c.Name != correctConnector)
                .OrderBy(_ => Guid.NewGuid())
                .Take(Constants.TotalNumberOfOptions - 1)
                .Select(c => c.Name)
                .ToArray();

            var options = new[] { correctConnector, distractors[0], distractors[1] }
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