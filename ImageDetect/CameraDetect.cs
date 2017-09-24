using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Cvb;
using DirectShowLib;


namespace ImageDetect
{
    public partial class CameraDetect : Form
    {
        //Camera
        Video_Device[] WebCams;
        private VideoCapture _capture = null;//Captura do vídeo
        private bool _captureInProgress;//Está capturando?

        //pego e imagem a ser tratada
        private Mat _retrive;
        Image<Bgr, Byte> _frame;
        //Imagem Hsv
        Image<Hsv, Byte> _hsvFrame;

        //Atualmente sendo procurado no HSV
        private Range _show;

        //Cores a serem buscadas
        private Range _RangeBola;
        private Range _RangeCampo;
        private Range _RangeTime;
        private Range _RangeGoleiro;
        private Range _RangeZagueiro;
        private Range _RangeAtacante;




        //para pegar a cor
        private Point _clickPoint;
        private bool _pickColor;


        //para cortar a Regiao de Interesse "ROI"
        private bool _cutField;
        private Rectangle _rect;
        private Point _rectStartPoint;

        //Para teste de localização
        private Cross2DF _centroide;

        public CameraDetect()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            fill_cameras();
            Setup_Camera();

            _retrive = new Mat();
            _rect = Rectangle.Empty;
            _clickPoint = Point.Empty;
            _rectStartPoint = Point.Empty;
            _pickColor = false;
            _cutField = false;
            _show = new Range(new Hsv());

