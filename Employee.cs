public class Employee
{
    // Employee data will be saved in the following variables, the variable names show the data that will be saved in each of them.
    private string firstName;
    private string lastName;
    private int age;
    private string companyRole;

    //The constructor takes the employee data as parameters and saves them.
    public Employee(string fName, string lName, int a, string role){
        firstName = fName;
        lastName = lName;
        age = a;
        companyRole = role;
    }

    public string DisplayInformation(){
        //This method returns the employee information in a string.
        return $"{firstName} {lastName}, {age}, {companyRole}";
    }

    public string GetStringRepresentation(){
        //This method will generate a string with the data separated in commas.
        return $"{firstName},{lastName},{age},{companyRole}";
    }

    public void Edit(){
        //The edit method asks the user which data to modify and sets the value of the object to the new one.
        int menu = 0;

        //The while loop is used here so the user can keep on editing until they decide to exit.
        while (menu != 5)
        {
            Console.WriteLine("Which data would you like to modify?: ");
            Console.WriteLine("\t1. First Name");
            Console.WriteLine("\t2. Last Name");
            Console.WriteLine("\t3. Age");
            Console.WriteLine("\t4. Company Role");
            Console.WriteLine("\t5. Exit");
            Console.Write("Please select the number of your choice: ");
            menu = int.Parse(Console.ReadLine());
            if (menu == 1)
            {
                Console.WriteLine("What is the new first name?");
                firstName = Console.ReadLine();
            }
            else if (menu == 2)
            {
                Console.WriteLine("What is the new last name?");
                lastName = Console.ReadLine();
            }
            else if (menu == 3)
            {
                Console.WriteLine("What is the new age?");
                age = int.Parse(Console.ReadLine());
            }
            else if (menu == 4)
            {
                Console.WriteLine("What is the new company role?");
                companyRole = Console.ReadLine();
            }

            Console.WriteLine("Would you like to continue editing? (y/n)");
            string option = Console.ReadLine();

            if (option == "y")
            {
                menu = 0;
            }
            else
            {
                menu = 5;
            }
        }
    }

}