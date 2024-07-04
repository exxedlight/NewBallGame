using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NewBallGame_WinForms
{
    //класс "Ігрове Поле"
    public class Field : AbstractGameField
    {
        //  КОНСТРУКТОР (розміри компоненту(панель), розміри поля у клітинках)
        public Field(int cW, int cH, int Width, int Heigth)
        {
            componentW = cW; componentH = cH;   //взяти розмір панелі
            width = Width; height = Heigth;     //взіти розмір у клітинках

            stepX = componentW / width;         //вирхувати кроки розміщення клітинок
            stepY = componentH / height;

            Buffer = new List<Cell>();          //виділити пам'ять під поле
            for (int i = 0; i < height; i++)    //заповнити поле порожніми клітинками (пікчер боксами)
            {
                for (int j = 0; j < width; j++)
                {
                    Buffer.Add(new Cell(new Size(stepX, stepY), stepX*j, stepY*i));
                }
            }
        }

        //  МЕТОДИ

        //  отримати/встановити символ за координатами (х, у) --- (0,0) = верхній лівий кут
        public override Cell GetCoord(int x, int y) { return Buffer[width * y + x]; }
        public override void SetCoord(int x, int y, CellTexture symbol) { Buffer[width * y + x].SetTexture(symbol); }

        //  Зміна режиму, гетери
        public override void BallMode() { isBall = !isBall; }
        public override bool IsBall() { return isBall; }

        //  Управління рахунком
        public override int GetScorePoints() { return scorePoints; } // отримати кількість кільок
        public override void Scored() { scorePoints--; }             // -1 від кількості кульок на полі

        //  створити поле з рамкою зі стін
        public override void MakeField(Panel gameBox, int scorepoints, ProgressBar bar)
        {
            bar.Value = 0;
            bar.Maximum = height * width;
            for (int i = 0; i < height; i++)        //  створити стіни по периметру
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                    {
                         SetCoord(j, i, CellTexture.Wall);  //  якщо периметр - ставити текстуру стіни
                    }
                    else SetCoord(j, i, CellTexture.Empty); //   інакше - порожню
                    gameBox.Controls.Add(GetCoord(j, i).getSprite());
                    bar.PerformStep();
                }
            }
            SetCoord(3, height / 2, CellTexture.Stop);      //  встановити текстуру позиції м'яча
            RandomScorePoints(scorepoints);
        }

        //  змінити розмір поля
        public override void Resize(Panel gameBox, int W, int H, int scorepoints, ProgressBar bar)
        {
            foreach(Cell a in Buffer) { a.Del(); }
            Buffer.Clear();

            componentW = gameBox.Width; componentH = gameBox.Height;
            width = W; height = H;

            stepX = componentW / width;
            stepY = componentH / height;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Buffer.Add(new Cell(new Size(stepX, stepY), stepX * j, stepY * i));
                }
            }
            MakeField(gameBox, scorepoints, bar);
        }

        //  випадково розташувати кульки (кількість)
        public override void RandomScorePoints(int number)
        {
            Random rnd = new Random();
            int count = number;

            Buffer = Buffer.Select(x => x.GetMark() == '@' || x.GetMark() == '/' ? new Cell(x.getSprite().Size, x.getX(), x.getY()) : x).ToList();     //  видалити кульки

            while (count > 0)   //генерувати кульки
            {
                int x = rnd.Next(4, width - 1);
                int y = rnd.Next(1, height - 1);
                if (GetCoord(x, y).GetMark() == ' ')            //  у порожні клітинки
                {
                    SetCoord(x, y, CellTexture.Energy);
                    count--;
                }
            }
            scorePoints = number;
        }

        //  Зберегти гру
        public void SaveGame(string filename)
        {
            string game = "";
            foreach(Cell c in Buffer)
            {
                game += c.GetMark();
            }
            StreamWriter fs = new StreamWriter(filename);
            fs.WriteLine(width);
            fs.WriteLine(height);
            fs.WriteLine(scorePoints);
            fs.WriteLine(game);
            fs.Close();
        }

        //  Завантажити гру
        public void LoadGame(string filename, Panel panel, ProgressBar bar)
        {
            int W, H, S;
            string game = "";
            StreamReader fs = new StreamReader(filename);
            W = Convert.ToInt32(fs.ReadLine());
            H = Convert.ToInt32(fs.ReadLine());
            S = Convert.ToInt32(fs.ReadLine());
            game = fs.ReadLine();
            fs.Close();

            

            width = W; height = H;
            componentW = panel.Width; componentH = panel.Height;
            stepX = componentW / width; stepY = componentH / height;
            scorePoints = S;

            bar.Value = 0;
            bar.Maximum = width * height;

            foreach (Cell a in Buffer) { a.Del(); }
            Buffer.Clear();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Buffer.Add(new Cell(new Size(stepX, stepY), stepX * j, stepY * i));
                }
            }

            int strindex = 0;
            for (int i = 0; i < height; i++)        //  створити стіни по периметру
            {
                for (int j = 0; j < width; j++, strindex++)
                {
                    switch (game[strindex])
                    {
                        case '#':
                            Buffer[strindex].SetTexture(CellTexture.Wall);
                            SetCoord(j, i, CellTexture.Wall);
                            break;
                        case ' ':
                        case 'O':
                        case 'X':
                            Buffer[strindex].SetTexture(CellTexture.Empty);
                            SetCoord(j, i, CellTexture.Empty);
                            break;
                        case '@':
                            Buffer[strindex].SetTexture(CellTexture.Energy);
                            SetCoord(j, i, CellTexture.Energy);
                            break;
                        case '/':
                            Buffer[strindex].SetTexture(CellTexture.Shield);
                            SetCoord(j, i, CellTexture.Shield);
                            break;
                    }
                    panel.Controls.Add(GetCoord(j, i).getSprite());
                    bar.PerformStep();
                }
            }
            SetCoord(3, height / 2, CellTexture.Stop);      //  встановити текстуру позиції м'яча
        }
    }
}
