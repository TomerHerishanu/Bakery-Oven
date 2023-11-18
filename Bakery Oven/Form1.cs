using System.Drawing.Text;

namespace Bakery_Oven
{
    public partial class Form1 : Form
    {
        private OnOffService onOffService;
        private TemperatureService temperatureService;
        private readonly SemaphoreSlim tempChangeSem = new SemaphoreSlim(1, 1);

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("100");
            comboBox1.Items.Add("150");
            comboBox1.Items.Add("180");
            comboBox1.Items.Add("220");
            comboBox1.SelectedIndex = 2;
            onOffService = new OnOffService();
            onOffService.OvenStatusChanged += OnOvenStatusChanged;
            onOffService.StartAsync(CancellationToken.None);
            temperatureService = new TemperatureService();
            temperatureService.TemperatureChanged += CurrentTempChanged;
        }

        private void CurrentTempChanged(object sender, int tempNum)
        {
            Invoke((MethodInvoker)delegate
            {
                currentTempNum.Text = $"{tempNum}";
            });
        }
        private void OnOvenStatusChanged(object sender, bool isOn)
        {
            if (isOn)
            {
                onOff.Text = "Oven is ON";
                onOff.ForeColor = Color.Green;
            }
            else
            {
                onOff.Text = "Oven is OFF";
                onOff.ForeColor = Color.Red;
            }
        }

        private async void setTempButton_Click(object sender, EventArgs e)
        {
            string selectedTempStr = comboBox1.SelectedItem as string;
            if (selectedTempStr != null)
            {
                int selectedTemp = Convert.ToInt32(selectedTempStr);
                await Task.Run(() =>
                {
                    temperatureService.Start(selectedTemp);
                });
            }
        }
    }
}