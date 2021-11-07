using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{

    public class RideRepository
    {

        //Dictionary to store UserId and int List
        Dictionary<string, List<Ride>> userRide = null;


        public RideRepository()
        {
            this.userRide = new Dictionary<string, List<Ride>>();
        }

        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRide.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRide.Add(userId, list);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Ride Is Null");
            }
        }


        public Ride[] GetRides(string userID)
        {
            try
            {
                return this.userRide[userID].ToArray();

            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User ID");
            }
        }
    }


}
