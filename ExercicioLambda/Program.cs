using ExercicioLambda.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExercicioLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string FilePath = Console.ReadLine();

            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine());

            List<Employee> list = new List<Employee>();

            try
            {
                using (StreamReader StreamReader = File.OpenText(FilePath))
                {
                    while (!StreamReader.EndOfStream)
                    {
                        string[] fields = StreamReader.ReadLine().Split(',');

                        string Name = fields[0];

                        string Email = fields[1];

                        double Salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                        list.Add(new Employee(Name, Email, Salary));
                    }

                    var emails = list.Where(obj => obj.Salary > salary).OrderBy(obj => obj.Email).Select(obj => obj.Email);

                    var Soma = list.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);


                    Console.WriteLine("Email of people whose salary is more than " + salary.ToString("F2", CultureInfo.InvariantCulture));

                    foreach (string email in emails)
                    {
                        Console.WriteLine(email);
                    }

                    Console.WriteLine("Sum of salary of people whose name starts with 'M': " + Soma.ToString("F2", CultureInfo.InvariantCulture));

                }

                Console.ReadLine();

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
