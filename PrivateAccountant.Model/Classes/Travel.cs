using System;
using System.Collections.Generic;

namespace PrivateAccountant.Model.Classes
{
    public class Travel : Job
    {
        public Travel() : base()
        {
            TravelDetails = new List<TravelDetail>();
        }

        public IList<TravelDetail> TravelDetails { get; set; }


    }
}