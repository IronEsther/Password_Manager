using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiklausAndreaLB_450_V1
{
    public class UserInterface : IUserInterface
    {
        private readonly IPasswordManager passwordManager;

        public UserInterface(IPasswordManager manager)
        {
            passwordManager = manager;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Bitte wählen Sie eine Option:");
                Console.WriteLine("1. Passwort verschlüsseln");
                Console.WriteLine("2. Passwort entschlüsseln");
                Console.WriteLine("3. Passwortstärke bewerten");
                Console.WriteLine("4. Beenden");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Geben Sie das zu verschlüsselnde Passwort ein:");
                        string passwordToEncrypt = Console.ReadLine();
                        passwordManager.EncryptPassword(passwordToEncrypt);
                        break;
                    case "2":
                        Console.WriteLine("Geben Sie das zu entschlüsselnde Passwort ein:");
                        string passwordToDecrypt = Console.ReadLine();
                        passwordManager.DecryptPassword(passwordToDecrypt);
                        break;
                    case "3":
                        Console.WriteLine("Geben Sie das zu bewertende Passwort ein:");
                        string passwordToEvaluate = Console.ReadLine();
                        passwordManager.EvaluatePasswordStrength(passwordToEvaluate);
                        break;
                    case "4":
                        Console.WriteLine("Das Programm wird beendet.");
                        return;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie eine der angegebenen Optionen.");
                        break;
                }

                Console.WriteLine();

                //HZ 4.1 void Run() war zuerst hier, geändert zu IUserInterface
            }
        }
    }
}
