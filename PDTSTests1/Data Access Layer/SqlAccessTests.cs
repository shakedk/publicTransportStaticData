using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDTS.Data_Access_Layer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PDTS.Data_Access_Layer.Tests
{
    [TestClass()]
    public class SqlAccessTests
    {
        [TestMethod()]
        public void CreateAgencyTest()
        {
            try
            {
                int id = SqlAccess.CreateAgency(1, "agencyTest", "Asia\\Jerudalem", "HE");
                SqlAccess.RemoveAgency(id);
                Assert.AreNotEqual(id, -1);
            }
            catch (Exception exception)
            {
                int x = 1;
            }
        }
    }
}
