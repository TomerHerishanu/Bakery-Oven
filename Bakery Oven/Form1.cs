using System.Collections.Concurrent;
using System.Drawing.Text;

namespace Bakery_Oven
{
    public partial class Form1 : Form
    {
        private OnOffService onOffService;
        private TemperatureService temperatureService;
        private readonly SemaphoreSlim tempChangeSem = new SemaphoreSlim(1, 1);
        //private InOvenQueue inOvenQueue;
        static ConcurrentQueue<string> inOvenQueue = new ConcurrentQueue<string>();
        static ConcurrentQueue<string> readyQueue = new ConcurrentQueue<string>();
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

        private void UpdateInTheOvenNumLabel()
        {
            inTheOvenNum.Text = $"{inOvenQueue.Count()}";
        }

        private void UpdateReadyNumLabel()
        {
            readyNum.Text = $"{readyQueue.Count()}";
        }

        private async void chocolateButton_Click(object sender, EventArgs e)
        {
            inOvenQueue.Enqueue("Chocolate");
            UpdateInTheOvenNumLabel();
            if (!inOvenQueue.IsEmpty)
            {
                await DequeueAfterDelay(3000);
            }
        }

        private async void butterButton_Click(object sender, EventArgs e)
        {
            inOvenQueue.Enqueue("Butter");
            UpdateInTheOvenNumLabel();
            if (!inOvenQueue.IsEmpty)
            {
                await DequeueAfterDelay(5000);
            }
        }

        private async void almondButton_Click(object sender, EventArgs e)
        {
            inOvenQueue.Enqueue("Almond");
            UpdateInTheOvenNumLabel();
            if (!inOvenQueue.IsEmpty)
            {
                await DequeueAfterDelay(7000);
            }
        }

        private async void cheeseButton_Click(object sender, EventArgs e)
        {
            inOvenQueue.Enqueue("Cheese");
            UpdateInTheOvenNumLabel();
            if (!inOvenQueue.IsEmpty)
            {
                await DequeueAfterDelay(10000);
            }
        }

        private async Task DequeueAfterDelay(int delayMili)
        {
            await Task.Delay(delayMili);

            inOvenQueue.TryDequeue(out string result);

            UpdateInTheOvenNumLabel();

            if (result != null)
            {
                readyQueue.Enqueue(result);
                UpdateReadyNumLabel();
            }

            if (!inOvenQueue.IsEmpty)
            {
                if (inOvenQueue.TryPeek(out string res))
                {
                    int nextDelay = 3000;
                    switch (res)
                    {
                        case "Chocolate":
                            nextDelay = 3000;
                            break;
                        case "Butter":
                            nextDelay = 5000;
                            break;
                        case "Almond":
                            nextDelay = 7000;
                            break;
                        case "Cheese":
                            nextDelay = 10000;
                            break;
                        default:
                            break;
                    }
                    await DequeueAfterDelay(nextDelay);
                }
            }
        }

        private void takeOutButton_Click(object sender, EventArgs e)
        {
            readyQueue.Clear();
            UpdateReadyNumLabel();
        }
    }
}