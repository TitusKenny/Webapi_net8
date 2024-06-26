﻿using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<KhoHang> KhoHangs { get; set; }
        public DbSet<ChucVu> chucVus { get; set; }
        public DbSet<ThongTinNguoiDung> ThongTinNguoiDungs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(100);

            });

            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDh, e.MaHh });

                entity.HasOne(e => e.DonHang)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
               .WithMany(e => e.DonHangChiTiets)
               .HasForeignKey(e => e.MaHh)
               .HasConstraintName("FK_DonHangCT_HangHoa");
            });
            modelBuilder.Entity<Loai>();
            modelBuilder.Entity<NguoiDung>(entity => 
            {
                entity.HasIndex(e => e.UserName).IsUnique();
            });
            modelBuilder.Entity<ThongTinNguoiDung>(entity =>
            {
                entity.Property(e => e.HoTen).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
