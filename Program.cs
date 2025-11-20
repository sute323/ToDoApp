
using System.Diagnostics.Contracts;
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
                    switch (index)
                    {
                        //プログラム終了
                        case 0:
                            break;
                        case 1:
                            taskItem.AddTask();
                            break;
                        case 2:
                            taskItem.ViewTask();
                            break;
                        case 3:
                            taskItem.DeleteTask();
                            break;
                        default:
                            Console.WriteLine("入力数値がエラーです");
                            break;
                    }

                    if (index == 0)
                    {
                        break;
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