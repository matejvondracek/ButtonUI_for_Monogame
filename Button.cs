using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    public class Button : UIObject
    {
        readonly Texture2D[] textures;
        public Texture2D texture;
        MouseState mouse;
        Label label;

        bool released = false;

        public Button(Rectangle _rect, Texture2D[] _textures) : base(_rect)
        {
            textures = _textures;
            texture = textures[0];
        }

        public void AddText(string _text, SpriteFont _spriteFont, int bezels, Color color)
        {
            Rectangle labelRect = new Rectangle(rect.X + bezels, rect.Y + bezels, rect.Width - 2 * bezels, rect.Height - 2 * bezels);
            label = new Label(labelRect, _text, _spriteFont, color);         
        }

        public void AddText(Label _label)
        {
            _label.rect = rect;
            label = _label;            
        }

        #region cycle
        public override void Update(MouseState _mouse, KeyboardState keyboard)
        {
            Update(_mouse);           
        }

        public void Update(MouseState _mouse)
        {
            if (enabled)
            {
                mouse = _mouse;
                if (IsHoveringOver()) texture = textures[1];
                else texture = textures[0];
            }
            else released = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(texture, rect, Color.White);
                if (label != null)
                    label.Draw(spriteBatch);
            }           
        }
        #endregion
        #region events
        public bool IsPressed()
        {
            if (enabled)
            {
                if (released)
                {
                    released = !IsTargeted();
                    return IsTargeted();
                }
                released = !IsTargeted();
            }
            return false;
        }

        public bool IsHoveringOver()
        {
            return mouse.LeftButton != ButtonState.Pressed && rect.Contains(mouse.Position);
        }

        public bool IsTargeted()
        {
            return mouse.LeftButton == ButtonState.Pressed && rect.Contains(mouse.Position);
        }
        #endregion
    }
}

