using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList
{
    public class MenuManager
    {
        private List<string> _menu = new List<string>();

        public MenuManager()
        {
            _menu.Add("*************************");
            _menu.Add("1.タスクを追加する");
            _menu.Add("2.タスクの一覧を表示する");
            _menu.Add("3.終了する");
        }

        public void Display()
        {
            for (int i = 0; i < _menu.Count; i++)
            {
                Console.WriteLine(_menu[i]);
            }
            Console.WriteLine("番号を入力してください");
        }
    }
}
