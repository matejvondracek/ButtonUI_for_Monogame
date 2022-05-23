using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    /// <summary>
    /// An UIObject in which user can type text. Supports only the most basic keys.
    /// </summary>
    public class TextBox : UIObject
    {
        protected Button button;
        readonly protected SpriteFont font;
        bool selected = false, released = false;
        public string text = "";
        public int bezels;
        readonly public Color textColor;

        public TextBox(Rectangle _rect, Texture2D[] _textures, SpriteFont _font, int _bezels, Color _color) : base(_rect)
        {
            button = new Button(_rect, _textures);
            button.AddText(text, _font, _bezels, _color);
            bezels = _bezels;
            font = _font;
            textColor = _color;
        }

        #region cycle
        public override void Update(MouseState mouse, KeyboardState keyboard)
        {
            button.Update(mouse);
            if (button.IsPressed())
            {
                selected = true;
            }
            else if ((mouse.LeftButton == ButtonState.Pressed) && (!button.IsTargeted()))
            {
                selected = false;
            }

            if (selected)
            {
                HandleInput(keyboard);
            }

            button.AddText(text, font, bezels, textColor);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            button.Draw(spriteBatch);
        }
        #endregion

        protected virtual void HandleInput(KeyboardState keyboard)
        {
            if ((keyboard.GetPressedKeyCount() > 0) && released)
            {
                released = false;
                List<Keys> keys = new List<Keys>(keyboard.GetPressedKeys());
                if (keys.Contains(Keys.Back) && text.Length > 0) text = text.Remove(text.Length - 1, 1);
                else
                {
                    for (int i = 0; i <= keys.Count - 1; i++)
                    {
                        Keys key = keys[i];
                        //capital letters
                        if ((key >= Keys.A) && (key <= Keys.Z))
                        {
                            //if (!keys.Contains(Keys.LeftShift) && !keys.Contains(Keys.RightShift)) key -= 32;
                            text += key;
                        }
                        if ((key >= Keys.NumPad0) && (key <= Keys.NumPad9))
                        {
                            text += Convert.ToString(((int)key) - 96);
                        }

                        switch (key)
                        {
                            case Keys.Enter:
                                selected = false;
                                break;
                            case Keys.OemPeriod:
                                text += '.';
                                break;
                            case Keys.OemComma:
                                text += ',';
                                break;
                            case Keys.OemMinus:
                                text += '-';
                                break;
                            case Keys.OemPlus:
                                text += '+';
                                break;
                            case Keys.OemSemicolon:
                                text += ';';
                                break;
                        }
                    }
                }
            }
            else if (keyboard.GetPressedKeyCount() == 0)
            {
                released = true;
            }
        }
    }
}