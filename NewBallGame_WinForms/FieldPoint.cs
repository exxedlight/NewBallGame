using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBallGame_WinForms
{
    //абстракт. рухома точка
    public abstract class FieldPoint
    {
        //  кординати
        protected int x;
        protected int y;

        protected PictureBox ?sprite { get; set; }

        //  мітка(поточна, пам'ять мітки при прихованні)
        protected char mark;
        protected char hidenMark;

        //  МЕТОДИ
        public abstract void setPos(int X, int Y);      //  встановити у позицію
        public abstract void Hide(Field f);             //  приховати
        public abstract void Show(Field f);             //  показати
        public abstract char GetMark();                 //  повернути мітку
        public abstract PictureBox getSprite();
        public abstract int getX();
        public abstract int getY();
    }
}
