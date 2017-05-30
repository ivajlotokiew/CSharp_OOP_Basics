using System.Collections.Generic;
using System.Linq;

namespace Keren.Models
{
    public class Child
    {
        private List<decimal> childConsumption;

        public Child(List<decimal> childConsumption)
        {
            this.childConsumption = childConsumption;
        }

        public decimal GetTotalConsumption()
        {
            return this.childConsumption.Sum();
        }
    }
}
