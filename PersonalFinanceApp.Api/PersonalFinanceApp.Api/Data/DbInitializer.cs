using BaseLibrary.Entities;

namespace PersonalFinanceApp.Api.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            //return;            

            if (!context.PaymentMethods.Any())
            {
                var paymentMethods = new PaymentMethod[]
                {
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.DebitCard,
                        Name = "Debit Card"
                    },
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.CreditCard,
                        Name = "Credit Card"
                    },
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.Cash,
                        Name = "Cash"
                    },
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.Deposit,
                        Name = "Deposit"
                    },
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.BankTransfer,
                        Name = "Bank Transfer"
                    },
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.Cheque,
                        Name = "Cheque"
                    },
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.DigitalWallet,
                        Name = "Digital Wallet"
                    },
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.DirectDebit,
                        Name = "Direct Debit"
                    },
                    new PaymentMethod
                    {
                        Id = (int)PaymentMethods.PrepaidCard,
                        Name = "Prepaid Card"
                    }
                };

                foreach (var paymentMethod in paymentMethods)
                    context.Add(paymentMethod);

                context.SaveChanges();
            }

            if (!context.TransactionTypes.Any())
            {
                var transactionTypes = new TransactionType[]
                {
                    new TransactionType
                    {
                        Id = (int)TransactionTypes.Expense,
                        Name = "Expense"
                    },
                    new TransactionType
                    {
                        Id = (int)TransactionTypes.Income,
                        Name = "Income"
                    }
                };

                foreach (var transactionType in transactionTypes)
                    context.Add(transactionType);

                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var categories = new Category[]
            {
                new Category
                {
                    Id = 0,
                    Name= "Multiple"
                },
                //Expenses
                new Category
                {
                    Id = (int)ExpenseCategories.Housing,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Housing"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.HouseholdItems,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Household Items"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Utilities,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Utilities"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Laundry,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Laundry"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Transportation,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Transportation"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Groceries,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Groceries"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.DiningOut,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Dining Out"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Clothing,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Clothing"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Education,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Education"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Entertainment,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Entertainment"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Technology,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Technology"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.PersonalCare,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Personal Care"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Healthcare,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Healthcare"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Insurance,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Insurance"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Services,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Services"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Savings,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Savings"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Investment,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Investment"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.DebtPayment,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Debt Payment"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Gifts,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Gifts"
                },
                new Category
                {
                    Id = (int)ExpenseCategories.Miscellaneous,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Miscellaneous"
                },
                //Income
                new Category
                {
                    Id = (int)IncomeCategories.Employment,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Employment"
                },
                new Category
                {
                    Id = (int)IncomeCategories.PreviousSavings,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Previous Savings"
                },
                new Category
                {
                    Id = (int)IncomeCategories.Investment,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Investment"
                },
                new Category
                {
                    Id = (int)IncomeCategories.TaxReturns,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Tax Returns"
                },
                new Category
                {
                    Id = (int)IncomeCategories.GovernmentBenefits,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Government Benefits"
                },
                new Category
                {
                    Id = (int)IncomeCategories.Gifts,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Gifts"
                },
                new Category
                {
                    Id = (int)IncomeCategories.Loan,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Loan"
                },
                new Category
                {
                    Id = (int)IncomeCategories.Refund,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Refund"
                },
                new Category
                {
                    Id = (int)IncomeCategories.Retirement,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Retirement"
                },
                new Category
                {
                    Id = (int)IncomeCategories.Rental,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Rental"
                },
                new Category
                {
                    Id = (int)IncomeCategories.Miscellaneous,
                    TransactionTypeId = (int)TransactionTypes.Income,
                    Name= "Miscellaneous"
                }
            };

                foreach (var category in categories)
                    context.Add(category);

                context.SaveChanges();
            }

            const string userId = "02cb4ad2-b52c-4194-8c14-3dab220f7865";

            if (!context.Transactions.Any())
            {
                var august23 = new Transaction[]
                {
                    //2023-08-13 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,13),
                        Location="Subway, Toronto Airport",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=2.25M,
                                Description="Doritos and brisk."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,13),
                        Location="Toronto Airport",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=68.08M,
                                Description="Uber from airport to Mohammed's Airbnb."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,13),
                        Location="Toronto Airport",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=68.08M,
                                Description="Mom's Nequi - Uber from airport to Mohammed's Airbnb."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,13),
                        Location="Bilal Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=20.39M,
                                Description="2 Burger combos."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,13),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=23.40M,
                                Description="Tuna, Pasta, Eggs, Butter Sticks, Juice, Bread, Salt, Tomato Paste"
                            }
                        }
                    },
                    //2023-08-14 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,14),
                        Location="Eglinton GO Station",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=48,
                                Description="Presto cards purchase and load."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,14),
                        TotalAmount=13.10M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(13.10M-3),
                                Description="Food"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=3,
                                Description="Latex Gloves x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,14),
                        TotalAmount=32,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(32-6.88M),
                                Description="Ham, Ramen, Potatoes, Milk, Ground Beef, Cheddar Cheese, Garlic"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(6.88M),
                                Description="Dove Bar,"
                            }
                        }
                    },
                    //2023-08-15 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=6927.21M,
                                Description="First GIC deposit"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=25,
                                Description="First Marce's Deposit"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,15),
                        Location="Best Buy",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Technology,
                                Amount=1581.99M,
                                Description="ASUS TUF Laptop"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,15),
                        Location="Kalanchiyam Food Mart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            { new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.35M,
                                Description="Milo, Crush Orange 2L"
                            } }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,15),
                        Location="Batala Supermarket",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4,
                                Description="Sunflower Oil 2L"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,15),
                        Location="Absolute Dollar",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.7M,
                                Description="Pop"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,15),
                        Location="Absolute Dollar",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.7M,
                                Description="Cheetos"
                            }
                        }
                    },
                    //2023-08-17 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,17),
                        TotalAmount=51.20M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(21+1.97M+5.78M+0.97M),
                                Description="Water, Nestea, Wieners, Chicken Breasts"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(8.97M+7.47M+2.58M),
                                Description="Lubriderm, Sunscreen, Shaving Foam"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,17),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.25M,
                                Description="Gummies, Meteor Chocolate x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,17),
                        Location="Batala Supermarket",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4,
                                Description="Lentils"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,17),
                        Location="Superfood Mart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.9M,
                                Description="Onions, Tomatoes"
                            }
                        }
                    },
                    //2023-08-18 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,18),
                        TotalAmount=10.15M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.50M+1.75M+3.50M),
                                Description="Clips, Container, Strainer"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(2.25M),
                                Description="Chips"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,18),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=10.40M,
                                Description="Sauce, Oregano, Carrots, Bay Leaves, Turmeric"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,18),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10
                            }
                        }
                    },
                    //2023-08-19 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,19),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.9M,
                                Description="Water, Pancake Mix, Broccoli, Nupak Lwht"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,19),
                        Location="Superfood Mart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1,
                                Description="2 Lime"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,19),
                        Location="Bilal Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=8.25M,
                                Description="Medium Cheese Pizza, Pop"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,19),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=20
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,19),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=995,
                                Description="Currency Exchange from 751 USD (996 CAD) at Calforex"
                            }
                        }
                    },
                    //2023-08-20 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,20),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1,
                                Description="Tuna"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(5.1M+6.35M-1),
                                Description="Food Grater, Salt/Pepper shakers, Measuring Cup"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,20),
                        TotalAmount=32.2M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(32.2M-(7.77M+9.97M)),
                                Description="Dark Sugar, Milk, Eggs"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(7.77M+9.97M),
                                Description="Tide laundry detergent, Fleecy Softener"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,20),
                        Location="Soap Stars Laundromat",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=13.45M
                            }
                        }
                    },                    
                    //2023-08-22 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,22),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4.69M,
                                Description="Chips Ahoy Cookies"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,22),
                        TotalAmount=5.37M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.25M,
                                Description="Chips"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=2.50M,
                                Description="Plastic Pitcher"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,22),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=4000,
                                Description="Currency Exchange from 3510 USD (4704.15CAD) at Calforex"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,22),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=700,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,22),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10
                            }
                        }
                    },
                    //2023-08-23 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,23),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=12.65M,
                                Description="Ice Cream x2, Water, Tomato Paste, Pasta"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,23),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=3200,
                                Description="First and last month payment."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10
                            }
                        }
                    },
                    //2023-08-24 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,24),
                        Location="Cineplex",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            { new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Entertainment,
                                Amount=8.26M,
                                Description="Tickets for Oppenheimer"
                            } }
                        }
                    },
                    //2023-08-25 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,25),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=32.12M,
                                Description="Water, Mushroom, Bologna, Freezepops, Bread, Tortillas, Potatoes, etc."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,25),
                        Location="Superfood Mart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=0.85M,
                                Description="Tomatoes"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,25),
                        Location="Batala Supermarket",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.61M,
                                Description="Plantain"
                            }
                        }
                    },
                    //2023-08-26 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=49.72M,
                                Description="File Folder, Tape Measure, Tape, Hangers, Hand Soap, Plastic Dust Pan, Bucket, Sponges," +
                                "Dishwashing Detergent, Power Bar, Air Freshner, Cutting Board, Broom, Large Eco Bag x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Coxwell Station",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10,
                                Description="Presto card load."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=5.92M,
                                Description="Lyft from Walmart to Home"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=5.92M,
                                Description="Mom's Nequi - Lyft from Walmart to Home"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=384.13M,
                                Description="Mattress, Bed Frame"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(179.84M-12.57M-11.97M),
                                Description="7 piece Bed-in-a-Bag, Flatware Set, Pillows, Prime"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(179.84M-27.73M),
                                Description="7 piece Bed-in-a-Bag, Flatware Set, Pillows, Prime, Roy VPAPR48 x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(37.26M-12+2.25M),
                                Description="Garbage Bin, Squeezer, Tide, Brush, etc."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        TotalAmount=38.21M,
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(38.21M-(1.5M*5)),
                                Description="Whisk, Jar, Containers, Spoons, Turner, Milk Pitcher, Glass Cups, Bowls, Mugs, Plates"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.5M*5),
                                Description="Pocky, Jelly Powder, Jam"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,26),
                        Location="Descendant Detroit Style Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=(66.67M+7.21M),
                                Description="2 Pizzas, 2 Pops"
                            }
                        }
                    },                                        
                    //2023-08-27 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,27),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=40,
                                Description="Presto cards load"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,27),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=135.63M,
                                Description="TT 3PC Set, Pail, Pan, Ess 3qt sp, Ess 2pk fp, 3qt s/s"
                            }
                        }
                    },
                    //2023-08-28 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,28),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(6.22M+14.84M),
                                Description="Hangers, Kitchen Shears, Cloth, Mop, Latex Gloves, Can Opener, Pine-Sol, Tuna"
                            }
                        }
                    },
                    //2023-08-29 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,29),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            { new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=2.26M,
                                Description="Bamboo Kitc ust"
                            } }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,29),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10
                            }
                        }
                    },
                    //2023-08-30
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10,
                                Description="Presto cards load"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=46.81M,
                                Description="Sliced Ham, Black Beans, Cheddar Cheese, Chicken Breasts, Bread, Mac & Cheese, Water, Ice Cream"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="Airbnb",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=7,
                                Description="Moving from Airbnb to home"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="Airbnb",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=7,
                                Description="Mom's Nequi - Moving from Airbnb to home"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="Dollar Tree",
                        TotalAmount=(9.04M+3.39M),
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(9.04M+3.39M-(1.5M+1.75M)),
                                Description="Cotton Balls, Shower Accessory, Notebook, Air Freshner, Water Bottle Straw"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.5M+1.75M),
                                Description="Strawberry Aloe Vera, Twinkies"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(16.25M),
                                Description="Popcorn, Soda, Bologna, Eggs"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(32.38M),
                                Description="Mozzarella, Linguine, Coffee, Zucchini, Vermicelli, Tomatoes, Onions, Rice, Mayonnaise"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=93.2M,
                                Description="Phone bill"
                            }
                        }
                    },
                    //2023-08-31
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,31),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.69M,
                                Description="Banana, Apple, Red Pepper, Beet Root, Limes"
                            }
                        }
                    },
                    //Incomplete
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,31),
                        Location="Eraa Supermarket",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2,
                                Description=""
                            }
                        }
                    },
                };

                foreach (var item in august23)
                {
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var september23 = new Transaction[]
                {
                    //2023-09-01 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,01),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=8,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,01),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4.99M,
                                Description="Broccoli, Wieners"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,01),
                        TotalAmount=17.52M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(17.52M-1.25M-4),
                                Description="Tuna, Popcorn, Cookies, Toothpaste, Cereal"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=1.25M,
                                Description="Plastic Tumbler, Bikini"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=4,
                                Description="Bikini"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,01),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.98M,
                                Description="Potatoes, Cauliflower"
                            }
                        }
                    },
                    //2023-09-02 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,02),
                        Location="Bathurst Station",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=(10+5.25M),
                                Description="Presto load, TTC Student Card purchase"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,02),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=3200,
                                Description="Rent for October and November."
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,02),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=(128.15M+20),
                                Description="Presto card load and Student Monthly Pass."
                            }
                        }
                    },
                    //2023-09-03 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,03),
                        TotalAmount=80.19M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(80.19M-3.97M),
                                Description="Water, Milk, Soy Sauce, Tortillas, Yogurt, Oil, Flour, Bread Crumbs, Spices, Pancake Mix, Ground Beef"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=3.97M,
                                Description="Zipper Freezer Bags"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,03),
                        TotalAmount=21.9M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(21.9M-4.25M-1.25M),
                                Description="Napkins, Paper Towels, Ketchup, Bento Box, Wrap, Parchment, Roaster Dish, Drink Mix"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(4.25M+1.25M),
                                Description="Ketchup, Drink Mix"
                            }
                        }
                    },
                    //2023-09-05 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,05),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.97M,
                                Description="Oranges, Green Onion"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,05),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.7M,
                                Description="Glass Canning Jar"
                            }
                        }
                    },
                    //2023-09-07 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,07),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=8,
                            }
                        }
                    },
                    //2023-09-09 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,09),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.25M,
                                Description="White Vinegar"
                            }
                        }
                    },
                    //2023-09-10 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,10),
                        Location="Takoyaki6ix",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=9.04M,
                                Description="Takoyaki"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,10),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=6.77M,
                                Description="Poutine"
                            }
                        }
                    },
                    //2023-09-12 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,12),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=11.85M,
                                Description="Drainer, Umbrella, Thread"
                            }
                        }
                    },
                    //2023-09-13 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,13),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.67M,
                                Description="Tuna x3, Chips, Dr Pepper"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,13),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.15M,
                                Description="Bananas, Tomatoes"
                            }
                        }
                    },
                    //2023-09-15 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,15),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=69.2M,
                                Description="Water, Bacon, Mozzarella, Cheddar Cheese, Wieners, Soap, Ground Beef, Avocados" +
                                "Bread, Corn Flour, Butter Sticks, Snack, Fries, Milk, Coca Cola"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,15),
                        Location="Kennedy Station",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=20,
                                Description="Presto card load"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,15),
                        Location="Unknown",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=5.64M,
                                Description="?"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=678.64M,
                                Description="GIC deposit"
                            }
                        }
                    },
                    //2023-09-16 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,16),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=34.03M,
                                Description="Meat, Lettuce, Chicken"
                            }
                        }
                    },
                    //2023-09-17 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,17),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=8,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,17),
                        TotalAmount=(6.09M+2),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.58M+2),
                                Description="Banana, Bologna"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(3.99M+0.52M),
                                Description="Dove Soap"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,17),
                        TotalAmount=19.6M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(19.6M-(4.75M*1.13M)),
                                Description="Skittles, Beef Concentrate, Gummies, Jelly Powder, Chews, Mayonnaise, Bubble Gum"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(4.75M*1.13M),
                                Description="Cutting Board"
                            }
                        }
                    },
                    //Incomplete
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,17),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=8,
                                Description="?"
                            }
                        }
                    },
                    //2023-09-22 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,22),
                        Location="Centennial College",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Education,
                                Amount=67.75M,
                                Description="COMM-161 Book purchase"
                            }
                        }
                    },
                    //2023-09-24 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,24),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=12.78M,
                                Description="Milk, Carrots, Bananas, Zucchini, Red Peppers, Cilantro, Bologna"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,24),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.65M,
                                Description="Kool-Aid, Cheese Sticks"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,24),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.27M,
                                Description="Tomatoes"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,24),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=5,
                            }
                        }
                    },
                    //2023-09-28 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,28),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=9
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,28),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=180
                            }
                        }
                    },
                    //2023-09-29 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,29),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.84M,
                                Description="Cookies, Cracker, Chips, Swissrolls, Hall Choco"
                            }
                        }
                    },
                };

                foreach (var item in september23)
                {
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var october23 = new Transaction[]
                {
                    //2023-10-01 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,01),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=8.5M,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,01),
                        Location="TSCF Community Thrift Store",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=7.9M,
                                Description="Sweatpants, T-Shirt"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,01),
                        Location="TD Bank",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=5.5M,
                                Description="ATM Withdrawal Fee"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,01),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=3.67M,
                                Description="Paper Towel, Gillette"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,01),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(13.49M+7.97M),
                                Description="Sardines, Bologna, Wieners, Baguette, Tortilla, Water, Eggs, Bread"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,01),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.06M,
                                Description="Liquid Soap, Baby Powder"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,01),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=(256.3M),
                                Description="Student Monthly Pass x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,01),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(45.2M*2),
                                Description="Phone bill"
                            }
                        }
                    },
                    //2023-10-03 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,03),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=(13.84M),
                                Description="3 Pizza Slices"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,03),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=(128.15M*2),
                                Description="Monthly Pass Presto Cards load"
                            }
                        }
                    },
                    //2023-10-05 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,05),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(5.08M),
                                Description="?"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,05),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(2.26M),
                                Description="?"
                            }
                        }
                    },
                    //2023-10-06 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,06),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=(6.77M),
                                Description="Too Good To Go"
                            }
                        }
                    },                   
                    //2023-10-07 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,07),
                        Location="Value Village",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(12.65M),
                                Description="Safety Boots"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,07),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=4020M,
                                Description="Deposit from currency exchange"
                            }
                        }
                    },
                    //2023-10-08 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,08),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=7,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,08),
                        TotalAmount=21.93M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(21.93M-(9*1.13M)-3),
                                Description="Toothpaste, Aluminum Foil, Degreaser"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(9*1.13M),
                                Description="Winter Hats"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3,
                                Description="Biscuits"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,08),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=18.36M,
                                Description="Soda, Corn Chips, Lays Chips, Milk, Pepper, Bananas, Zucchini"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,08),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=2.26M,
                                Description="T-Shirt"
                            }
                        }
                    },
                    //Incomplete
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,08),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.83M,
                                Description="?"
                            }
                        }
                    },
                    //2023-10-11 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,11),
                        TotalAmount=25.44M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.33M+4.97M),
                                Description="Apples, Ground Beef"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=1.97M,
                                Description="Palmolive Dish Soap"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=14.97M,
                                Description="Durex"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,11),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=20.08M,
                                Description="NN Chad Thn Sl, Strawberries, Bananas, Onions, Broccoli, Bologna, Ham"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,11),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.35M,
                                Description="Tomatoes"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,11),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=1.7M,
                                Description="Masking Tape"
                            }
                        }
                    },
                    //2023-10-12 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,12),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=826.63M
                            }
                        }
                    },
                    //2023-10-14 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,14),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(13.56M+2.91M),
                                Description="Bread, Jelly Powder, Chipits Mini, Wieners, Pancake Mix, Tuna x3"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,14),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.49M,
                                Description="Water"
                            }
                        }
                    },
                    //2023-10-15 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,15),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=7,
                            }
                        }
                    },
                    //Incomplete
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,15),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.7M,
                                Description="?"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,15),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.35M,
                                Description="Coca-Cola, Milk, Chicken Legs"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,15),
                        TotalAmount=47.95M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(2.77M+4.97M*2),
                                Description="Pancake Mix, CHPSUCNVACH, PRE STRHTK"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(9.97M*1.13M),
                                Description="Knit Gloves"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(6.88M*3*1.13M),
                                Description="Dove Soap Bars x6 (x3)"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,15),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=12.15M,
                                Description="Ear Muff, Foam Insoles, 1 Pair Sole Pads, Thermal Socks, Men Checkered Fl"
                            }
                        }
                    },
                    //2023-10-16 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,16),
                        TotalAmount=19.53M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(7.77M*1.13M),
                                Description="Tide Laundry Detergent"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(4.78M+5.97M),
                                Description="Fries, Nuggets"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,16),
                        TotalAmount=14.89M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((4.25M+1.25M)*1.13M),
                                Description="Bento Box, Scourer"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(14.89M-((4.25M+1.25M)*1.13M)),
                                Description="Chips, Salsa, Gummies, Cookies"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,16),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=678.64M,
                                Description="Deposit from GIC"
                            }
                        }
                    },
                    //2023-10-17 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,17),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=10.06M,
                                Description="Curry Powder, Sugar, Tuna x6"
                            }
                        }
                    },
                    //2023-10-18 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,18),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cheque,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=46.5M,
                                Description="Training"
                            }
                        }
                    },
                    //2023-10-21 - DONE                    
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,21),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=5.09M,
                                Description="Broom Mop Handle, Ice Cream Scoop, Wide Broom"
                            }
                        }
                    },
                    //2023-10-22 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,22),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=4.75M,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,22),
                        TotalAmount=26.27M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(26.27M-(1.5M*1.13M)-((4*2+4.5M)*1.13M)),
                                Description="Cheetos Puffs, Mints, Gumball, Sour Candy, Twizzlers"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.5M*1.13M),
                                Description="SS Tongs"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=((4*2+4.5M)*1.13M),
                                Description="Socks x2, Pants"
                            },
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,22),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=14.61M,
                                Description="Avocados, Ground Beef, Chicken Drums"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,22),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=15.26M,
                                Description="Milk, Carrots, Baguette, Bread, Tortillas"
                            }
                        }
                    },
                    //2023-10-26 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,26),
                        TotalAmount=51.13M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.65M,
                                Description="Tomatoes"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(51.13M-1.65M),
                                Description="Hydrocortisone, Allergy, Heartburn, Vitamin C"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,18),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1036.27M
                            }
                        }
                    },
                    //2023-10-27 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,27),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4.04M,
                                Description="Cracker, Chips"
                            }
                        }
                    },                    
                    //2023-10-28 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,28),
                        Location="Fairweather International Clothiers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=146.89M,
                                Description="Winter Coat"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,28),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(3.99M+7.23M),
                                Description="Spinach, Baguette, Mozzarella, Potatoes, Bananas"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,28),
                        TotalAmount=8.02M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2,
                                Description="Swissrolls"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(2.5M*1.13M),
                                Description="Men Checkered Fl"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((1.5M*1.13M)+1.5M),
                                Description="Clips, Napkins"
                            }
                        }
                    },
                    //2023-10-29 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,29),
                        Location="Winners",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=169.49M,
                                Description="Winter Coat"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,29),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=141.18M,
                                Description="Winter Boots x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,29),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.99M,
                                Description="White Eggs"
                            }
                        }
                    },
                    //2023-10-30 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,30),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=5,
                            }
                        }
                    },
                    //2023-10-31 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,31),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=3.96M,
                                Description="Laminated Padlock, Toothbrush"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,10,31),
                        Location="Centennial College",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Education,
                                Amount=15,
                                Description="College account load, myCard load"
                            }
                        }
                    }
                };

                foreach (var item in october23)
                {
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var november23 = new Transaction[]
                {
                    //2023-11-01 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,01),
                        TotalAmount=3.11M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.25M*1.13M),
                                Description="Drink Mix"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.5M*1.13M),
                                Description="Bottle Brush"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,01),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=143,
                                Description="Monthly Pass"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,01),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(45.2M*2),
                                Description="Phone bill"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,01),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=128.15M,
                                Description="Student Monthly Pass"
                            }
                        }
                    },
                    //2023-11-03 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,03),
                        TotalAmount=6.3M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(2*1.13M),
                                Description="Toothpaste x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(6.3M-(2*1.13M)),
                                Description="Chips, Cookies"
                            }
                        }
                    },       
                    //2023-11-04 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,04),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Miscellaneous,
                                Amount=100,
                                Description="Promotional Bonus"
                            }
                        }
                    }, 
                    //2023-11-05 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,05),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=27.86M,
                                Description="Cheese Twists, Water, Cheddar, Milk, Chicken, Baguette, Bread"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,05),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=13.25M
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,05),
                        Location="Bilal Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=(6.75M),
                                Description="Medium Cheese Pizza"
                            }
                        }
                    },
                    //2023-11-07 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,07),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.37M,
                                Description="?"
                            }
                        }
                    },  
                    //2023-11-08 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,08),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4,
                                Description="Bologna, Wieners"
                            }
                        }
                    },
                    //2023-11-09 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,09),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=989.76M
                            }
                        }
                    },
                    //2023-11-10 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,10),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.15M,
                                Description="Butter Sticks, Condensed Milk, Apples"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,10),
                        TotalAmount=(1.75M+13.31M),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.75M+(13.31M-(3.28M*1.13M))),
                                Description="Biskwi, Cereal, Mayonnaise, Kool-Aid, Chicken Broth"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Technology,
                                Amount=(3.28M*1.13M),
                                Description="20cm USB Cable"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,10),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=8.84M,
                                Description="Tostitos, Popcorn, Gummies"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,10),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=8.84M,
                                Description="Nequi - Tostitos, Popcorn, Gummies"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,10),
                        Location="FedEx Ground",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cheque,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=84.27M
                            }
                        }
                    },
                    //2023-11-12 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,12),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=5,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,12),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=10.45M,
                                Description="Christmas (Pine Tree, Ornaments, Lights), Teaspons"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,12),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(24.89M+2.49M),
                                Description="Jelly Powder x4, Soda, Cookies, Cheddar, Bananas, Plantain, Avocado, " +
                                "Bologna, Ground Chicken, Bread, Tortillas, Wieners"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,12),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.98M,
                                Description="12 Eggs x2"
                            }
                        }
                    },
                    //2023-11-14 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,14),
                        Location="Centennial College",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Education,
                                Amount=10000,
                                Description="Second semester payment"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,14),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=5.65M,
                                Description="Work Gloves"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,14),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=5.65M,
                                Description="Nequi - Work Gloves"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,14),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=4060,
                                Description="Currency Exchange from 3000 USD"
                            }
                        }
                    },
                    //2023-11-15 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,15),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=8.19M,
                                Description="Thin Mints, Panettone, Coffee Drink"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=678.64M,
                                Description="GIC deposit"
                            }
                        }
                    },
                    //2023-11-18 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,18),
                        TotalAmount=71.64M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(71.64M-(12.99M*1.13M)),
                                Description="Kimchi Ramen, Pocky, Corn Flour, Meat, Spring Rolls, Vinegar, Chicharron, Sardines" +
                                "Mandarinas, Red Pepper, Rice"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(12.99M*1.13M),
                                Description="Olleta Chocolatera"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,18),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=17.48M,
                                Description="Cream Cheese, Mozzarella, Bananas, Hot Dog Bun, Tortillas"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,18),
                        TotalAmount=14.62M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(14.62M-(1.75M+3.5M)*1.13M),
                                Description="Cream Soap, Cracker, Cookies, Drink Mix, Christmas Chocolate"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((1.75M+3.5M)*1.13M),
                                Description="Christmas (Star, Garland)"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,18),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=14.62M,
                                Description="Nequi - Cream Soap, Cracker, Cookies, Drink Mix, Christmas Chocolate, Christmas (Star, Garland)"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,18),
                        Location="FedEx Ground",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cheque,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=211.62M
                            }
                        }
                    },
                    //2023-11-19 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,19),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=58.59M,
                                Description="Vitamin D3 x2, Probiotics, Vitamin B12"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,19),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=58.59M,
                                Description="Mom's Nequi - Vitamin D3 x2, Probiotics, Vitamin B12"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,19),
                        TotalAmount=65.83M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(65.83M-(9.77M+6.27M)*1.13M),
                                Description="Milk, Pasta, Oil, Ground Beef, GV Crisp Hadd, Sugar Cones, Bread, Oat" +
                                "Chipits Choc, Corona Chocolate, Pepper, Evaporated Milk, Salt"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=((9.77M+6.27M)*1.13M),
                                Description="Hot Water Bottle 2L, Herbal Essences"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,19),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=5.25M,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,19),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=13.28M,
                                Description="Chubby Drink, Corn Chips, Pizza Pop x2, Wieners"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,19),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.59M,
                                Description="Chocolates, Truffle, Cereal, Sparkles"
                            }
                        }
                    },
                    //2023-11-22 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,22),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3,
                                Description="Cinnamon"
                            }
                        }
                    },
                    //2023-11-23 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,23),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=994.59M
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=143,
                                Description="Monthly Pass"
                            }
                        }
                    },
                    //2023-11-24 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,24),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=6.5M,
                                Description="Pot Holders, Bleach, Pepsi"
                            }
                        }
                    },
                    //2023-11-25 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,25),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=16.1M,
                                Description="Sugar Cane Panela, Milk, Water, Avocados"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,25),
                        Location="FedEx Ground",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cheque,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=259.12M
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,25),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=13.41M,
                                Description="?"
                            }
                        }
                    },
                    //2023-11-26 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,26),
                        Location="Decathlon",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=113,
                                Description="Base Layer (Top, Bottom)x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,26),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=15.92M,
                                Description="Popcorn, Soda, Hot Chocolate Mix, Bologna, Baguette, Sugar Donuts"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,26),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=5.25M,
                            }
                        }
                    },
                    //2023-11-28 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,28),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=22.53M,
                                Description="Murine Ear Wax Removal, Voltaren"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,28),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=67.73M,
                                Description="Brita Pitcher and Filters x4"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,28),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=67.73M,
                                Description="Mom's Nequi - Brita Pitcher and Filters x4"
                            }
                        }
                    },
                    //2023-11-29 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,29),
                        TotalAmount=23.8M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(23.8M-((1.5M+3.75M+4)*1.13M)-(1.25M*2*1.13M)),
                                Description="Farcitino Cakes, Cookies, Christmas Hot Chocolate, Gummies"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=((1.5M+3.75M+4)*1.13M),
                                Description="Thermal Insoles, Socks"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.25M*2*1.13M),
                                Description="Toothpicks, Spray Bottle"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,29),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.44M,
                                Description="Carrots, Tomatoes, Vegetables"
                            }
                        }
                    },
                    //2023-11-30 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,30),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=128.15M,
                                Description="Student Monthly Pass"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,11,30),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(45.2M*2),
                                Description="Phone bill"
                            }
                        }
                    },
                };

                foreach (var item in november23)
                {
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var december23 = new Transaction[]
                {
                    //2023-12-01 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,01),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=1600
                            }
                        }
                    },
                    //2023-12-02 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,02),
                        TotalAmount=29.99M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(29.99M-((4+1.25M+2.5M+4.75M+5)*1.13M)),
                                Description="Candies, Cookies, Rice Pudding, Chews, Butterfly Cookies, Biscuits, Sour Straws"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((4+1.25M+2.5M+4.75M)*1.13M),
                                Description="Hooks, Hangers, Extension Cord"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(5M*1.13M),
                                Description="Yoga Mat"
                            }
                        }
                    },
                    //2023-12-03 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,03),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=5
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,03),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=6.77M,
                                Description="Cookies Mug x2, Container, Drink"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,03),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=24.08M,
                                Description="Wafers, Snacks, Pringles, Crisps, Mozzarella, Bologna, Wieners, Donuts, Bread"
                            }
                        }
                    },
                    //2023-12-05 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,05),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=14.11M,
                                Description="Ground Beef, Coca-Cola, Milk"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,05),
                        TotalAmount=8.24M,
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(8.24M-(2*1.13M)),
                                Description="Eggs, Baguette"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(2*1.13M),
                                Description="Eggs, Baguette"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,05),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.83M,
                                Description="Super Glue, Drink Mix"
                            }
                        }
                    },       
                    //2023-12-07 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,07),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(3.67M+0.47M),
                                Description="Tostitos, Lighter"
                            }
                        }
                    },
                    //2023-12-10 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,10),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=7
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,10),
                        Location="Bilal Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=24.85M,
                                Description="Beef Burger Combo x2, 2 Fried Chicken Pieces"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,10),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=37.55M,
                                Description="Nestle Chocolates, Soda, Corn Chips, Cream Cheese, Cheddar Cheese, Bananas, Kiwi" +
                                "Plantain, Bologna, Baguette, Glazed Donuts, Hot Dog Bun, Ham"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,10),
                        TotalAmount=7.89M,
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(7.89M-(1.5M*1.13M)),
                                Description="Chocolate Spread, Cereal x2, Jam"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(1.5M*1.13M),
                                Description="Cuticle Trimmer"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,10),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=12.88M,
                                Description="Apples, Ice Cream, Avocados, R3bumpy Carm"
                            }
                        }
                    },
                    //2023-12-16 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,16),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=60.53M,
                                Description="Pasta, Milk, Yogurt, Shirmp Ring, Bread, Ground Beef, Butter Sticks, Jelly Powder x4," +
                                "Tomato Sauce, Soda, Oreo, Pizza Pop, Sup Chrycn"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,16),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=6,
                                Description="Cake"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,16),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=6,
                                Description="Mom's Nequi - Cake"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,16),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=19.3M,
                                Description="Onion Rings, Cheese Snacks, Frozen Fries, Wieners, Chicken Nuggets"
                            }
                        }
                    },                     
                    //2023-12-17 - DONE                    
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,17),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=5
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,17),
                        TotalAmount=25.54M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(2.5M*1.13M),
                                Description="Toothbrush"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=((1.75M+3.5M+3)*1.13M),
                                Description="Silkies, Gloves, Santa Hat x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.5M+(2.25M+1.5M+4+1)*1.13M),
                                Description="Napkins, Party Candles, Travel Bottles, Laundry Bag, Bags"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(2),
                                Description="Tuna x2"
                            }
                        }
                    },
                    //2023-12-18 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,18),
                        Location="Centennial College",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Education,
                                Amount=300
                            }
                        }
                    },                    
                    //2023-12-19 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,19),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=8.22M,
                                Description="Mozzarella, Pineapple Slices, Potatoes"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,19),
                        TotalAmount=8.76M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(8.76M-(1.5M*1.13M)),
                                Description="Paper Towels, Cookie Sheet"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(1.5M*1.13M),
                                Description="Thermo Comfort"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,19),
                        TotalAmount=3.11M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=((1.5M*1.13M)),
                                Description="Drink Mix"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(1.5M*1.13M),
                                Description="Ear Murf"
                            }
                        }
                    },                    
                    //2023-12-20 - DONE                                        
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,20),
                        TotalAmount=13.77M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(13.77M-((2.5M+4.25M+2)*1.13M)),
                                Description="Lemonade, Cracker, Chicken Broth"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((4.25M+2)*1.13M),
                                Description="Dishes Shelf, Splatter Screen"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(2.5M*1.13M),
                                Description="Flute"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,20),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=16.95M,
                                Description="Glass Lid x2, Lighter, Peeler, Spoon"
                            }
                        }
                    },
                    //2023-12-21 - DONE   
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,21),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=10.45M,
                                Description="Glass Lid x2, Lighter"
                            }
                        }
                    },
                    //2023-12-22 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,22),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=6.77M,
                                Description="Too Good To Go"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,22),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=6.77M,
                                Description="Mom's Nequi - Cake"
                            }
                        }
                    },
                    //2023-12-23 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,23),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=14,
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,23),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(10.11M+6.77M),
                                Description="Eggs, Bananas, Plantain, Cabbage, Burger Buns, Tortillas"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,23),
                        TotalAmount=17.03M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(17.03M-((5+1.5M+1.5M)*1.13M)),
                                Description="Peaches, Gummies, Gum, Skittles, Chocolate Chips"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((5+1.5M+1.5M)*1.13M),
                                Description="Scented Candle, Treat Bag, Cake Pan"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,23),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=0.9M,
                                Description="Tomatoes"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,23),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=1.7M,
                                Description="Peace Tea Razzleberry"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=143,
                                Description="Monthly Pass"
                            }
                        }
                    },
                    //2023-12-24 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,24),
                        TotalAmount=53.08M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(4.47M*1.13M),
                                Description="Pillow"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(53.08M-(4.47M*1.13M)),
                                Description="Burger Sauce, Tartar Sauce, Raisins, Ground Beef, Milk, Chicken Breast"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,24),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4.2M,
                                Description="Drink Mix, Mushrooms, French Mushroom x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,24),
                        Location="Colombian Street Food",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=4.24M,
                                Description="Empanada"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,24),
                        Location="KFC",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=18.08M,
                                Description="Combo"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,24),
                        Location="Unknown",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=21.46M,
                                Description="Nose Piercing"
                            }
                        }
                    },
                    //2023-12-26 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,26),
                        TotalAmount=80.49M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(80.49M-(29*1.13M)),
                                Description="Blanket, Pillow, Bed Sheets"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(29*1.13M),
                                Description="Shoes"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,26),                        
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=32.77M,
                                Description="Shoes"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,26),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=32.77M,
                                Description="Nequi - Shoes"
                            }
                        }
                    },
                    //2023-12-28 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,28),                        
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=15.5M,
                                Description="Puff Pastry, Fruit Cocktail x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,28),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=15.5M,
                                Description="Evaporated Milk, Apples, Avocados, Bologna, Baguette, Bread"
                            }
                        }
                    },
                    //2023-12-30 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,30),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=1.7M,
                                Description="Pedicure Set"
                            }
                        }
                    },
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,30),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=0.98M,
                                Description="Tomatoes"
                            }
                        }
                    },
                    //2023-12-31 - DONE
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,12,31),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=128.15M,
                                Description="Student Monthly Pass"
                            }
                        }
                    }
                };
                foreach (var item in december23)
                {
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
