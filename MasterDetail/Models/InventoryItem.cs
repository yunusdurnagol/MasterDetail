﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MasterDetail.Models
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public string InventoryItemCode { get; set; }
        public string InventoryItemName { get; set; }
        public decimal UnitPrice { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}