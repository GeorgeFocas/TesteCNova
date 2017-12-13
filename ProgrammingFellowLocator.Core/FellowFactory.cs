using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingFellowLocator.Core
{
    public static class FellowFactory
    {
        public static List<Fellow> CreateFellowList(string fellowCollectionInAString)
        {
            string[] fellowListString = fellowCollectionInAString.Split(new char[] { ';' });
            var fellowList = new List<Fellow>();

            foreach (string felloListItemString in fellowListString)
            {
                fellowList.Add(CreateFellow(felloListItemString));
            }

            return fellowList;
        }

        public static Fellow CreateFellow(string fellowString)
        {
            string[] tempArray = fellowString.Split(new char[] { ':' });

            int x = Convert.ToInt32(tempArray[1].Split(new char[] { ',' })[0]);
            int y = Convert.ToInt32(tempArray[1].Split(new char[] { ',' })[1]);

            var fellow = new Fellow()
            {
                Name = tempArray[0],
                Position = new System.Drawing.Point(x, y)
            };

            return fellow;
        }
    }
}
