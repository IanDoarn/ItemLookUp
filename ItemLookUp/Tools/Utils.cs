using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemLookUp.LookUp.Inventory;
using ItemLookUp.Config;

namespace ItemLookUp.Tools
{
    /// <summary>
    /// Collection of helper methods
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Formats information to a string representation of a kit
        /// 
        /// Example:
        ///     Product Number = 57-5990-000-00
        ///     Serial Number = 23
        ///     Output = 57-5990-000-00 {23}
        ///     
        /// </summary>
        /// <param name="productnumber">Product number of the kit</param>
        /// <param name="serialnumber">Kits serial number</param>
        /// <returns></returns>
        public static string FormatKitNumber(string productnumber, string serialnumber)
        {
            return productnumber + " {" + serialnumber + "}";
        }

        /// <summary>
        /// Returns the product id from a kit barcode
        /// 
        /// Example:
        ///    barcode = Z-637284-23
        ///    product id = 637284
        /// </summary>
        /// <param name="barcode">kit barcode number</param>
        public static string[] SplitKitBarcode(string barcode)
        {
            string[] s = barcode.Split('-');
            return new string[] { s[1], s[2] };
        }


        /// <summary>
        /// Determine if a kit should be broken down based on the qty of components contained
        /// versus the Components qty standard
        /// </summary>
        /// <param name="k">kit to breakdown</param>
        /// <returns>bool</returns>
        public static bool DetermineBreakdown(Kit k)
        {
            double std = (double)k.ComponentStd;
            double qty = (double)k.ComponentQty;
            double percent = (qty / std);

            if (std <= 10.0)
            {
                switch ((int)std)
                {
                    case 2:
                        return k.ComponentQty < 2;
                    case 3:
                        return percent > 1 / 3;
                    case 4:
                        return percent > 0.5;
                    case 5:
                        return percent > 2 / 5;
                    case 6:
                        return percent > 2 / 3;
                    case 7:
                        return percent > 3 / 7;
                    case 8:
                        return percent > 1 / 4;
                    case 9:
                        return percent > 2 / 3;
                    case 10:
                        return percent > 1 / 5;
                    default:
                        return false;
                 }
            }
            else if (std >= 15 && std <= 30)
            {
                return percent > 1 / 6;
            }
            else
            {
                return percent > Constants.BREAKDOWN_THRESHOLD;
            }

        }
    }
}
