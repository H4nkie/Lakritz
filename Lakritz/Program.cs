namespace Lakritz
{
    internal class Program
    {
        /// <summary>
        /// Glasinhalt:
        ///     Eine Liste mit den Süßigkeiten im Glas
        /// </summary>
        static List<Suessigkeit> _glasInhalt = new List<Suessigkeit>();
        static void Main( string[] args )
        {
            // Zähler für die Anzahl der Süßigkeitenentnahme
            int zaehler = 0;

            // Methode um das Glas mit Random-Süßigkeiten zu befüllen
            FuelleGlas();

            // Nimm zwei Süßigkeiten aus dem Glas, solange das Glas mehr als eine Süßigkeit beinhaltet.
            do
            {
                zaehler++;
                NimmZwei( zaehler );
            }
            /*
             *  Frage C beantwortet: Der Vorgang ist deterministisch, weil die Anzahl der Gummibärchen im Glas abnimmt und gezogene Gummibärchen
             *  vernascht werden und nie wieder aufgefüllt werden. Die Anzahl der Süßigkeiten reduziert sich, 
             *  da durch die 2.Regel und 3.Regel die Anzahl der Süßigkeiten um eins reduziert wird. Es gibt aber keine Regel, die die Anzahl der Süßigkeiten erhöht.
             */
            while( _glasInhalt . Count > 1 );
        }
        /// <summary>
        /// Das Glas wird mit vielen Lakritzschnecken und Gummibärchen gefüllt.
        /// </summary>
        private static void FuelleGlas()
        {   
            // Zufallsinstanz
            Random random = new Random();

            // Zuerst die Lakritzschnecken
            int lakritzeAnzahl = random . Next( 15, 40 );
            for( int i = 1; i <= lakritzeAnzahl; i++ )
            {
                Suessigkeit lakritz = new Suessigkeit(){ Lakritz = true, Gummibaerchen = false };
                _glasInhalt . Add( lakritz );
            }
            Console . WriteLine( $"Das Glas wurde mit {_glasInhalt.Count} Lakritzschnecken gefüllt." );

            // Dann die Gummibärchen
            int gummibaerchenAnzahl = random . Next( 15, 40 );
            for( int i = 1; i <= gummibaerchenAnzahl; i++ )
            {
                Suessigkeit gummibaerchen = new Suessigkeit(){ Lakritz = false, Gummibaerchen = true };
                _glasInhalt . Add( gummibaerchen );
            }
            Console . WriteLine( $"Das Glas wurde mit {gummibaerchenAnzahl} Gummibärchen gefüllt." );
            Console . WriteLine( $"Es befinden sich {_glasInhalt . Count} Süßigkeiten im Glas." );
        }

        /// <summary>
        /// Zwei zufällige Süßigkeiten werden aus dem Glas genommen.
        /// </summary>
        /// <param name="zaehler"></param>
        private static void NimmZwei( int zaehler )
        {   
            Console . WriteLine( $"--------- {zaehler}. Durchlauf ---------" );
            Random random = new Random();

            // Greife ins Glas und nimm eine zufällige Süßigkeit heraus.
            int ersteSuessigkeit = random . Next( 0, _glasInhalt . Count - 1);
            // Gezogene Süßigkeit in string umwandeln für die Ausgabe
            string ersteSussigkeitName = ConvertInhaltToSuessigkeit( _glasInhalt[ ersteSuessigkeit ] );
            Console . Write( $"Gezogen wurde {ersteSussigkeitName} und " );
            // Die Süßigkeit aus dem Inhalt entfernen
            _glasInhalt . RemoveAt( ersteSuessigkeit );

            // repeat für zweite Süßigkeit
            int zweiteSuessigkeit = random . Next( 0, _glasInhalt . Count - 1 );
            string zweiteSuessigkeitName = ConvertInhaltToSuessigkeit( _glasInhalt[ zweiteSuessigkeit ] );
            Console . Write( $" {zweiteSuessigkeitName}." + Environment . NewLine );                      
            _glasInhalt . RemoveAt( zweiteSuessigkeit );

            // wurden 2 gleiche Süßigkeiten gezogen, werden beiden gegessen und eine neue Lakritzschnekce wird ins Glas getan
            if( ersteSussigkeitName == zweiteSuessigkeitName )
            {
                _glasInhalt . Add( new Suessigkeit() { Gummibaerchen = false, Lakritz = true } );
                Console . WriteLine( "Beide gezogenen Süßigkeiten wurden genascht und eine neue Lakritzschnecke wurde ins Glas getan." );
            }
            // wurden 2 unterschiedliche Süßigkeiten gezogen, wird die Lakritzschnecke gegessen und das Gummibärchen zurück ins Glas getan
            else
            {
                _glasInhalt . Add( new Suessigkeit() { Lakritz = false, Gummibaerchen = true } );
                Console . WriteLine( "Die Lakritzschnecke wurde genascht und das Gummibärchen wurde zurück ins Glas getan." );
            }   
            // Ausgabe des verbleibenden Glasinhaltes in Süßigkeiten
            Console . WriteLine($"Es sind noch {_glasInhalt.Count} Süßigkeiten im Glas.");
        }

        /// <summary>
        /// Der übergebene Inhalt wird in einen lesbaren string Konvertiert
        /// </summary>
        /// <param name="inhalt"></param>
        /// <returns></returns>
        private static string ConvertInhaltToSuessigkeit( Suessigkeit inhalt )
        {
            if( inhalt . Lakritz )
                return "eine Lakritzschnecke";
            else if( inhalt . Gummibaerchen )
                return "ein Gummibärchen";
            else
                return "Dieser Teil des Codes sollte nicht erreicht werden.";
        }

    }
}