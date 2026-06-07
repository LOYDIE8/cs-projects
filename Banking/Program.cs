using System;
using System.Collections.Generic;
using System.Xml;

namespace Banking
{
    public class Bank
    {
        public static void Main(String[] args)
        {
            Dictionary<string, int> accounts = new Dictionary<string, int>();
            bool bankActive = true;
            string currentAccount = "";
            System.Console.WriteLine("================================================");
            System.Console.WriteLine("=================BULLSHIT BANK==================");
            System.Console.WriteLine("================================================");
            while (bankActive)
            {

                System.Console.WriteLine("\n\n[1]     Create account");
                System.Console.WriteLine("[2]     Switch account");
                System.Console.WriteLine("[3]     Deposit");
                System.Console.WriteLine("[4]     Withdraw ");
                System.Console.WriteLine("[5]     Check balance");
                System.Console.WriteLine("[6]     Show all accounts");
                System.Console.WriteLine("[7]     Delete account");
                System.Console.WriteLine("[8]     EXIT");
                int nav;
                if (!int.TryParse(Console.ReadLine(), out nav))
                {
                    if (nav >= 7)
                    {
                        System.Console.WriteLine("invalid action");
                    }
                }
                switch (nav)
                {
                    case 1:
                        Console.Clear();
                        System.Console.WriteLine("ENTER ACCOUNT NAME");
                        String accName = Console.ReadLine() ?? "";
                        if (string.IsNullOrWhiteSpace(accName))
                        {
                            System.Console.WriteLine("Error   Account Name cannot be empty!");
                            break;
                        }
                        if (accounts.ContainsKey(accName))
                        {
                            System.Console.WriteLine($"Error {accName} already exist");
                            break;
                        }
                        else
                        {
                            accounts.Add(accName, 0);
                            currentAccount = accName;
                            System.Console.WriteLine($"{accName} Successfully Added");

                        }
                        break;
                    case 2:
                        Console.Clear();
                        System.Console.WriteLine("PLEASE ENTER ACCOUNT NAME");
                        string tempAcc = Console.ReadLine() ?? "";
                        if (!accounts.ContainsKey(tempAcc))
                        {
                            System.Console.WriteLine($"Error {tempAcc} does'nt exist");
                            break;
                        }
                        else
                        {
                            currentAccount = tempAcc;
                            System.Console.WriteLine("success");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (string.IsNullOrWhiteSpace(currentAccount))
                        {
                            System.Console.WriteLine("NO ACCOUNTS DETECTED");
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine("==ACCOUNT================BALANCE===");
                            System.Console.WriteLine($"{currentAccount}        {accounts[currentAccount]}");
                            System.Console.WriteLine("PLEASE ENTER AMOUNT TO DEPOSIT");
                            int deposit;
                            if (!int.TryParse(Console.ReadLine(), out deposit)) { System.Console.WriteLine("ERROR INVALID AMOUNT"); }
                            else
                            {
                                accounts[currentAccount] += deposit;
                                System.Console.WriteLine($"success!   {deposit} was added to {currentAccount}");
                            }

                        }
                        break;
                    case 4:
                        Console.Clear();
                        if (string.IsNullOrWhiteSpace(currentAccount))
                        {
                            System.Console.WriteLine("NO ACCOUNTS DETECTED");
                            break;
                        }
                        else
                        {
                            System.Console.WriteLine("==ACCOUNT================BALANCE===");
                            System.Console.WriteLine($"{currentAccount}        {accounts[currentAccount]}");
                            System.Console.WriteLine("PLEASE ENTER AMOUNT TO WIDRAW");
                            int widraw;
                            if (int.TryParse(Console.ReadLine(), out widraw))
                            {
                                if (widraw > accounts[currentAccount])
                                {
                                    System.Console.WriteLine("INSUFFICIENT AMOUNT!!!");
                                }
                                else
                                {
                                    accounts[currentAccount] -= widraw;
                                    System.Console.WriteLine($"success!   {widraw} was deducted from {currentAccount}");
                                }
                            }
                            else
                            {
                                System.Console.WriteLine("ERROR INVALID AMOUNT");
                            }
                        }

                        break;
                    case 5:
                        Console.Clear();
                        if (string.IsNullOrWhiteSpace(currentAccount))
                        {
                            System.Console.WriteLine("NO ACCOUNTS DETECTED");
                        }
                        else
                        {
                            System.Console.WriteLine("==ACCOUNT================BALANCE===");
                            System.Console.WriteLine($"{currentAccount}        {accounts[currentAccount]}");
                        }
                        break;
                    case 6:
                        Console.Clear();
                        if (accounts.Count == 0)
                        {
                            System.Console.WriteLine("NO ACCOUNTS AVAILABLE");
                        }
                        else
                        {
                            foreach (var account in accounts)
                            {
                                System.Console.WriteLine("====ACCOUNT=======BALANCE====");
                                System.Console.WriteLine($"  {account.Key}       {account.Value}");
                            }
                        }
                        break;
                    case 7:
                        Console.Clear();
                        System.Console.WriteLine("PLEASE ENTER ACCOUNT NAME");
                        tempAcc = Console.ReadLine() ?? "";
                        if (!accounts.ContainsKey(tempAcc))
                        {
                            System.Console.WriteLine($"Error {tempAcc} does'nt exist");
                            break;
                        }
                        else
                        {
                            accounts.Remove(tempAcc);
                            System.Console.WriteLine($"{tempAcc} was successfully removed");
                            if(tempAcc == currentAccount) currentAccount = "";
                        }
                        break;
                    case 8:
                        bankActive = false;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}