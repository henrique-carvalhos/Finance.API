using Finance.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Finance.Infrastructure.Persistence
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
            
        }

        public DbSet<User > Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpensesCategories { get; set; }
        public DbSet<ExpenseType> ExpensesTypes { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuração da entidade User
            builder.Entity<User>()
            .HasKey(u => u.Id);

            builder.Entity<User>()
                .HasMany(u => u.Incomes)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(u => u.Expenses)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração da entidade Income
            builder.Entity<Income>()
            .HasKey(i => i.Id);

            builder.Entity<Income>()
                .Property(i => i.Amount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Income>()
                .Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(100);

            // Configuração da entidade Expense
            builder.Entity<Expense>()
                .HasKey(e => e.Id);

            builder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Expense>()
                .Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Expense>()
                .HasOne(e => e.ExpenseCategory)
                .WithMany()
                .HasForeignKey(e => e.IdExpenseCategory)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Expense>()
                .HasOne(e => e.ExpenseType)
                .WithMany()
                .HasForeignKey(e => e.IdExpenseType)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Expense>()
                .HasOne(e => e.PaymentType)
                .WithMany()
                .HasForeignKey(e => e.IdPaymentType)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração da entidade ExpenseCategory
            builder.Entity<ExpenseCategory>()
                .HasKey(ec => ec.Id);

            builder.Entity<ExpenseCategory>()
                .Property(ec => ec.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<ExpenseCategory>()
                .HasMany(ec => ec.ExpensesTypes)
                .WithOne(et => et.ExpenseCategory)
                .HasForeignKey(et => et.IdExpenseCategory)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração da entidade ExpenseType
            builder.Entity<ExpenseType>()
                .HasKey(et => et.Id);

            builder.Entity<ExpenseType>()
                .Property(et => et.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<ExpenseType>()
                .HasOne(et => et.ExpenseCategory)
                .WithMany(ec => ec.ExpensesTypes)
                .HasForeignKey(et => et.IdExpenseCategory)
                .OnDelete(DeleteBehavior.Restrict);


            //configuração da entidade PaymentType
            builder.Entity<PaymentType>()
                .HasKey (et => et.Id);

            builder.Entity<PaymentType>()
                .Property(pt => pt.Description)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
