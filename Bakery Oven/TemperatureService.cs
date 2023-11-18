using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Bakery_Oven
{
    internal class TemperatureService
    {
        private readonly SemaphoreSlim tempSem = new SemaphoreSlim(1, 1);
        private int currentTemperature = 0;

        private readonly object lockObject = new object();
        public int CurrentTemperature
        {
            get
            {
                lock (lockObject)
                {
                    return currentTemperature;
                }
            }
        }

        public event EventHandler<int> TemperatureChanged;

        public async Task Start(int desiredTemp)
        {
            await tempSem.WaitAsync();
            try
            {
                await ChangeTemp(desiredTemp, currentTemperature);
            }
            finally
            {
                tempSem.Release();
            }
        }

        public async Task ChangeTemp(int temperatureRequested, int temperatureCurrent)
        {
            await Task.Run(() =>
            {
                if (currentTemperature <= temperatureRequested)
                {
                    while (temperatureCurrent <= temperatureRequested)
                    {
                        SetCurrentTemp(temperatureCurrent);
                        temperatureCurrent++;
                        Thread.Sleep(50);
                    }
                }
                else
                {
                    while (temperatureCurrent >= temperatureRequested)
                    {
                        SetCurrentTemp(temperatureCurrent);
                        temperatureCurrent--;
                        Thread.Sleep(50);
                    }
                }
            });
        }
        
        public void SetCurrentTemp(int tempNum)
        {
            lock (lockObject)
            {
                currentTemperature = tempNum;
            }
            TemperatureChanged?.Invoke(this, tempNum);
        }


    }
}
