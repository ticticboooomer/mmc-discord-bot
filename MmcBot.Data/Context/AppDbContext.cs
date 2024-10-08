﻿using Microsoft.EntityFrameworkCore;
using MmcBot.Data.Model;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MmcBot.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<CommandMacro> CommandMacros { get; init; }
    public DbSet<SuperAdmin> SuperAdmins { get; init; }
    public DbSet<TrackedForum> TrackedForums { get; init; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CommandMacro>().ToCollection("command_macros");
        modelBuilder.Entity<SuperAdmin>().ToCollection("super_admins");
        modelBuilder.Entity<TrackedForum>().ToCollection("tracked_forum");
    }
}