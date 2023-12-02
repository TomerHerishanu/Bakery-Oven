using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery_Oven
{
    public class PastryButton : Button
    {
        private static string _pastryName;
        private static int _delayTime;
        private ConcurrentQueue<string> _ovenQueue;
        private ConcurrentQueue<string> _readyQueue;

        public PastryButton(string pastryName, int delayTime, ConcurrentQueue<string> ovenQueue, ConcurrentQueue<string> readyQueue)
        {
            Name = pastryName.ToLower() + "Button";
            Text = pastryName;
            _pastryName = pastryName;
            _delayTime = delayTime;
            _ovenQueue = ovenQueue;
            _readyQueue = readyQueue;
            Click += PastryButtonClick;
            Size = new Size(112, 34);
            UseVisualStyleBackColor = true;
            _readyQueue = readyQueue;
        }

        private static int DelayTime()
        {
            return _delayTime;
        }

        private static string PastryName()
        {
            return _pastryName;
        }

        private async void PastryButtonClick(object sender, EventArgs e)
        {
            _ovenQueue.Enqueue(_pastryName);
            Form1.UpdateInTheOvenNumLabel();
            if (!_ovenQueue.IsEmpty)
            {
                await DequeueAfterDelay(_delayTime);
            }
        }

        private async Task DequeueAfterDelay(int delayMili)
        {
            await Task.Delay(delayMili);

            _ovenQueue.TryDequeue(out string result);

            Form1.UpdateInTheOvenNumLabel();

            if (result != null)
            {
                _readyQueue.Enqueue(result);
                Form1.UpdateReadyNumLabel();
            }

            if (!_ovenQueue.IsEmpty)
            {
                if (_ovenQueue.TryPeek(out string res))
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
    }
}