            _centroide = new Cross2DF();
        }
        //Preenche a combobox com os dispositivos conectados ao sistema
        private void fill_cameras()
        {
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Video_Device[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new Video_Device(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID); //fill web cam array
                Cameras_cb.Items.Add(WebCams[i].ToString());
            }
            if (Cameras_cb.Items.Count > 0)
            {
                Cameras_cb.SelectedIndex = 0; //Set the selected device the default
                Capture_btn.Enabled = true; //Enable the start
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                //Pegando um frame
                _capture.Retrieve(_retrive);

                //Redimensionando para o tamanho a ser mostrado se estiver mostrando né
                if (Mostrar_cbox.Checked)
                {
                    CvInvoke.Resize(_retrive, _retrive, new Size(480, 270));
                }

                //Convertendo para imagem, para algumas operações
                _frame = _retrive.ToImage<Bgr, Byte>();
                //Aplicando o gaussian para "interligar" a imagem
                _frame._SmoothGaussian(3, 3, 1, 1);
                //_frame._Dilate(1);
                //_frame._Erode(1);
                //_frame._GammaCorrect(1);
                CvInvoke.MedianBlur(_frame, _frame, 3);
                try
                {
                    //Detectando a imagem apos a cor ter sido selecionada
                    Image<Bgr, Byte> temp = _frame.Copy();
                    if (_rect != null)
                    {
                        if (_rect.Width > 0 && _rect.Height > 0 && !_cutField)
                        {
                            temp.ROI = _rect;
                        }
                        _frame.Draw(_rect, new Bgr(Color.Red), 3);
                    }
                    _hsvFrame = temp.Convert<Hsv, Byte>();
                    _hsvFrame._SmoothGaussian(5, 5, 0.1, 0.1);

                    if (Mostrar_cbox.Checked)
                    {
                        //Pegando a imagem dentro do range determinado
                        Image<Gray, Byte> InRangeFrame = things_to_show();
                        formatedImageBox.Image = InRangeFrame;
                        captureImageBox.Image = _frame;
                        #region Desenhando os elementos
                        Image<Bgr, Byte> teste = _frame.CopyBlank();
                        //Bola

                        try
                        {
                            Point ball = detect_ball();
                            teste.Draw(_centroide, new Bgr(Color.Red), 1);
                        }
                        catch { }
                        //Robos
                        try
                        {
                            Robo[] robos = detect_time();
                            Color[] cores = { Color.Magenta, Color.Green, Color.Yellow };
                            if (robos != null)
                            {
                                int i = 0;
                                foreach (Robo robo in robos)
                                {
                                    teste.Draw(robo.Orientation, new Bgr(cores[i++]), 4);
                                }
                                //teste.Draw(robos[0].Orientation, new Bgr(Color.Magenta), 4);
                            }
                            testesImageBox.Image = teste;
                        }
                        catch { /*MessageBox.Show("Erro ao Desenhar retas");*/ }
                        #endregion

                    }
                    else
                    {
                        formatedImageBox.Image = null;
                        captureImageBox.Image = null;
                    }


                }
                catch (Exception ex)
                {
                    //   captureImageBox.Image = _frame;
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //MEXENDO NISSO AGORA, JOIN DE IMAGENS
        private Image<Gray, Byte> things_to_show(string target = null)
        {
            Image<Gray, Byte> inRangeFrame = null;
            string selected;
            if (target == null)
            {
                selected = get_text();
            }
            else
            {
                selected = target;
            }
            switch (selected)
            {
                case "Bola":
                    if (_RangeBola != null) { inRangeFrame = (_hsvFrame.InRange(_RangeBola.Lowerrange, _RangeBola.Upperrange)); }
                    break;
                case "Contorno Campo":
                    if (_RangeCampo != null) { inRangeFrame = (_hsvFrame.InRange(_RangeCampo.Lowerrange, _RangeCampo.Upperrange)); }
                    break;
                case "Time":
                    if (_RangeTime != null) { inRangeFrame = (_hsvFrame.InRange(_RangeTime.Lowerrange, _RangeTime.Upperrange)); }
                    break;
                case "Goleiro":
                    if (_RangeGoleiro != null) { inRangeFrame = (_hsvFrame.InRange(_RangeGoleiro.Lowerrange, _RangeGoleiro.Upperrange)); }
                    break;
                case "Zagueiro":
                    if (_RangeZagueiro != null) { inRangeFrame = (_hsvFrame.InRange(_RangeZagueiro.Lowerrange, _RangeZagueiro.Upperrange)); }
                    break;
                case "Atacante":
                    if (_RangeAtacante != null) { inRangeFrame = (_hsvFrame.InRange(_RangeAtacante.Lowerrange, _RangeAtacante.Upperrange)); }
                    break;
                default:
                    break;
            }
            return inRangeFrame;
        }
        #region Form e Camera
        /*Operação necessária para interagir entre a thread Form e Camera*/
        private delegate string get_text_delegate();
        private string get_text()
        {
            string s;
            if (InvokeRequired)
            {
                s = (string)Invoke(new get_text_delegate(get_text));
            }
            else
            {
                s = Finding_cb.Text;
            }
            return s;
        }



        private void Setup_Camera()
        {
            try
            {
                if (_capture != null)
                {
                    _capture.Stop();
                }
                _capture = new VideoCapture(WebCams[Cameras_cb.SelectedIndex].Device_ID);
                //Pra ficar igual espelho
                //_capture.FlipHorizontal = !_capture.FlipHorizontal;
                //Se colocar 1920x1080 fica low fps acima ele seta em 1920x1080 então, bora
                _capture.SetCaptureProperty(CapProp.FrameWidth, 1920);
                _capture.SetCaptureProperty(CapProp.FrameHeight, 1080);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ReleaseData()
        {
            if (_capture != null)
            {
                _capture.Dispose();
            }
        }

        #endregion

        #region Converte HSV para BGR
        const float FLOAT_TO_BYTE = 255.0f;
        const float BYTE_TO_FLOAT = 1.0f / FLOAT_TO_BYTE;

        private Bgr Convert(Hsv hsv)
        {
            int H = (int)hsv.Hue;
            int S = (int)hsv.Satuation;
            int V = (int)hsv.Value;
            // HSV to RGB color conversion in OpenCV

            int bH = H; // H component
            int bS = S; // S component
            int bV = V; // V component
            float fH, fS, fV;
            float fR, fG, fB;

            // Convert from 8-bit integers to floats
            fH = (float)bH * BYTE_TO_FLOAT;
            fS = (float)bS * BYTE_TO_FLOAT;
            fV = (float)bV * BYTE_TO_FLOAT;

            // Convert from HSV to RGB, using float ranges 0.0 to 1.0
            int iI;
            float fI, fF, p, q, t;

            if (bS == 0)
            {
                // achromatic (grey)
                fR = fG = fB = fV;
            }
            else
            {
                // If Hue == 1.0, then wrap it around the circle to 0.0
                if (fH >= 1.0f)
                    fH = 0.0f;

                fH *= (float)6.0; // sector 0 to 5
                fI = (float)Math.Floor(fH); // integer part of h (0,1,2,3,4,5 or 6)
                iI = (int)fH; // " " " "
                fF = fH - fI; // factorial part of h (0 to 1)

                p = fV * (1.0f - fS);
                q = fV * (1.0f - fS * fF);
                t = fV * (1.0f - fS * (1.0f - fF));

                switch (iI)
                {
                    case 0:
                        fR = fV;
                        fG = t;
                        fB = p;
                        break;

                    case 1:
                        fR = q;
                        fG = fV;
                        fB = p;
                        break;

                    case 2:
                        fR = p;
                        fG = fV;
                        fB = t;
                        break;

                    case 3:
                        fR = p;
                        fG = q;
                        fB = fV;
                        break;

                    case 4:
                        fR = t;
                        fG = p;
                        fB = fV;
                        break;

                    default: // case 5 (or 6):
                        fR = fV;
                        fG = p;
                        fB = q;
                        break;
                }
            }

            // Convert from floats to 8-bit integers
            int bR = (int)(fR * FLOAT_TO_BYTE);
            int bG = (int)(fG * FLOAT_TO_BYTE);
            int bB = (int)(fB * FLOAT_TO_BYTE);

            // Clip the values to make sure it fits within the 8bits.
            if (bR > 255)
                bR = 255;
            if (bR < 0)
                bR = 0;
            if (bG > 255)
                bG = 255;
            if (bG < 0)
                bG = 0;
            if (bB > 255)
                bB = 255;
            if (bB < 0)
                bB = 0;

            // Set the RGB cvScalar with G B R, you can use this values as you want too..
            return new Bgr(bB, bG, bR); // R component
        }



        #endregion

        #region EVENTOS

        private void Capture_btn_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    Capture_btn.Text = "Capturar";
                    _capture.Stop();
                    Cameras_cb.Enabled = true;
                }
                else
                {
                    //start the capture
                    Capture_btn.Text = "Parar";
                    _capture.Start();
                    Cameras_cb.Enabled = false;
                }
                _captureInProgress = !_captureInProgress;
            }
        }


        private void captureImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (_pickColor)
            {
                _clickPoint = new Point(e.X, e.Y);
                PegaCor_btn.Enabled = true;
                CortarCampo_btn.Enabled = true;
                _pickColor = false;
                Rectangle Rect = new Rectangle(_clickPoint.X - 5, _clickPoint.Y - 5, 3, 3);
                if (Rect.X < 0)
                {
                    Rect.X = 0;
                }
                if (Rect.Y < 0)
                {
                    Rect.Y = 0;
                }
                Hsv _targetColor;
                using (Image<Bgr, Byte> TouchRegion = _frame.GetSubRect(Rect))
                {
                    using (Image<Hsv, Byte> TouchRegionHsv = TouchRegion.Convert<Hsv, byte>())
                    {
                        //pega a media dos valores
                        _targetColor = TouchRegionHsv.GetAverage();
                        //pega o intervalo de +-delta da cor
                        _show = new Range(_targetColor);
                    }
                }
                switch (Finding_cb.Text)
                {
                    case "Bola":
                        _RangeBola = new Range(_targetColor);
                        break;
                    case "Contorno Campo":
                        _RangeCampo = new Range(_targetColor);
                        break;
                    case "Time":
                        _RangeTime = new Range(_targetColor);
                        break;
                    case "Goleiro":
                        _RangeGoleiro = new Range(_targetColor);
                        break;
                    case "Zagueiro":
                        _RangeZagueiro = new Range(_targetColor);
                        break;
                    case "Atacante":
                        _RangeAtacante = new Range(_targetColor);
                        break;
                    default:
                        break;
                }
            }
        }



        //Selecionar os limites que serão considerados na análise de imagem
        private void CortarCampo_btn_Click(object sender, EventArgs e)
        {
            if (_cutField)
            {
                CortarCampo_btn.Text = "Cortar Campo";
                //_cutField = false;
            }
            else
            {
                CortarCampo_btn.Text = "Cancelar Corte";
                //_cutField = true;
            }
            _cutField = !_cutField;
            PegaCor_btn.Enabled = !PegaCor_btn.Enabled;
        }

        private void PegaCor_btn_Click(object sender, EventArgs e)
        {
            PegaCor_btn.Enabled = false;
            CortarCampo_btn.Enabled = false;
            _pickColor = true;
        }



        private void captureImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_cutField)
            {
                _rectStartPoint = e.Location;
            }
        }

        private void captureImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (_cutField)
            {
                Point tempEndPoint = e.Location;
                //Para desenhar o retangulo é necessario setar o inicio (x,y esquerdo superior) e o tamanho dele
                _rect.Location = new Point(Math.Min(_rectStartPoint.X, tempEndPoint.X), Math.Min(_rectStartPoint.Y, tempEndPoint.Y));
                _rect.Size = new Size(Math.Abs(_rectStartPoint.X - tempEndPoint.X), Math.Abs(_rectStartPoint.Y - tempEndPoint.Y));

                if (!_captureInProgress)
                {
                    try
                    {
                        Image<Bgr, Byte> temp = _frame.Copy();
                        temp.Draw(_rect, new Bgr(Color.Red), 3);
                        captureImageBox.Image = temp;
                    }
                    catch { }
                }
            }
        }

        private void captureImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_cutField)
            {
                _cutField = false;
                CortarCampo_btn.Text = "Cortar Campo";
                PegaCor_btn.Enabled = !PegaCor_btn.Enabled;
            }
        }

        private void ResetCorte_btn_Click(object sender, EventArgs e)
        {
            _rect = Rectangle.Empty;
        }
        #endregion

        #region Interpretações

        public Point detect_ball()
        {
            Image<Gray, Byte> bola = things_to_show("Bola");

            CvBlobDetector blobDetector = new CvBlobDetector();
            //USANDO BLOBS
            CvBlobs blobBall = new CvBlobs();
            blobDetector.Detect(bola, blobBall);
            //blobBall.FilterByArea(100, int.MaxValue);
            List<CvBlob> bolaBlob = blobBall.Values.ToList();
            int posicao = filterSize(bolaBlob);
            Point centro = new Point((int)bolaBlob[posicao].Centroid.X, (int)bolaBlob[posicao].Centroid.Y);
            PointF p = new PointF(centro.X, centro.Y);

            _centroide = new Cross2DF(p, 30, 30);

            return centro;
        }
        //Seleciona o maior tamanho dos blobs, elimina ruídos
        private int filterSize(List<CvBlob> blobs)
        {
            int area = blobs[0].Area;
            int loc = 0;
            for (int i = 1; i < blobs.Count; i++)
            {
                if (blobs[i].Area > area)
                {
                    area = blobs[i].Area;
                    loc = i;
                }
            }
            return loc;
        }


        //Retorna uma array de 3 posições
        //As posições são: 0- goleiro, 1-atacante, 2-zagueiro
        public Robo[] detect_time()
        {
            Robo[] array = null;
            try
            {
                Image<Gray, Byte> timeImg = things_to_show("Time");
                CvBlobDetector blobDetector = new CvBlobDetector();
                //USANDO BLOBS
                CvBlobs blobsTime = new CvBlobs();
                //Detecta os blobs relativos ao time
                blobDetector.Detect(timeImg, blobsTime);
                //Filtra os blobs, excluindo os com área muito pequena
                int minSizeBlob = 10;
                blobsTime.FilterByArea(minSizeBlob, int.MaxValue);
                //Se não há um blob desejado, sai da função
                if (blobsTime.Count == 0) { return null; }
                //Cria a imagem bgr com os blobs 


                //Os pontos dos times
                List<CvBlob> bTime = blobsTime.Values.ToList();
                List<PointF> pontosTime = new List<PointF>();
                foreach (CvBlob blo in bTime)
                {
                    pontosTime.Add(new PointF(blo.Centroid.X, blo.Centroid.Y));
                }
                if (pontosTime.Count != 0)
                {
                    Robo goleiro = novoRobo(pontosTime, blobDetector, "Goleiro");
                    Robo atacante = novoRobo(pontosTime, blobDetector, "Atacante");
                    Robo zagueiro = novoRobo(pontosTime, blobDetector, "Zagueiro");
                    array = new Robo[] { goleiro, atacante, zagueiro };
                }
                Image<Bgr, Byte> teste = _frame.CopyBlank();
                //DESENHAR BLOBS teste = blobDetector.DrawBlobs(timeImg, blobsTime, CvBlobDetector.BlobRenderType.Default, 1);
                if (array != null)
                {
                    teste.Draw(array[0].Orientation, new Bgr(Color.Magenta), 4);
                }
                testesImageBox.Image = teste;
                blobsImageBox.Image = blobDetector.DrawBlobs(timeImg, blobsTime, CvBlobDetector.BlobRenderType.Default, 1);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return array;
        }

        private Robo novoRobo(List<PointF> pontosTime, CvBlobDetector blobDetector, string nomeRobo)
        {
            //seleciona o jogador pela string
            Image<Gray, Byte> jogadorImg = things_to_show(nomeRobo);
            if (jogadorImg == null) { return null; }
            CvBlobs blobsJogador = new CvBlobs();
            //Detectar o posicionamento do jogador
            blobDetector.Detect(jogadorImg, blobsJogador);
            //Passa para uma lista os blobs
            List<CvBlob> bJogador = blobsJogador.Values.ToList();
            //Cria um segmento usando o ponto do Jogador e o do time mais próximo
            int posicao = filterSize(bJogador);
            Point jogador = new Point((int)bJogador[posicao].Centroid.X, (int)bJogador[posicao].Centroid.Y);
            PointF near = nearest(pontosTime, bJogador[posicao].Centroid);
            //P1=Jogador=frente;P2=Time=Tras
            LineSegment2D jogaRobo = new LineSegment2D(jogador, new Point((int)near.X, (int)near.Y));
            //Cria o novo robô
            return new Robo(jogaRobo, nomeRobo);
        }

        //Detectando a menor distancia entre os pontos do time e do jogador
        private PointF nearest(List<PointF> pontosTime, PointF jogador)
        {
            int selected = 0;
            double d = double.MaxValue;
            double test;
            for (int i = 0; i < pontosTime.Count; i++)
            {
                test = Math.Sqrt(Math.Pow((pontosTime[i].X - jogador.X), 2) + Math.Pow((pontosTime[i].Y - jogador.Y), 2));
                if (test < d)
                {
                    d = test;
                    selected = i;
                }
            }
            return pontosTime[selected];
        }


        #endregion


        private void Cameras_cb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _capture.Dispose();
                Setup_Camera();
            }
            catch
            {
                MessageBox.Show("ERRO");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string texto = Finding_cb.Text;
                if (texto.Equals("Bola"))
                {
                    detect_ball();
                }
                else if (texto.Equals("Time"))
                {
                    detect_time();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void fps_Click(object sender, EventArgs e)
        {
            fps.Text = "FPS: " + _capture.GetCaptureProperty(CapProp.FrameCount);
        }
    }
}
