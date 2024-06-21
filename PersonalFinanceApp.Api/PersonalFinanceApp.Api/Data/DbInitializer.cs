using BaseLibrary.Entities;

namespace PersonalFinanceApp.Api.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            //return;
            if (context.Transactions.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category
                {
                    Name= "Rent"
                },
                new Category
                {
                    Name= "Transportation"
                },
                new Category
                {
                    Name= "Groceries"
                },
                new Category
                {
                    Name= "Cellphone"
                },
                new Category
                {
                    Name= "Clothing"
                },
                new Category
                {
                    Name= "Restaurant"
                },
                new Category
                {
                    Name= "Household Item"
                },
                new Category
                {
                    Name= "College"
                },
                new Category
                {
                    Name= "Savings"
                },
                new Category
                {
                    Name= "Entertainment"
                }
            };

            foreach (var category in categories)
            {
                context.Add(category);
            }

            context.SaveChanges();            

            var transactions = new Transaction[]
            {
                new Transaction
                {
                    CategoryId = context.Categories.Single(c=>c.Name.Equals("College")).Id,
                    Amount=10000,
                    Date= new DateTime(2023,11,15),
                    Description="Payment",
                    Location="Centennial College"
                },
                new Transaction
                {
                    CategoryId = context.Categories.Single(c=>c.Name.Equals("Transportation")).Id,
                    Amount=68.08M,
                    Date= new DateTime(2023,08,13),
                    Description="Uber ride to Airbnb",
                    Location="Toronto Airport"
                },
                new Transaction
                {
                    CategoryId = context.Categories.Single(c=>c.Name.Equals("Rent")).Id,
                    Amount=3200,
                    Date= new DateTime(2023,08,23),
                    Description="First and Last month",
                    Location="775 Midland Avenue"
                }
            };

            foreach (var transaction in transactions)
            {
                context.Add(transaction);
            }            

            context.SaveChanges();
        }
    }
}
