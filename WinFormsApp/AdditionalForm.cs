using AlarmLib;
using AlarmLib.Entities;
using System.Globalization;

namespace WinFormsApp;

public partial class AdditionalForm : Form
{
    private static Logic _logic = new();
    private static Alarm _alarm;
    private static bool _isEdit;
    public AdditionalForm(bool isEdit, Alarm alarm)
    {
        InitializeComponent();

        _isEdit = isEdit;
        _alarm = alarm;
        comboBox.DataSource = _logic.ListOfSounds();

        comboBox.SelectedItem = alarm.SoundName;
    }
    public AdditionalForm(bool isEdit)
    {
        InitializeComponent();

        _isEdit = isEdit;
        comboBox.DataSource = _logic.ListOfSounds();
    }

    private void AdditionalForm_Load(object sender, EventArgs e)
    {
        if (_isEdit)
        {
            maskedTextBox.Text = _alarm.Time.ToShortTimeString();
            textBoxName.Text = _alarm.Name;

            if (_alarm.State == "Включен")
                checkState.Checked = true;
            else checkState.Checked = false;

            if (_alarm.DayOfTheWeek == "Выходной")
                checkDayOfTheWeek.Checked = true;
            else checkDayOfTheWeek.Checked = false;
        }
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        if (_isEdit)
        {
            Alarm alarmToUpdate = new(
                _alarm.Id,
                textBoxName.Text,
                TimeOnly.ParseExact(maskedTextBox.Text, "HH:mm", CultureInfo.InvariantCulture),
                checkDayOfTheWeek.Checked ? "Выходной" : "Будний",
                checkState.Checked ? "Включен" : "Выключен",
                comboBox.SelectedItem.ToString()
                );

            MessageBox.Show(_logic.UpdateAlarm(alarmToUpdate), "Уведомление");
            buttonCancel_Click(sender, e);
        }
        else
        {
            Alarm alarmToAdd = new(
                textBoxName.Text,
                TimeOnly.ParseExact(maskedTextBox.Text, "HH:mm", CultureInfo.InvariantCulture),
                checkDayOfTheWeek.Checked ? "Выходной" : "Будний",
                checkState.Checked ? "Включен" : "Выключен",
                comboBox.SelectedItem.ToString()
                );

            MessageBox.Show(_logic.AddAlarm(alarmToAdd), "Уведомление");
            buttonCancel_Click(sender, e);
        }
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
