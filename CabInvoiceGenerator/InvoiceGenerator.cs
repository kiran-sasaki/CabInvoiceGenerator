using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;

        private double MINIMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }
            catch (CabInvoiceExecption)
            {
                throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }

        public double CalculateFare(double distance,int time)
        {
            double totalfare = 0;
            try
            {
                totalfare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch
            {
                if(rideType.Equals(null))
                {
                    throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
                }
                if(distance <= 0)
                {
                    throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if(time < 0)
                {
                    throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalfare,  MINIMUM_FARE);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double TotalFare = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    TotalFare += this.CalculateFare(ride.distance,ride.time);
                }

            }
            catch(CabInvoiceExecption)
            {
                if(rides == null)
                {
                    throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_RIDES, "Invalid Ride");
                }
            }
            return new InvoiceSummary(rides.Length, TotalFare);
        }
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                rideRepository.AddRide(userId, rides);
            }
            catch
            {
                if(rides == null)
                {
                    throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_RIDES, "Invalid ride");
                }
            }
        }
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch
            {
                throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_USER_ID, "Invalid userId");
            }
        }

    }
}
