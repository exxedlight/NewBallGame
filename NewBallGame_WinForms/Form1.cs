using Timer = System.Windows.Forms.Timer;

namespace NewBallGame_WinForms
{
    public partial class Form1 : Form
    {
        private Field field;        //  ����
        private Ball ball;          //  �'��
        private Timer ballTimer;    //  ������ ���� �'���

        public Form1()  //  �����������
        {
            InitializeComponent();
            creationProgressBar.Visible = false;
            field = new Field(GameFieldPanel.Width, GameFieldPanel.Height,  //  �������� ����
                Convert.ToInt32(widthTextBox.Text),
                Convert.ToInt32(heightTextBox.Text));
            ball = new Ball(field);

            ballTimer = new Timer();            //  �������� ������
            ballTimer.Interval = ball.speed;    //  ���������� ������� ������� �������� �'���
            ballTimer.Tick += (sender, e) =>    //  ���������� ������� � ������
            {
                if (!field.IsBall())            //  ���� �� ����� �'���
                {
                    ball.Hide(field);           //  ������� �'��
                    ballTimer.Stop();           //  �������� ������
                    return;
                }
                ballTimer.Interval = ball.speed;    //  ������ - ������� �������� �������
                ball.Move(field, 0);                //  ������ �'��

                if (field.GetScorePoints() == 0)    //  ���� ���� ������������ ������ - ��������
                {
                    switchModeButton.PerformClick();    //  ��������� �� ���� ������
                    MessageBox.Show("³����! �� ������ �� ������! ��� ���� ������������ ;)");
                    applySizeButton.PerformClick();     //  ��������� �� �����
                }
            };
        }

        //  ������ �����
        private void applySizeButton_Click(object sender, EventArgs e)
        {
            int W, H, E;

            try
            {
                W = Convert.ToInt32(widthTextBox.Text);
                H = Convert.ToInt32(heightTextBox.Text);
                E = Convert.ToInt32(energyTextBox.Text);
            }
            catch (FormatException exc)
            {
                MessageBox.Show("�������� ��������. � ����� ����� ���� ��� �����.");
                return;
            }

            if (W < 10 || W > 70 ||
                H < 10 || H > 70 ||
                E > W * H / 2 ||
                E < 1)
            {
                MessageBox.Show("����������� �����.\r\n" +
                    "����� �� ���� �� 10�10 �� 70�70.\r\n" +
                    "E���㳿 �� ���� �� ����� �� �������� ����� ����, ��� �� ����� 1!");
                return;
            }
            creationProgressBar.Visible = true;
            field.Resize(GameFieldPanel, Convert.ToInt32(widthTextBox.Text), Convert.ToInt32(heightTextBox.Text), Convert.ToInt32(energyTextBox.Text), creationProgressBar);
            ball = new Ball(field);
            saveGameButton.Enabled = true;
            switchModeButton.Enabled = true;
            creationProgressBar.Visible = false;
        }

        //  ������ ���� ������
        private void switchModeButton_Click(object sender, EventArgs e)
        {
            field.BallMode();   //  ������ �����
            if (field.IsBall()) //  ���� ����� �� ���
            {
                switchModeButton.Text = "����������";   //  ����� �'��� ����������, ������ �����

                ball.Show(field);                       //  �������� �'��
                ballTimer.Start();                      //  ������ ���
            }
            else                                        // ������ - ����� �'��� ��������
            {
                switchModeButton.Text = "��������� �'��";
                ball.Hide(field);                       //  ������� �'��
                field.SetCoord(3, field.height / 2, CellTexture.Stop);  //  ��������� ���� ������ �'��� �� ����
            }
        }

        private void saveGameButton_Click(object sender, EventArgs e)
        {
            if (saveFd.ShowDialog() == DialogResult.OK)
            {
                field.SaveGame(saveFd.FileName);
                MessageBox.Show("��� ��������� � " + saveFd.FileName);
            }
        }

        private void loadGameButton_Click(object sender, EventArgs e)
        {
            if (loadFd.ShowDialog() == DialogResult.OK)
            {
                creationProgressBar.Visible = true;
                field.LoadGame(loadFd.FileName, GameFieldPanel, creationProgressBar);
                MessageBox.Show("��������� ��� �����������");
                creationProgressBar.Visible = false;
                saveGameButton.Enabled = true;
                switchModeButton.Enabled = true;
            }
        }
    }
}