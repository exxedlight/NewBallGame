using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBallGame_WinForms
{
    public abstract class AbstractGameField
    {
        //      ВЛАСТИВОСТІ
        public int width { get; protected set; }            //  ширина поля
        public int height { get; protected set; }           //  висота поля

        protected int componentW;                           //  ширина компонента в якому розміщено поле
        protected int componentH;                           //  висота компонента в якому розміщено поле

        protected int stepX;                                //  крок клітинки поля по Х
        protected int stepY;                                //  крок клітинки поля по У

        protected int scorePoints = 0;                      //  кількість кульок на полі
        protected bool isBall = false;                      //  режим гравця (фолс) / м'яча (тру)

        public List<Cell> Buffer { get; protected set; }    //поле з клітинок, масив

        //      МЕТОДИ
        public abstract Cell GetCoord(int x, int y);                                //  отримати клітину з координати
        public abstract void SetCoord(int x, int y, CellTexture symbol);            //  встановити у клітину (х, у) мітку
        public abstract void MakeField(Panel gameBox, int scorepoints, ProgressBar bar);             //  створити поле у вказаній панелі з кількістю енергетичних кульок
        public abstract void Resize(Panel gameBox, int W, int H, int scorepoints, ProgressBar bar);  //  змінити розмір поля, приймає панель, нові розміри та кількість кульок
        public abstract int GetScorePoints();                                       //  отримати кількість кільок
        public abstract void Scored();                                              //  -1 від кількості кульок на полі
        public abstract void RandomScorePoints(int number);                         //  видалити всі кульки та розташувати по новому
        public abstract void BallMode();                                            //  переключити режим гравець / м'яч
        public abstract bool IsBall();                                              //  отримати стан гри - гравець / м'яч
    }
}
