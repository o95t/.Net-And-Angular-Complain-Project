using Test.Web.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Web.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)

        {
        }
        public DbSet<Complain> Complains { get; set; }
        public class Complain
        {
            public int Id { get; set; }
            public string Status { get; set; }
            public string Description { get; set; }
            public string Custmer { get; set; }
            public int Rate { get; set; }
            public string MainProblem { get; set; }
            public string Subject { get; set; }
            
        }
    }
}
