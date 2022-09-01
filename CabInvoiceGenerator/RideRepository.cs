using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        public void AddRide(string userId, Ride[] rides)
        {
            bool ridesList=this.userRides.ContainsKey(userId);
            try
            {
                if (!ridesList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceExecption)
            {
                throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_RIDES, "Invalid ride");
            }

            
            
        }
        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch(CabInvoiceExecption)
            {
                throw new CabInvoiceExecption(CabInvoiceExecption.ExceptionType.INVALID_USER_ID, "Invalid UserId");
            }
        }
    }
}
