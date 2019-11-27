using System;
using System.Diagnostics;

namespace ReakcniRychlosti
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch cas = new Stopwatch();
            Random random = new Random();
            int uspesnost = 0;
            char[] znamenka = new char[] { '+', '-', '/', '*' };
            TimeSpan avg = new TimeSpan { };
            TimeSpan vs;
            string uplynulycas;
            string uplynuly;


            for (int i = 0; i < 5; i++)
            {
                int a = random.Next(-10, 10);
                int b = random.Next(-10, 10);
                char rand = znamenka[random.Next(znamenka.Length)];

                double vysledek;

                if (rand == '+')
                {
                    vysledek = a + b;
                }
                else if (rand == '-')
                {
                    vysledek = a - b;
                }
                else if (rand == '*')
                {
                    vysledek = a * b;
                }
                else
                {
                    vysledek = a / b;
                }

                if (b < 0)
                {
                    Console.WriteLine($"Vypocitej: {a}{rand}({b})");
                }
                else
                {
                    Console.WriteLine($"Vypocitej: {a}{rand}{b}");
                }

                cas.Start();
                int odpoved = int.Parse(Console.ReadLine());

                cas.Stop();

                if (odpoved == vysledek)
                {
                    ++uspesnost;
                }
            }
            avg += cas.Elapsed;
            vs = avg / 5;


            uplynulycas = String.Format("{00:00}.{00:00}", vs.Seconds, vs.Milliseconds);
            uplynuly = String.Format("{00:00}.{00:00}", avg.Seconds, avg.Milliseconds);

            Console.WriteLine($"Vase uspesnost je: {uspesnost}/5");
            Console.WriteLine($"Vase prumerna reakcni doba je:{uplynulycas}");
            // Console.WriteLine($"Celkova doba je:{uplynuly}");

            Console.ReadKey();

        }
    }
}
