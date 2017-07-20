using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Books.Entities;
using System.Diagnostics;

namespace Books.Web.DataContexts
{
    public class BooksDb: DbContext
    {
        public BooksDb()
            : base("DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }        
        
        /// <summary>
        /// Moving Schema: dbo > library
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("library");
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Book> Books { get; set; }
    }
}