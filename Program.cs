using System;

class Program
{
    private static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Bitte Startzeit und Endzeit in folgendem Format angeben: HH:mm");
            return;
        }

        try
        {
            DateTime startZeit = DateTime.Parse(args[0]);
            DateTime endZeit = DateTime.Parse(args[1]);

            var sollArbeitsstunden = 7 + 48.0 / 60.0; 
            var pausenMinuten = 45; 
            
            TimeSpan gearbeiteteZeit = endZeit - startZeit;

            TimeSpan gearbeiteteZeitOhnePause = gearbeiteteZeit - TimeSpan.FromMinutes(pausenMinuten);

            DateTime fruehesteEndZeit = startZeit.AddHours(sollArbeitsstunden).AddMinutes(pausenMinuten);
            
            var gearbeiteteGesamtstunden = gearbeiteteZeitOhnePause.TotalHours;
            var ueberstunden = gearbeiteteGesamtstunden - sollArbeitsstunden;

            Console.WriteLine($"Gearbeitete Zeit (ohne Pause): {gearbeiteteZeitOhnePause.Hours} Stunden und {gearbeiteteZeitOhnePause.Minutes} Minuten");
            Console.WriteLine($"Pause: {pausenMinuten} Minuten");
            Console.WriteLine($"Früheste mögliche Endzeit: {fruehesteEndZeit.ToString("HH:mm")}");
            
            var ueberstundenStunden = (int)ueberstunden;
            var ueberstundenMinuten = (int)((ueberstunden - ueberstundenStunden) * 60);

            if (ueberstunden >= 0)
            {
                Console.WriteLine($"Überstunden: {ueberstundenStunden:D2}:{ueberstundenMinuten:D2}");
            }
            else
            {
                var fehlstundenStunden = Math.Abs(ueberstundenStunden);
                var fehlstundenMinuten = Math.Abs(ueberstundenMinuten);
                Console.WriteLine($"Fehlstunden: {fehlstundenStunden:D2}:{fehlstundenMinuten:D2}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Fehler. Bitte Zeit im Format HH:mm eingeben.");
        }

        Console.WriteLine("Drücken eine Taste, um das Programm zu beenden.");
        Console.ReadLine();
    }
}
