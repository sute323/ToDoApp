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
                Console.WriteLine($"{i + 1}.{task[i].Title}");
            }

        }

        /// <summary>
        /// タスク削除
        /// </summary>
        public void DeleteTask()
        {
            Console.WriteLine("削除するタスク番号を入力してください");
            ViewTask();

            string inputTaskNumber = Console.ReadLine();
            if (int.TryParse(inputTaskNumber, out int index))
            {
                //タスクを数える
                int taskCount = task.Count;

                switch (index)
                {
                    case int m when m <= taskCount && m > 0:
                        task.RemoveAt(m - 1);
                        break;

                    case int n when n > taskCount || n == 0:
                        Console.WriteLine("入力数値がエラーです");
                        break;
                }
            }
            else
            {
                Console.WriteLine("数値を入力してください");
            }

        }
    }
}
