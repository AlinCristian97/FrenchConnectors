using FrenchConnectors;
using System.Diagnostics;
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

        PrintSentencesForConnector(connector);

        Console.WriteLine(Constants.LineSeparator);
    }

    private static void PrintSentencesForConnector(Connector connector)
    {
        if (connector.Name.Contains("..."))
        {
            return;
        }

        var examples = ExercisesDatabase.GetExercisesForConnector(connector);
        if (examples.Count == 0)
        {
            // no examples available
            if (debug)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("(No example sentences found in JSON.)");
                Console.ResetColor();
            }
        }
        else
        {
            var sampleCount = Math.Min(3, examples.Count);
            var samples = examples
                .OrderBy(_ => Guid.NewGuid())
                .Take(sampleCount)
                .Select(e => e.Text)
                .ToList();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            foreach (var s in samples)
            {
                string formattedSample = s.Replace(Constants.SentenceConnectorHideSymbol, connector.Name);
                Console.WriteLine(formattedSample);
            }
            Console.ResetColor();
        }
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

        int totalExercisesResolved = 0;
        int totalCorrect = 0;
        int totalWrong = 0;
        int currentStreak = 0;
        int maxStreak = 0;
        const int MinForStreak = 3;

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
            var (quitRequested, idx) = ReadAnswerForExercise(ex);

            if (quitRequested)
            {
                break;
            }

            totalExercisesResolved++;

            if (idx.HasValue && idx >= 1 && idx <= Constants.TotalNumberOfOptions)
            {
                bool isCorrect = ex.Options[idx.Value - 1].Name == ex.CorrectOption.Name;
                if (isCorrect)
                {
                    totalCorrect++;
                    currentStreak++;
                    if (currentStreak >= MinForStreak && currentStreak > maxStreak)
                    {
                        maxStreak = currentStreak;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    if (currentStreak >= MinForStreak)
                    {
                        Console.WriteLine($"Correct ! (Streak: {currentStreak} ^_^)");
                    }
                    else
                    {
                        Console.WriteLine("Correct !");
                    }
                }
                else
                {
                    totalWrong++;

                    Console.ForegroundColor = ConsoleColor.Red;

                    if (currentStreak >= MinForStreak)
                    {
                        Console.WriteLine($"Faux ! Streak of {currentStreak} ended -_- ! Réponse correcte : {ex.CorrectOption.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"Faux ! Réponse correcte : {ex.CorrectOption.Name}");
                    }

                    currentStreak = 0;
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

        // Session ended — show summary
        Console.WriteLine();
        Console.WriteLine(Constants.LineSeparator);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("*** Game Ended ***");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Total Exercises Resolved: {totalExercisesResolved}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Total Correct Answers: {totalCorrect}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Total Wrong Answers: {totalWrong}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Best Correct Streak: {maxStreak}");
        Console.ResetColor();

        Console.WriteLine(Constants.LineSeparator);
    }

    // Reads a single key repeatedly until a valid numeric answer is provided or user quits.
    // Pressing 'C' copies the exercise text immediately (no Enter required) and continues waiting for an answer.
    // Returns (quitRequested, selectedIndex). If quitRequested is true, selectedIndex is null.
    private static (bool QuitRequested, int? SelectedIndex) ReadAnswerForExercise(Exercise ex)
    {
        while (true)
        {
            var keyInfo = Console.ReadKey(true);

            // Copy to clipboard silently on 'C'
            if (keyInfo.Key == ConsoleKey.C)
            {
                try
                {
                    CopyTextToClipboard(ex.Text);
                }
                catch
                {
                    // keep silent on copy failure
                }
                continue;
            }

            // Quit on 'Q'
            if (keyInfo.Key == ConsoleKey.Q)
            {
                return (true, null);
            }

            // Determine numeric input (supports digits and numpad)
            int idx = -1;
            var keyChar = keyInfo.KeyChar;
            if (char.IsDigit(keyChar))
            {
                idx = (int)char.GetNumericValue(keyChar);
            }
            else
            {
                if (keyInfo.Key >= ConsoleKey.D0 && keyInfo.Key <= ConsoleKey.D9)
                    idx = keyInfo.Key - ConsoleKey.D0;
                else if (keyInfo.Key >= ConsoleKey.NumPad0 && keyInfo.Key <= ConsoleKey.NumPad9)
                    idx = keyInfo.Key - ConsoleKey.NumPad0;
            }

            if (idx >= 1 && idx <= Constants.TotalNumberOfOptions)
            {
                return (false, idx);
            }

            // invalid key, give minimal feedback
            Console.WriteLine("Invalid input.");
        }
    }


    private static void CopyTextToClipboard(string text)
    {
        var psi = new ProcessStartInfo("cmd", "/c clip")
        {
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var p = Process.Start(psi);
        if (p != null)
        {
            p.StandardInput.Write(text);
            p.StandardInput.Close();
            p.WaitForExit();
        }
    }
    
    #endregion
}
