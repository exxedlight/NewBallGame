using NewBallGame_WinForms.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBallGame_WinForms
{
    //  ідентифікатори текстури клітинки
    public enum CellTexture
    {
        Empty,  //порожня
        Ball,   //м'яч
        Wall,   //стіна
        Energy, //кулька
        Shield, //щит для м'яча
        Stop    //мітка старту м'яча
    }

    public class Cell : FieldPoint
    {
        public Cell(Size sprtSize, int X, int Y)
        {
            x = X; y = Y;
            sprite = new PictureBox();
            sprite.Location = new Point(x, y);
            sprite.Size = sprtSize;
            sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            sprite.Image = Resources.EmptyTex;
            sprite.BorderStyle = BorderStyle.None;
            sprite.Click += sprite_Click;
            mark = ' ';
        }

        //клік на клітинку
        private void sprite_Click(object sender, EventArgs e)
        {
            if (mark == '#' || mark == 'O' || mark == '@' || mark == 'X') return;   //якщо зайнята - не виконувати

            if(mark == '/') { SetTexture(CellTexture.Empty); }  //інакше - щит/порожня, переключення
            else { SetTexture(CellTexture.Shield); }
        }

        //встановити текстуру та мітку
        public void SetTexture(CellTexture c)
        {
            switch (c)
            {
                case CellTexture.Empty:
                    sprite.Image = Resources.EmptyTex;  mark = ' '; break;
                case CellTexture.Wall:
                    sprite.Image = Resources.WallTex;   mark = '#'; break;
                case CellTexture.Ball:
                    sprite.Image = Resources.BallTex;   mark = 'O'; break;
                case CellTexture.Energy:
                    sprite.Image = Resources.EnergyTex; mark = '@'; break;
                case CellTexture.Shield:
                    sprite.Image = Resources.ShieldTex; mark = '/'; break;
                case CellTexture.Stop:
                    sprite.Image = Resources.StopTex; mark = 'X'; break;
            }
        }

        //гет-сетери
        public override PictureBox getSprite() { return sprite; }
        public override int getX() { return x; }
        public override int getY() { return y; }
        public override char GetMark() { return mark; }
        public override void Show(Field f) { sprite.Visible = true; }
        public override void Hide(Field f) { sprite.Visible = false; }
        public void Del() { sprite.Dispose(); }
        public override void setPos(int X, int Y) { x = X; y = Y; }
    }
}
