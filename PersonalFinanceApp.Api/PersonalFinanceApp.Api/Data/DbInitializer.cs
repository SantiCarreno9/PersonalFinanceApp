using BaseLibrary.Entities;

namespace PersonalFinanceApp.Api.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            //context.Database.EnsureCreated();
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
                    Id = (int)ExpenseCategories.Taxes,
                    TransactionTypeId = (int)TransactionTypes.Expense,
                    Name= "Taxes"
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

            const string userId = "9eec4ece-f10f-43e2-a7ca-4b1d1dfa5657";

            if (!context.Transactions.Any())
            {
                var august23 = new Transaction[]
                {
                    //2023-08-13 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,08,15),
                        Location="Absolute Dollar",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(5.4M+0.89M)*1.13M,
                                Description="Cheetos & Pop"
                            }
                        }
                    },
                    //2023-08-17 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,08,18),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=30
                            }
                        }
                    },
                    //2023-08-19 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,08,19),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=996,
                                Description="Currency Exchange from 751 USD (996 CAD) at Calforex"
                            }
                        }
                    },
                    //2023-08-20 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,08,22),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=4704.15M,
                                Description="Currency exchange from 3510 USD (4704.15CAD) at Calforex"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2023,08,22),
                        Location="Queen Station",
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
                    //2023-08-24 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,08,26),
                        Location="Coxwell Station",
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
                        Date= new DateTime(2023,08,26),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=37.26M,
                                Description="Garbage Bin, Squeezer, Brush, etc."
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2023,08,26),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=2.25M,
                                Description="Tide"
                            }
                        }
                    },
                    new Transaction
                    {
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
                        Date= new DateTime(2023,08,26),
                        Location="Descendant Detroit Style Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
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
                        Date= new DateTime(2023,08,27),
                        Location="Scarborough Station",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10,
                                Description="Presto card load"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2023,08,27),
                        Location="Scarborough Station",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=10,
                                Description="Presto card load"
                            }
                        }
                    },
                    new Transaction
                    {
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
                        Date= new DateTime(2023,08,28),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
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
                    new Transaction
                    {
                        Date= new DateTime(2023,08,28),
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
                    //2023-08-29 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,08,30),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=46.66M,
                                Description="Phone bill"
                            }
                        }
                    },
                    //2023-08-31
                    new Transaction
                    {
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
                    new Transaction
                    {
                        Date= new DateTime(2023,08,31),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=46.66M,
                                Description="Phone bill"
                            }
                        }
                    },
                    //Incomplete
                    new Transaction
                    {
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
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var september23 = new Transaction[]
                {
                    //2023-09-01 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,09,15),
                        Location="Kennedy Subway Station",
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
                    //2023-09-29 - DONE
                    new Transaction
                    {
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
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var october23 = new Transaction[]
                {
                    //2023-10-01 - DONE
                    new Transaction
                    {
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
                    //2023-10-05 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,10,07),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=4029.9M,
                                Description="Currency exchange at Interchange Currency Exchange 3000USD -> 4029.90CAD (9.90 for cash)"
                            }
                        }
                    },
                    //2023-10-08 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,10,12),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                        Date= new DateTime(2023,10,16),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    new Transaction
                    {
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
                    //2023-10-17 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,10,26),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var november23 = new Transaction[]
                {
                    //2023-11-01 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,11,09),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                        Date= new DateTime(2023,11,14),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=4066.8M,
                                Description="Currency Exchange at Interchange Currency Exchange from 3000 USD -> 4066.80 CAD"
                            }
                        }
                    },
                    //2023-11-15 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,11,23),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                        Date= new DateTime(2023,11,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DirectDebit,
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
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var december23 = new Transaction[]
                {
                    //2023-12-01 - DONE
                    new Transaction
                    {
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
                    new Transaction
                    {
                        Date= new DateTime(2023,12,02),
                        Location="FedEx Ground",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cheque,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=366.5M
                            }
                        }
                    },
                    //2023-12-03 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,12,05),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(2.83M+2.54M),
                                Description="Super Glue, Drink Mix"
                            }
                        }
                    },       
                    //2023-12-07 - DONE                    
                    new Transaction
                    {
                        Date= new DateTime(2023,12,07),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1058.34M
                            }
                        }
                    },
                    new Transaction
                    {
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
                    //2023-12-08 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2023,12,08),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=3.53M,
                                Description="?"
                            }
                        }
                    },
                    //2023-12-10 - DONE
                    new Transaction
                    {
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
                    //2023-12-11 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2023,12,11),
                        Location="FedEx Ground",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cheque,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=329.78M
                            }
                        }
                    },
                    //2023-12-08 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2023,12,12),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=4.24M,
                                Description="?"
                            }
                        }
                    },
                    //2023-12-15 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2023,12,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    new Transaction
                    {
                        Date= new DateTime(2023,12,15),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=2.4M,
                                Description="?"
                            }
                        }
                    },
                    //2023-12-16 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2023,12,16),
                        Location="FedEx Ground",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cheque,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=314.73M
                            }
                        }
                    },
                    new Transaction
                    {
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
                    new Transaction
                    {
                        Date= new DateTime(2023,12,21),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=919.21M
                            }
                        }
                    },
                    //2023-12-22 - DONE
                    new Transaction
                    {
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
                    new Transaction
                    {
                        Date= new DateTime(2023,12,23),
                        Location="FedEx Ground",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Cheque,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=478.64M
                            }
                        }
                    },
                    //2023-12-24 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,12,24),
                        Location="KFC",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=18.08M,
                                Description="Combo x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2023,12,24),
                        Location="Lovisa",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=21.46M,
                                Description="Nose Piercing"
                            }
                        }
                    },
                    //2023-12-26 - DONE
                    new Transaction
                    {
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
                        Date= new DateTime(2023,12,28),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5,
                                Description="Puff Pastry, Fruit Cocktail x2"
                            }
                        }
                    },
                    new Transaction
                    {
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
                    new Transaction
                    {
                        Date= new DateTime(2023,12,30),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=16
                            }
                        }
                    },
                    //2023-12-31 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2023,12,31),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
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
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var january24 = new Transaction[]
                {
                    //2024-01-01 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,01),
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
                    new Transaction
                    {
                        Date= new DateTime(2024,01,01),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(45.2M),
                                Description="Phone bill"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,01),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(45.2M),
                                Description="Phone bill"
                            }
                        }
                    },
                    //2024-01-02 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,02),
                        TotalAmount=16.95M,
                        Location="Top Food Supermarket",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=16.95M,
                                Description="Eggs 18 x2, Sardines x2, Mozzarella"
                            }
                        }
                    },
                    //2024-01-03 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,03),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.98M,
                                Description="Baguette, Bread"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,03),
                        TotalAmount=45.51M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(45.51M-(1.87M*1.13M)),
                                Description="Butter, PAN Flour, Pancake Mix, Iced Tea, Milk, Sugar, Cheddar x2, Ketchup, Mayonnaise, Tomatoes, Wieners"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.87M*1.13M),
                                Description="Palmolive Dish Soap"
                            }
                        }
                    },
                    //2024-01-05 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,05),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1067.97M
                            }
                        }
                    },
                    //2024-01-08 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,08),
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
                    //2024-01-10 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,10),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=17.4M,
                                Description="Cheese Snacks, Corn Chips, Fries, Pogo, Bananas, Bologna, Wieners, Bread"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,10),
                        TotalAmount=4.11M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(4.11M-(1.25M*1.13M)),
                                Description="Tuna, Drink Mix"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.25M*1.13M),
                                Description="Sponges"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,10),
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
                        Date= new DateTime(2024,01,10),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=6.77M,
                                Description="Nequi - Too Good To Go"
                            }
                        }
                    },
                    //2024-01-11 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,11),
                        TotalAmount=(8.56M+13),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(5*1.13M),
                                Description="Muffin Mold"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(1.25M*1.13M),
                                Description="Cotton Swabs"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.5M,
                                Description="Cracker"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=13,
                                Description="Drawing Pad, Octopus Plush, Everyday Cards, Stickers"
                            }
                        }
                    },
                    //2024-01-12 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,12),
                        TotalAmount=14.57M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(3.75M*1.13M),
                                Description="Oven Mitts"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(4.5M*1.13M),
                                Description="Back Wrap"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.25M+2.25M+1.75M),
                                Description="Cookies, Frosting, Cake Mix"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=13,
                                Description="Drawing Pad, Octopus Plush, Everyday Cards, Stickers"
                            }
                        }
                    }, 
                    //2024-01-13 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,13),
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
                    //2024-01-14 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,14),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=17.28M,
                                Description="Linguine, Broccoli, Bologna, Ground Pork, Baguette"
                            }
                        }
                    },
                    //2024-01-15 - DONE                                        
                    new Transaction
                    {
                        Date= new DateTime(2024,01,15),
                        TotalAmount=14.75M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=(2.75M*1.13M),
                                Description="Coffee Drink"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((1.25M+3.5M)*1.13M),
                                Description="Cupcakes Cups, Spatula"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(4*1.13M),
                                Description="Lunch Bag"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.75M,
                                Description="Cake Mix"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    //2024-01-16 - DONE  
                    new Transaction
                    {
                        Date= new DateTime(2024,01,16),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=44.12M,
                                Description="Jelly Powder, Milk, Yogurt, Ground Beef, Bread, Chicken Breasts x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,16),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.88M,
                                Description="Tortillas"
                            }
                        }
                    },
                    //2024-01-18 - DONE 
                    new Transaction
                    {
                        Date= new DateTime(2024,01,18),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.46M,
                                Description="Mushrooms, Vermicelli x2, Mozzarella"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,18),
                        Location="Smart Dollar",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=3.96M,
                                Description="Powder Detergent"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,18),
                        TotalAmount=14.07M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(14.07M-((3.5M+1.5M)*1.13M)),
                                Description="Cookies, Gummies, Tuna x3, Chips"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=((3.5M+1.5M)*1.13M),
                                Description="Insoles, Hair Scrunches"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,18),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1154.35M
                            }
                        }
                    },
                    //2024-01-19 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,19),
                        TotalAmount=3.7M,
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=1.7M,
                                Description="Food Storage"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2,
                                Description="Paris Pate Spread-Deviled"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,19),
                        TotalAmount=5.33M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(0.75M*2+1),
                                Description="Pork and Mushroom Condiments, Parsley"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(2.5M*1.13M),
                                Description="Boot Tray"
                            }
                        }
                    },
                    //2024-01-21 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,21),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=8.25M
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,21),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.99M,
                                Description="Vegetable Oil"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,21),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=12.35M,
                                Description="Bread, Wieners, Yeast, Black Beans, PAN Flour"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,21),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=16.54M,
                                Description="Vitamin E, Selenium"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,21),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=16.54M,
                                Description="Mom's Nequi - Vitamin E, Selenium"
                            }
                        }
                    },
                    //2024-01-23 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DirectDebit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=143,
                                Description="Marce's Monthly Pass"
                            }
                        }
                    },
                    //2024-01-24 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,24),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=6.5M,
                                Description="Rolling Pin, Paper Towels"
                            }
                        }
                    },                    
                    //2024-01-25 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,25),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=10.4M,
                                Description="Pepsi, Popcorn, Cookies, Butterflies, Juice Powder"
                            }
                        }
                    },
                    //2024-01-26 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,26),
                        TotalAmount=(20.32M+5.91M),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(20.32M-(5*1.13M)+1.5M),
                                Description="Doritos, Plantain Bag, Peanut, Toast, Candy, Wafers, Crackers"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(3+(5*1.13M)),
                                Description="After Sun Gel, Pads x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.25M*1.13M),
                                Description="Claw Clips"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,26),
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
                        Date= new DateTime(2024,01,26),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=6.77M,
                                Description="Nequi - Too Good To Go"
                            }
                        }
                    },
                    //2024-01-27 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,01,27),
                        TotalAmount=34.58M,
                        Location="Giant Tiger",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(13.97M*2),
                                Description="Parboiled Rice x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(5.88M*1.13M),
                                Description="Colgate Toothpaste, Perfume"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,27),
                        TotalAmount=35.1M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(35.1M-(7.97M*1.13M)),
                                Description="Plantain, Bread, Donuts, Mushrooms, Oranges, Coffee, Pringles x2, Milk"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(7.97M*1.13M),
                                Description="Fabric Softener"
                            }
                        }
                    },                    
                    //2024-01-28 - DONE                                        
                    new Transaction
                    {
                        Date= new DateTime(2024,01,28),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=15.31M,
                                Description="Tuna, Coca-Cola, Penne, Red Pepper, Papaya"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,28),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=5.25M
                            }
                        }
                    },
                    //2024-01-29 - DONE        
                    new Transaction
                    {
                        Date= new DateTime(2024,01,29),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=12.41M,
                                Description="Bologna, Ground Pork, Ground Beef"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,01,29),
                        Location="Walmart",
                        TotalAmount=31.28M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.97M,
                                Description="Apple Snack (Compote)"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(31.28M-1.97M),
                                Description="Toilet Paper"
                            }
                        }
                    },
                    //2024-01-31 - DONE        
                    new Transaction
                    {
                        Date= new DateTime(2024,01,31),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=128.15M,
                                Description="Student Monthly Pass"
                            }
                        }
                    },
                };
                foreach (var item in january24)
                {
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var february24 = new Transaction[]
                {
                    //2024-02-01 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,01),
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
                    new Transaction
                    {
                        Date= new DateTime(2024,02,01),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=45.2M,
                                Description="Phone bill"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,01),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=45.2M,
                                Description="Phone bill"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,01),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1110.92M,
                            }
                        }
                    },
                    //2024-02-04 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,04),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.54M,
                                Description="Chips, Avocados, Bologna, Bread"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,04),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=8.5M
                            }
                        }
                    },
                    //2024-02-05 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,05),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.22M,
                                Description="Broccoli, Garlic Bread, Baguette"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,05),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=19.21M,
                                Description="Milk, Tea, Tuna, Coca-Cola, Cauliflower, Pasta, Cake Mix x3"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,05),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.99M,
                                Description="Potatoes Bag 10LB, Bananas"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,05),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.99M,
                                Description="Lime x3, Carrots"
                            }
                        }
                    },
                    //2024-02-08 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,09),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=25,
                                Description="Donation for Niru"
                            }
                        }
                    },
                    //2024-02-09 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,09),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(2.54M+4.88M),
                                Description="Chips, Eggies, Cookies, Butterfly Cookies, Frenchs Ragout, French Mushroom"
                            }
                        }
                    },
                    //2024-02-10 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,10),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.8M,
                                Description="Green Beans, Cilantro"
                            }
                        }
                    },                    
                    //2024-02-11 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,11),
                        Location="Ticketmaster",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Entertainment,
                                Amount=94.5M,
                                Description="SiM Concert tickets"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,11),
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
                        Date= new DateTime(2024,02,11),
                        TotalAmount=56.55M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(56.55M-((8.48M+1.97M)*1.13M)),
                                Description="Pizza pops x 3, Chicken wings, Milk, Lean Ground Beef, Wieners, Ice cream, Bananas, Tomatoes, Bread, Mozzarella Cheese"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(8.48M*1.13M),
                                Description="Magnesium Citrate"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.97M*1.13M),
                                Description="Palmolive"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,11),
                        TotalAmount=24.05M,
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(24.05M-1.13M),
                                Description="Apple 4lb, Sliced Turkey, Chicken, Tortillas, Hot Dog Buns"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(1.13M),
                                Description="Colgate Toothpaste"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,11),
                        Location="Subway",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=14.44M,
                                Description="Marce trip to Mississauga"
                            }
                        }
                    },
                    //2024-02-12 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,12),
                        TotalAmount=6.62M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.25M+(1.13M*2)),
                                Description="Chicken Broth, Eggies x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.25M*1.13M),
                                Description="Bobby Pins"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(1.5M*1.13M),
                                Description="Lip Balm"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,12),
                        TotalAmount=14.76M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(14.76M-(10.97M*1.13M)),
                                Description="Orange Soda, Pasta Penne"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(10.97M*1.13M),
                                Description="Lubriderm"
                            }
                        }
                    },
                    //2024-02-13 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,13),
                        Location="Tim Hortons",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=5.64M,
                                Description="Roast Beef Burger"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,13),
                        Location="Tim Hortons",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=5.64M,
                                Description="Nequi - Roast Beef Burger"
                            }
                        }
                    },
                    //2024-02-14 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,14),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.63M,
                                Description="Chocolates, Swissrolls, Gummies, Drink Mix"
                            }
                        }
                    },
                    //2024-02-15 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,15),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=12.98M,
                                Description="Eggs x2, Chocolate Bar, Baguette"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    new Transaction
                    {
                        Date= new DateTime(2024,02,15),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1294
                            }
                        }
                    },
                    //2024-02-16 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,16),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=10.15M,
                                Description="Broccoli, Cucumber, Chips, Lettuce"
                            }
                        }
                    },                                        
                    //2024-02-18 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,18),
                        Location="Aliexpress",
                        TotalAmount=23.34M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(6.88M+2.74M*2+5.5M),
                                Description="Posture Improver, Teeth Scissors, Hair Towel, Acne Remover Kit"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=2.74M,
                                Description="Winter Gloves"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Technology,
                                Amount=2.74M,
                                Description="Wireless Earphones"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,18),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=7.57M,
                                Description="Lyft"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,18),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=7.57M,
                                Description="Nequi - Lyft"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,18),
                        TotalAmount=(53.4M-23.65M),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(53.4M-23.65M-(12*1.13M)),
                                Description="Orange Soda, Donuts, Bread, PAN Flour, Sardines x3, Panela"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(12*1.13M),
                                Description="Panties x6"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,18),
                        TotalAmount=19.74M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(19.74M-((4.03M+3.53M+5)*1.13M)),
                                Description="Butterfly Cookies, Cookies, Chips"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Technology,
                                Amount=((4.03M+3.53M+5)*1.13M),
                                Description="Mouse, Keyboard, HDMI Cable"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,18),
                        TotalAmount=(32.19M+20.33M),
                        Location="Value Village",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=32.19M,
                                Description="Work Boots"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Technology,
                                Amount=20.33M,
                                Description="TV"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,18),
                        Location="Amazon",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Technology,
                                Amount=28.24M,
                                Description="Wi-Fi Adapter"
                            }
                        }
                    },
                    //2024-02-19 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,19),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=14.25M
                            }
                        }
                    },
                    //2024-02-20 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,20),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=13.29M,
                                Description="Wieners, Mozzarella, Cheddar x2, Tuna"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,20),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=10.98M,
                                Description="Oranges, Bologna, Sliced Turkey, Ground Chicken"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,20),
                        TotalAmount=5.37M,
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(5.37M-(1.75M*1.13M)),
                                Description="Toothbrushes x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.75M*1.13M),
                                Description="Air Freshner"
                            }
                        }
                    },
                    //2024-02-21 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,21),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=12.29M,
                                Description="Toilet Paper x2"
                            }
                        }
                    },
                    //2024-02-21 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DirectDebit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=143,
                                Description="Marce's Monthly Pass"
                            }
                        }
                    },
                    //2024-02-24 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,24),
                        TotalAmount=17.49M,
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(17.49M-(4*1.13M)),
                                Description="Cheese Snacks, Avocados, Plantain, Baguette, Bread"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(4*1.13M),
                                Description="Toothbrushes x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,24),
                        TotalAmount=6.7M,
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(6.7M-(1.5M*1.13M)),
                                Description="Jam, Pop & Top Cheddar, Cereal"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(1.5M*1.13M),
                                Description="Water Bottle"
                            }
                        }
                    },
                    //2024-02-25 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,25),
                        TotalAmount=25.67M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(25.67M-(7.88M*2*1.13M)),
                                Description="Milk, Hot Dog Bun"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(7.88M*2*1.13M),
                                Description="Dove Soap x2"
                            }
                        }
                    },
                    //2024-02-27 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,27),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=12.4M,
                                Description="Croissant, Cracker, Jelly Powder, Gummies, Gumballs, Slush Pops"
                            }
                        }
                    },
                    //2024-02-29 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,02,29),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=15.63M,
                                Description="Oreo, Eggs x2, Bananas, Baguette, Tortillas"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,29),
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
                        Date= new DateTime(2024,02,29),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(49.72M*2),
                                Description="Phone bill"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,29),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1158.9M
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,02,29),
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
                };
                foreach (var item in february24)
                {
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var march24 = new Transaction[]
                {
                    //2024-03-01 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,01),
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
                    new Transaction
                    {
                        Date= new DateTime(2024,03,01),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.94M,
                                Description="Wafers, Corn Chips, Chips"
                            }
                        }
                    },
                    //2024-03-02 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,02),
                        Location="Nathan Phillips Square",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Entertainment,
                                Amount=30,
                                Description="Ice Skating (Skates Rent)"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,02),
                        Location="Tim Hortons",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=7.65M,
                                Description="Hot Chocolate x2, Cinnamon Stick"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,02),
                        Location="Ruby Thai",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=25.05M,
                                Description="Lunch x2, Coke"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,02),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=4001.4M,
                                Description="Currency Exchange at Calforex 3000USD -> 4001.4CAD "
                            }
                        }
                    },
                    //2024-03-03 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,03),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=(6.5M+5+2+2+0.5M)
                            }
                        }
                    },
                    //2024-03-04 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,04),
                        TotalAmount=35.54M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(35.54M-(7.97M*1.13M)-(1.77M+1.87M+(1.18M*1.13M))),
                                Description="Bread, Milk, Whip Dressing, Strawberries, Cola, Apple Snacks, Frosting x3"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(7.97M*1.13M),
                                Description="Tide Laundry Detergent"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=(1.77M+1.87M+(1.18M*1.13M)),
                                Description="For Niru - Naan, Gummies, Strawberries"
                            }
                        }
                    },
                    //2024-03-05 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,05),
                        Location="Dollarama",
                        TotalAmount=5.71M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(3.5M*1.13M),
                                Description="Lip Balm"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.75M,
                                Description="Tomato can"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,05),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=13.88M,
                                Description="Chicken Drumsticks, Tomatoes, Frozen Fries"
                            }
                        }
                    },
                    //2024-03-11 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,11),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=18.74M,
                                Description="Marshmallows, Jelly Powder x4, Chicken Nuggets, Baguette"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,11),
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
                    //2024-03-14 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,14),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1085.41M
                            }
                        }
                    },
                    //2024-03-15 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,15),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=26.88M,
                                Description="Ground Beef x2, Eggs 30"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    //2024-03-19 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,19),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=23.81M,
                                Description="Bread, Milk, Tuna x4, Wieners, Orange Soda, White Sugar, Bologna, Ice Cream"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,19),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=25.22M,
                                Description="Macaroni Elbows, Shells, Rigatoni, Penne, Spaghetti, Bananas, Plantain, Potato Chips, Tomatoes, Ground Pork"
                            }
                        }
                    },
                    //2024-03-20 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,20),
                        TotalAmount=8.87M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(8.87M-(4.75M*1.13M)),
                                Description="Swissrolls, Cracker"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Healthcare,
                                Amount=(4.75M*1.13M),
                                Description="Tylenol"
                            }
                        }
                    },
                    //2024-03-21 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,21),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=7.25M
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,21),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.26M,
                                Description="Cookies, Gummies, Cookies"
                            }
                        }
                    },
                    //2024-03-22 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,22),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.87M,
                                Description="Carrots, Vegetables"
                            }
                        }
                    },
                    //2024-03-23 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DirectDebit,
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
                    //2024-03-24 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,24),
                        Location="Bilal Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=27.1M,
                                Description="Medium Pizza, Breef Burger Combo x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,24),
                        TotalAmount=86.8M,
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(86.8M-(9.87M*1.13M)-((19.97M+6.97M+4.74M)*1.13M)),
                                Description="Orange Soda, Mozzarella, Apple Snacks, Bread, Cereal, Butter Sticks, Ranch Dressings, Bologna," +
                                "Chocolate Chips, Hot Dog Bun, Cake Mix x3, Salt, Resses Ice Cream"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Healthcare,
                                Amount=(9.87M*1.13M),
                                Description="Back Pain Pills"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=((19.97M+6.97M+4.74M)*1.13M),
                                Description="Magnesium Citrate, B12, Johnson Baby Shampoo"
                            }
                        }
                    },
                    //2024-03-26 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,26),
                        Location="Real Canadian Superstore",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4,
                                Description="Jelly Powder x4"
                            }
                        }
                    },
                    //2024-03-27 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,27),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=6.78M,
                                Description="Present for Michelle"
                            }
                        }
                    },
                    //2024-03-28 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,28),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1172.3M
                            }
                        }
                    },
                    //2024-03-30 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,30),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.96M,
                                Description="Wafers, Peanuts"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,30),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=37.29M,
                                Description="Corn Chips, Cheese Snacks, Chicken Breast x2, Tortillas"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,30),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.93M,
                                Description="Bananas, Strawberries, Corn, Plantain"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,03,30),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
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
                        Date= new DateTime(2024,03,30),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(49.72M),
                                Description="Phone bill"
                            }
                        }
                    },
                    //2024-03-31 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,03,31),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(49.72M),
                                Description="Phone bill"
                            }
                        }
                    }
                };
                foreach (var item in march24)
                {
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var april24 = new Transaction[]
                {
                    //2024-04-01 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,01),
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
                    new Transaction
                    {
                        Date= new DateTime(2024,04,01),
                        TotalAmount=(13.82M+2.83M),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(13.82M+2.83M-(3+(2.75M*1.13M))),
                                Description="Bubble Gum, Drink Mix, Chocolate Bars x2, Chips, Cracker, Choco Bites"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(3+(2.75M*1.13M)),
                                Description="Liquid Soap, Napkins x2"
                            }
                        }
                    },
                    //2024-04-02 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,02),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.7M,
                                Description="Parsley Flakes, Drink Mix"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,02),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=1.03M,
                                Description="Rolo Bar Chocolate"
                            }
                        }
                    },
                    //2024-04-03 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,03),
                        Location="Centennial College",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=5,
                                Description="Photocopies"
                            }
                        }
                    },
                    //2024-04-04 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,04),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=25.11M,
                                Description="Cheddar Cheese x2, Corona Chocolate, Pizza Pop x3, Milk"
                            }
                        }
                    },                    
                    //2024-04-06 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,06),
                        TotalAmount=23.67M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(23.67M-((1.75M+1.25M+1.5M)*1.13M)-((2.75M+5)*1.13M)),
                                Description="Sour Candy x2, Cookies x2, Ramen x3, Choco Biscuits "
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=((2.75M+5)*1.13M),
                                Description="Eye Lash Curler, Mascara"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((1.75M+1.25M+1.5M)*1.13M),
                                Description="Wizcloth Cloth, Container, Square Bowl"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,06),
                        TotalAmount=9.87M,
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(9.87M-(1.5M*1.13M)),
                                Description="Jam, Nestle Assorted, Syrup Blue Raspberry, Skittles, Cookies"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.5M*1.13M),
                                Description="Can Opener"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,06),
                        Location="Canada Post",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=12.77M,
                                Description="Envelopes, Tax Documents Delivery"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,06),
                        TotalAmount=34.99M,
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(34.99M-(6*1.13M)),
                                Description="Cheddar Cheese, Apples, Bananas, Ground Pork, Chicken Legs, Baguette, Bread, Tortillas"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(6*1.13M),
                                Description="Colgate Toothpaste x6"
                            }
                        }
                    },
                    //2024-04-07 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,07),
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
                        Date= new DateTime(2024,04,07),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4.51M,
                                Description="Lay's Chips"
                            }
                        }
                    },
                    //2024-04-08 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,08),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=80,
                                Description="Presto Cards load for St. Catharines"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,08),
                        TotalAmount=34.99M,
                        Location="Niagara Region Transit",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=12,
                                Description="Tickets for bus (St. Catharines)"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,08),
                        Location="Gino's Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=(8.48M+19.53M),
                                Description="Pizza, two burger combos"
                            }
                        }
                    },                    
                    //2024-04-10 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,10),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.51M,
                                Description="Raspberries, Zucchini, Coca-Cola"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,10),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.87M,
                                Description="Mandarins, Baguette"
                            }
                        }
                    },
                    //2024-04-11 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,11),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.42M,
                                Description="Ginger, Lime x3"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,11),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1195.73M
                            }
                        }
                    },
                    //2024-04-13 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,13),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=29.54M,
                                Description="Donuts, Bread, Oatmeal, Tortillas, Wieners, Bologna x2, Tuna x2, Broccoli, Tomatoes, Oregano Leaves, Milk"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,13),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.96M,
                                Description="Halls, Ice Pops"
                            }
                        }
                    },
                    //2024-04-15 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,15),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1,
                                Description="Lime x3"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    //2024-04-18 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,18),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=1.7M,
                                Description="Disposable Masks"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,18),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Healthcare,
                                Amount=5.25M,
                                Description="Vapocool Drops"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,18),
                        TotalAmount=16.56M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(16.56M-(3.5M*1.13M)),
                                Description="Chips, Drink Mix, Tostitos, Choco Cupcake, Cinnamon, Swissrolls"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(3.5M*1.13M),
                                Description="Nivea Lip Balm"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,18),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=7.75M
                            }
                        }
                    },
                    //2024-04-19 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,19),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=21.69M,
                                Description="Jelly Powder, Popcorn, Fruit Snacks x2, Lentils, Cinnamon Cereal, FrootLoops Cereal, Mozzarella"
                            }
                        }
                    },
                    //2024-04-20 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,20),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.39M,
                                Description="Wieners, Bread, Ginger, Cilantro, Sliced Ham (Total 12.39M - $10 Points Redeemed)"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,20),
                        Location="Danforth Food Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4.1M,
                                Description="Chicken Feet"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,20),
                        Location="India Town",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3,
                                Description="Potatoes 10LB"
                            }
                        }
                    },
                    //2024-04-21 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,21),
                        Location="Shoppers",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.98M,
                                Description="Eggs 12 x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,21),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.5M,
                                Description="Frozen Fries, Tortillas, Hot Dog Bun"
                            }
                        }
                    },
                    //2024-04-23 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,23),
                        TotalAmount=8.28M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.5M,
                                Description="Crackers"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.5M*1.13M),
                                Description="Napkins"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(4.5M*1.13M),
                                Description="Deodorant"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DirectDebit,
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
                    //2024-04-24 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,24),
                        TotalAmount=6.78M,
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.5M*1.13M),
                                Description="Choco Cupcake"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(3*1.13M),
                                Description="Facial Masks x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.5M*1.13M),
                                Description="Paper Towels"
                            }
                        }
                    },
                    //2024-04-25 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,25),
                        TotalAmount=(1.5M+9.5M),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.5M,
                                Description="Cookies"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=9.5M,
                                Description="Kisses x3, Rolo Bar"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,25),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.62M,
                                Description="Cookies, Tortillas, Drink Mix"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,25),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1080.5M
                            }
                        }
                    },
                    //2024-04-26 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,26),
                        TotalAmount=21.18M,
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(21.18M-(4.79M*1.13M)),
                                Description="Cheese Snack, Milka Chocolate, Ground Chicken, Pepper, Aloe Leaf"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(4.79M*1.13M),
                                Description="Vaseline"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,26),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.21M,
                                Description="Gummies, Marshmallow, Honey"
                            }
                        }
                    },
                    //2024-04-29 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,29),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=8.34M,
                                Description="Bananas, Grapes, Baguette, Bread"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,29),
                        Location="Giant Tiger",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.61M,
                                Description="Jelly Powder x2, Ice Cream, Spaguettini x3"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,29),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=6.5M
                            }
                        }
                    },
                    //2024-04-30 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,04,30),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=(3+5+5.5M+1.75M)
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,30),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.99M,
                                Description="Eggs 30"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,04,30),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.76M,
                                Description="Corn x5, Milk"
                            }
                        }
                    },
                };
                foreach (var item in april24)
                {
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var may24 = new Transaction[]
                {
                    //2024-05-01 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,01),
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
                    new Transaction
                    {
                        Date= new DateTime(2024,05,01),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=99.44M,
                                Description="Phone bill"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,01),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=1.7M,
                                Description="Clear Bowls 12ct 4in"
                            }
                        }
                    },
                    //2024-05-02 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,02),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.37M,
                                Description="Golden Cake, Tostitos"
                            }
                        }
                    },
                    //2024-05-04 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,04),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.83M,
                                Description="Iced Tea, Skittles"
                            }
                        }
                    },
                    //2024-05-06 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,06),
                        Location="Walmart",
                        TotalAmount=40.45M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(40.45M-(5.98M*1.13M)),
                                Description="Tuna x2, Donuts, Table Cream, Coffee, Lettuce, Condensed Milk, Bologna, Soda, Bread, Yogurt, Cucumber, Pancake Mix"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Healthcare,
                                Amount=(5.98M*1.13M),
                                Description="Alleve 24"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,06),
                        Location="Food Basics",
                        TotalAmount=14.36M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(14.36M-(1.25M*1.13M)),
                                Description="Baguette, Frozen Breaded Fish x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=(1.25M*1.13M),
                                Description="Milk Chocolate"
                            }
                        }
                    },
                    //2024-05-07 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,07),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=16.88M,
                                Description="Chips x2, Ahoy Cookies, Potatoes 10LB, Pizza Pops x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,07),
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
                        Date= new DateTime(2024,05,07),
                        Location="Amazon",
                        TotalAmount=45.49M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(26.5M*1.13M),
                                Description="Shower Filter"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(13.75M*1.13M),
                                Description= "Calendula Cream"
                            }
                        }
                    },
                    //2024-05-09 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,09),
                        Location="Top Food Supermarket",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=14.23M,
                                Description="Spring Rolls, Tang, Chicharron"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,09),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=8.76M,
                                Description="WD-40 178G, Clingwrap"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,09),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1230.9M
                            }
                        }
                    },
                    //2024-05-12 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,12),
                        Location="Dollarama",
                        TotalAmount=12.11M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(12.11M-(1.5M*1.13M)-(0.91M*4*1.13M)),
                                Description="Crackers, Gumballs, Tostitos"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=(0.91M*4*1.13M),
                                Description="Hershey Bar x2, Kit Kat x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.5M*1.13M),
                                Description="Paper Towels"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,12),
                        Location="A&W",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=33.51M,
                                Description="Double Teen Burger x2, Poutine, Sprite Regular"
                            }
                        }
                    },
                    //2024-05-14 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,14),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=5.08M,
                                Description="Dustpan & Broom"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,14),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=11.58M,
                                Description="Food Containers, Herb Chopper, Glass Container"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,14),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=8
                            }
                        }
                    },
                    //2024-05-15 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,15),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.59M,
                                Description="Bananas, Bread x2, Plantain, Mangoes x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    //2024-05-17 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,17),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.91M,
                                Description="Mood Cookie x2, Cookies Duo, Chicken Broth, Cereal Fruity"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,17),
                        Location="Canada Revenue Agency",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.TaxReturns,
                                Amount=1902.33M,
                                Description="Marcela's tax returns"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,17),
                        Location="Canada Revenue Agency",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.TaxReturns,
                                Amount=155.63M,
                                Description="Santiago's tax returns"
                            }
                        }
                    },
                    //2024-05-18 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,18),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.96M,
                                Description="Air Freshner x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,18),
                        Location="bb.q Chicken",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=83.17M,
                                Description="Cream Dukk-Bokki, Galbi Q Chicken, Honey Garlic Chicken"
                            }
                        }
                    },
                    //2024-05-19 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,19),
                        Location="Giant Tiger",
                        TotalAmount=13.79M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.88M,
                                Description="Milk"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(7*1.13M),
                                Description="Men's T-Shirt"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,19),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4.88M,
                                Description="Plantain Chips, Coca-Cola"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,19),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
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
                        Date= new DateTime(2024,05,19),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=15
                            }
                        }
                    },
                    //2024-05-21 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,21),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=22.74M,
                                Description="Lean Ground Beef, Pepper, Strawberries, Kiwi, Mozzarella x2, Cheddar, Baguette, Burger Buns"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,21),
                        Location="Dollarama",
                        TotalAmount=6.78M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(6.78M-(1.5M*1.13M)),
                                Description="Moth Ball"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=(1.5M*1.13M),
                                Description="Crush Soda"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,21),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=40,
                                Description="Presto Cards Load"
                            }
                        }
                    },
                    //2024-05-22 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,22),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.99M,
                                Description="Hot Dog Buns, Firci Gragola Snack Cakes, Granola Bars"
                            }
                        }
                    },
                    //2024-05-23 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,23),
                        Location="Dollarama",
                        TotalAmount=9.32M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(2.25M*1.13M),
                                Description="Chips"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(1.5M*1.13M),
                                Description="Note Pad"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=(1.5M*3*1.13M),
                                Description="Ferrero Rocher x3"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DirectDebit,
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
                        Date= new DateTime(2024,05,23),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1312.22M
                            }
                        }
                    },
                    //2024-05-24 - DONE                    
                    new Transaction
                    {
                        Date= new DateTime(2024,05,24),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=40,
                                Description="Presto Cards Load"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,24),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.89M,
                                Description="Lettuce, Tomatoes"
                            }
                        }
                    },
                    //2024-05-25 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,25),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=14.48M,
                                Description="Bologna, Orange Soda, Milk, Ice Cream"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,25),
                        Location="Go Transit",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=20,
                                Description="GO Weekend pass x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,25),
                        Location="Nakamori",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=18.08M,
                                Description="Takoyaki, Onigiri x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,25),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=(14+3.3M),
                                Description="New Presto Card, Card Load, Ticket"
                            }
                        }
                    },
                    //2024-05-26 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,26),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=2.26M,
                                Description="Foam Insoles"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,26),
                        Location="Fusion Wrap",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=27.1M,
                                Description="Shawarma x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,26),
                        Location="Beaver Tail",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=8.99M,
                                Description="Beaver Tail"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,05,26),
                        Location="Downhill Hot Dogs",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=8.8M,
                                Description="Ice"
                            }
                        }
                    },
                    //2024-05-27 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,27),
                        Location="Dollarama",
                        TotalAmount=6.27M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.75M),
                                Description="Cookies"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=(4*1.13M),
                                Description="Daisy Bush, Everyday Cards"
                            }
                        }
                    },
                    //2024-05-28 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,28),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=6.78M,
                                Description="Ladies T-Shirt x3"
                            }
                        }
                    },
                    //2024-05-30 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,05,30),
                        Location="Dollarama",
                        TotalAmount=8.22M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(8.22M-(4.5M*1.13M)),
                                Description="Gummies, Creamer"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Healthcare,
                                Amount=(4.5M*1.13M),
                                Description="Acetaminophen"
                            }
                        }
                    },
                };
                foreach (var item in may24)
                {
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var june24 = new Transaction[]
                {
                    //2024-06-01 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,01),
                        Location="No Frills",
                        TotalAmount=44.26M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(44.26M-(14.99M*1.13M)),
                                Description="Chicharron, Frozen Breaded Fish, Potatoes 10LB, Cornbeef, Sliced Ham, Sliced Turkey, Chicken Breasts" +
                                "Baguette, WW Bread, Tomatoes"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(14.99M*1.13M),
                                Description="Dove Soap Sensitive 12"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,01),
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
                    //2024-06-03 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,02),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=99.44M,
                                Description="Phone bill"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,03),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=67.8M,
                                Description="Selection Cheese Snack, Muffins, Coca-Cola, Whole Chicken, Carrots, Red Grapes, Frozen Pizza, Pizza Pops" +
                                "Garlic Bread, Salmon, Chocolate Cup Cakes"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,03),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1.97M,
                                Description="Eggs 18 x2, Wieners ($10 points redeemed)"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,03),
                        Location="Dollarama",
                        TotalAmount=9.28M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(9.28M-(2.5M*1.13M)-(3.5M*1.13M)),
                                Description="Ramen x3, Cracker"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(2.5M*1.13M),
                                Description="Spice Shakers"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(3.5M*1.13M),
                                Description="Sports Bra"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,03),
                        Location="Centennial College",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Education,
                                Amount=8925,
                                Description="3rd Semester Payment"
                            }
                        }
                    },
                    //2024-06-06 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,06),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1281.24M
                            }
                        }
                    },
                    //2024-06-08 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,08),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.PreviousSavings,
                                Amount=6903.36M,
                                Description="Currency Exchange at Calforex 5076USD -> 6903.36CAD "
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,08),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=75.71M,
                                Description="Marce's Sneakers, Woven Pant"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,08),
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
                        Date= new DateTime(2024,06,08),
                        Location="Gino's Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=16.95M,
                                Description="Large Meat Lovers Pizza"
                            }
                        }
                    },
                    //2024-06-09 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,09),
                        Location="AliBaba",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=12.1M,
                                Description="Beef Shawarma, Coke Can"
                            }
                        }
                    },
                    //2024-06-10 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,10),
                        Location="LCBO",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.BankTransfer,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=20,
                                Description="Gift for Hector (Tequila, Bottle Bag)"
                            }
                        }
                    },
                    //2024-06-11 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,11),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=15.09M,
                                Description="Jelly Powder x2, Cheese Snack, Midi Hazelnut, Plantain, Strawberries, Garlic Bread, WW Bread"
                            }
                        }
                    },
                    //2024-06-12 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,12),
                        Location="Dollarama",
                        TotalAmount=29.35M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(25.39M-(3*1.13M)-((1.5M*2+1.75M+1.25M)*1.13M)),
                                Description="Que Pasa Tortilla Chips, Wafers, Cookies Duo, Meteor Choc x2, Puff Pastry, Maria Cookies, Beef Concentrate"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(3.96M+(1.5M*2+1.75M+1.25M)*1.13M),
                                Description="Dish Rack, Kitchen Funnels, Basting Brush, Paper Towels, Scissors"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(3*1.13M),
                                Description="Deodorant"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,12),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=5.95M,
                                Description="Modern Basket"
                            }
                        }
                    },
                    //2024-06-13 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,13),
                        Location="Dollarama",
                        TotalAmount=16.34M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(16.34M-(3.5M*1.13M)-1),
                                Description="Lazy Susan (Rotating Tray), Sink Mat, Napkins"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(3.5M*1.13M),
                                Description="Pregnancy Test"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=1,
                                Description="Cookies"
                            }
                        }
                    },
                    //2024-06-14 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,14),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.92M,
                                Description="Cookie Little Heart x2, Wieners, Red Grapes, Iogo Yogurt, Boneless Pork ($10 points redeemed)"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,14),
                        Location="Canada Revenue Agency",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.GovernmentBenefits,
                                Amount=210,
                                Description="Climate Action Incentive"
                            }
                        }
                    },
                    //2024-06-15 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,15),
                        Location="Dollarama",
                        TotalAmount=17.23M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(17.23M-(2.25M+1+2.5M)*1.13M),
                                Description="OVD Rack, Shower Caddy, Air Freshner"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=((2.25M+1+2.5M)*1.13M),
                                Description="Gummies, Candy, Party Mix"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,15),
                        Location="Giant Tiger",
                        TotalAmount=39.45M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(11*2*1.13M),
                                Description="Women's Dresses x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(8.97M+4.97M*1.13M),
                                Description="Ice Cream, Tempura Shrimp"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    //2024-06-16 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,16),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=20.34M,
                                Description="Scrubber Sponge, Basket, Pastic Basket, Plastic Pantry, Ziploc 4ct"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,16),
                        Location="Giant Tiger",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=56.47M,
                                Description="GL 4T LD Shelf, Magic Hose, Four Tier Shelf"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,16),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=19.21M,
                                Description="Glass Jar x9, Bounce Dryer, Kitchen Towel"
                            }
                        }
                    },
                    //2024-06-18 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,18),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=9.25M
                            }
                        }
                    },
                    //2024-06-20 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,20),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.08M,
                                Description="Milk"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,20),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1146.91M
                            }
                        }
                    },
                    //2024-06-23 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,23),
                        Location="Dollarama",
                        TotalAmount=19.86M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((3*1.13M)+1.5M),
                                Description="White Bowl x2, Napkins"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=((2.25M+2.5M)*1.13M),
                                Description="Chips, Skittles"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(3.5M*1.13M),
                                Description="Sports Bra"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(5*1.13M),
                                Description="Body Scrubs"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DirectDebit,
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
                        Date= new DateTime(2024,06,23),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=(9.5M+1.75M)
                            }
                        }
                    },
                    //2024-06-24 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,24),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=36.23M,
                                Description="Meat Sirloin, Navel Oranges, Avocado Bag, Bananas, Cucumber, Tomatoes, Eggs 12 x3, Baguette, WW Bread"
                            }
                        }
                    },
                    //2024-06-25 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,25),
                        Location="Walmart",
                        TotalAmount=30.16M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(12.07M+3.27M+2.97M),
                                Description="Lean Ground Beef, Glazed Donut, Ketchup"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((7.97M+0.84M*3)*1.13M),
                                Description="Tide Laundry Detergent, Colgate x3"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,25),
                        Location="Gentle Procedures Clinic",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Healthcare,
                                Amount=100,
                                Description="Deposit for vasectomy"
                            }
                        }
                    },
                    //2024-06-27 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,27),
                        Location="FV Foods",
                        TotalAmount=17.9M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=(12.74M*1.13M),
                                Description="Chicharron"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3.5M,
                                Description="Pandesal"
                            }
                        }
                    },
                    //2024-06-29 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,29),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=24.08M,
                                Description="White Vinegar, Tuna x2, Panela, Ice Cream x2, Mushrooms, Watermelon, WW Bread, Tortillas x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,29),
                        Location="Dollar Tree",
                        TotalAmount=14.71M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(4.5M*1.13M),
                                Description="Damp Trap, Mix&Serve Container x2 (Laundry Detergent, Fabric Softener containers)"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(2*1.13M+2),
                                Description="Nestle Milk Wafers, Cinnabon Cereal"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(1.75M*1.13M),
                                Description="Paddle Brush"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(3*1.13M),
                                Description="Modeling Clay"
                            }
                        }
                    },
                    //2024-06-30 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,06,30),
                        Location="Hoop Sports Bar & Grill",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=17.59M,
                                Description="Creemore IPA Jug x6, Hoops Fries"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,06,30),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=99.44M,
                                Description="Phone bill"
                            }
                        }
                    },
                };
                foreach (var item in june24)
                {
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var july24 = new Transaction[]
                {                    
                    //2024-07-02 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,02),
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
                    //2024-07-03 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,03),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.22M,
                                Description="Cookie Little Heart x2, Wieners, Cheddar"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,03),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=7.44M,
                                Description="Selection Cheese Snack, Strawberries, Butter Sticks, Hot Dog Buns"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,03),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=9
                            }
                        }
                    },
                    //2024-07-04 - DONE                    
                    new Transaction
                    {
                        Date= new DateTime(2024,07,04),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1382.74M
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,04),
                        Location="Taptap Send",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DebtPayment,
                                Amount=250,
                                Description="Money sent to Marce's Mom to reduce loan debt"
                            }
                        }
                    },
                    //2024-07-05 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,05),
                        Location="Canada Revenue Agency",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.GovernmentBenefits,
                                Amount=170,
                                Description="GST"
                            }
                        }
                    },
                    //2024-07-06 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,06),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=13.98M,
                                Description="Crackers, Gummies x2, Tostitos, Puff Pastry, Swissrolls, Party Mix"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,06),
                        Location="Giant Tiger",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=5.22M,
                                Description="Linguine x4, Fettuccine x2"
                            }
                        }
                    },
                    //2024-07-10 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,10),
                        Location="Dollarama",
                        TotalAmount=12.15M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=((4+3.5M)*1.13M),
                                Description="Glass Container, Wooden Spoon"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(2*1.13M),
                                Description="Makeup Towel"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(1.25M*1.13M),
                                Description="Notebook"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,10),
                        Location="Canada Revenue Agency",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.GovernmentBenefits,
                                Amount=60,
                                Description="Ontario Trillium Benefit"
                            }
                        }
                    },
                    //2024-07-11 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,11),
                        Location="Dollarama",
                        TotalAmount=18.7M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(18.7M-(8.5M*1.13M)-(1.5M*1.13M)),
                                Description="Chocolate, Candy, Cookies, Mountain Dew"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(8.5M*1.13M),
                                Description="Dish Mat, Umbrella"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(1.5M*1.13M),
                                Description="Bra Extender"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,11),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=12.8M,
                                Description="Milk, Soy Sauce, WW Bread, Orange Soda, Mango x2"
                            }
                        }
                    },
                    //2024-07-14 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,14),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=(5.5M+6+2+2+0.5M)
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,14),
                        Location="No Frills",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=10.36M,
                                Description="Tomatoes, Wieners, Ground Chicken, Baguette"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,14),
                        Location="Dollar Tree",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(3*1.13M),
                                Description="Strawberry Juice Powder, Cherry Juice Powder"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(1.5M*1.13M),
                                Description="Damp Trap"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(1.5M*1.13M),
                                Description="Disposable Razor"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,14),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=18.07M,
                                Description="Large Meatlovers Pizza, Coke x3"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,14),
                        Location="Pizza Pizza",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.PrepaidCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Gifts,
                                Amount=18.07M,
                                Description="Nequi - Large Meatlovers Pizza, Coke x3"
                            }
                        }
                    },
                    //2024-07-15 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,15),
                        Location="Scotiabank",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
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
                    new Transaction
                    {
                        Date= new DateTime(2024,07,15),
                        Location="Canada Revenue Agency",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.GovernmentBenefits,
                                Amount=210,
                                Description="Canada Carbon Rebate"
                            }
                        }
                    },
                    //2024-07-16 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,16),
                        Location="Dollarama",
                        TotalAmount=11.38M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Healthcare,
                                Amount=(4*1.13M),
                                Description="Tylenol Extra"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(4.25M*1.13M),
                                Description="Pill Organizer"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=(0.91M*2*1.13M),
                                Description="Coffee Crisp"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,16),
                        Location="Yal Market",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=3,
                                Description="Lime x3, Ginger Tea"
                            }
                        }
                    },
                    //2024-07-17 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,17),
                        Location="FreshCo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=20.98M,
                                Description="Eggs 30, Rice"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,17),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=16.75M,
                                Description="Cheese Snacks, Chips, Pork Loin, Apples"
                            }
                        }
                    },
                    //2024-07-18 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,18),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=6.56M,
                                Description="Selection Ripple (Chips), Mozzarella Slices x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,18),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1219.69M
                            }
                        }
                    },
                    //2024-07-20 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,20),
                        Location="Burger King",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=18.08M,
                                Description="Long Cheeseburger Combos x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,20),
                        Location="Ardene",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=69.75M,
                                Description="Sneakers, Ultra Crop Dolman Boxy Tee With Pocket x2, Crop Short Sleeves Jersey, Waist Short"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,20),
                        Location="Old Navy",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=44.06M,
                                Description="T-Shirts x2, Sunglasses"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,20),
                        Location="Walmart",
                        TotalAmount=49.68M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(49.68M-(14.97M*1.13M)-(4.97M+4.98M)),
                                Description="Mayonnaise, Milk, WW Bread, Bologna x2, Corn x4, Pancake Mix"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(14.97M*1.13M),
                                Description="Durex"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Gifts,
                                Amount=(4.97M+4.98M),
                                Description="Ice Cream, Chips Ahoy Cookies - For Diana"
                            }
                        }
                    },
                    //2024-07-21 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,21),
                        Location="Dollarama",
                        TotalAmount=15.15M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=(15.15M-4.13M),
                                Description="Air Freshner, Febreze Warmer, Bra Wash Bag"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=4.13M,
                                Description="Biscuits, Gumballs"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,21),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=(5+3+2+2.5M)
                            }
                        }
                    },
                    //2024-07-23 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,23),
                        Location="Presto",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DirectDebit,
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
                    //2024-07-24 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,24),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=9.01M,
                                Description="Chicken Breasts"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,24),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=2.38M,
                                Description="Cookies Duo, Pepsi 1L"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,24),
                        Location="Walmart",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=20.06M,
                                Description="Table Cream 18%, Condensed Milk, Gelatine Flavorless, Coffee, Doña Arepas Flour"
                            }
                        }
                    },
                    //2024-07-25 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,25),
                        Location="Dollarama",
                        TotalAmount=6.18M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(1.75M*1.13M),
                                Description="Self-Laminating (Cards)"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(4*1.05M),
                                Description="Socks"
                            }
                        }
                    },
                    //2024-07-26 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,26),
                        Location="Ardene",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=49.46M,
                                Description="Classic High Waist (Shorts), Longline Underwire & HR Plisse Short with Lining (Swimwear), Kimono Floral (Cover-up)"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,26),
                        Location="Decathlon",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=13.56M,
                                Description="Microfiber Towel L size"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,26),
                        Location="Burger King",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=18.08M,
                                Description="Long Cheeseburger Combo x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,26),
                        Location="Walmart",
                        TotalAmount=38.79M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.97M+0.94M),
                                Description="Mushroom, Bread,"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=((7.88M*2+8.87M)*1.13M),
                                Description="Dove x6 x2, Banana Boat Sunscreen"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Healthcare,
                                Amount=(7.12M*1.13M),
                                Description="Equate Bismuth Subsalicylate"
                            }
                        }
                    },
                    //2024-07-27 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,27),
                        Location="Giant Tiger",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=18.08M,
                                Description="T-Shirt & Shorts (Activewear)"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,27),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=1.41M,
                                Description="Elastics"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,27),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Clothing,
                                Amount=(4.75M*2*1.13M),
                                Description="Lady's Clogs, Men's Clogs (Crocs)"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(2.25M*1.13M),
                                Description="Chips"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(4.5M*1.13M),
                                Description="Picnic Blanket"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,27),
                        Location="Dollarama",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=1.13M,
                                Description="Dr Pepper 1L"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,27),
                        Location="916 Midland Ave Parking",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Entertainment,
                                Amount=70,
                                Description="40 Coupons to ride fair attractions"
                            }
                        }
                    },
                    //2024-07-28 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,28),
                        Location="Kennedy Subway Station",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=20,
                                Description="Presto Card Load"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,28),
                        Location="Shawarma King",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.DiningOut,
                                Amount=19.20M,
                                Description="Beef Shawarma x2"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,28),
                        Location="OLG",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=4,
                                Description="Lottery ticket"
                            }
                        }
                    },
                    //2024-07-30 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,30),
                        Location="Aliexpress",
                        TotalAmount=20.02M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=6.76M,
                                Description="Card Holder Keychain x2"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=9.88M,
                                Description="Women Tummy Control Waist Slimming"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=3.38M,
                                Description="Universal Hose Tap Adapter"
                            }
                        }
                    },
                    //2024-07-31 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,07,31),
                        Location="Dollarama",
                        TotalAmount=9.32M,
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.PersonalCare,
                                Amount=(3.25M*1.13M),
                                Description="Eyebrow razor, Antiperspirant"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Miscellaneous,
                                Amount=(3.5M*1.13M),
                                Description="Make Up Bag"
                            },
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=(1.5M*1.13M),
                                Description="Choco Cupcake"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,07,31),
                        Location="Fido",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Utilities,
                                Amount=(49.72M*2),
                                Description="Phone Bill"
                            }
                        }
                    }
                };
                foreach (var item in july24)
                {
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();

                var august24 = new Transaction[]
                {                    
                    //2024-08-01 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,08,01),
                        Location="Mad Mexican",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1262.87M
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,08,01),
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
                    new Transaction
                    {
                        Date= new DateTime(2024,08,02),
                        Location="Food Basics",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Groceries,
                                Amount=21.46M,
                                Description="Whole Chicken, Avocado, Muffins, Baguette, Wheat Bread"
                            }
                        }
                    },
                    //2024-08-02 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2024,08,02),
                        Location="Home Essentials",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.HouseholdItems,
                                Amount=13.55M,
                                Description="Shopping Cart"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,08,02),
                        Location="Wash 4 Less Coin Laundry",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Laundry,
                                Amount=8
                            }
                        }
                    },
                };
                foreach (var item in august24)
                {
                    item.UserId = userId;
                    item.Update();
                    context.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
