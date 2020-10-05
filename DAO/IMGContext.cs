using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using testeBanco.Model;

namespace testeBanco.DAO
{
    class IMGContext : DbContext
    {
        public DbSet<ObjImagem> Imagens { get; set; }

        public void Iniciar()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseOracle("Data Source=localhost;User Id=C##JOAO;Password=123");
    }
}
