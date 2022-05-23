using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_JoshuaCowell.Model
{
    public class City : BaseClass
    {
        public int CityID { get; set; }

        public string CityName { get; set; }

        public Country Country { get; set; }


    }
}
