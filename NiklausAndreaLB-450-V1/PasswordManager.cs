using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiklausAndreaLB_450_V1;

namespace NiklausAndreaLB_450_V1
{
    public class PasswordManager : IPasswordManager
    {
        public void EncryptPassword(string password)
        {
            string encryptedPassword = Encipher(password, GetEncryptionKey());
            Console.WriteLine("Verschlüsseltes Passwort: " + encryptedPassword);
        }

        public void DecryptPassword(string password)
        {
            string decryptedPassword = Decipher(password, GetEncryptionKey());
            Console.WriteLine("Entschlüsseltes Passwort: " + decryptedPassword);
        }

        public void EvaluatePasswordStrength(string password)
        {
            int minLength = 8;
            int maxLength = 20;

            bool isLengthValid = password.Length >= minLength && password.Length <= maxLength;
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigits = password.Any(char.IsDigit);
            bool hasSpecialChars = password.Any(IsSpecialCharacter); //HZ 4.1 geändert von IsSpecialChar zu IsSpecialCharacter

            if (!isLengthValid)
            {
                Console.WriteLine("Das Passwort muss zwischen {0} und {1} Zeichen lang sein.", minLength, maxLength);
            }

            if (!hasUpperCase)
            {
                Console.WriteLine("Das Passwort muss mindestens einen Großbuchstaben enthalten.");
            }

            if (!hasLowerCase)
            {
                Console.WriteLine("Das Passwort muss mindestens einen Kleinbuchstaben enthalten.");
            }

            if (!hasDigits)
            {
                Console.WriteLine("Das Passwort muss mindestens eine Ziffer enthalten.");
            }

            if (!hasSpecialChars)
            {
                Console.WriteLine("Das Passwort muss mindestens ein Sonderzeichen enthalten.");
            }

            if (isLengthValid && hasUpperCase && hasLowerCase && hasDigits && hasSpecialChars)
            {
                Console.WriteLine("Das Passwort ist stark und sicher.");
            }
        }

        private static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char c = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + (key)) - c) % 26) + c);
        }

        private static string Encipher(string input, int key)
        {
            StringBuilder output = new StringBuilder();

            foreach (char ch in input)
            {
                output.Append(Cipher(ch, key));
            }

            return output.ToString();
        }

        private static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

        //HZ 4.1 geändert von IsSpecialChar zu IsSpecialCharacter
        private static bool IsSpecialCharacter(char c)
        {
            return !char.IsLetterOrDigit(c);
        }

        //HZ 4.1 hinzugefügt: Eingabevalidierung
        //HZ 7.1: Debugger Fehler behoben
        private static int GetEncryptionKey()
        {
            Console.Write("Geben Sie Ihren Schlüssel ein: ");
            int key;
            
            while (!int.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine ganze Zahl ein.");
                Console.Write("Geben Sie Ihren Schlüssel ein: ");
            }
            

            return key;
            
        }
    }
}
