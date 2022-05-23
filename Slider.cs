using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    /// <summary>
    /// An UIobject for choosing int value using mouse.
    /// </summary>
    public class Slider : UIObject
    {
        readonly List<ToggleButton> buttons = new List<ToggleButton>();
        public int value, min, max, difference;
        readonly Texture2D texture;
        readonly Texture2D[] textures = new Texture2D[3];

        /// <summary>
        /// Generates Slider in given Rectangle _rect. It's values are between int _min and int _max, devided into int steps.
        /// </summary>
        /// <param name="_rect"></param>
        /// <param name="_min"></param>
        /// <param name="_max"></param>
        /// <param name="steps"></param>
        /// <param name="_textures"></param>
        public Slider(Rectangle _rect, int _min, int _max, int steps, Texture2D[] _textures) : base(_rect)
        {
            min = _min;
            max = _max;
            value = (min + max) / 2;
            difference = (max - min) / (steps - 1);
            texture = _textures[2];
            textures = _textures;
            float buttonWidth = rect.Width / steps;
            
            for (int i = 0; i < steps; i++)
            {
                buttons.Add(new ToggleButton(new Rectangle(rect.X + (int)(buttonWidth * i), rect.Y, (int)buttonWidth, rect.Height), textures, false));
            }
            buttons[steps / 2].on = true;
        }

        #region cycle
        /// <summary>
        /// Updates Slider
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="keyboard"></param>
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

        /// <summary>
        /// Draws Slider. Must be called only between spriteBatch.Begin() and spriteBatch.End().
        /// </summary>
        /// <param name="spriteBatch"></param>
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
