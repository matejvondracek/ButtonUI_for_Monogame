using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    public class Slider : UIObject
    {
        readonly List<ToggleButton> buttons = new List<ToggleButton>();
        public int value, min, max, difference;
        readonly Texture2D texture;
        readonly Texture2D[] textures = new Texture2D[3];

        public Slider(Rectangle _rect, int _min, int _max, int steps, Texture2D[] _textures) : base(_rect)
        {
            min = _min;
            max = _max;
            value = (min + max) / 2;
            difference = (max - min) / steps;
            texture = _textures[2];
            textures = _textures;

            for (int i = 0; i < steps; i++)
            {
                buttons.Add(new ToggleButton(new Rectangle(rect.X + rect.Width / steps * i, rect.Y, rect.Width / steps, rect.Height), textures, false));
            }
        }

        #region cycle
        public override void Update(MouseState mouse, KeyboardState keyboard)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Update(mouse);
                if (buttons[i].IsPressed())
                {
                    value = min + difference * i;
                    foreach (ToggleButton button in buttons)
                    {
                        if (button != buttons[i])
                        {
                            button.on = false;
                        }
                    }
                }
                if (buttons[i].on)
                {
                    buttons[i].button.texture = textures[1];
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //design for whole slider
            spriteBatch.Draw(texture, rect, Color.White);

            //shows value
            foreach (ToggleButton button in buttons)
            {
                button.Draw(spriteBatch);
            }
        }

        #endregion
    }
}
