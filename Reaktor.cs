using System;
using System.Threading;

class AtomreaktorSzimulator
{
    static Random random = new Random();
    static double hőfok = 0;
    static double energia = 0;
    static bool reaktorMukodik = false;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Atomreaktor szimulátor");
            Console.WriteLine("1. Beindítás");
            Console.WriteLine("2. Leállítás");
            Console.WriteLine("3. Generált energia mennyiség");
            Console.WriteLine("4. Hőfok");
            Console.WriteLine("5. Hűtővíz beengedése");
            Console.WriteLine("6. Kilépés");
            Console.Write("Válasszon egy menüpontot: ");

            string valasztas = Console.ReadLine();

            switch (valasztas)
            {
                case "1":
                    Beinditas();
                    break;
                case "2":
                    Leallitas();
                    break;
                case "3":
                    GeneraltEnergia();
                    break;
                case "4":
                    Hofok();
                    break;
                case "5":
                    Hutoviz();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Érvénytelen választás. Kérjük, próbálja újra.");
                    break;
            }

            Thread.Sleep(2000); // Egy kis várakozás, hogy a felhasználó láthassa az üzenetet
        }
    }

    static void Beinditas()
    {
        if (reaktorMukodik)
        {
            Console.WriteLine("A reaktor már működik.");
            return;
        }

        Console.WriteLine("Reaktor beindítása...");
        Thread.Sleep(2000);
        hőfok = random.Next(40, 101);
        energia = random.Next(1, 101);
        reaktorMukodik = true;

        Console.WriteLine($"Reaktor beindítva. Hőfok: {hőfok} °C, Generált energia: {energia} GW");
    }

    static void Leallitas()
    {
        if (!reaktorMukodik)
        {
            Console.WriteLine("A reaktor nem működik.");
            return;
        }

        if (hőfok > 70)
        {
            Console.WriteLine("A reaktor hőfoka túl magas a leállításhoz. Hűtse le a reaktort először.");
        }
        else
        {
            Console.WriteLine("Reaktor leállítása...");
            Thread.Sleep(2000);
            reaktorMukodik = false;
            Console.WriteLine("Reaktor leállítva.");
        }
    }

    static void GeneraltEnergia()
    {
        if (!reaktorMukodik)
        {
            Console.WriteLine("A reaktor nem működik.");
            return;
        }

        double ujEnergia = energia + random.Next(1, 11);
        energia = ujEnergia;
        Console.WriteLine($"Generált energia: {energia} GW");
    }

    static void Hofok()
    {
        if (!reaktorMukodik)
        {
            Console.WriteLine("A reaktor nem működik.");
            return;
        }

        Console.WriteLine($"Reaktor hőfoka: {hőfok} °C");
    }

    static void Hutoviz()
    {
        if (!reaktorMukodik)
        {
            Console.WriteLine("A reaktor nem működik.");
            return;
        }

        Console.WriteLine("Hűtővíz beengedése...");
        Thread.Sleep(2000);
        hőfok = 40;
        Console.WriteLine("Reaktor lehűtve 40 °C-ra.");
    }
}
