using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingFellowLocator.Core
{
    public class FellowLocatorManager
    {
        private List<Fellow> FellowList { get; set; }

        public FellowLocatorManager(string fellowListOnString)
        {
            FellowList = FellowFactory.CreateFellowList(fellowListOnString);
        }

        public List<Fellow> ClosestFellows(string fellowName)
        {
            Fellow referenceFellow = FellowList.Single(p => p.Name == fellowName);

            FellowList.ForEach(fellowItem => fellowItem.CalculateRelativeDistance(referenceFellow.Position));

            return FellowList.Where(p => p.Name != referenceFellow.Name).OrderBy(p => p.RelativeDistance).Take(3).ToList();
        }
    }
}
