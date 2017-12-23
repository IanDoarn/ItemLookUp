using ItemLookUp.Barcodes;
using System.Collections.Generic;
using System;

namespace ItemLookUp.LookUp.Inventory
{
    public class Kit : Product, IComparable
    {
        private string productid;
        private string description;
        private string serialnumber;

        private int componentstd;
        private int componentqty;

        private LinkedList<Component> components;

        /// <summary>
        /// Kit product number
        /// </summary>
        public override string ProductNumber { get { return productnumber; } }

        /// <summary>
        /// Product Id of kit
        /// </summary>
        public string ProductId { get { return productid; } set { productid = value; } }

        /// <summary>
        /// Kits descritpion
        /// </summary>
        public string Description { get { return description; } set { description = value; } }

        /// <summary>
        /// Unique serial number of kit
        /// </summary>
        public string SerialNumber { get { return serialnumber; } set { serialnumber = value; } }

        /// <summary>
        /// Component Standard, how many components should be contained in the kit
        /// </summary>
        public int ComponentStd { get { return componentstd; } }

        /// <summary>
        /// Actual number of components contained in the kit
        /// </summary>
        public int ComponentQty { get { return componentqty; } }

        /// <summary>
        /// Collection of Component Objects in the Kit
        /// </summary>
        public LinkedList<Component> Components {  get { return components; } set { components = value; } }

        public Kit(string productnumber, BKit kitBarcode, LinkedList<Component> components, int componentstd, int componentqty) : base(productnumber)
        {
            this.productid = kitBarcode.ProductId;
            this.description = kitBarcode.Description;
            this.serialnumber = kitBarcode.SerialNumber;
            this.components = components;
            this.componentstd = componentstd;
            this.componentqty = componentqty;
        }

        public Kit(string productnumber, string productid, string description, string serialnumber, int componentstd, int componentqty)
            : base(productnumber)
        {
            this.productid = productid;
            this.description = description;
            this.serialnumber = serialnumber;
            this.componentstd = componentstd;
            this.componentqty = componentqty;
        }

        public Kit(string productnumber, string productid, string description, string serialnumber, LinkedList<Component> components, int componentstd, int componentqty)
            : base(productnumber)
        {
            this.productid = productid;
            this.description = description;
            this.serialnumber = serialnumber;
            this.components = components;
            this.componentstd = componentstd;
            this.componentqty = componentqty;
        }

        /// <summary>
        /// Returns whether a kit contains all of its components
        /// </summary>
        /// <returns>bool</returns>
        public bool isValid()
        {
            return isvalid();
        }

        /// <summary>
        /// Wrapper method to determine whether a kit is valid
        /// based on the cound of components versus the component standard
        /// </summary>
        /// <returns></returns>
        private bool isvalid()
        {
            int count = 0;

            foreach(Component c in components)
            {
                c.isFull();
                count += c.Qty;
            }

            this.componentqty = count;

            return count == this.ComponentStd;
        }

        public override string ToString()
        {
            return productnumber + " {" + serialnumber + "}";
        }

        public int CompareTo(object obj)
        {
            Kit k = ((Kit) obj);

            if (this.ComponentQty == k.ComponentQty)
                return 0;
            else if (this.ComponentQty > k.ComponentQty)
                return -1;
            else
                return 1;        
        }
    }
}
