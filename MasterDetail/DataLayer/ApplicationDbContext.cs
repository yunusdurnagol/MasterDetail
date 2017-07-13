﻿using MasterDetail.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MasterDetail.DataLayer
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Labor> Labors { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<InventoryItem> InevtoryItems { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new InventoryItemConfiguration());
            modelBuilder.Configurations.Add(new LaborConfiguration());
            modelBuilder.Configurations.Add(new PartConfiguration());
            modelBuilder.Configurations.Add(new ServiceItemConfiguration());
            modelBuilder.Configurations.Add(new WorkOrderConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}