using AlarmLib.Entities;
using System.Media;

namespace AlarmLib;

public class Logic
{
    // Список будильников
    private static List<Alarm> _alarms = new()
    { 
        new Alarm("Будильник", new TimeOnly(12, 12), "Будний", "Выключен", "Sencha"),
        new Alarm("Будильник", new TimeOnly(16, 16), "Выходной", "Выключен", "Trill"),
        new Alarm("Будильник", new TimeOnly(19, 19), "Будний", "Выключен", "Ripples")
    };

    /// <summary>
    /// Получение списка будильников
    /// </summary>
    /// <returns>Список будильников</returns>
    public List<Alarm> ListOfAlarms()
    {
        return _alarms
            .OrderBy(alarm => alarm.Time)
            .ToList();
    }

    /// <summary>
    /// Добавление нового будильника в список
    /// </summary>
    /// <param name="alarm">Будильник для добавления</param>
    /// <returns>Если операция прошла успешно, то возвращает строку "Будильник успешно добавлен", в противном случае "Ошибка"</returns>
    public string AddAlarm(Alarm alarm)
    {
        if (!_alarms.Any(innerAlarm => innerAlarm.Id == alarm.Id))
        {
            _alarms.Add(alarm);

            return "Будильник успешно добавлен";
        }

        return "Ошибка";
    }

    /// <summary>
    /// Удаление существущего будильника
    /// </summary>
    /// <param name="id">Номер будильника, который нужно удалить</param>
    /// <returns>Если удаление произошло успешно, то возвращает строку "Будильник успешно удален", в противном случае "Ошибка"</returns>
    public string DeleteAlarm(int id)
    {
        var alarmToDelete = _alarms.FirstOrDefault(innerAlarm => innerAlarm.Id == id);

        if (alarmToDelete == null)
            return "Ошибка";

        _alarms.Remove(alarmToDelete);

        return "Будильник успешно удален";
    }

    /// <summary>
    /// Обновление существующего будильника
    /// </summary>
    /// <param name="alarm">Будильник, который нужно обновить</param>
    /// <returns>Если обновление произошло успешно, то возвращает строку "Будильник успешно обновлен", в противном случае "Ошибка"</returns>
    public string UpdateAlarm(Alarm alarm)
    {
        var find = _alarms.Find(innerAlarm => innerAlarm.Id == alarm.Id);
        int index = _alarms.IndexOf(find);

        if (index > -1)
        {
            _alarms[index] = alarm;

            return "Будильник успешно обновлен";
        }

        return "Ошибка";
    }

    /// <summary>
    /// Получение списка рингтонов
    /// </summary>
    /// <returns>Список рингтонов</returns>
    public List<string> ListOfSounds()
    {
        string path = $@"{Environment.CurrentDirectory}\Sounds\";
        List<string> soundList = new List<string>();

        if (Directory.Exists(path))
        {
            foreach (var musicName in Directory.GetFiles(path))
                soundList.Add(Path.GetFileName(musicName).Replace(".wav", ""));

            return soundList;
        }

        return soundList;
    }

    /// <summary>
    /// Воспроизведение музыки
    /// </summary>
    /// <param name="soundName">Название рингтона</param>
    public void SoundPlayBack(string soundName)
    {
        string path = $@"{Environment.CurrentDirectory}\Sounds\{soundName}.wav";

        if (File.Exists(path))
        {
            var soundPlayer = new SoundPlayer(path);
            soundPlayer.Play();
        }
    }
}