﻿using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    internal class PassengerConfiguration: IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.Fullname, 
                            fullName =>
                                {
                                    fullName.Property(x => x.FirstName).HasMaxLength(30)
                                                                    .HasColumnName("PassFirstName");
                                    fullName.Property(x => x.LastName).IsRequired()
                                                                    .HasColumnName("PassLastName");
                                }
            );

            //builder.HasDiscriminator<string>("IsTraveller")
            //    .HasValue<Traveller>("1").HasValue<Staff>("2")
            //   .HasValue<Traveller>("0");
        }

        
    }
}
