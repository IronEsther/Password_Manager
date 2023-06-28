using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NiklausAndreaLB_450_V1
{
    public class MockUserInterface : IUserInterface
    {
        public bool RunCalled { get; set; }

        public void Run()
        {
            // Mock implementation - nichts machen :D
            // In einer echten Implementation würde hier Code Logic sein.
            // RunCalled = true speichern für Test Zwecke
            RunCalled = true;
        }
    }
}
