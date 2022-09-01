using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int numberofRides;
        private double TotalFare;
        private double averageFare;


        public InvoiceSummary(int numberofRides, double totalFare)
        {
            this.numberofRides = numberofRides;
            this.TotalFare = totalFare;
            this.averageFare = this.TotalFare/this.numberofRides;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)return false;
            if(!(obj is InvoiceSummary)) return false;

            InvoiceSummary inputedobject=(InvoiceSummary)obj;
            return this.numberofRides == inputedobject.numberofRides && this.TotalFare == inputedobject.TotalFare && this.averageFare == inputedobject.averageFare;
        }
        public override int GetHashCode()
        {
            return this.numberofRides.GetHashCode() ^ this.TotalFare.GetHashCode()^this.averageFare.GetHashCode();

        }
    }
}
