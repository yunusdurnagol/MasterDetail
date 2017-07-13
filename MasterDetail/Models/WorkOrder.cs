﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterDetail.Models
{
    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime? TargetDateTime { get; set; }
        public  DateTime? DropDeadTime { get; set; }
        public string Description { get; set; }
        public WorkOrderStatus WorkOrderStatus { get; set; }
        public decimal Total  { get; set; }
        public string CertificationRequirements { get; set; }
    }

    public enum WorkOrderStatus
    {
        Created=0,
        InProcess=10,
        Submitted=20,
        Approved=30,
        Cancelled=-10,
        Rejected=-20
    }
}