using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using NiklausAndreaLB_450_V1;

namespace NiklausAndreaLB_450_V1.Tests
{
    [TestFixture]
    public class UserInterfaceTests
    {
        private UserInterface userInterface;
        private PasswordManagerMock passwordManagerMock;

        [SetUp]
        public void Setup()
        {
            passwordManagerMock = new PasswordManagerMock();
            userInterface = new UserInterface(passwordManagerMock);
        }

        [TearDown]
        public void Cleanup()
        {
            passwordManagerMock.Reset();
        }

        [Test]
        public void Run_EncryptOption_CallsEncryptPassword()
        {
            // Arrange
            passwordManagerMock.ExpectEncryptPassword("password123");

            // Act
            using (StringReader input = new StringReader("1\npassword123\n4"))
            {
                Console.SetIn(input);
                userInterface.Run();
            }

            // Assert
            passwordManagerMock.ExpectEncryptPassword("password123");
        }

        [Test]
        public void Run_DecryptOption_CallsDecryptPassword()
        {
            // Arrange
            passwordManagerMock.ExpectDecryptPassword("encrypted123");

            // Act
            using (StringReader input = new StringReader("2\nencrypted123\n4"))
            {
                Console.SetIn(input);
                userInterface.Run();
            }

            // Assert
            passwordManagerMock.ExpectDecryptPassword("encrypted123");
        }

        [Test]
        public void Run_EvaluateOption_CallsEvaluatePasswordStrength()
        {
            // Arrange
            passwordManagerMock.ExpectEvaluatePasswordStrength("password123");

            // Act
            using (StringReader input = new StringReader("3\npassword123\n4"))
            {
                Console.SetIn(input);
                userInterface.Run();
            }

            // Assert
            passwordManagerMock.ExpectEvaluatePasswordStrength("password123");
        }

        // Mock class for PasswordManager
        public class PasswordManagerMock : IPasswordManager
        {
            private string expectedEncryptedPassword;
            private string expectedDecryptedPassword;
            private string expectedEvaluatedPassword;

            public void EncryptPassword(string password)
            {
                Assert.AreEqual(expectedEncryptedPassword, password);
            }

            public void DecryptPassword(string password)
            {
                Assert.AreEqual(expectedDecryptedPassword, password);
            }

            public void EvaluatePasswordStrength(string password)
            {
                Assert.AreEqual(expectedEvaluatedPassword, password);
            }

            public void ExpectEncryptPassword(string encryptedPassword)
            {
                expectedEncryptedPassword = encryptedPassword;
            }

            public void ExpectDecryptPassword(string decryptedPassword)
            {
                expectedDecryptedPassword = decryptedPassword;
            }

            public void ExpectEvaluatePasswordStrength(string evaluatedPassword)
            {
                expectedEvaluatedPassword = evaluatedPassword;
            }

            public void Reset()
            {
                expectedEncryptedPassword = null;
                expectedDecryptedPassword = null;
                expectedEvaluatedPassword = null;
            }
        }
    }

}