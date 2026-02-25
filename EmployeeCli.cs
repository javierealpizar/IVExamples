using System;
using System.IO;

namespace InterviewProblems.EmployeeCli {
    class Program {
        static void Main(string[] args) {
            var command = args[0];

            switch (command) {
                case "PrintActions":
                    {
                        Console.WriteLine("PrintActions: Shows a list of all of the actions that are available.");
                        Console.WriteLine("PrintEmployeeList: Shows a list of all the employees in the system.");
                        Console.WriteLine("AddEmployee[First name][Last name]: Adds a new employee to the system and shows the employee id of the new employee.");
                        Console.WriteLine("FindEmployee[Search Property][Search Value]: Searches the system for all the employees that meet the search criteria and shows them on the console.");
                        return;
                    }
                case "PrintEmployeeList":
                    {
                        var employees = File.ReadAllLines("employees.txt");
                        foreach(var employee in employees)
                        {
                            var parts = employee.Split(',');
                            var firstName = parts[0];
                            var lastName = parts[1];

                            Console.WriteLine($"{firstName} {lastName}");
                        }
                        return;
                    }
                case "AddEmployee":
                    {
                        var firstName = args[1];
                        var lastName = args[2];
                        File.AppendAllText("employees.txt", $"{firstName},{lastName}\r\n");
                        return;
                    }
                case "FindEmployee":
                    {
                        var searchProperty = args[1];
                        var searchValue = args[2];
                        var employees = File.ReadAllLines("employees.txt");
                        foreach(var employee in employees)
                        {
                            var parts = employee.Split(',');
                            var firstName = parts[0];
                            var lastName = parts[1];

                            switch (searchProperty) {
                                case "FirstName":
                                    {
                                        if (firstName.Contains(searchValue))
                                            Console.WriteLine($"{firstName} {lastName}");
                                        break;
                                    }
                                case "LastName":
                                    {
                                        if (lastName.Contains(searchValue))
                                            Console.WriteLine($"{firstName} {lastName}");
                                        break;
                                    }
                            }
                        }
                        return;
                    }
            }
        }
    }
}
