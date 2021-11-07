using NUnit.Framework;
using CabInvoiceGenerator;

namespace TestProject1
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //creating instance of InvoiceGenerator for NormalFare
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            //calculating fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;


            //Asserting value
            Assert.AreEqual(expected, fare);
        }
       //Test case for calculating fare function for mutiple rides summary
       [Test]
       public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            //creating instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride (2.0, 5 ), new Ride(0.1, 1) };

            //Generating Summary for Rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            //Asserting values
            Assert.AreEqual(expectedSummary, summary);


        }

    }
}