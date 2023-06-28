using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiklausAndreaLB_450_V1;
class Program
{
    public static void Main(string[] args)
    {
        IPasswordManager passwordManager = new PasswordManager();
        IUserInterface userInterface = new UserInterface(passwordManager);
        userInterface.Run();
    }
}