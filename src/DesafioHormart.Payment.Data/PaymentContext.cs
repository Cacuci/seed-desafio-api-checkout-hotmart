using DesafioHortmart.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioHormart.Payment.Data
{
    public class PaymentContext(DbContextOptions<PaymentContext> options) : DbContext(options), IUnityOfWork
    {
        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataRegister").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataRegister").IsModified = false;
                }
            }

            var success = await SaveChangesAsync(cancellationToken) > 0;

            return success;
        }
    }
}
