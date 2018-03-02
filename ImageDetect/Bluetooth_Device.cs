using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net.Sockets;
namespace ImageDetect
{
    class Bluetooth_Device
    {
        private string NomeDoDispositivo { get; set; }
        private uint Sap { get; set; }
        private BluetoothDeviceInfo dispositivo;

        public BluetoothDeviceInfo Dispositivo {
            get {
                return dispositivo;
            }
        }

        public Bluetooth_Device(BluetoothDeviceInfo dispositivo_info)
        {
            this.NomeDoDispositivo = dispositivo_info.DeviceName;
            this.Sap = dispositivo_info.DeviceAddress.Sap;
            this.dispositivo = dispositivo_info;
        }
        public override string ToString()
        {
            return this.NomeDoDispositivo;
        }
    }
}
