using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(i => i.Name).HasMaxLength(100);
            builder.Property(i => i.Surname).HasMaxLength(100);

            builder.HasMany(i => i.Gorevler).WithOne(i => i.AppUser).HasForeignKey(i => i.AppUserId).OnDelete(DeleteBehavior.SetNull);
            //çoka tek ilişkide çok olan kısımdan hasmany ile başlanır. OnDelete metodunda, eğer bir kullanıcı silinirse onun görevleri silinmesin
            //kullanıcı id kısmı null olarak atansın olarak düzenlenmiştir.
        }
    }
}
