namespace MasterDetail.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MasterDetail.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MasterDetail.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            string accountNumber = "ABC123";
            context.Customers.AddOrUpdate(c=>c.AccountNumber,
             new Customer()
             {
                 AccountNumber=accountNumber,
                 CompanyName="American Company",
                 City="Washington",
                 State="WS",
                 Zipcode="30048",
                 Adress="Region Street",
                 PhoneNumber="5066947012"
             }
                );
            context.SaveChanges();

            Customer customer = context.Customers.First(c=>c.AccountNumber==accountNumber);
            string description = "Just another work order";

            context.WorkOrders.AddOrUpdate(wo => wo.Description,
                new WorkOrder() { Description = description, CustomerId = customer.CustomerId, WorkOrderStatus = WorkOrderStatus.Approved}
                );
            context.SaveChanges();

            WorkOrder workOrder = context.WorkOrders.First(wo => wo.Description == description);
            context.Parts.AddOrUpdate(p => p.InventoryItemCode,
               new Part() {
                   WorkOrderId =workOrder.WorkOrderId,
                   InventoryItemCode="THING1",
                   InventoryItemName ="Thing Number 1",
                   Quantity =1,
                   UnitPrice =1.34m,
                   IsInstalled =true
               } );

            context.Labors.AddOrUpdate(l => l.ServiceItemCode,
              new Labor()
              {
                  WorkOrderId = workOrder.WorkOrderId,
                  ServiceItemCode= "Install1",
                  ServiceItemName = "Install Number 1",
                  LaborHours = 9.87m,
                  Rate = 35.75m
              });

            string categoryName = "Devices";
            context.Categories.AddOrUpdate(c => c.CategoryName, new Category() { CategoryName = categoryName });
            context.SaveChanges();

            Category category = context.Categories.First(c => c.CategoryName == categoryName);
            context.InevtoryItems.AddOrUpdate(ii => ii.InventoryItemCode,
                new InventoryItem() {
                        InventoryItemCode="THING2",
                        InventoryItemName="A Seconf Kind of Thing",
                        UnitPrice=3.3m,
                        CategoryId=category.CategoryId

                });

            context.ServiceItems.AddOrUpdate(si => si.ServiceItemCode,
                new ServiceItem()
                {
                    ServiceItemCode = "CLEAN",
                    ServiceItemName ="General Cleaning",
                    Rate=23.33m
                   
                });

           // context.SaveChanges();
        }
    }
}
