using ProgrammingFellowLocator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingFellowLocator.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder fellowListOnString = new StringBuilder();
            string key = "S";
            if (args.Length == 0)
            {
                while (key.ToUpper() == "S")
                {
                    string input = "";
                    do
                    {
                        Console.WriteLine("Informe uma localização válida do amigo no formato Nome:ValorDeX,ValorDeY");
                        input = Console.ReadLine();
                    } while (FellowValidator.ValidateFellowString(input) == false);

                    if (fellowListOnString.Length == 0)
                    {
                        fellowListOnString.Append(input);
                    }
                    else
                    {
                        fellowListOnString.AppendFormat("{0}{1}", ";", input);
                    }

                    Console.WriteLine("Deseja informar outro (S/N)?");
                    key = Console.ReadLine();
                }

                var fellowLocatorManager = new FellowLocatorManager(fellowListOnString.ToString());

                Console.WriteLine("Informe o nome do amigo que você deseja visitar");
                string fellowName = Console.ReadLine();


                key = "S";
                while (key.ToUpper() == "S")
                {
                    try
                    {
                        List<Fellow> fellowList = fellowLocatorManager.ClosestFellows(fellowName);

                        foreach (Fellow fellowItem in fellowList)
                        {
                            Console.WriteLine("{0} está perto de você", fellowItem.Name);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Amigo não encontrado");
                    }

                    Console.WriteLine("Deseja informar outro (S/N)?");
                    key = Console.ReadLine();
                }
            }
        }
    }
}
