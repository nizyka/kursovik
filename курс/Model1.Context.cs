//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace курс
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {


        private static Entities _context;
        public Entities()
            : base("name=Entities")
        {
        }
     /*   public static Entities GetContext()
        {
            if (_context == null)
                _context = new Entities();
            return _context;
        }*/
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Dispetsher> Dispetsher { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Zakazi> Zakazi { get; set; }
        public virtual DbSet<Zayavka> Zayavka { get; set; }
        public virtual DbSet<Tarif> Tarif { get; set; }
    }
}
