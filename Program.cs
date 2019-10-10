﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace linqCustomTypes
{
    public class Program
{
    public static void Main() {
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            List<Customer> millionaires = customers.Where(c => c.Balance >= 1000000).ToList();


            //GroupBy with some funky parameters
            var millionaireByBank = millionaires.GroupBy(millionaire => millionaire.Bank,
                millionaire => millionaire, (key, g) => new
                {
                    nameOfBank = key,
                    MillionaireCount = g.Count()
                }

            );
            foreach (var count in millionaireByBank) {
                Console.WriteLine($"{count.nameOfBank}: {count.MillionaireCount}");
            }

        }
    }
}
