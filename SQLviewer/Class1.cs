﻿using Microsoft.EntityFrameworkCore;
using System;

namespace SQLviewer
{
    public class Databases : DbContext
    {
        public string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static bool _created = false;
        public Databases()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source="+path+"\\Databases.db");
        }
        public DbSet<Database> Db { get; set; }
    }
    public class Database
    {
        public int DatabaseID { get; set; }
        public string server_name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
