using System;
using System.Diagnostics;
/*! \mainpage Programová dokumentace Reakčních rychlostí
 *
 * \section intro Úvod
 *
 * Tento program slouží ke generování náhodných příkladů. Kód byl vytvořen v jazyce C# v IDE Visual Studio.
 *
 * \section motiv Zadání projektu:
 *Program se postupně dotazuje uživatele na výsledek pěti pseudonáhodně generovaných jednoduchých výrazů a [+*-/] b(a , b∈⟨−10,10⟩ ), přičemž měří reakční dobu a vyhodnocuje správnost.
 * 
 * VSTUP:
 * 
 * • Reakce uživatele na příklady v podobě zadaných výsledků
 * 
 * VÝSTUP:
 * 
 * • Informace o úspěšnosti(kolikrát bylo zodpovězeno správně)
 * 
 * • Informace o průměrné reakční době.
 * 
 * Cílem tohoto programu je ukázat jednoduchý kód pro generování náhodných příkladů. Odkaz na repozitář programu:
 *  - https://github.com/sablikj/nvs_projekt
 *
 * 
 * Autoři projektu Adéla Kovářová, Jan Sáblík, David Bilnica.
 */


namespace ReakcniRychlosti
{
    /**
    * \brief Metoda vrací úspěšnost uživatele a jeho průměrnou reakční dobu
    * \return Metoda získáva vstup od uživatele na základě vygenerovaných příkladů
    */
    class Program
    {

        static void Main(string[] args)
        {

            Stopwatch cas = new Stopwatch(); /*Třída pro měření času*/
            Random random = new Random(); /*Třída pro generování náhodných čísel */
            int uspesnost = 0; /*Proměnná pro meření úspešnosti uživatele */
            char[] znamenka = new char[] { '+', '-', '/', '*' }; /*Pole operátorů pro náhoodné generování příkladů*/
            TimeSpan time = new TimeSpan { }; /*Časový interval jednoho cyklu */
            TimeSpan vs; /*Průměrná délka všech cyklů */
            string uplynulycas; /*Řetězec pro vypsání průměrného času*/
            

            for (int i = 0; i < 5; i++) /*Cyklus pro generování příkladů */
            {
                int a = random.Next(-10, 10); /*Generování náhodné proměnné a z intervalu */
                int b = random.Next(-10, 10); /*Generování náhodné proměnné b z intervalu */
                
                char rand = znamenka[random.Next(znamenka.Length)]; /*Řetězec pro vygenerování náhodného znaménka*/
               
                double vysledek; /*Výsledek vygenerovaného příkladu*/

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

                if (rand == '/' && b == 0)
                {
                    --i;
                    continue;
                }

                cas.Start();
                int odpoved;
            
                string vstup = Console.ReadLine(); /*Vstup uživatele */
                Type tp = vstup.GetType();
                if (tp.Equals(typeof(string)))
                {
                    Console.WriteLine("Zadej cislo");
                    odpoved = int.Parse(Console.ReadLine());
                }
                else
                {
                    odpoved = int.Parse(vstup);
                }
                
                cas.Stop();

                if (odpoved == vysledek)
                {
                    ++uspesnost;
                }
            }
            time += cas.Elapsed;
            vs = time / 5 ;

            
            uplynulycas = String.Format("{00:00}.{00:00}", vs.Seconds, vs.Milliseconds);
            

            Console.WriteLine($"Vase uspesnost je: {uspesnost}/5");                       
            Console.WriteLine($"Vase prumerna reakcni doba je:{uplynulycas}");
       
                        
            Console.ReadKey();          

        }
    }
}
