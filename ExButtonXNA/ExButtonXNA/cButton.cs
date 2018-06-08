using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExButtonXNA
{
    class cButton : DrawableGameComponent
    {
        Texture2D texture;
        Vector2 Position;
        Rectangle rectangle;

        Color colour = new Color(255, 255, 255, 255);

        public Vector2 size = new Vector2(150, 50);

        public cButton(Game game,Texture2D texture)
            :base(game)
        {

            this.texture = texture;

        }

        bool down;
        public bool Isclicked;
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)Position.X, (int)Position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            if (mouseRectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = false;
                if (down) colour.A += 3; else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) Isclicked = true;
            }
            else if (colour.A < 255)
            {
                colour.A += 3;
                Isclicked = false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, rectangle, colour);
        }
    }
}
