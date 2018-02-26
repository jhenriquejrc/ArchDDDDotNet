using ArquiteturaDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ArquiteturaDDD.Infra.Data.Context
{
    public class ArquiteturaDDDContext<TEntity> : DbContext where TEntity : class
    {
        public DbSet<TEntity> DbSet
        {
            get;
            set;
        }
        public ArquiteturaDDDContext()
            : base("ArquiteturaDDD")
        {
            Database.SetInitializer<ArquiteturaDDDContext<TEntity>>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IdnMapping).IsAssignableFrom(x)
                                  select x).ToList();

            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }
        }

        public virtual void ChangeObjectState(object model, EntityState state)
        {
            //Aqui trocamos o estado do objeto, 
            //facilita quando temos alterações e exclusões
            ((IObjectContextAdapter)this)
                          .ObjectContext
                          .ObjectStateManager
                          .ChangeObjectState(model, state);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property("Created").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

        public virtual int Save(TEntity obj)
        {
            this.DbSet.Add(obj);
            return this.SaveChanges();
        }

        public virtual int Update(TEntity obj)
        {
            var entry = this.Entry(obj);
          
            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(obj);

            this.ChangeObjectState(obj, EntityState.Modified);
            return this.SaveChanges();
        }

        public virtual void Delete(TEntity obj)
        {
            var entry = this.Entry(obj);
            if (entry.State == EntityState.Detached)
                this.DbSet.Attach(obj);

            this.ChangeObjectState(obj, EntityState.Deleted);
            this.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbSet.Where(expression);
        }

        public IEnumerable<TEntity> OrderBy(Expression<Func<TEntity, bool>> expression)
        {
            return this.DbSet.OrderBy(expression);
        }
    }
}
