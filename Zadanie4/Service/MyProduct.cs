using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class MyProduct
    {
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public string Color { get; set; }
        public Guid rowguid { get; set; }
        public int ProductID { get; set; }

        public MyProduct()
        {
        }
        public MyProduct(Product p)
        {
            this.ProductID = p.ProductID;
            this.Name = p.Name;
            this.ProductNumber = p.ProductNumber;
            this.ModifiedDate = p.ModifiedDate;
            this.SellStartDate = p.SellStartDate;
            this.SellEndDate = p.SellEndDate;
            this.SafetyStockLevel = p.SafetyStockLevel;
            this.ReorderPoint = p.ReorderPoint;
            this.Color = p.Color;
            this.rowguid = p.rowguid;
            this.ProductID = p.ProductID;
        }
    }
}
