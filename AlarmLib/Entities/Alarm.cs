namespace AlarmLib.Entities;

public class Alarm
{
    // Инкремент
    private static int _counter;

    // Конструкторы
    public Alarm() => Id = _counter++;
    public Alarm(string name, TimeOnly time, string dayOfTheWeek, string state, string soundName)
    {
        Id = _counter++;
        Name = name;
        Time = time;
        DayOfTheWeek = dayOfTheWeek;
        State = state;
        SoundName = soundName;
    }
    public Alarm(int id, string name, TimeOnly time, string dayOfTheWeek, string state, string soundName)
    {
        Id = id;
        Name = name;
        Time = time;
        DayOfTheWeek = dayOfTheWeek;
        State = state;
        SoundName = soundName;
    }

    // Аксессоры
    public int Id { get; set; }
    public TimeOnly Time { get; set; }
    public string DayOfTheWeek { get; set; }
    public string State { get; set; }
    public string Name { get; set; }
    public string SoundName { get; set; }
}
