using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingFellowLocator.Core
{
    public static class FellowValidator
    {
        public static bool ValidateFellowListOnString(string fellowListOnString)
        {
            string[] tempArray = fellowListOnString.Split(new char[] { ';' });

            if (tempArray.Length > 0)
            {
                foreach (string fellowStringItem in tempArray)
                {
                    if (ValidateFellowString(fellowStringItem) == false)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static bool ValidateFellowString(string fellowString)
        {
            string[] arrayTemp = fellowString.Split(new char[] { ':' });

            if (arrayTemp.Length != 2)
                return false;

            bool result1 = int.TryParse(arrayTemp[1].Split(new char[] { ',' })[0], out int temp);
            bool result2 = int.TryParse(arrayTemp[1].Split(new char[] { ',' })[1], out temp);

            if (!(result1 && result2))
                return false;

            return true;
        }
    }
}
