using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    /// <summary>
    /// Basically an ON/OFF switch. 
    /// </summary>
    public class ToggleButton : UIObject
    {
        public readonly Button button;
        public bool on;
        public string onText = "", offText = "";
        public SpriteFont spriteFont;
        public int textBezel;
        public Color textColor;

        bool isPressed = false;

        public ToggleButton(Rectangle _rect, Texture2D[] _textures, bool defaultState) : base(_rect)
        {
            button = new Button(_rect, _textures);
            on = defaultState;
        }

        public void DefineText(string on, string off, SpriteFont font, int bezel, Color color)
        {
            onText = on;
            offText = off;
            spriteFont = font;
            textBezel = bezel;
            textColor = color;
        }

        #region cycle
        /// <summary>
        /// Updates ToggleButton. KeybordState is not needed, this method is used in foreach cycles with another UIObjects.
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="keyboard"></param>
        public override void Update(MouseState mouse, KeyboardState keyboard)
        {
            Update(mouse);
        }

        /// <summary>
        /// Updates ToggleButton.
        /// </summary>
        /// <param name="mouse"></param>
        public void Update(MouseState mouse)
        {
            button.Update(mouse);
            if (button.IsPressed())
            {
                on = !on;
                isPressed = true;
            }
            else isPressed = false;
                
            if (spriteFont != null)
            {
                string text;
                if (on) text = onText;
                else text = offText;
                button.AddText(text, spriteFont, textBezel, textColor);
            }
        }

        /// <summary>
        /// Draws ToggleButton. Must be called only between spriteBatch.Begin() and spriteBatch.End().
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            button.Draw(spriteBatch);
        }
        #endregion

        #region events
        public bool IsPressed()
        {
            return isPressed;
        }
        #endregion
    }
}
