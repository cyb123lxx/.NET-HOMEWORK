using System;


public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }


    public Account(string accountNumber)
    {
        AccountNumber = accountNumber;
        Balance = 0;
    }


    public void Deposit(decimal amount)
    {
        Balance += amount;
    }


    public virtual void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InsufficientFundsException("余额不足");
        }
        Balance -= amount;
    }
}


public class CreditAccount : Account
{
    public decimal CreditLimit { get; set; }

    public CreditAccount(string accountNumber, decimal creditLimit) : base(accountNumber)
    {
        CreditLimit = creditLimit;
    }


    public override void Withdraw(decimal amount)
    {
        if (amount > Balance + CreditLimit)
        {
            throw new InsufficientFundsException("超出信用额度");
        }
        Balance -= amount;
    }
}


public class BigMoneyArgs : EventArgs
{
    public Account Account { get; }
    public decimal Amount { get; }

    public BigMoneyArgs(Account account, decimal amount)
    {
        Account = account;
        Amount = amount;
    }
}


public class ATM
{
    public event EventHandler<BigMoneyArgs> BigMoneyFetched;

    public void WithdrawMoney(Account account, decimal amount)
    {
        try
        {
            if (amount > 10000)
            {
                BigMoneyFetched?.Invoke(this, new BigMoneyArgs(account, amount));
            }

            if (new Random().Next(0, 100) < 30)
            {
                throw new BadCashException("发现坏的钞票");
            }

            account.Withdraw(amount);
            Console.WriteLine($"从账户{account.AccountNumber}取款{amount}元成功。");
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"取款失败：{ex.Message}");
        }
        catch (BadCashException ex)
        {
            Console.WriteLine($"取款失败：{ex.Message}");
        }
    }
}

public class BadCashException : Exception
{
    public BadCashException(string message) : base(message)
    {
    }
}

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {

        var creditAccount = new CreditAccount("123456789", 5000);

   
        var atm = new ATM();
        atm.BigMoneyFetched += (sender, e) =>
        {
            Console.WriteLine($"大笔金额取款警告：从账户{e.Account.AccountNumber}取款{e.Amount}元！");
        };

   
        atm.WithdrawMoney(creditAccount, 2000);
        atm.WithdrawMoney(creditAccount, 6000);
        atm.WithdrawMoney(creditAccount, 12000);

        Console.ReadKey();
    }
}
