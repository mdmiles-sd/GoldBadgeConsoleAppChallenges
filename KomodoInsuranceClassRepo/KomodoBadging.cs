using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceClassRepo
{
    public class KomodoBadging
    {
        private static Dictionary<int, object> dict;



        
        //Plain Old c# Object --POCO
        public class BadgingSystem
        {
            public int BadgeID { get; set; }
            public List <string> DoorNames { get; set; }
            

            public BadgingSystem() { }

            public BadgingSystem(int badgeID, List<string> doorNames)
            {
                BadgeID = badgeID;
                DoorNames = doorNames;
            }

        }

    }
}

