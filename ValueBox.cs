using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    public class ValueBox : UIObject
    {
        readonly Button displayButton, upButton, downButton;
        public int value, minValue, maxValue, bezel;
        readonly SpriteFont font;
        readonly Texture2D[] textures;
        Color textColor;

        public ValueBox(Rectangle _rect, float ratio, int _bezel, int min, int max, SpriteFont spriteFont, Color _color, Texture2D[] _textures) 
            : base (_rect)
        {
            //setting vars
            minValue = min;
            maxValue = max;
            bezel = _bezel;
            value = (min + max) / 2;
            font = spriteFont;
            textures = _textures;
            textColor = _color;

            //placing buttons
            int arrowWidth = (int)(rect.Width * ratio);
            int displayWidth = (int)(rect.Width * (1 - 2 * ratio));
            downButton = new Button(new Rectangle(rect.X, rect.Y, arrowWidth, rect.Height), textures);
            upButton = new Button(new Rectangle(rect.X + arrowWidth + displayWidth, rect.Y, arrowWidth, rect.Height), textures);
            displayButton = new Button(new Rectangle(rect.X + arrowWidth, rect.Y, displayWidth, rect.Height), textures);
            upButton.AddText(">", font, bezel, textColor);
            downButton.AddText("<", font, bezel, textColor);
            displayButton.AddText(value.ToString(), font, bezel, textColor);
        }

        #region cycle
        public override void Update(MouseState mouse, KeyboardState keyboard)
        {
            Update(mouse);
        }

        public void Update(MouseState mouse)
        {
            upButton.Update(mouse);
            downButton.Update(mouse);
            if (upButton.IsPressed())
            {
                if (value + 1 <= maxValue) value += 1;
            }
            else if (downButton.IsPressed())
            {
                if (value - 1 >= minValue) value -= 1;
            }
            displayButton.AddText(value.ToString(), font, bezel, textColor);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            displayButton.Draw(spriteBatch);
            upButton.Draw(spriteBatch);
            downButton.Draw(spriteBatch);
        }
        #endregion

        public void SetValue(int newValue)
        {
            if ((newValue <= maxValue) && (newValue >= minValue))
            {
                value = newValue;
            }
        }

        public int GetValue()
        {
            return value;
        }
    }
}
