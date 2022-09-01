using CabInvoiceGenerator;

namespace UnitTest1
{

    [TestClass]
    public class UnitTest1
    {
        InvoiceGenerator invoicegenerator = null;
        [TestMethod]
        public void GivenDistanceReturnTotalFare()
        {
            invoicegenerator = new InvoiceGenerator(RideType.NORMAL);

            double distance = 2.0;
            int time = 5;

            double fare =invoicegenerator.CalculateFare(distance, time);

            double expected = 25;

            Assert.AreEqual(expected, fare);
        }
        [TestMethod]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoicegenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoicegenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, summary);
        }
    }
}