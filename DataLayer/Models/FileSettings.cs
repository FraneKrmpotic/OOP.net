using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FileSettings
    {
        public static string language;
        public static bool gender;
        public static string country;
        public static string versusCountry;
        public static HashSet<string> favourites;
        public static int countryIndex;
        public static int versusCountryIndex;
    }
}
