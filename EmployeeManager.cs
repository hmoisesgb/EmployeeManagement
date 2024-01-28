public class EmployeeManager
{
    //The employee manager keeps track of a list of Employee objects
    private List<Employee> _employees;

    public EmployeeManager(){
        //The constructor just initializes the _employees list
        _employees = new List<Employee>();
    }

    public void Start(){
        //This method is the main method of the class and program, this method shows a menu and manages the Employee methods, and the list
        int option = 0;

        while (option != 7)
        {
            //The while loop shows the menu until the user selects the number to exit.
            Console.WriteLine("\nMenu Options: ");
            Console.WriteLine("\t1. Add new employee");
            Console.WriteLine("\t2. Edit employee information");
            Console.WriteLine("\t3. Display employees information");
            Console.WriteLine("\t4. Delete employee");
            Console.WriteLine("\t5. Save file");
            Console.WriteLine("\t6. Load file");
            Console.WriteLine("\t7. Quit");
            Console.Write("Select a number from the menu: ");
            option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                AddEmployee();
            }
            if(option == 2)
            {
                EditEmployee();
            }
            if(option == 3)
            {
                DisplayEmployees();
            }
            if(option == 4)
            {
                DeleteEmployee();
            }
            if(option == 5)
            {
                SaveFile();
            }
            if(option == 6)
            {
                LoadFile();
            }
            if(option == 7)
            {
                Environment.Exit(0);
            }
        }
    }

    public void AddEmployee(){
        //This method asks data to the user and uses them to create an Employee object and add it to the list.
        Console.WriteLine("What is the first name of the employee?");
        string firstName = Console.ReadLine();
        Console.WriteLine("What is the last name of the employee?");
        string lastName = Console.ReadLine();
        Console.WriteLine("What is the age of the employee?");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("What is the company role of the employee?");
        string role = Console.ReadLine();
        Employee employee = new Employee(firstName, lastName, age, role);
        _employees.Add(employee);
    }

    public void DisplayEmployees(){
        //This method displays all the employees to the user by using a foreach, and showing each employee information using the DisplayInformation method in the Employee class
        int number = 1;
        foreach (Employee employee in _employees)
        {
            Console.WriteLine($"{number}. {employee.DisplayInformation()}");
            number++;
        }
    }

    public void EditEmployee(){
        //This method uses the previously created DisplayEmployees method to show a list of the employees, 
        // so they can select which one to edit, and uses the Edit method of the employee selected. The edit variable has a
        // -1 at the end as the DisplayEmployees will show a list starting with the number 1, and this will provide
        // with the exact index to edit.
        Console.WriteLine("Which employee would you like to edit?");
        DisplayEmployees();
        Console.Write("Please select the number of employee you would like to edit: ");
        int edit = int.Parse(Console.ReadLine()) - 1;
        _employees[edit].Edit();
    }

    public void DeleteEmployee(){
        //This method uses the previously created DisplayEmployees method to show a list of the employees, 
        // so they can select which one to remove, then removes the employee selected. The remove variable has a
        // -1 at the end as the DisplayEmployees will show a list starting with the number 1, and this will provide
        // with the exact index to remove.
        Console.WriteLine("Which employee would you like to remove?");
        DisplayEmployees();
        Console.Write("Please select the number of employee you would like to edit: ");
        int remove = int.Parse(Console.ReadLine()) - 1;
        _employees.RemoveAt(remove);
    }

    public void SaveFile(){
        //This method asks the user for a filename, and then uses the StreamWriter from the system class to save the information in a text file
        Console.Write("What is the filename for the employee list? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Employee employee in _employees)
            {
                outputFile.WriteLine(employee.GetStringRepresentation());
            }
        }
        Console.WriteLine($"File saved as {fileName}");
    }

    public void LoadFile(){
        //This method asks the user for a filename, then saves each of the lines into strings.
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        //This foreach, separates all lines, and process them individually
        foreach (string line in lines)
        {
            //The data is then split in each comma as the string representation has every
            //value separated through commas, and then creates a new Employee with the data
            //and adds it to the employee list.
            string [] data = line.Split(",");
            string fName = data[0];
            string lName = data[1];
            int a = int.Parse(data[2]);
            string role = data[3];
            Employee employee = new Employee(fName,lName,a,role);
            _employees.Add(employee);
        }
        Console.WriteLine($"File {fileName} loaded");
    }
}