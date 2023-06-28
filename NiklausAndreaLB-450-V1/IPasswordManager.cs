using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiklausAndreaLB_450_V1;

namespace NiklausAndreaLB_450_V1
{
    public interface IPasswordManager
    {
        void EncryptPassword(string password);
        void DecryptPassword(string password);
        void EvaluatePasswordStrength(string password);
    }
}
