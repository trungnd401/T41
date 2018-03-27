using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using T41.Areas.Admin.Model.DataModel;

namespace T41.Areas.Admin.Model.BusinessModel
{
    public class DTPowerDBContext:DbContext 
    {
        public DTPowerDBContext() : base("name=T41ConnectionString") { }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<GrantPermission> GrantPermission { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Post> Post { get; set; }
    }
}