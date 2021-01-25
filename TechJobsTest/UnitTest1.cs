using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography.X509Certificates;
using TechJobsOO;

namespace TechJobsTest
{
    [TestClass]
    public class UnitTest1
    {
        static Employer acme = new Employer("ACME");
        static Location desert = new Location("Desert");
        static CoreCompetency cc = new CoreCompetency("Persistance");
        static PositionType pt = new PositionType("Quality Control");
        Job a = new Job("Product Tester", acme, desert, pt, cc);
        Job b = new Job("Product Tester", acme, desert, pt, cc);
        Job c = new Job();
        Job d = new Job(null, acme, desert, pt, cc);

        [TestMethod]
        public void TestSettingJobId()
        {
            Assert.IsTrue((a.Id < b.Id) && ((a.Id + 1) == b.Id));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.IsTrue(a.Name == "Product Tester");
            Assert.AreEqual("Quality Control", a.JobType.ToString());
            Assert.AreEqual(cc.ToString(), a.JobCoreCompetency.ToString());
            Assert.AreEqual(a.EmployerLocation, desert);
            Assert.IsTrue(a.EmployerName.Value == "ACME");
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Assert.IsFalse(a.Id == b.Id);
        }

        [TestMethod]
        public void TestJobsForDisplay()
        {
            StringAssert.StartsWith(a.ToString(), "\n");
            StringAssert.Contains(a.ToString(), "ID:   " + a.Id);
            StringAssert.Contains(a.ToString(), "Name:   Product Tester");
            StringAssert.Contains(a.ToString(), "Employer:   ACME");
            StringAssert.Contains(a.ToString(), "Location:   Desert");
            StringAssert.Contains(a.ToString(), "Position Type:   Quality Control");
            StringAssert.Contains(a.ToString(), "Core Competency:   Persistance");
            StringAssert.EndsWith(a.ToString(), "\n");

            StringAssert.Contains(c.ToString(), "OOPS! This job does not seem to exist.");

            StringAssert.Contains(d.ToString(), "Data not available");
        }
    }
}