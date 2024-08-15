using System;
using System.Collections.Generic;

namespace TodoList
{
    public class Program
    {
        public static List<string> ToDos = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            string userInput = Console.ReadLine();
            do
            {
                Console.WriteLine("What do you want to do ?");
                Console.WriteLine("[S]ee all TODO's");
                Console.WriteLine("[A]dd a TODO");
                Console.WriteLine("[R]emove a TODO");
                Console.WriteLine("[E]xit");
                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                case "S":
                        GetToDos();
                        break; 
                case "A":
                        Console.WriteLine("Enter the TODO description");
                        string description = Console.ReadLine();
                        AddTodo(description);
                        break;
                case "R":
                        Console.WriteLine("Select the index of the ToDo you want to remove: ");
                        GetToDos();
                        if(int.TryParse(Console.ReadLine(), out int indexSelected))
                        {
                            DeleteTodo(indexSelected);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index. Please enter a number.");
                        }
                        break;
                default: 
                        Console.WriteLine("Invalid option. Please try again."); 
                        break;
                }
            } while (userInput != "E");
        }

        public static void AddTodo(string description)
        {

            if (!ToDos.Contains(description))
            {
                if (!string.IsNullOrEmpty(description)  )
                {
                    ToDos.Add(description);
                
                    Console.Write($" TODO successfully added: {description}");
                }
                else
                {
                    Console.WriteLine("Description cannot be empty");
                }

            }
            else
            {
                Console.WriteLine("The description must be unique");
            }
        }

        public static void DeleteTodo(int indexSelected)
        {
            if (indexSelected > 0 && indexSelected <= ToDos.Count && indexSelected != null)
            {
                string removedTodo = ToDos[indexSelected - 1]; //take the ToDo removed to show it later in the console
                ToDos.RemoveAt(indexSelected - 1); //In the list, the todos shows as a 1++ index , so i have to rest 1 to adjust to the correct index in the collection
                Console.Write($" TODO removed: {removedTodo}");
            }
            else
            {
                Console.WriteLine("Invalid index. Please select a valid index from the list.");
            }
        }
        public static void GetToDos()
        {
            if(ToDos.Count > 0)
            {
                Console.WriteLine("All ToDo's: ");
                for(int i = 0; i < ToDos.Count; i++)
                {
                    Console.WriteLine($"{i+ 1}. {ToDos[i]}");
                }
            }
            else
            {
                Console.WriteLine("No TODOs have been added yet");
            }
        }
    }
}
