﻿using System.Globalization;



/* PLAN
1. göra en "while" menyn som man kan navigera.
2. sätt in help och quit kommandon i loopen
3. välj vilka andra 4 kommandon och lägga in dom
*/
namespace MJU23v_DTP_T1
{
    public class Language
    {
        public string family, group;
        public string language, area, link;
        public int pop;
        public Language(string line)
        {
            string[] field = line.Split("|");
            family = field[0];
            group = field[1];
            language = field[2];
            pop = (int)double.Parse(field[3], CultureInfo.InvariantCulture);
            area = field[4];
            link = field[5];
        }
        public void Print()
        {
            Console.WriteLine($"Language {language}:");
            Console.Write($"  family: {family}");
            if (group != "")
                Console.Write($">{group}");
            Console.WriteLine($"\n  population: {pop}");
            Console.WriteLine($"  area: {area}");
        }
    }
    public class Program
    {
        static string dir = @"..\..\..";
        static List<Language> eulangs = new List<Language>();
        static void Main(string[] arg)
        {
            

            using (StreamReader sr = new StreamReader($"{dir}\\lang.txt"))
            {
                Language lang;
                string line = sr.ReadLine();
                while (line != null)
                {
                    // Console.WriteLine(line);
                    lang = new Language(line);
                    eulangs.Add(lang);
                    line = sr.ReadLine();
                }
            }
            Console.WriteLine("==== Languages in Spain ====");
            foreach (Language L in eulangs)
            {
                int index = L.area.IndexOf("Spain");
                if (index != -1)
                    L.Print();
            }
            Console.WriteLine("==== Baltic Languages ====");
            foreach (Language L in eulangs)
            {
                int index = L.group.IndexOf("Baltic");
                if (index != -1)
                    L.Print();
            }
            Console.WriteLine("==== Population larger than 50 millions ====");
            foreach (Language L in eulangs)
            {
                if (L.pop >= 50_000_000)
                    L.Print();
            }
            Console.WriteLine("==== Number of Germanics ====");
            int sumgerm = 0;
            foreach (Language L in eulangs)
            {
                int index = L.group.IndexOf("Germanic");
                if (index != -1)
                    sumgerm += L.pop;
            }
            Console.WriteLine($"Germanic speaking population: {sumgerm}");
            Console.WriteLine("==== Number of Romance ====");
            int sumromance = 0;
            foreach (Language L in eulangs)
            {
                int index = L.group.IndexOf("Romance");
                if (index != -1)
                    sumromance += L.pop;
            }
            Console.WriteLine($"Romance speaking population: {sumromance}");

            string[] input;
            Console.Write(">");
            do
            {
                input = Console.ReadLine().Split(' ');
                if (input[0] == "help")
                {
                    //TODO: Gör Help funtionen
                    Console.WriteLine("Waow");
                }
                else if (input[0] == "quit")
                {
                    Console.WriteLine("Adjö");
                }
                else if (input[0] == "list")
                {
                    foreach (Language L in eulangs)
                    {
                        if (L.pop >= 50_000_000)
                            L.Print();
                    }
                }
                else
                {
                    Console.WriteLine("Okänt kommand, Tönt");
                }

            } while (input[0] != "quit");
        }
    }
}
