using FrenchConnectors;
using System.Drawing;

internal class Program
{
    private static bool debug = true;
    
    static void Main()
    {
        Console.WriteLine("Bienvenue à l'entraînement des connecteurs français !");
        while (true)
        {
            Console.WriteLine("\nChoisissez une option :");
            Console.WriteLine("S - Commencer le jeu");
            Console.WriteLine("D - Lister tous les connecteurs");
            Console.WriteLine("F - Lister les connecteurs par type");
            Console.WriteLine("Q - Quitter");

            var choice = Console.ReadLine()?.Trim().ToUpper();

            if (choice == "Q")
            {
                Console.WriteLine("Au revoir !");
                break; // exit only on Q
            }

            switch (choice)
            {
                case "S":
                    var exercises = GetAllConnectorsExercises();
                    if (exercises.Count > 0)
                        RunExercises(exercises);
                    else
                        Console.WriteLine("Aucun exercice trouvé.");
                    break;

                case "D":
                    ListAllConnectors();
                    break;

                case "F":
                    ListConnectorsByUserType();
                    break;

                default:
                    Console.WriteLine("Option invalide, veuillez réessayer.");
                    break;
            }
        }
    }

    static void ListAllConnectors()
    {
        Console.WriteLine("\nListe de tous les connecteurs :\n");

        foreach (var connector in Connectors.All)
        {
            PrintConnector(connector, true);
        }
    }

    static void ListConnectorsByUserType()
    {
        var availableTypes = Connectors.All
            .Select(c => c.Type)
            .Distinct()
            .OrderBy(t => t) // optional: alphabetical order
            .ToList();

        Console.Write("\nEntrez le type de connecteur (options disponibles: ");
        Console.Write(string.Join(", ", availableTypes));
        Console.Write(") : ");
        var inputType = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(inputType))
        {
            Console.WriteLine("Type invalide.");
            return;
        }

        // Find connectors matching the type (case-insensitive)
        var filtered = Connectors.All
            .Where(c => string.Equals(c.Type, inputType, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine($"Aucun connecteur trouvé pour le type '{inputType}'.");
            return;
        }

        Console.WriteLine($"\nConnecteurs de type '{inputType}' :\n");

        foreach (var connector in filtered)
        {
            PrintConnector(connector, false);
        }
    }
    
    static void PrintConnector(Connector connector, bool showType)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"'{connector.Name}'");
        Console.ResetColor();

        if (showType)
        {
            Console.Write("Type : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(connector.Type);
            Console.ResetColor(); 
        }

        Console.Write("Explication : ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(connector.Explanation);
        Console.ResetColor();

        Console.Write("Notes : ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(connector.Notes);
        Console.ResetColor();

        Console.WriteLine(Constants.LineSeparator);
    }

    static List<Exercise> GetAllConnectorsExercises()
    {
        var allExercises = new List<Exercise>();
        foreach (var connector in Connectors.All)
        {
            var exercisesForConnector = ExercisesDatabase.GetExercisesForConnector(connector);
            
            if (debug)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Found {exercisesForConnector.Count} exercises for '{connector.Name}'.");
                Console.ResetColor();
            }

            allExercises.AddRange(exercisesForConnector);
        }

        if (debug)
        {
            int allPossibleExercisesCount = Connectors.All.Count() * 20;
            int allExercisesFoundCount = allExercises.Count();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Found {allExercisesFoundCount}/{allPossibleExercisesCount} exercises.");
            Console.ResetColor();
        }
        
        return allExercises;
    }

    #region Exercise Runner

    
    static void RunExercises(List<Exercise> exercises)
    {
        var randomizedExercises = exercises.OrderBy(_ => Guid.NewGuid()).ToList();

        for (int j = 0; j < randomizedExercises.Count; j++)
        {
            Exercise? ex = randomizedExercises[j];

            if (debug)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\n{ex.Text}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                int exerciseIndex = exercises.FindIndex(re => re.Text == ex.Text);
                Console.WriteLine($" ({exerciseIndex + 1}/{randomizedExercises.Count})");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n{ex.Text}");
                Console.ResetColor();
            }

            for (int i = 0; i < ex.Options.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{i + 1}. {ex.Options[i].Name}");
                Console.ResetColor();
            }

            Console.Write($"Votre réponse (1-{Constants.TotalNumberOfOptions}, Q pour quitter) : ");
            var answer = Console.ReadLine()?.Trim().ToUpper();

            if (answer == "Q") break;

            if (int.TryParse(answer, out int idx) && idx >= 1 && idx <= Constants.TotalNumberOfOptions)
            {
                if (ex.Options[idx - 1].Name == ex.CorrectOption.Name)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct !");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Faux ! Réponse correcte : {ex.CorrectOption.Name}");
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Explication : {ex.Explanation}");
                Console.ResetColor();
                foreach (var wrongOption in ex.Options)
                {
                    if (wrongOption.Name == ex.CorrectOption.Name)
                    {
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(wrongOption.Explanation);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
    
    #endregion
}
