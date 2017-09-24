using System;
using System.Windows.Forms;


using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
using System.IO;
using System.Threading;


using DirectShowLib;
using System.ComponentModel;
using System.Collections.Generic;

namespace ImageDetect
{
    public partial class Connection : Form
    {
        BackgroundWorker bg;
        public Connection()
        {
            InitializeComponent();
            bg = new BackgroundWorker();
            bg.DoWork += new DoWorkEventHandler(bg_DoWork);
            bg.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
        }
        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach(Bluetooth_Device dev in (List<Bluetooth_Device>)e.Result) {
                listBox1.Items.Add(dev);
            }
            
        }
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Bluetooth_Device> devices = new List<Bluetooth_Device>();
            BluetoothClient bc = new BluetoothClient();
            BluetoothDeviceInfo[] array = bc.DiscoverDevices();
            int count = array.Length;
            for (int i = 0; i < count; i++)
            {
                Bluetooth_Device device = new Bluetooth_Device(array[i]);
                devices.Add(device);
            }
            e.Result = devices;
        }

        private void Find_btn_Click(object sender, EventArgs e)
        {
            if (!bg.IsBusy)
            {
                listBox1.Items.Clear();
                bg.RunWorkerAsync();
            }
            
    }
    }
}
