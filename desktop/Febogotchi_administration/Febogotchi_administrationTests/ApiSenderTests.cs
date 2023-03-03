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
    public class ApiSenderTests
    {
       
        [TestMethod()]
        public void LoginTest()
        {
            ApiSender apisender = new ApiSender();
            apisender.Login("Feco", "jelszo");
            Assert.AreNotEqual("Password mismatch",apisender.token);
            apisender.Login("Feco", "asdasd");
            Assert.AreEqual("Password mismatch", apisender.message);
        }
    }
}