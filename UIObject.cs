using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    public class UIObject
    {
        public Rectangle rect;
        public bool enabled = true, visible = true;

        public UIObject(Rectangle _rect)
        {
            rect = _rect;
        }

        public virtual void Update(MouseState mouse, KeyboardState keyboard)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
