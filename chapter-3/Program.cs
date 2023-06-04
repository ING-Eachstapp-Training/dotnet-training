using chapter_3.Business;

namespace chapter_3;
class Program
{
    static void Main(string[] args)
    {
        TodoListBusiness menu = new TodoListBusiness();

        while (true)
        {
            DisplayMenu();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    menu.ViewTasks();
                    break;

                case "2":
                    menu.AddTask();
                    break;

                case "3":
                    menu.CompleteTask();
                    break;

                case "4":
                    menu.UncompleteTask();
                    break;

                case "5":
                    menu.EditTask();
                    break;

                case "6":
                    menu.DeleteTask();
                    break;

                case "7":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("----- To-Do List Menu -----");
        Console.WriteLine("1. View Tasks");
        Console.WriteLine("2. Add Task");
        Console.WriteLine("3. Complete Task");
        Console.WriteLine("4. Uncomplete Task");
        Console.WriteLine("5. Edit Task");
        Console.WriteLine("6. Delete Task");
        Console.WriteLine("7. Exit");
    }
}

