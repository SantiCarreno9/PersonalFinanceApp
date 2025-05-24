using BaseLibrary.Entities;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceApp.Api.Data;

namespace PersonalFinanceApp.Api.Extensions
{
    public static class GuestEndpointExtension
    {
        public static IApplicationBuilder MapGuestEndpoint(this WebApplication app)
        {
            app.MapPost("/login-as-guest", async Task<Results<Ok<AccessTokenResponse>, EmptyHttpResult, ProblemHttpResult>>
            ([FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies, [FromServices] IServiceProvider sp) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();

                var email = configuration["Guest:Email"] ?? throw new InvalidOperationException("Guest email not found");
                var password = configuration["Guest:Password"] ?? throw new InvalidOperationException("Guest password not found");

                var signInManager = sp.GetRequiredService<SignInManager<IdentityUser>>();

                var useCookieScheme = useCookies == true || useSessionCookies == true;
                var isPersistent = useCookies == true && useSessionCookies != true;
                signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

                var result = await signInManager.PasswordSignInAsync(email, password, isPersistent, lockoutOnFailure: true);

                if (!result.Succeeded)
                {
                    return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
                }

                await CleanAndSeedDb(sp);
                // The signInManager already produced the needed response in the form of a cookie or bearer token.
                return TypedResults.Empty;
            });

            return app;
        }

        private static async Task CleanAndSeedDb(IServiceProvider sp)
        {
            var guestDbContext = sp.GetRequiredService<GuestDbContext>();
            await guestDbContext.Database.ExecuteSqlRawAsync("DELETE FROM Transactions");
            //await guestDbContext.Database.ExecuteSqlRawAsync("DELETE FROM sqlite_sequence WHERE name = 'Transactions'");

            var dummyTransactions = new Transaction[]
                {
                    //2024-05-01 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,05,01),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=1800
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2025,05,01),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=1800
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2025,03,01),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=1800
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2025,02,01),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=1800
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2025,01,01),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=1800
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,12,01),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=1800
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,11,01),
                        Location="Home",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.Cash,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Housing,
                                Amount=1800
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2025,03,01),
                        Location="Comcel",
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
                        Date= new DateTime(2025,05,01),
                        Location="Comcel",
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
                        Date= new DateTime(2025,04,01),
                        Location="Dollar Flower",
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
                    //2025-05-02 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,03,02),
                        Location="Dollar Store",
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
                    //2025-05-04 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,02,04),
                        Location="Dollar Store",
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
                    //2025-05-06 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,01,06),
                        Location="Supercenter",
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
                        Date= new DateTime(2025,05,06),
                        Location="Meal Basics",
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
                    //2025-05-07 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,04,07),
                        Location="Meal Basics",
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
                        Date= new DateTime(2025,03,07),
                        Location="Your Laundromat",
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
                        Date= new DateTime(2025,02,07),
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
                    //2025-05-09 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,01,09),
                        Location="Your Food Market",
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
                        Date= new DateTime(2025,05,09),
                        Location="Dollar Store",
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
                        Date= new DateTime(2025,04,09),
                        Location="Larkin-Gerlach",
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
                    //2025-05-12 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,03,12),
                        Location="Dollar Store",
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
                        Date= new DateTime(2025,02,12),
                        Location="W&A",
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
                    //2025-05-14 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,01,14),
                        Location="House Must Haves",
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
                        Date= new DateTime(2025,05,14),
                        Location="Dollar Store",
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
                        Date= new DateTime(2025,04,14),
                        Location="Your Laundromat",
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
                    //2025-05-15 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,03,15),
                        Location="Supercenter",
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
                        Date= new DateTime(2025,02,15),
                        Location="CanadaBank",
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
                    //2025-05-17 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,01,17),
                        Location="Dollar Store",
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
                    //2025-05-18 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,03,18),
                        Location="Dollar Flower",
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
                        Date= new DateTime(2025,02,18),
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
                    //2025-05-19 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,01,19),
                        Location="Giant Puma",
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
                        Date= new DateTime(2025,05,19),
                        Location="Grocery Store",
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
                        Date= new DateTime(2025,04,19),
                        Location="Dollar Store",
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
                        Date= new DateTime(2025,03,19),
                        Location="Your Laundromat",
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
                    //2025-05-21 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,02,21),
                        Location="Meal Basics",
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
                        Date= new DateTime(2025,01,21),
                        Location="Dollar Store",
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
                        Date= new DateTime(2025,05,21),
                        Location="Regalo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=40,
                                Description="Regalo Cards Load"
                            }
                        }
                    },
                    //2025-05-22 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,04,22),
                        Location="Meal Basics",
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
                    //2025-05-23 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,03,23),
                        Location="Dollar Store",
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
                        Date= new DateTime(2025,02,23),
                        Location="Regalo",
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
                        Date= new DateTime(2025,01,23),
                        Location="Larkin-Gerlach",
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
                    new Transaction
                    {
                        Date= new DateTime(2025,03,23),
                        Location="Larkin-Gerlach",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1500.22M
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,12,23),
                        Location="Larkin-Gerlach",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=2000
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2024,11,23),
                        Location="Larkin-Gerlach",
                        TransactionTypeId = (int)TransactionTypes.Income,
                        PaymentMethodId = (int)PaymentMethods.Deposit,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)IncomeCategories.Employment,
                                Amount=1800
                            }
                        }
                    },
                    //2025-05-24 - DONE                    
                    new Transaction
                    {
                        Date= new DateTime(2025,05,24),
                        Location="Regalo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.CreditCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=40,
                                Description="Regalo Cards Load"
                            }
                        }
                    },
                    new Transaction
                    {
                        Date= new DateTime(2025,04,24),
                        Location="Meal Basics",
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
                    //2025-05-25 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,03,25),
                        Location="Supercenter",
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
                        Date= new DateTime(2025,02,25),
                        Location="The Transit",
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
                        Date= new DateTime(2025,01,25),
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
                        Date= new DateTime(2025,05,25),
                        Location="Regalo",
                        TransactionTypeId = (int)TransactionTypes.Expense,
                        PaymentMethodId = (int)PaymentMethods.DebitCard,
                        TransactionDetails = new List<TransactionDetail>
                        {
                            new TransactionDetail
                            {
                                CategoryId = (int)ExpenseCategories.Transportation,
                                Amount=(14+3.3M),
                                Description="New Regalo Card, Card Load, Ticket"
                            }
                        }
                    },
                    //2025-05-26 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,04,26),
                        Location="Dollar Store",
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
                        Date= new DateTime(2025,03,26),
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
                        Date= new DateTime(2025,02,26),
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
                        Date= new DateTime(2025,01,26),
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
                    //2025-05-27 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,05,27),
                        Location="Dollar Store",
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
                    //2025-05-28 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,04,28),
                        Location="Dollar Flower",
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
                    //2025-05-30 - DONE
                    new Transaction
                    {
                        Date= new DateTime(2025,03,30),
                        Location="Dollar Store",
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
            foreach (var item in dummyTransactions)
            {
                item.UserId = "guest";
                item.Update();
            }

            await guestDbContext.AddRangeAsync(dummyTransactions);

            guestDbContext.SaveChanges();
        }
    }
}
