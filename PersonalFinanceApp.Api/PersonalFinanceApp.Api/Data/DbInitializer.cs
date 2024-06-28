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

            const string userId = "d24783b8-e327-478b-a5ec-ebdac75e9752";

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
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
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
                                Amount=30,
                                Description="Presto cards load"
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
                            { new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=3200,
                                Description="First and last month payment."
                            } }
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
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
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
                                Amount=10,
                                Description="Presto card load."
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
                                Amount=10,
                                Description="Presto cards load"
                            }
                        }
                    },
                    //2023-08-30
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="Presto",
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
                    //Incomplete
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
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=46.81M,
                                Description="?"
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
                    //Incomplete
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(9.04M+3.39M),
                                Description="?"
                            }
                        }
                    },
                    //Incomplete
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
                                Description="?"
                            }
                        }
                    },
                    //Incomplete
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,30),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(32.38M),
                                Description="?"
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
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,08,31),
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
            };

                var september23 = new Transaction[]
        {
                //2023-09-02
                    new Transaction
                    {
                        UserId = userId,
                        Date= new DateTime(2023,09,02),
                        Location="Bathurst Station",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10,
                                Description="Presto load."
                            }
                        }
                    },
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
        };

                var transaction = new Transaction
                {
                    UserId = userId,
                    Date = new DateTime(2023, 11, 14),
                    Location = "Centennial College",
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    TransactionDetails = new List<TransactionDetail>
                    {
                        new TransactionDetail
                        {
                            Amount = 10000,
                            Description="Second semester payment",
                            CategoryId = (int)ExpenseCategories.Education
                        }
                    }
                };


                context.SaveChanges();
            }
        }
    }
}
