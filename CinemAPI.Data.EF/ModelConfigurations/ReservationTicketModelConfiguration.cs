using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using CinemAPI.Models;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class ReservationTicketModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<ReservationTicket> projectionModel = modelBuilder.Entity<ReservationTicket>();

            projectionModel.HasKey(model => model.Id);

            projectionModel.Property(model => model.ProjId).IsRequired();

            projectionModel.Property(model => model.SeatRow).IsRequired();
            projectionModel.Property(model => model.SeatCol).IsRequired();


        }
    }
}
