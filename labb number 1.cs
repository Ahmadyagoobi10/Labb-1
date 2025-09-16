

using System;
class Program
{
    static void Main()
    {
        string input = "Sträng";

        // Lista för att spara startposition och längd på giltiga delsträngar
        List<(int start, int length)> validSubstrings = new List<(int, int)>();
        long totalSum = 0;

        int i = 0;

        while (i < input.Length)
        {
            // Hitta en sekvens av siffror
            if (char.IsDigit(input[i]))
            {
                int seqStart = i;

                // Gå igenom hela siffersekvensen
                while (i < input.Length && char.IsDigit(input[i]))
                    i++;

                int seqLength = i - seqStart;
                string sequence = input.Substring(seqStart, seqLength);

                // Kolla alla möjliga delsträngar i siffersekvensen
                for (int startSub = 0; startSub < sequence.Length; startSub++)
                {
                    for (int endSub = startSub + 1; endSub < sequence.Length; endSub++)
                    {
                        string sub = sequence.Substring(startSub, endSub - startSub + 1);

                        // Kontrollera om första och sista tecken är samma
                        if (sub[0] == sub[sub.Length - 1])
                        {
                            string middle = sub.Length > 2 ? sub.Substring(1, sub.Length - 2) : "";

                            // Kontrollera att mitten inte innehåller samma tecken som start/slut
                            if (!middle.Contains(sub[0]))
                            {
                                int globalStart = seqStart + startSub;

                                // Lägg till i listan och summera
                                validSubstrings.Add((globalStart, sub.Length));
                                totalSum += long.Parse(sub);
                            }
                        }
                    }
                }
            }
            else
            {
                i++; // Hoppa över bokstäver och andra tecken
            }
        }

        // Den här loopen går igenom varje delsträng som är markerad giltig tidigare i koden.
        foreach (var (start, length) in validSubstrings)
        {
            // 
            for (int idx = 0; idx < input.Length; idx++)
            {
                // När vi starten av delsträngen, då ändra färgen till grön
                if (idx == start)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(input[idx]);

                // när vi når slutet av delsträngen, då återställ färgen till standar.
                if (idx == start + length - 1)
                    Console.ResetColor();
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Summan av alla matchade tal: " + totalSum);
    }
}

