using Microsoft.VisualStudio.TestTools.UnitTesting;
using Febogotchi_administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Febogotchi_administration.Tests
{
    [TestClass()]
    public class ApiReaderTests
    {
        ApiReader apiReader = new ApiReader("http://localhost:8881/api/users");
        ApiSender apisender = new ApiSender();
        
        [TestMethod()]
        public void GetUserTest()
        {
            
        }
    }
}