﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading;
using System.Web;
using MasterDetail.Models;

namespace MasterDetail.DataLayer
{
    public class PartConfiguration:EntityTypeConfiguration<Part>
    {
        public PartConfiguration()
        {
            Property(p => p.InventoryItemCode)
                .HasMaxLength(15)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("AK_Part", 2)));

            Property(p => p.WorkOrderId)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("AK_Part", 1)));

            Property(p => p.InventoryItemName)
                .HasMaxLength(80)
                .IsRequired();

            Property(p => p.UnitPrice)
                .HasPrecision(18, 2);

            Property(p => p.ExtendedPrice)
                .HasPrecision(18, 2)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(p => p.Notes).IsOptional().HasMaxLength(140);
            
        }
    }
}