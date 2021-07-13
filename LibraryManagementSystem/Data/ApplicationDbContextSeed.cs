using LibraryManagementSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Data
{
    public class ApplicationDbContextSeed
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        public static void SeedEssentials()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            // Add Default Role(Admin)
            // Add Default User
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists(Constants.Admin))
            {
                role.Name = Constants.Admin;
                roleManager.Create(role);

                ApplicationUser user = new ApplicationUser()
                {
                    Email = Constants.AdminEmail,
                    UserName = Constants.AdminEmail
                };

                var check = userManager.Create(user, Constants.AdminPassword);
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, Constants.Admin);
                }
                else
                {
                    var e = new Exception("Couldn't add Default Admin");
                    var enumerator = check.Errors.GetEnumerator();
                    foreach (var error in check.Errors)
                    {
                        e.Data.Add(enumerator.Current, error);
                    }
                    throw e;
                }
            }

            // Add Default Role(Employee)
            // Add Default User
            IdentityRole EmployeeRole = new IdentityRole();

            if (!roleManager.RoleExists(Constants.Employee))
            {
                EmployeeRole.Name = Constants.Employee;
                roleManager.Create(EmployeeRole);

                ApplicationUser user = new ApplicationUser()
                {
                    Email = Constants.EmployeeEmail,
                    UserName = Constants.EmployeeEmail
                };

                var check = userManager.Create(user, Constants.EmployeePassword);
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, Constants.Employee);
                }
                else
                {
                    var e = new Exception("Couldn't add Default Employee");
                    var enumerator = check.Errors.GetEnumerator();
                    foreach (var error in check.Errors)
                    {
                        e.Data.Add(enumerator.Current, error);
                    }
                    throw e;
                }
            }


        }
    }
}