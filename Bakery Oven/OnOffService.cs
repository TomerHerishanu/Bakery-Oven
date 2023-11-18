using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace Bakery_Oven
{
    internal class OnOffService : BackgroundService
    {
        public event EventHandler<bool> OvenStatusChanged;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            OnOvenStatusChanged(false);
            await Task.Delay(4000);
            while (!stoppingToken.IsCancellationRequested)
            {
                OnOvenStatusChanged(true);
                await Task.Delay(1000); 
            }
        }

        private void OnOvenStatusChanged(bool isOn)
        {
            OvenStatusChanged?.Invoke(this, isOn);
        }
    }
}
