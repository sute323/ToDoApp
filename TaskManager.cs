using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TodoList
{
    public class TaskManager
    {
        public List<ToDoItem> task = new List<ToDoItem>();

        //タスク追加
        public void AddTask()
        {
            Console.WriteLine("タスクを入力してください");

            string inputTask = Console.ReadLine();
            ToDoItem newItem = new ToDoItem(inputTask);
            task.Add(newItem);
        }

        //タスク表示
        public void ViewTask()
        {
            for (int i = 0; i < task.Count; i++)
            {
                Console.WriteLine(task[i].Title);
            }

        }
    }
}
