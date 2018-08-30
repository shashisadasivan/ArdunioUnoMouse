using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

namespace DEL_Iot1
{
    class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=Looneystar-IoTHub-01.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=bE3Feo/56b4eeZ1EnLcml2oeXueY1jO4/H0yVDtBS10=";

        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadLine();
        }

        private static async Task AddDeviceAsync()
        {
            string deviceId = "myTestDevice1";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
            }

            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);// OB6YoFwlaT6UVSUx0AaQ2zo2OmESDcJJ0mtFz0NmD+A=
        }
    }
}
