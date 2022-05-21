using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    public class UIGroup
    {
        public readonly List<UIObject> objects = new List<UIObject>();
        
        public UIGroup()
        {

        }

        public void Add(UIObject _object)
        {
            objects.Add(_object);
        }

        #region cycle
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            foreach (UIObject _object in objects)
            {
                if (_object.enabled) _object.Update(mouse, keyboard);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (UIObject _object in objects)
            {
                if (_object.visible) _object.Draw(spriteBatch);
            }
        }
        #endregion

        #region properties
        public void ChangeVisible(bool value)
        {
            foreach (UIObject _object in objects)
            {
                _object.visible = value;
            }
        }

        public void ChangeEnabled(bool value)
        {
            foreach (UIObject _object in objects)
            {
                _object.enabled = value;
            }
        }
        #endregion
    }
}
