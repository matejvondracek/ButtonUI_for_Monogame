using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    /// <summary>
    /// Parent class, has only the most necessary atributes and methods.
    /// </summary>
    public class UIObject
    {
        public Rectangle rect;
        public bool enabled = true, visible = true;
        public string tag = "";

        public UIObject(Rectangle _rect)
        {
            rect = _rect;
        }

        /// <summary>
        /// Updates UIObject, called in Update() method of Game1.
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="keyboard"></param>
        public virtual void Update(MouseState mouse, KeyboardState keyboard)
        {

        }

        /// <summary>
        /// Draws UIObject in it's rectangle. Must be called only between spriteBatch.Begin() and spriteBatch.End().
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
