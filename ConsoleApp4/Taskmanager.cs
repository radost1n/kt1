using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class TaskManager
{
    private List<TaskItem> tasks = new List<TaskItem>();
    private int nextId = 1;
    private readonly string logFile = "app_log.txt";
    private readonly string traceFile = "trace_log.txt";

    public TaskManager()
    {
        
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener(traceFile));
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.AutoFlush = true;

        LogEvent("Инициализация менеджера задач");
        Trace.WriteLine("Tracer: TaskManager создан");
    }


    public void LogEvent(string message)   
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
        File.AppendAllText(logFile, logMessage + Environment.NewLine);
        Console.WriteLine($"[LOG] {logMessage}");
    }


    public void AddTask(string title)
    {
        Trace.WriteLine($"Tracer: Начало AddTask с title='{title}'");

        if (string.IsNullOrWhiteSpace(title))
        {
            LogEvent("Ошибка: попытка добавить задачу с пустым названием");
            Trace.WriteLine("Tracer: Ошибка - пустой заголовок");
            Console.WriteLine("Название задачи не может быть пустым.");
            return;
        }

        var task = new TaskItem(nextId++, title);
        tasks.Add(task);
        LogEvent($"Добавлена задача: ID={task.Id}, название='{task.Title}'");
        Trace.WriteLine($"Tracer: Задача {task.Id} добавлена в список");
    }

    
    public void RemoveTask(int id)
    {
        Trace.WriteLine($"Tracer: Начало RemoveTask с id={id}");

        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            LogEvent($"Ошибка: попытка удалить несуществующую задачу с ID={id}");
            Trace.WriteLine($"Tracer: Задача с ID={id} не найдена");
            Console.WriteLine($"Задача с ID {id} не найдена.");
            return;
        }

        tasks.Remove(task);
        LogEvent($"Удалена задача: ID={id}, название='{task.Title}'");
        Trace.WriteLine($"Tracer: Задача {id} удалена");
    }

    
    public void ListTasks()
    {
        Trace.WriteLine("Tracer: Начало ListTasks");
        LogEvent("Запрошен вывод списка задач");

        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            Trace.WriteLine("Tracer: Список задач пуст");
            return;
        }

        Console.WriteLine("Список задач:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"  {task}");
        }
        Trace.WriteLine($"Tracer: Выведено {tasks.Count} задач(и)");
    }
}
