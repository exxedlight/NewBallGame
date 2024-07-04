using NewBallGame_WinForms.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;

namespace NewBallGame_WinForms
{
    //класс м'яч, нащадок абстрактного класу "рухома точка"
    class Ball : FieldPoint
    {
        private int MWay = 0;           // поточний напрямок руху м'яча     //  0 - right, 1 - up, 2 - left, 3 - down 
        private DateTime from, to;      //  часові проміжки синхронізації руху
        public int speed { get; private set; }         //  швидкість м'яча

        public Ball(Field f)
        {
            sprite = new PictureBox();
            x = 3;
            y = f.height / 2;
            sprite.Location = new Point(x, y);
            sprite.Size = new Size(f.Buffer[0].getSprite().Width, f.Buffer[0].getSprite().Height);
            sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            sprite.Image = Resources.BallTex;
            mark = 'O';
            speed = 50;
            
        }

        //  встановити у позицію
        public override void setPos(int X, int Y)
        {
            x = X; y = Y;
        }

        //  сховати / показати
        public override void Hide(Field f)
        {
            sprite.Image = Resources.EmptyTex;
            f.SetCoord(x, y, CellTexture.Empty);
            MWay = 0;
        }
        public override void Show(Field f)
        {
            x = 3;
            y = f.height / 2;
            MWay = 0;
            f.SetCoord(x, y, CellTexture.Ball);
            sprite.Image = Resources.BallTex;
        }
        public override int getX() { return x; }
        public override int getY() { return y; }
        public override char GetMark() { return mark; }
        public override PictureBox getSprite() { return sprite; }

        //  рухати
        public void Move(Field f, int way)
        {
            
            int prevx, prevy;       //  поточка координата
            prevx = x; prevy = y;

            to = DateTime.Now;      //  замір часу
            if ((to - from).TotalMilliseconds < speed)
            {
                //  якщо менше за час оновлення - 
                //  не виконувати рух
                return;
            }

            from = DateTime.Now;    //змінити час відліку руху

            f.SetCoord(x, y, CellTexture.Empty);  //очистити поточну клітинку

            switch (MWay)           //отримати нову координату в залежності від напряму руху
            {
                case 0: x++; break;
                case 2: x--; break;
                case 1: y--; break;
                case 3: y++; break;
            }

            switch (f.GetCoord(x, y).GetMark())   //  у новій клітині, в залежності від вмісту
            {
                case '#':               //якщо це стіна - повернутися у минулу позицію, рухатися у протилежний бік
                    x = prevx; y = prevy;
                    MWay = (MWay + 2) % 4;
                    break;
                case '/':               //якщо ігрова стінка - повернути на 90 градусів вліво (завжди)
                    x = prevx; y = prevy;
                    MWay = (MWay + 1) % 4;
                    break;
                case '@':               //якщо це кулька - пройти по ній та -1 від кількості кульок
                    f.Scored();
                    break;
            }

            f.SetCoord(x, y, CellTexture.Ball);     //встановити мітку м'яча у нову позицію
            
        }
    }
}
