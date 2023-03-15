using System;
using Microsoft.EntityFrameworkCore;
using PI4.Models;

namespace PI4.Data
{
    public class VideoSubjectDbContext : DbContext
    {
        public VideoSubjectDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Onderwerp> Onderwerpen { get; set; } = default;
        public DbSet<Video> Videos { get; set; } = default;
    }
}
