namespace BillingAPI
{
    using System;

    public class InvoiceItem
    {
        private string description = string.Empty;
        private string name = string.Empty;
        private double quantity = 0.0;
        private string tax1Name = string.Empty;
        private int tax1Percent = 0;
        private string tax2Name = string.Empty;
        private int tax2Percent = 0;
        private double unitcost = 0.0;

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public double Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                this.quantity = value;
            }
        }

        public string Tax1Name
        {
            get
            {
                return this.tax1Name;
            }
            set
            {
                this.tax1Name = value;
            }
        }

        public int Tax1Percent
        {
            get
            {
                return this.tax1Percent;
            }
            set
            {
                this.tax1Percent = value;
            }
        }

        public string Tax2Name
        {
            get
            {
                return this.tax2Name;
            }
            set
            {
                this.tax2Name = value;
            }
        }

        public int Tax2Percent
        {
            get
            {
                return this.tax2Percent;
            }
            set
            {
                this.tax2Percent = value;
            }
        }

        public double UnitCost
        {
            get
            {
                return this.unitcost;
            }
            set
            {
                this.unitcost = value;
            }
        }
    }
}

