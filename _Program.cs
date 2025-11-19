using System.IO; // ファイル操作のための「道具箱」
using System.Text.Json; // JSONを扱うための「道具箱」

// 1つのタスクを表現するための「クラス」という設計図
public class TodoItem
{
    // タスクの内容を保存する場所
    public string Title { get; set; }

    // タスクが完了したかどうかを保存する場所 (true = 完了, false = 未完了)
    public bool IsDone { get; set; }
}

class _Program
{
    // このクラス全体で使えるように、todoListとファイルパスを定義
    static List<TodoItem> todoList = new List<TodoItem>();
    static readonly string filePath = "todolist.json"; // 保存するファイル名

    static void Main_Osriginal(string[] args)
    {
        LoadTasks(); // ▼▼▼ アプリケーション起動時にタスクを読み込む ▼▼▼

        while (true) // 無限に繰り返す
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("やるべきことリスト");
            Console.WriteLine("1: タスクを追加する");
            Console.WriteLine("2: タスクの一覧を見る");
            Console.WriteLine("3: タスクを完了にする");
            Console.WriteLine("4: タスクを削除する"); // ▼▼▼メニュー追加▼▼▼
            Console.WriteLine("5: タスクを編集する"); // ▼▼▼メニュー追加▼▼▼
            Console.WriteLine("6: 終了する");           // ▼▼▼メニュー追加▼▼▼
            Console.Write("操作を選んでください > ");

            // ユーザーが入力した文字を読み取る
            string input = Console.ReadLine();

            if (input == "1")
            {
                AddTask();
            }
            else if (input == "2")
            {
                ViewTasks();
            }
            else if (input == "3")
            {
                CompleteTask();
            }
            else if (input == "4")
            {
                DeleteTask(); // 「タスクを削除する」メソッドを呼び出す
            }
            else if (input == "5")
            {
                EditTask(); // 「タスクを編集する」メソッドを呼び出す
            }
            else if (input == "6")
            {

                SaveTasks(); // ▼▼▼ アプリケーション終了時にタスクを保存する ▼▼▼
                Console.WriteLine("タスクを保存しました。アプリケーションを終了します。");
                break;
            }
            else
            {
                Console.WriteLine("1, 2, 3,4のいずれかを入力してください。");
            }

            Console.WriteLine(); // 見やすくするために改行
        }
    }
    // ▼▼▼ 以下、新しく作成したメソッド ▼▼▼

    /// <summary>
    /// タスクを追加する処理
    /// </summary>
    static void AddTask()
    {
        Console.Write("追加するタスクの内容を入力してください > ");
        string taskTitle = Console.ReadLine();

        TodoItem newItem = new();
        newItem.Title = taskTitle;
        newItem.IsDone = false;

        todoList.Add(newItem);
        Console.WriteLine("タスクを追加しました。");
    }
    /// <summary>
    /// タスクの一覧を表示する処理
    /// </summary>
    static void ViewTasks()
    {
        Console.WriteLine("--- タスク一覧 ---");
        if (todoList.Count == 0)
        {
            Console.WriteLine("登録されているタスクはありません。");
        }
        else
        {
            for (int i = 0; i < todoList.Count; i++)
            {
                TodoItem item = todoList[i];
                string status = item.IsDone ? "[完了]" : "[未完了]";
                Console.WriteLine($"{i + 1}. {status} {item.Title}");
            }
        }
    }

    /// <summary>
    /// タスクを完了にする処理
    /// </summary>
    static void CompleteTask()
    {
        ViewTasks(); // 先に一覧を表示して、ユーザーが選びやすくする

        if (todoList.Count == 0) return; // タスクがなければ処理を中断

        Console.Write("完了にするタスクの番号を入力してください > ");
        string taskNumberInput = Console.ReadLine();

        if (int.TryParse(taskNumberInput, out int taskNumber))
        {
            int index = taskNumber - 1;

            if (index >= 0 && index < todoList.Count)
            {
                // まだ完了していないタスクの場合のみ更新
                if (!todoList[index].IsDone)
                {
                    todoList[index].IsDone = true;
                    Console.WriteLine("タスクを完了にしました。");
                }
                else
                {
                    Console.WriteLine("そのタスクはすでに完了しています。");
                }
            }
            else
            {
                Console.WriteLine("エラー: 無効な番号です。");
            }
        }
        else
        {
            Console.WriteLine("エラー: 数値を入力してください。");
        }
    }
    // ▼▼▼ 以下、新しく作成したメソッド ▼▼▼

    /// <summary>
    /// タスクを削除する処理
    /// </summary>
    static void DeleteTask()
    {
        ViewTasks(); // 先に一覧を表示して、ユーザーが選びやすくする

        if (todoList.Count == 0) return; // タスクがなければ処理を中断

        Console.Write("削除するタスクの番号を入力してください > ");
        string taskNumberInput = Console.ReadLine();

        if (int.TryParse(taskNumberInput, out int taskNumber))
        {
            int index = taskNumber - 1;

            if (index >= 0 && index < todoList.Count)
            {
                // 指定されたインデックスの要素をリストから削除する
                todoList.RemoveAt(index);
                Console.WriteLine("タスクを削除しました。");
            }
            else
            {
                Console.WriteLine("エラー: 無効な番号です。");
            }
        }
        else
        {
            Console.WriteLine("エラー: 数値を入力してください。");
        }
    }
    /// <summary>
    /// タスクを編集する処理
    /// </summary>
    static void EditTask()
    { 
        ViewTasks(); // 先に一覧を表示して、ユーザーが選びやすくする

        if (todoList.Count == 0) return; // タスクがなければ処理を中断

        Console.Write("編集するタスクの番号を入力してください > ");
        string taskNumberInput = Console.ReadLine();

        if(int.TryParse(taskNumberInput, out int taskNumber))
        {
            int index = taskNumber - 1;

            if (index >= 0 && index < todoList.Count)
            {
                Console.WriteLine("タスクの編集内容を入力してください。");
                todoList[index].Title = Console.ReadLine();
                Console.WriteLine("タスクを編集しました。");
            }
            else
            {
                Console.WriteLine("エラー: 無効な番号です。");
            }
        }
        else
        {
            Console.WriteLine("エラー: 数値を入力してください。");
        }
    }


    /// <summary>
    /// ファイルからタスクを読み込む処理
    /// </summary>
    static void LoadTasks()
    {
        // もし保存ファイルが存在すれば、読み込み処理を行う
        if (File.Exists(filePath))
        {
            // ファイルのすべてのテキストを読み込む
            string json = File.ReadAllText(filePath);

            // JSONテキストを List<TodoItem> オブジェクトに変換（デシリアライズ）
            var loadedTasks = JsonSerializer.Deserialize<List<TodoItem>>(json);

            // 読み込みが成功していれば、現在のリストを読み込んだリストで置き換える
            if (loadedTasks != null)
            {
                todoList = loadedTasks;
                Console.WriteLine($"{todoList.Count}件のタスクを読み込みました。");
            }
        }
        else
        {
            Console.WriteLine("保存ファイルが見つかりません。新しいリストで開始します。");
        }
    }
    /// <summary>
    /// ファイルへタスクを保存する処理
    /// </summary>
    static void SaveTasks()
    {
        // List<TodoItem> オブジェクトをJSONテキストに変換（シリアライズ）
        // WriteIndented = true は、人間が読みやすいようにインデントを付けて出力する設定
        string json = JsonSerializer.Serialize(todoList, new JsonSerializerOptions { WriteIndented = true });

        // すべてのテキストをファイルに書き込む（上書き保存）
        File.WriteAllText(filePath, json);
    }

}
