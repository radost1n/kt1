using System;

class Program
{
    static void Main(string[] args)
    {
        var manager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\n--- Управление задачами ---");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Удалить задачу");
            Console.WriteLine("3. Показать все задачи");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите действие (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите название задачи: ");
                    string title = Console.ReadLine();
                    manager.AddTask(title);
                    break;

                case "2":
                    Console.Write("Введите ID задачи для удаления: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        manager.RemoveTask(id);
                    }
                    else
                    {
                        Console.WriteLine("Неверный ID.");
                    }
                    break;

                case "3":
                    manager.ListTasks();
                    break;

                case "4":
                    manager.LogEvent("Завершение работы приложения");
                    Console.WriteLine("Выход...");
                    return;

                default:
                    Console.WriteLine("Неверный ввод. Повторите.");
                    break;
            }
        }
    }
}