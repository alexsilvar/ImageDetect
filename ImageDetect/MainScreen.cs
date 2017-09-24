using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDetect
{
    public partial class MainScreen : Form
    {
        //Telas;
        CameraDetect _passoCamera;
        Connection _passoConexao;
        public MainScreen()
        {
            InitializeComponent();
            _passoCamera = null;
            _passoConexao = null;
        }

        private void Camera_tsbtn_Click(object sender, EventArgs e)
        {
            if (_passoCamera == null)
            {
                _passoCamera = new CameraDetect();
                _passoCamera.TopLevel = false;
                _passoCamera.AutoScroll = true;
            }
            //Limpa os já abertos
            Container_ts.ContentPanel.Controls.Clear();
            //Adiciona o form ao painel
            Container_ts.ContentPanel.Controls.Add(_passoCamera);
            //mostra o form
            _passoCamera.Show();
        }

        private void DetectRobots_tsbtn_Click(object sender, EventArgs e)
        {
            if (_passoConexao == null)
            {
                _passoConexao = new Connection();
                _passoConexao.TopLevel = false;
                _passoConexao.AutoScroll = true;
            }
            //Limpa os já abertos
            Container_ts.ContentPanel.Controls.Clear();
            //Adiciona o form ao painel
            Container_ts.ContentPanel.Controls.Add(_passoConexao);
            //mostra o form
            _passoConexao.Show();
        }
    }
}
