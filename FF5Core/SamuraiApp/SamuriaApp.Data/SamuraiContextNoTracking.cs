using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;

namespace SamuraiApp.Data
{

    //perfomance benefits to be gained from not traking data if its disconnected.
    public class SamuraiContextNoTracking : SamuraiContext
    {
        //override constructor from base class
        public SamuraiContextNoTracking()
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

    }
}
