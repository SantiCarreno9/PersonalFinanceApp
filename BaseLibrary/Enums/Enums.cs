﻿using BaseLibrary.Entities;

public enum PaymentMethods
{
    DebitCard = 1,
    CreditCard,
    Cash,
    Deposit,
    BankTransfer,
    Cheque,
    DigitalWallet,
    DirectDebit,
    PrepaidCard
}

public enum TransactionTypes
{    
    All=0,
    Expense,
    Income,
}

public enum ExpenseCategories
{
    Housing = 1,
    HouseholdItems,
    Utilities,
    Laundry,
    Transportation,
    Groceries,
    DiningOut,
    Clothing,
    Education,
    Entertainment,
    Technology,
    PersonalCare,
    Healthcare,
    Insurance,
    Services,
    Savings,
    Investment,
    DebtPayment,
    Gifts,
    Taxes,
    Miscellaneous = 99
}

public enum IncomeCategories
{
    Employment = 101,
    PreviousSavings,
    Investment,
    TaxReturns,
    GovernmentBenefits,
    Gifts,
    Loan,
    Refund,
    Retirement,
    Rental,
    Miscellaneous = 199
}