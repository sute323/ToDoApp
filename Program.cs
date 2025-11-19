
using System.Diagnostics.Contracts;
//GitHub
namespace TodoList
{
    class Program
    {

        static void Main(string[] args)
        {

            //メニュー取得
            Menu menu = new Menu();
            //タスククラス取得
            TaskManager taskItem = new TaskManager();

            while (true)
            {
                //メニュー表示
                menu.Display();

                //入力の受付
                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out int index))
                {
                    index = index - 1;
                    if (index == 0) 
                    {
                        //タスク追加処理
                        taskItem.AddTask();
                    }
                    else if (index == 1) //タスク一覧
                    {
                        //タスク一覧の表示処理
                        taskItem.ViewTask();
                    }
                    else if (index == 2) //終了
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("入力数値がエラーです");
                    }
                }
                else
                {
                    Console.WriteLine("数値を入力してください。");
                }
            }
        }

    }
}