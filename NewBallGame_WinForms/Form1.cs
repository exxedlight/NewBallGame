using Timer = System.Windows.Forms.Timer;

namespace NewBallGame_WinForms
{
    public partial class Form1 : Form
    {
        private Field field;        //  поле
        private Ball ball;          //  м'€ч
        private Timer ballTimer;    //  таймер руху м'€ча

        public Form1()  //  конструктор
        {
            InitializeComponent();
            creationProgressBar.Visible = false;
            field = new Field(GameFieldPanel.Width, GameFieldPanel.Height,  //  створити поле
                Convert.ToInt32(widthTextBox.Text),
                Convert.ToInt32(heightTextBox.Text));
            ball = new Ball(field);

            ballTimer = new Timer();            //  створити таймер
            ballTimer.Interval = ball.speed;    //  встановити ≥нервал таймеру швидк≥стю м'€ча
            ballTimer.Tick += (sender, e) =>    //  встановити функц≥ю у таймер
            {
                if (!field.IsBall())            //  €кщо не режим м'€ча
                {
                    ball.Hide(field);           //  сховати м'€ч
                    ballTimer.Stop();           //  зупинити таймер
                    return;
                }
                ballTimer.Interval = ball.speed;    //  ≥накше - оновити ≥нтервал таймеру
                ball.Move(field, 0);                //  рухати м'€ч

                if (field.GetScorePoints() == 0)    //  €кщо немаЇ енергетичних кульок - перемога
                {
                    switchModeButton.PerformClick();    //  натиснути на зм≥ну режиму
                    MessageBox.Show("¬≥таЇмо! ¬и з≥брали вс≥ кульки! √ру буде перезапущено ;)");
                    applySizeButton.PerformClick();     //  натиснути на старт
                }
            };
        }

        //  кнопка старт
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
                MessageBox.Show("ѕерев≥рте введенн€. ” пол€х мають бути ц≥л≥ числа.");
                return;
            }

            if (W < 10 || W > 70 ||
                H < 10 || H > 70 ||
                E > W * H / 2 ||
                E < 1)
            {
                MessageBox.Show("Ќекоректний розм≥р.\r\n" +
                    "–озм≥р маЇ бути в≥д 10х10 до 70х70.\r\n" +
                    "Eнерг≥њ маЇ бути не б≥льше за половину площ≥ пол€, але не менше 1!");
                return;
            }
            creationProgressBar.Visible = true;
            field.Resize(GameFieldPanel, Convert.ToInt32(widthTextBox.Text), Convert.ToInt32(heightTextBox.Text), Convert.ToInt32(energyTextBox.Text), creationProgressBar);
            ball = new Ball(field);
            saveGameButton.Enabled = true;
            switchModeButton.Enabled = true;
            creationProgressBar.Visible = false;
        }

        //  кнопка зм≥ни режиму
        private void switchModeButton_Click(object sender, EventArgs e)
        {
            field.BallMode();   //  зм≥нити режим
            if (field.IsBall()) //  €кщо тепер це тру
            {
                switchModeButton.Text = "–едагувати";   //  режим м'€ча активовано, зм≥нити напис

                ball.Show(field);                       //  показати м'€ч
                ballTimer.Start();                      //  почати рух
            }
            else                                        // ≥накше - режим м'€ча вимкнуто
            {
                switchModeButton.Text = "«апустити м'€ч";
                ball.Hide(field);                       //  сховати м'€ч
                field.SetCoord(3, field.height / 2, CellTexture.Stop);  //  повернути м≥тку старта м'€ча на поле
            }
        }

        private void saveGameButton_Click(object sender, EventArgs e)
        {
            if (saveFd.ShowDialog() == DialogResult.OK)
            {
                field.SaveGame(saveFd.FileName);
                MessageBox.Show("√ру збережено у " + saveFd.FileName);
            }
        }

        private void loadGameButton_Click(object sender, EventArgs e)
        {
            if (loadFd.ShowDialog() == DialogResult.OK)
            {
                creationProgressBar.Visible = true;
                field.LoadGame(loadFd.FileName, GameFieldPanel, creationProgressBar);
                MessageBox.Show("ѕопередню гру завантажено");
                creationProgressBar.Visible = false;
                saveGameButton.Enabled = true;
                switchModeButton.Enabled = true;
            }
        }
    }
}