using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiklausAndreaLB_450_V1
{
    public class MockPasswordManager : IPasswordManager
    {
        public string EncryptedPassword { get; set; }
        public string DecryptedPassword { get; set; }
        public bool EvaluatePasswordStrengthCalled { get; set; }

        public void EncryptPassword(string password)
        {
            // Mock implementation - nichts machen :D
            // In einer echten Implementation würde hier Code Logic sein.
            // Password speichern für Test Zwecke
            EncryptedPassword = password;
        }

        public void DecryptPassword(string password)
        {
            // Mock implementation - nichts machen :D
            // In einer echten Implementation würde hier Code Logic sein.
            // Password speichern für Test Zwecke
            DecryptedPassword = password;
        }

        public void EvaluatePasswordStrength(string password)
        {
            // Mock implementation - nichts machen :D
            // In einer echten Implementation würde hier Code Logic sein.
            // Password speichern für Test Zwecke
            EvaluatePasswordStrengthCalled = true;
        }
    }
}
