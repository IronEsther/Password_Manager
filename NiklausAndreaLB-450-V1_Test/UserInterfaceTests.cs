using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using NiklausAndreaLB_450_V1;

namespace NiklausAndreaLB_450_V1_Test
{
    [TestFixture]
    public class UserInterfaceTests
    {
        [Test]
        public void Run_EncryptPasswordOption_CallsEncryptPasswordMethod()
        {
            // Arrange
            StubPasswordManager passwordManagerStub = new StubPasswordManager();
            UserInterface userInterface = new UserInterface(passwordManagerStub);

            // Act
            userInterface.Run("1");

            // Assert
            Assert.IsTrue(passwordManagerStub.EncryptPasswordCalled);
        }

        [Test]
        public void Run_DecryptPasswordOption_CallsDecryptPasswordMethod()
        {
            // Arrange
            StubPasswordManager passwordManagerStub = new StubPasswordManager();
            UserInterface userInterface = new UserInterface(passwordManagerStub);

            // Act
            userInterface.Run("2");

            // Assert
            Assert.IsTrue(passwordManagerStub.DecryptPasswordCalled);
        }

        [Test]
        public void Run_EvaluatePasswordOption_CallsEvaluatePasswordStrengthMethod()
        {
            // Arrange
            StubPasswordManager passwordManagerStub = new StubPasswordManager();
            UserInterface userInterface = new UserInterface(passwordManagerStub);

            // Act
            userInterface.Run("3");

            // Assert
            Assert.IsTrue(passwordManagerStub.EvaluatePasswordStrengthCalled);
        }

        [Test]
        public void Run_InvalidOption_DisplaysErrorMessage()
        {
            // Arrange
            StubPasswordManager passwordManagerStub = new StubPasswordManager();
            UserInterface userInterface = new UserInterface(passwordManagerStub);
            string expectedOutput = "Ungültige Eingabe. Bitte wählen Sie eine der angegebenen Optionen.";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                userInterface.Run("invalid");

                string output = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, output);
            }
        }

        // Stub-Klasse für den PasswordManager
        public class StubPasswordManager : IPasswordManager
        {
            public bool EncryptPasswordCalled { get; private set; }
            public bool DecryptPasswordCalled { get; private set; }
            public bool EvaluatePasswordStrengthCalled { get; private set; }

            public void EncryptPassword(string password)
            {
                EncryptPasswordCalled = true;
            }

            public void DecryptPassword(string password)
            {
                DecryptPasswordCalled = true;
            }

            public void EvaluatePasswordStrength(string password)
            {
                EvaluatePasswordStrengthCalled = true;
            }
        }
    }

}
