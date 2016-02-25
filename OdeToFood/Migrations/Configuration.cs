namespace OdeToFood.Migrations
{
    using OdeToFood.Helpers;
    using OdeToFood.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Paullos", City = "Lisbon", Country = "Portugal" },
                new Restaurant { Name = "Capa Negra", City = "Porto", Country = "Portugal" },
                new Restaurant
                {
                    Name = "Casa Mia",
                    City = "Feira",
                    Country = "Portugal",
                    Reviews =
                        new List<RestaurantReview>{
                            new RestaurantReview { Rating = 9, Body ="Bons bifes", ReviewerName = "Bernas"}
                        }
                });

            SeedMemberShip();
        }

        public void SeedMemberShip()
        {
            Util.InitializeDbConn();

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("bernardo", false) == null)
            {
                membership.CreateUserAndAccount("bernardo", "bernardo");
            }
            if(!roles.GetRolesForUser("bernardo").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "bernardo" }, new[] { "Admin" });
            }
        }
    }
}
