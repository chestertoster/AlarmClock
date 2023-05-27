using AlarmLib;
using AlarmLib.Entities;

namespace WinFormsApp;

public partial class Main : Form
{
    private static Logic _logic = new();
    public Main()
    {
        InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {
        Refresh();

        dataGridView.Columns["Id"].Visible = false;
        dataGridView.Columns["Time"].HeaderText = "Время";
        dataGridView.Columns["DayOfTheWeek"].HeaderText = "День недели";
        dataGridView.Columns["State"].HeaderText = "Состояние";
        dataGridView.Columns["Name"].HeaderText = "Название";
        dataGridView.Columns["SoundName"].Visible = false;

        dataGridView.RowHeadersVisible = false;

        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView.ReadOnly = true;

        dataGridView.AllowUserToResizeRows = false;
        dataGridView.AllowUserToResizeColumns = false;
    }

    private void Refresh()
    {
        dataGridView.DataSource = _logic.ListOfAlarms();
    }

    private void buttonUpdate_Click(object sender, EventArgs e)
    {
        Alarm alarm = (Alarm)dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[dataGridView.CurrentCell.ColumnIndex].OwningRow.DataBoundItem;

        AdditionalForm additionalForm = new(true, alarm);
        additionalForm.Text = "Редактирование";
        additionalForm.ShowDialog();
        Refresh();
    }

    private void buttonAdd_Click(object sender, EventArgs e)
    {
        Alarm alarm = (Alarm)dataGridView.Rows[dataGridView.CurrentRow.Index].Cells[dataGridView.CurrentCell.ColumnIndex].OwningRow.DataBoundItem;

        AdditionalForm additionalForm = new(false, alarm);
        additionalForm.Text = "Добавление";
        additionalForm.ShowDialog();
        Refresh();
    }

    private void timer_Tick(object sender, EventArgs e)
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
                        logic.SoundPlayBack(alarm.SoundName);
                        logic.UpdateAlarm(alarmToUpdate);
                        MessageBox.Show("Будильник сработал", "Уведомление");
                    }
                }
                else
                {
                    if (alarm.DayOfTheWeek == "Будний")
                    {
                        logic.SoundPlayBack(alarm.SoundName);
                        logic.UpdateAlarm(alarmToUpdate);
                        MessageBox.Show("Будильник сработал", "Уведомление");
                    }
                }
            }
        }
    }
}