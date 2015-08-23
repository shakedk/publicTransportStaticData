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

        //[TestMethod()]
        //public void CreateTripTest()
        //{
        //    Assert.AreNotEqual();;
        //}

        //[TestMethod()]
        //public void CreateTranlsationTest()
        //{
        //    Assert.AreNotEqual();;
        //}

        //[TestMethod()]
        //public void CreateStopTimeTest()
        //{
        //    Assert.AreNotEqual();;
        //}

        //[TestMethod()]
        //public void CreateStopTest()
        //{
        //    Assert.AreNotEqual();;
        //}

        //[TestMethod()]
        //public void CreateShapeTest()
        //{
        //    Assert.AreNotEqual();;
        //}

        //[TestMethod()]
        //public void CreateRouteTest()
        //{
        //    Assert.AreNotEqual();;
        //}

        //[TestMethod()]
        //public void CrateCalendarTest()
        //{
        //    Assert.AreNotEqual();;
        //}
    }
}

namespace PDTSTests.Data_Access_Layer
{
    class SqlAccessTests
    {
    }
}
