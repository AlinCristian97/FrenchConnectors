namespace FrenchConnectors;

public static class Connectors
{
    public static readonly IReadOnlyList<Connector> All = new List<Connector>
    {
        // Coordination
        new() { Name = Constants.ConnectorNames.Et, Type = Constants.ConnectorTypes.Coordination, Explanation = "'et' exprime l'addition.", JsonFileName = nameof(Constants.ConnectorNames.Et), Notes = "Très courant, utilisé tous les jours pour additionner." },
        new() { Name = Constants.ConnectorNames.Ou, Type = Constants.ConnectorTypes.Coordination, Explanation = "'ou' exprime l'alternative.", JsonFileName = nameof(Constants.ConnectorNames.Ou), Notes = "Très courant, introduit un choix." },
        new() { Name = Constants.ConnectorNames.NiNi, Type = Constants.ConnectorTypes.Coordination, Explanation = "'ni... ni' exprime la négation combinée.", JsonFileName = nameof(Constants.ConnectorNames.NiNi), Notes = "Moins courant, plutôt littéraire." },
        new() { Name = Constants.ConnectorNames.Mais, Type = Constants.ConnectorTypes.Coordination, Explanation = "'mais' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.Mais), Notes = "Très courant, contraste simple." },
        new() { Name = Constants.ConnectorNames.Donc, Type = Constants.ConnectorTypes.Coordination, Explanation = "'donc' exprime la conséquence.", JsonFileName = nameof(Constants.ConnectorNames.Donc), Notes = "Très courant, exprime la conclusion." },
        new() { Name = Constants.ConnectorNames.Alors, Type = Constants.ConnectorTypes.Coordination, Explanation = "'alors' exprime la conséquence.", JsonFileName = nameof(Constants.ConnectorNames.Alors), Notes = "Courant, parfois pour introduire un moment temporel." },
        new() { Name = Constants.ConnectorNames.Car, Type = Constants.ConnectorTypes.Coordination, Explanation = "'car' exprime la cause.", JsonFileName = nameof(Constants.ConnectorNames.Car), Notes = "Formel, plus fréquent à l'écrit qu'à l'oral." },

        // Cause / Reason
        new() { Name = Constants.ConnectorNames.ParceQue, Type = Constants.ConnectorTypes.Cause, Explanation = "'parce que' exprime la cause.", JsonFileName = nameof(Constants.ConnectorNames.ParceQue), Notes = "Très courant, oral et écrit." },
        new() { Name = Constants.ConnectorNames.Puisque, Type = Constants.ConnectorTypes.Cause, Explanation = "'puisque' exprime la cause.", JsonFileName = nameof(Constants.ConnectorNames.Puisque), Notes = "Courant à l'écrit, légèrement formel." },
        new() { Name = Constants.ConnectorNames.Comme, Type = Constants.ConnectorTypes.Cause, Explanation = "'comme' exprime la cause.", JsonFileName = nameof(Constants.ConnectorNames.Comme), Notes = "Souvent en début de phrase, plus écrit que parlé." },
        new() { Name = Constants.ConnectorNames.EnRaisonDe, Type = Constants.ConnectorTypes.Cause, Explanation = "'en raison de' exprime la cause.", JsonFileName = nameof(Constants.ConnectorNames.EnRaisonDe), Notes = "Formel, administratif." },
        new() { Name = Constants.ConnectorNames.GraceA, Type = Constants.ConnectorTypes.Cause, Explanation = "'grâce à' exprime la cause favorable.", JsonFileName = nameof(Constants.ConnectorNames.GraceA), Notes = "Courant, exprime une cause positive." },
        new() { Name = Constants.ConnectorNames.ACauseDe, Type = Constants.ConnectorTypes.Cause, Explanation = "'à cause de' exprime la cause défavorable.", JsonFileName = nameof(Constants.ConnectorNames.ACauseDe), Notes = "Très courant, exprime une cause négative." },

        // Consequence / Result
        new() { Name = Constants.ConnectorNames.ParConsequent, Type = Constants.ConnectorTypes.Consequence, Explanation = "'par conséquent' exprime la conséquence.", JsonFileName = nameof(Constants.ConnectorNames.ParConsequent), Notes = "Courant, souvent écrit." },
        new() { Name = Constants.ConnectorNames.CestPourquoi, Type = Constants.ConnectorTypes.Consequence, Explanation = "'c’est pourquoi' exprime la conséquence.", JsonFileName = nameof(Constants.ConnectorNames.CestPourquoi), Notes = "Courant, exprime un lien logique clair." },
        new() { Name = Constants.ConnectorNames.SiBienQue, Type = Constants.ConnectorTypes.Consequence, Explanation = "'si bien que' exprime la conséquence.", JsonFileName = nameof(Constants.ConnectorNames.SiBienQue), Notes = "Moins courant, écrit ou littéraire." },
        new() { Name = Constants.ConnectorNames.DeSorteQue, Type = Constants.ConnectorTypes.Consequence, Explanation = "'de sorte que' exprime la conséquence.", JsonFileName = nameof(Constants.ConnectorNames.DeSorteQue), Notes = "Formel, écrit." },

        // Opposition / Contrast
        new() { Name = Constants.ConnectorNames.Cependant, Type = Constants.ConnectorTypes.Opposition, Explanation = "'cependant' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.Cependant), Notes = "Courant à l'écrit, un peu formel." },
        new() { Name = Constants.ConnectorNames.Pourtant, Type = Constants.ConnectorTypes.Opposition, Explanation = "'pourtant' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.Pourtant), Notes = "Courant, écrit et oral." },
        new() { Name = Constants.ConnectorNames.Toutefois, Type = Constants.ConnectorTypes.Opposition, Explanation = "'toutefois' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.Toutefois), Notes = "Formel, écrit." },
        new() { Name = Constants.ConnectorNames.EnRevanche, Type = Constants.ConnectorTypes.Opposition, Explanation = "'en revanche' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.EnRevanche), Notes = "Courant, exprime un contraste fort." },
        new() { Name = Constants.ConnectorNames.AuContraire, Type = Constants.ConnectorTypes.Opposition, Explanation = "'au contraire' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.AuContraire), Notes = "Courant, surtout oral." },
        new() { Name = Constants.ConnectorNames.Malgre, Type = Constants.ConnectorTypes.Opposition, Explanation = "'malgré' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.Malgre), Notes = "Courant, indique une opposition malgré quelque chose." },
        new() { Name = Constants.ConnectorNames.BienQue, Type = Constants.ConnectorTypes.Opposition, Explanation = "'bien que' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.BienQue), Notes = "Très courant, souvent utilisé avec le subjonctif." },
        new() { Name = Constants.ConnectorNames.Quoique, Type = Constants.ConnectorTypes.Opposition, Explanation = "'quoique' exprime l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.Quoique), Notes = "Courant, formel ou écrit." },

        // Addition / Emphasis
        new() { Name = Constants.ConnectorNames.DePlus, Type = Constants.ConnectorTypes.Addition, Explanation = "'de plus' exprime l'addition.", JsonFileName = nameof(Constants.ConnectorNames.DePlus), Notes = "Courant, souvent écrit." },
        new() { Name = Constants.ConnectorNames.EnOutre, Type = Constants.ConnectorTypes.Addition, Explanation = "'en outre' exprime l'addition.", JsonFileName = nameof(Constants.ConnectorNames.EnOutre), Notes = "Formel, écrit." },
        new() { Name = Constants.ConnectorNames.Dailleurs, Type = Constants.ConnectorTypes.Addition, Explanation = "'d’ailleurs' exprime l'addition.", JsonFileName = nameof(Constants.ConnectorNames.Dailleurs), Notes = "Courant, oral et écrit." },
        new() { Name = Constants.ConnectorNames.NonSeulementMaisAussi, Type = Constants.ConnectorTypes.Addition, Explanation = "'non seulement... mais aussi' exprime l'addition.", JsonFileName = nameof(Constants.ConnectorNames.NonSeulementMaisAussi), Notes = "Formel, un peu littéraire." },

        // Time / Sequence
        new() { Name = Constants.ConnectorNames.Puis, Type = Constants.ConnectorTypes.Time, Explanation = "'puis' exprime la succession dans le temps.", JsonFileName = nameof(Constants.ConnectorNames.Puis), Notes = "Courant, oral et écrit." },
        new() { Name = Constants.ConnectorNames.Ensuite, Type = Constants.ConnectorTypes.Time, Explanation = "'ensuite' exprime la succession dans le temps.", JsonFileName = nameof(Constants.ConnectorNames.Ensuite), Notes = "Très courant, suivi logique." },
        new() { Name = Constants.ConnectorNames.AvantQue, Type = Constants.ConnectorTypes.Time, Explanation = "'avant que' exprime une antériorité.", JsonFileName = nameof(Constants.ConnectorNames.AvantQue), Notes = "Courant, utilisé avec le subjonctif." },
        new() { Name = Constants.ConnectorNames.ApresQue, Type = Constants.ConnectorTypes.Time, Explanation = "'après que' exprime une postériorité.", JsonFileName = nameof(Constants.ConnectorNames.ApresQue), Notes = "Courant, suivi d’un indicatif." },
        new() { Name = Constants.ConnectorNames.Dabord, Type = Constants.ConnectorTypes.Time, Explanation = "'d’abord' exprime la première action.", JsonFileName = nameof(Constants.ConnectorNames.Dabord), Notes = "Très courant, oral et écrit." },
        new() { Name = Constants.ConnectorNames.Finalement, Type = Constants.ConnectorTypes.Time, Explanation = "'finalement' exprime la conclusion temporelle.", JsonFileName = nameof(Constants.ConnectorNames.Finalement), Notes = "Courant, souvent à l’écrit." },
        new() { Name = Constants.ConnectorNames.TandisQue, Type = Constants.ConnectorTypes.Time, Explanation = "'tandis que' exprime la simultanéité ou l'opposition.", JsonFileName = nameof(Constants.ConnectorNames.TandisQue), Notes = "Courant, oral et écrit, exprime simultanéité ou contraste." },
        new() { Name = Constants.ConnectorNames.Lorsque, Type = Constants.ConnectorTypes.Time, Explanation = "'lorsque' exprime le moment où une action se produit, équivalent à 'quand' en français.", JsonFileName = nameof(Constants.ConnectorNames.Lorsque), Notes = "Courant, écrit et parlé, utilisé pour indiquer le moment précis d'une action ou d'un événement." },

        // Condition
        new() { Name = Constants.ConnectorNames.Si, Type = Constants.ConnectorTypes.Condition, Explanation = "'si' exprime la condition.", JsonFileName = nameof(Constants.ConnectorNames.Si), Notes = "Très courant, oral et écrit." },
        new() { Name = Constants.ConnectorNames.AConditionQue, Type = Constants.ConnectorTypes.Condition, Explanation = "'à condition que' exprime la condition.", JsonFileName = nameof(Constants.ConnectorNames.AConditionQue), Notes = "Courant, utilisé avec le subjonctif." },
        new() { Name = Constants.ConnectorNames.PourvuQue, Type = Constants.ConnectorTypes.Condition, Explanation = "'pourvu que' exprime la condition.", JsonFileName = nameof(Constants.ConnectorNames.PourvuQue), Notes = "Formel, moins courant à l’oral." },
        new() { Name = Constants.ConnectorNames.AuCasOu, Type = Constants.ConnectorTypes.Condition, Explanation = "'au cas où' exprime la condition.", JsonFileName = nameof(Constants.ConnectorNames.AuCasOu), Notes = "Courant, exprime une hypothèse." },
        new() { Name = Constants.ConnectorNames.DansLeCasOu, Type = Constants.ConnectorTypes.Condition, Explanation = "'dans le cas où' exprime la condition.", JsonFileName = nameof(Constants.ConnectorNames.DansLeCasOu), Notes = "Formel, écrit ou administratif." },

        // Concession
        new() { Name = Constants.ConnectorNames.MemeSi, Type = Constants.ConnectorTypes.Concession, Explanation = "'même si' exprime la concession.", JsonFileName = nameof(Constants.ConnectorNames.MemeSi), Notes = "Très courant, oral et écrit." },
        new() { Name = Constants.ConnectorNames.EncoreQue, Type = Constants.ConnectorTypes.Concession, Explanation = "'encore que' exprime la concession.", JsonFileName = nameof(Constants.ConnectorNames.EncoreQue), Notes = "Moins courant, formel ou littéraire." },

        // Purpose / Goal
        new() { Name = Constants.ConnectorNames.PourQue, Type = Constants.ConnectorTypes.Purpose, Explanation = "'pour que' exprime le but.", JsonFileName = nameof(Constants.ConnectorNames.PourQue), Notes = "Courant, utilisé avec le subjonctif." },
        new() { Name = Constants.ConnectorNames.AfinQue, Type = Constants.ConnectorTypes.Purpose, Explanation = "'afin que' exprime le but.", JsonFileName = nameof(Constants.ConnectorNames.AfinQue), Notes = "Formel, surtout écrit." },
        new() { Name = Constants.ConnectorNames.DePeurQue, Type = Constants.ConnectorTypes.Purpose, Explanation = "'de peur que' exprime le but ou la crainte.", JsonFileName = nameof(Constants.ConnectorNames.DePeurQue), Notes = "Formel, rare à l’oral." },
        new() { Name = Constants.ConnectorNames.DeFaconA, Type = Constants.ConnectorTypes.Purpose, Explanation = "'de façon à' exprime le but.", JsonFileName = nameof(Constants.ConnectorNames.DeFaconA), Notes = "Courant, surtout écrit." },

        // Comparison
        new() { Name = Constants.ConnectorNames.AinsiQue, Type = Constants.ConnectorTypes.Comparison, Explanation = "'ainsi que' exprime la comparaison.", JsonFileName = nameof(Constants.ConnectorNames.AinsiQue), Notes = "Courant, écrit et oral." },
        new() { Name = Constants.ConnectorNames.DeMemeQue, Type = Constants.ConnectorTypes.Comparison, Explanation = "'de même que' exprime la comparaison.", JsonFileName = nameof(Constants.ConnectorNames.DeMemeQue), Notes = "Formel, surtout écrit." },
        new() { Name = Constants.ConnectorNames.AutantQue, Type = Constants.ConnectorTypes.Comparison, Explanation = "'autant que' exprime la comparaison.", JsonFileName = nameof(Constants.ConnectorNames.AutantQue), Notes = "Courant, utilisé pour comparer des quantités ou qualités." },
        new() { Name = Constants.ConnectorNames.CommeSi, Type = Constants.ConnectorTypes.Comparison, Explanation = "'comme si' est une conjonction qui introduit une proposition subordonnée hypothétique ou comparative, exprimant une situation irréelle ou imaginaire.", JsonFileName = nameof(Constants.ConnectorNames.CommeSi), Notes = "Fixe et invariable ; suivi généralement de l'imparfait pour des situations présentes/fictives ou du plus-que-parfait pour des situations passées irréelles. Courant à l'écrit et à l'oral." },

    }.AsReadOnly();
}
