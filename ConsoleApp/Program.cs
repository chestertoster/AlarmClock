using AlarmLib;
using AlarmLib.Entities;

namespace ConsoleApp;

class Program
{
    private static Logic _logic = new();
    static void Main(string[] args)
    {
        Console.Title = "Будильник";

        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Enabled = true;
        timer.Interval = 1000;
        timer.Elapsed += TimerTick;

        while (true) 
        {
            ListOfCommands();
            if (!Commands(Console.ReadLine()))
                Console.Clear();
        }
    }

    static void TimerTick(Object source, System.Timers.ElapsedEventArgs e)
    {
        Logic logic = new();
        List<Alarm> alarms = logic.ListOfAlarms();

        foreach (var alarm in alarms)
        {
            if ((DateTime.Now.ToShortTimeString() == alarm.Time.ToShortTimeString())
                && (alarm.State == "Включен"))
            {
                Alarm alarmToUpdate = new(alarm.Id, alarm.Name, alarm.Time, alarm.DayOfTheWeek, "Выключен", alarm.SoundName);

                if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday || DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (alarm.DayOfTheWeek == "Выходной")
                    {
                        Console.WriteLine("Будильник сработал");
                        logic.SoundPlayBack(alarm.SoundName);
                        logic.UpdateAlarm(alarmToUpdate);
                    }
                }
                else
                {
                    if (alarm.DayOfTheWeek == "Будний")
                    {
                        Console.WriteLine("Будильник сработал");
                        logic.SoundPlayBack(alarm.SoundName);
                        logic.UpdateAlarm(alarmToUpdate);
                    }
                }
            }
        }
    }

    static void ListOfCommands()
    {
        Console.WriteLine(" 1. Список будильников");
        Console.WriteLine(" 2. Добавить будильник");
        Console.WriteLine(" 3. Удалить будильник");
        Console.WriteLine(" 4. Обновить будильник");
        Console.Write("> ");
    }

    static bool Commands(string commandName)
    {
        switch (commandName)
        {
            case "1":
                ListOfAlarms();
                return true;
            case "2":
                AddAlarm();
                return true;
            case "3":
                DeleteAlarm();
                return true;
            case "4":
                UpdateAlarm();
                return true;
            default: return false;
        }
    }

    static bool ListOfAlarms()
    {
        List<Alarm> alarms = _logic.ListOfAlarms();

        if (alarms.Count > 0)
        {
            Console.WriteLine($"\n {"Номер",-5} | {"Время",-5} | {"Состояние",-9} | {"День недели",-11} | Название");
            Console.WriteLine("-------+-------+-----------+-------------+----------");

            foreach (var alarm in alarms)
                Console.WriteLine($" {alarm.Id,-5} | {alarm.Time.ToShortTimeString(),-5} | {alarm.State,-9} | {alarm.DayOfTheWeek,-11} | {alarm.Name}");

            Console.WriteLine();

            return true;
        }

        Console.WriteLine("\nСписок будильников пуст\n");

        return false;
    }

    static void AddAlarm()
    {
        Console.WriteLine("\nПроцесс добавления будильника...\n");

        Console.Write(" Название будильника\n Пример: \"Новый будильник\"\n> ");
        string name = Console.ReadLine();

        TimeOnly time;
        void TimeCheck()
        {
            Console.Write("\n Время будильника\n Формат: [HH:mm] или [HH:mm:ss]\n> ");

            bool timeCheck = TimeOnly.TryParse(Console.ReadLine(), out TimeOnly testedTime);

            if (timeCheck)
                time = testedTime;
            else TimeCheck();
        }
        TimeCheck();

        Console.Write("\n День недели\n [0] - Будний, [1] - Выходной\n> ");
        string dayOfTheWeek = Console.ReadLine() switch
        {
            "0" => "Будний",
            "1" => "Выходной",
            _ => "Будний"
        };

        Console.Write("\n Состояние\n [0] - Выключен, [1] - Включен\n> ");
        string state = Console.ReadLine() switch
        {
            "0" => "Выключен",
            "1" => "Включен",
            _ => "Выключен"
        };

        string soundName = string.Empty;
        InteractionWithSound(ref soundName);

        Alarm alarmToAdd = new(name, time, dayOfTheWeek, state, soundName);

        Console.WriteLine('\n' + _logic.AddAlarm(alarmToAdd) + '\n');
    }

    static void DeleteAlarm()
    {
        if (ListOfAlarms())
        {
            Console.Write(" Введите номер будильника, который хотите удалить\n> ");
            try
            {
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine('\n' + _logic.DeleteAlarm(id) + '\n');
            }
            catch { Console.WriteLine("\nВы ввели некорретный номер\n"); }
        }
    }

    static void UpdateAlarm()
    {
        if (ListOfAlarms())
        {
            Console.WriteLine("\nПроцесс обновления будильника...\n");

            int id = 0;
            void NumberCheck()
            {
                Console.Write(" Введите номер будильника, который хотите обновить\n> ");
                bool numberCheck = int.TryParse(Console.ReadLine(), out int testedNumber);

                if (numberCheck)
                    id = testedNumber;
                else
                {
                    Console.WriteLine("\nВы ввели некорретный номер\n");
                    NumberCheck();
                }
            }
            NumberCheck();

            Console.Write(" Название будильника\n Пример: \"Новый будильник\"\n> ");
            string name = Console.ReadLine();

            TimeOnly time;
            void TimeCheck()
            {
                Console.Write("\n Время будильника\n Формат: [HH:mm] или [HH:mm:ss]\n> ");

                bool timeCheck = TimeOnly.TryParse(Console.ReadLine(), out TimeOnly testedTime);

                if (timeCheck)
                    time = testedTime;
                else TimeCheck();
            }
            TimeCheck();

            Console.Write("\n День недели\n [0] - Будний, [1] - Выходной\n> ");
            string dayOfTheWeek = Console.ReadLine() switch
            {
                "0" => "Будний",
                "1" => "Выходной",
                _ => "Будний"
            };

            Console.Write("\n Состояние\n [0] - Выключен, [1] - Включен\n> ");
            string state = Console.ReadLine() switch
            {
                "0" => "Выключен",
                "1" => "Включен",
                _ => "Выключен"
            };

            string soundName = string.Empty;
            InteractionWithSound(ref soundName);

            Alarm alarmToUpdate = new(id, name, time, dayOfTheWeek, state, soundName);

            Console.WriteLine('\n' + _logic.UpdateAlarm(alarmToUpdate) + '\n');
        }
    }

    static bool InteractionWithSound(ref string name)
    {
        List<string> soundNames = _logic.ListOfSounds();

        bool ListOfSounds()
        {
            if (soundNames.Count > 0)
            {
                Console.WriteLine("\nНазвание файлов рингтонов:");

                foreach (var soundName in soundNames)
                    Console.WriteLine($" - {soundName}");

                Console.WriteLine();

                return true;
            }

            Console.WriteLine("\nФайл с рингтонами пуст");

            return false;
        }

        if (ListOfSounds())
        {
            Console.Write(" Введите название файла\n> ");
            string inputSoundName = Console.ReadLine();

            foreach (var soundName in soundNames)
            {
                if (inputSoundName == soundName)
                {
                    name = inputSoundName;
                    return true;
                }
            }
        }

        Console.WriteLine("\nВы ввели неверное название файла");
        InteractionWithSound(ref name);
        return false;
    }
}