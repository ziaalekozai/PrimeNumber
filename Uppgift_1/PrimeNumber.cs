using System;
using System.Collections.Generic;

public class PrimeNumber
{
    private static List<int> nummer = new List<int>();                  //En list som sparar data.

    public static void primtal()                                            // Metod som inbär ett menu.
    {
        var loop = true;
        while (loop)                                                        // loopar.
        {
            Console.WriteLine("=========================================================================");
            Console.WriteLine(
                "[A] Ange talet\n" +
                "[S] Skriva ut hela data\n" +
                "[H] Hita nästa Primtal \n" +
                "[C] För att stäng av");
            Console.WriteLine("=========================================================================");

            var userInput = Console.ReadLine().ToLower();

            if (userInput == "a")
            {
                Console.WriteLine("Skriv ett tal");
                var input = inputControllar();

                var findPrimeNum = FindPrimeNumber(input);
                if (findPrimeNum == false)
                {
                    Console.WriteLine("Talet är inte ett primtal.");
                }
                else if (findPrimeNum)
                {
                    Console.WriteLine("Talet är ett primtal.");
                    nummer.Add(input);
                }
            }
            else if (userInput == "s")
            {
                nummer.Sort();                                                  // Skrivar ut sparande data, sorterat.
                for (int i = 0; i < nummer.Count; i++)
                {
                    Console.WriteLine($"Input {i} Primtal  = {nummer[i]}");
                }
            }
            else if (userInput == "h")
            {
                find_Next_PrimeNumber();
            }
            else if (userInput == "c")
            {
                loop = false;                                                 // (loop = false) för att stänga av programmet.
                Console.WriteLine("Välkommen åter!");
                break;
            }
            else
            {
                inputControllar();
            }
            Console.ReadLine();
            Console.Clear();
        }
    }

    private static int inputControllar()
    {
        int check;
        while (!int.TryParse(Console.ReadLine(), out check))             //Kolla om input är inte int så-
        {                                                           //skicka ett medalande att talet är inte int.
            Console.Clear();
            Console.WriteLine("Du har skrivt ett fel input försök igen.");
            primtal();
        }
        return check;
    }

    private static bool FindPrimeNumber(int input)
    {
        int divisor = 0;

        for (int i = 1; i <= input; i++)                                // En for loop som kollar efter primtal.
        {
            if (input % i == 0)
            {
                divisor++;
            }
        }
        if (divisor == 2)
        {
            return true;
        }
        return false;
    }

    private static void find_Next_PrimeNumber()
    {
        var next_Prime_Num = 0;

        nummer.Sort();
        if (nummer.Count != 0)
        {
            next_Prime_Num = nummer[nummer.Count - 1];                      //Hitta nästa tal
        }
        var loop = true;
        while (loop)
        {
            next_Prime_Num++;
            if (FindPrimeNumber(next_Prime_Num))
            {
                Console.WriteLine("Nästa primtal är " + next_Prime_Num);
                nummer.Add(next_Prime_Num);                                 // lägga till nästa primtal i lista
                loop = false;
            }
        }
    }
}