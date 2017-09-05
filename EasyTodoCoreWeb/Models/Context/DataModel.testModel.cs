﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2017/09/06 1:10:47
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using EasyTodoCoreWeb;

namespace CoreContext
{

    public partial class testModel : DbContext
    {

        public testModel() :
            base()
        {
            OnCreated();
        }

        public testModel(DbContextOptions<testModel> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UsePostgreSql(@"User Id=ruser;Password=rpass;Host=192.168.52.128;Database=test;Persist Security Info=True");
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<Person> People
        {
            get;
            set;
        }

        public virtual DbSet<TodoDetailData> TodoDetailDatas
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.PersonMapping(modelBuilder);
            this.CustomizePersonMapping(modelBuilder);

            this.TodoDetailDataMapping(modelBuilder);
            this.CustomizeTodoDetailDataMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }
    
        #region Person Mapping

        private void PersonMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable(@"person", @"public");
            modelBuilder.Entity<Person>().Property<int>(x => x.Id).HasColumnName(@"id").HasColumnType(@"int4").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Person>().Property<string>(x => x.Name).HasColumnName(@"name").HasColumnType(@"char").ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<Person>().Property<System.Nullable<int>>(x => x.Age).HasColumnName(@"age").HasColumnType(@"int4").ValueGeneratedNever();
            modelBuilder.Entity<Person>().HasKey(@"Id");
        }
	
        partial void CustomizePersonMapping(ModelBuilder modelBuilder);

        #endregion
    
        #region TodoDetailData Mapping

        private void TodoDetailDataMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoDetailData>().ToTable(@"todo_detail_data", @"public");
            modelBuilder.Entity<TodoDetailData>().Property<int>(x => x.UserId).HasColumnName(@"user_id").HasColumnType(@"int4").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<TodoDetailData>().Property<int>(x => x.DataId).HasColumnName(@"data_id").HasColumnType(@"int4").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<TodoDetailData>().Property<string>(x => x.Title).HasColumnName(@"title").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<TodoDetailData>().Property<string>(x => x.Detail).HasColumnName(@"detail").HasColumnType(@"varchar").ValueGeneratedNever().HasMaxLength(100);
            modelBuilder.Entity<TodoDetailData>().Property<System.Nullable<System.DateTime>>(x => x.StartDate).HasColumnName(@"start_date").HasColumnType(@"date").ValueGeneratedNever();
            modelBuilder.Entity<TodoDetailData>().Property<System.Nullable<System.DateTime>>(x => x.EndDate).HasColumnName(@"end_date").HasColumnType(@"date").ValueGeneratedNever();
            modelBuilder.Entity<TodoDetailData>().Property<System.Nullable<int>>(x => x.State).HasColumnName(@"state").HasColumnType(@"int4").ValueGeneratedNever();
            modelBuilder.Entity<TodoDetailData>().Property<System.Nullable<int>>(x => x.ColorId).HasColumnName(@"color_id").HasColumnType(@"int4").ValueGeneratedNever();
            modelBuilder.Entity<TodoDetailData>().HasKey(@"UserId", @"DataId");
        }
	
        partial void CustomizeTodoDetailDataMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
