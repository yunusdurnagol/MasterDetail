﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MasterDetail.Models;

namespace MasterDetail.DataLayer
{
    public class WorkOrderConfiguration:EntityTypeConfiguration<WorkOrder>
    {
        public WorkOrderConfiguration()
        {
            Property(wo => wo.OrderDateTime).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(wo => wo.Description).HasMaxLength(256).IsOptional();
            Property(wo => wo.CertificationRequirements).HasMaxLength(120).IsOptional();
            Property(wo => wo.Total).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            HasRequired(wo => wo.CurrentWorker).WithMany(au=>au.WorkOrders).WillCascadeOnDelete(false);
            HasRequired(wo=>wo.Customer).WithMany(c=>c.WorkOrders).WillCascadeOnDelete(false);
        }
    }
}