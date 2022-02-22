namespace zar;

public class Program
{
    static List<String> lista = new List<String>(File.ReadAllLines(@"ajto.txt"));
    static string bKod = "";
    static Random rand = new Random();
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //1. feladat
        //lista;

        //2. feladat
        Feladat2();

        //3. feladat
        Feladat3();

        //4. feladat
        Feladat4();

        //5. feladat
        Feladat5();

        //6. feladat
        //nyit();

        //7. feladat
        Feladat7();

        Console.ReadKey();
    }
    private static void Feladat2()
    {
        Console.WriteLine("2. feladat");

        Console.Write("Adja meg, mi nyitja a zárat! ");
        bKod = Console.ReadLine(); 
    }
    private static void Feladat3()
    {
        Console.WriteLine("3. feladat");

        int sor = 0;

        foreach (var item in lista)
        {
            sor++;

            if (item == bKod) Console.Write($"{sor} ");
        }

        Console.WriteLine();
    }
    private static void Feladat4()
    {
        Console.WriteLine("4. feladat");

        int sor = 0;
        bool ismetlodo = false;

        foreach (var item in lista)
        {
            if (ismetlodo) break;
            sor++;

            var szamok = new List<char>();
            char[] probalkozas = item.ToCharArray();

            foreach (var szam in probalkozas)
            {
                szamok.Add(szam);

                if(szamok.Where(x => x.Equals(szam)).Count() != 1) ismetlodo = true;
            }
        }

        Console.WriteLine($"Az első ismétlődést tartalmazó próbálkozás sorszáma: {sor}");
    }
    private static void Feladat5()
    {
        Console.WriteLine("5. feladat");

        List<int> szamok = new List<int>();
        int szam = 0;

        for (int i = 0; i < bKod.Length; i++)
        {
            do
            {
                szam = rand.Next(0, 9);
            }
            while (szamok.Contains(szam));

            szamok.Add(szam);
        }

        Console.WriteLine($"Egy {bKod.Length} hosszú kódszám: {String.Join(null, szamok)}");
    }
    private static bool nyit(char[] jo, char[] proba)
    {
        bool egyezik = jo.Length == proba.Length ? true : false;

        if (egyezik)
        {
            var elteres = (char)jo[1] - (char)proba[1];

            for (int i = 2; i < jo.Length; i++)
            {
                if ((elteres - ((char)jo[i] - (char)proba[i])) % 10 != 0) egyezik = false;
            }
        }

        return egyezik;
    }
    private static void Feladat7()
    {
        StreamWriter sw = new StreamWriter(@"siker.txt");

        foreach (var item in lista)
        {
            string valasz = "";

            if (item.Length != bKod.Length) valasz = "hibás hossz";
            else if (!nyit(bKod.ToCharArray(), item.ToCharArray())) valasz = "hibás kódszám";
            else if (nyit(bKod.ToCharArray(), item.ToCharArray())) valasz = "sikeres";

            sw.WriteLine($"{item} {valasz}");
        }

        sw.Close();
    }
}