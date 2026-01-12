namespace FrenchConnectors;

public static class Constants
{
    public const int TotalNumberOfOptions = 4;
    
    public static class ConnectorTypes
    {
        public const string Coordination = "Coordination";
        public const string Cause = "Cause";
        public const string Consequence = "Consequence";
        public const string Opposition = "Opposition";
        public const string Addition = "Addition";
        public const string Time = "Time";
        public const string Condition = "Condition";
        public const string Concession = "Concession";
        public const string Purpose = "Purpose";
        public const string Comparison = "Comparison";
    }
    
    public static class ConnectorNames
    {
        // Coordination
        public const string Et = "et";
        public const string Ou = "ou";
        public const string NiNi = "ni... ni";
        public const string Mais = "mais";
        public const string Donc = "donc";
        public const string Alors = "alors";
        public const string Car = "car";

        // Cause / Reason
        public const string ParceQue = "parce que";
        public const string Puisque = "puisque";
        public const string Comme = "comme";
        public const string EnRaisonDe = "en raison de";
        public const string GraceA = "grâce à";
        public const string ACauseDe = "à cause de";

        // Consequence / Result
        public const string ParConsequent = "par conséquent";
        public const string CestPourquoi = "c’est pourquoi";
        public const string SiBienQue = "si bien que";
        public const string DeSorteQue = "de sorte que";

        // Opposition / Contrast
        public const string Cependant = "cependant";
        public const string Pourtant = "pourtant";
        public const string Toutefois = "toutefois";
        public const string EnRevanche = "en revanche";
        public const string AuContraire = "au contraire";
        public const string Malgre = "malgré";
        public const string BienQue = "bien que";
        public const string Quoique = "quoique";

        // Addition / Emphasis
        public const string DePlus = "de plus";
        public const string EnOutre = "en outre";
        public const string Dailleurs = "d’ailleurs";
        public const string NonSeulementMaisAussi = "non seulement... mais aussi";

        // Time / Sequence
        public const string Puis = "puis";
        public const string Ensuite = "ensuite";
        public const string AvantQue = "avant que";
        public const string ApresQue = "après que";
        public const string Dabord = "d’abord";
        public const string Finalement = "finalement";
        public const string TandisQue = "tandis que";

        // Condition
        public const string Si = "si";
        public const string AConditionQue = "à condition que";
        public const string PourvuQue = "pourvu que";
        public const string AuCasOu = "au cas où";
        public const string DansLeCasOu = "dans le cas où";

        // Concession
        public const string MemeSi = "même si";
        public const string EncoreQue = "encore que";

        // Purpose / Goal
        public const string PourQue = "pour que";
        public const string AfinQue = "afin que";
        public const string DePeurQue = "de peur que";
        public const string DeFaconA = "de façon à";

        // Comparison
        public const string AinsiQue = "ainsi que";
        public const string DeMemeQue = "de même que";
        public const string AutantQue = "autant que";
    }

    public const string LineSeparator = "----------------------------------------";
}