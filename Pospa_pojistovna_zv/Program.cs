using System.Linq;

namespace Pospa_pojistovna_zv
{
    internal class Program
    {
        static void Main(string[] args)
        {


            DatabazePojistenych databazePojistencu = new DatabazePojistenych();

            while (true)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Vítejte v aplikaci Pospa pojišťovna - databáze!");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Vyberte jednu z uvedených možností: ");
                Console.WriteLine("1 - Přidat nového pojištěného klienta");
                Console.WriteLine("2 - Vypiš celkový seznam všech pojištěných osob");
                Console.WriteLine("3 - Vyhledat konkrétního pojištěného klienta");
                Console.WriteLine("4 - Ukončit aplikace Pospa pojišťovny");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Jaké číslo možnosti chcete vybrat? ");

                string vybranaMoznostZeSeznamu = Console.ReadLine();
                int celkovySeznamAkci = 0;

                // Vybraná možnost ze seznamu musí být číslo!
                if (vybranaMoznostZeSeznamu.All(char.IsDigit))
                {
                    celkovySeznamAkci = int.Parse(vybranaMoznostZeSeznamu);
                }

                
                switch (celkovySeznamAkci)
                {
                    case 1:
                        try
                        {   
                            // Zadávání osobních informací o pojištěné osobě
                            PojistenaOsoba pojistenaOsoba = new PojistenaOsoba();
                            Console.WriteLine("Zadejte jméno pojištěného klienta:");
                            pojistenaOsoba.JmenoPojistence = Console.ReadLine();
                            if (pojistenaOsoba.JmenoPojistence.Length < 2)
                            {
                                Console.WriteLine("CHYBA! Délka jména obsahuje minimálně dva znaky!");
                                break;
                            }
                            Console.WriteLine("Zadejte přijmení pojištěného klienta:");
                            pojistenaOsoba.PrijmeniPojistence = Console.ReadLine();
                            if (pojistenaOsoba.PrijmeniPojistence.Length < 2)
                            {
                                Console.WriteLine("CHYBA! Délka příjmení obsahuje minimálně dva znaky!");
                                break;
                            }
                            Console.WriteLine("Zadejte věk pojištěného klienta:");
                            pojistenaOsoba.VekPojistence = int.Parse(Console.ReadLine());
                            Console.WriteLine("Zadejte telefonní číslo pojištěného klienta:");
                            pojistenaOsoba.TelefonPojistence = int.Parse(Console.ReadLine());
                            databazePojistencu.PridejPojistence(pojistenaOsoba);
                        }
                        catch (System.FormatException)
                        {
                            Console.WriteLine("Pojištěná osoba nebyla uložena z důvodu chybně uvedených dat! Zkuste to znova.");
                        }
                        break;

                    case 2:
                        //Jedná se o variantu, která vypíše všechny pojištěné osoby z databáze.
                        List<PojistenaOsoba> pojisteni = databazePojistencu.VypisSeznamPojistencu();
                        if (pojisteni.Count == 0)
                        {
                            Console.WriteLine("Nebyla nalezena žádná pojištěná osoba ze seznamu. Vyberte jinou možnost!");
                        }
                        else
                        {
                            foreach (PojistenaOsoba pojistenyOs in databazePojistencu.VypisSeznamPojistencu())
                            {
                                Console.WriteLine(pojistenyOs.ToString());
                            }
                        }
                        break;

                    case 3:
                        //Jedná se o variantu, která vyhledá pojištěnou osobu v databázi.
                        Console.WriteLine("Zadejte jméno pojištěného:");
                        string jmeno = Console.ReadLine();
                        Console.WriteLine("Zadejte přijmení pojištěného:");
                        string prijmeni = Console.ReadLine();
                        List<PojistenaOsoba> vyhledani = databazePojistencu.NajdiPojistence(jmeno, prijmeni);
                        if (vyhledani.Count == 0)
                        {
                            Console.WriteLine("Pojištěný nebyl nalezen!!!");
                        }
                        else
                        {
                            foreach (PojistenaOsoba po in vyhledani)
                            {
                                Console.WriteLine(po.ToString());
                            }
                        }
                        break;

                    case 4:
                        //Ukončení aplikace pojišťovny
                        Console.WriteLine("Aplikace Pospa pojišťovny byla ukončena. Děkujeme za použití a těšíme se opět na další použití!!!");
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("CHYBA! Opravdu bylo zadané číslo z uvedených možností správně napsané? Zkuste to ještě jednou!");
                        break;
                }
                Console.WriteLine("Zadejte prosím libovolnou klávesu a můžete opět pokračovat ve výběru možnosti ze seznamu...");
                Console.ReadKey();
                Console.Clear();
            }



        }
    }
}