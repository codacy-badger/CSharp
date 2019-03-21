﻿using ExercicioFixacaoInterface.Entities;
using ExercicioFixacaoInterface.Services;
using System;
using System.Globalization;

namespace ExercicioFixacaoInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Contract value: ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Contract contract = new Contract(number, date, contractValue);

            Console.Write("Enter number of installments: ");
            int nInstallments = int.Parse(Console.ReadLine());

            ContractProccessmentService _contractProccessmentService = new ContractProccessmentService(new PayPalService());
            _contractProccessmentService.proccessContract(contract, nInstallments);

            Console.WriteLine("INSTALLMENTS: ");
            foreach (Installment installment in contract.Installments)
            {
                Console.WriteLine(installment);
            }

        }
    }
}
