using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    /// <summary>
    /// List of all UIObjects. Used for repeating action with all of it's components.
    /// </summary>
    public class UIGroup
    {
        public readonly List<UIObject> objects = new List<UIObject>();
        
        public UIGroup()
        {

        }

        /// <summary>
        /// Adds another object to the group. 
        /// </summary>
        /// <param name="obj"></param>
        public void Add(UIObject obj)
        {
            objects.Add(obj);
        }

        /// <summary>
        /// Adds another object to the group with the ability to find it later. Same tag shouldn't be used twice.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tag"></param>
        public void Add(UIObject obj, string tag)
        {
            obj.tag = tag;
            objects.Add(obj);
        }

        /// <summary>
        /// Finds object with given type and tag and returns it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tag"></param>
        /// <returns></returns>
        public T GetObject<T>(string tag) where T: UIObject
        {
            return objects.OfType<T>().FirstOrDefault(obj => obj.tag == tag);
        }

        #region cycle
        /// <summary>
        /// Updates all members of the group.
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="keyboard"></param>
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            foreach (UIObject _object in objects)
            {
                if (_object.enabled) _object.Update(mouse, keyboard);
            }
        }

        /// <summary>
        /// Draws all members of the group. Must be called only between spriteBatch.Begin() and spriteBatch.End().
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (UIObject _object in objects)
            {
                if (_object.visible) _object.Draw(spriteBatch);
            }
        }
        #endregion

        #region properties

        /// <summary>
        /// Changes visible property of all of it's members to given value.
        /// </summary>
        /// <param name="value"></param>
        public void ChangeVisible(bool value)
        {
            foreach (UIObject _object in objects)
            {
                _object.visible = value;
            }
        }

        /// <summary>
        /// Changes enabled property of all of it's members to given value.
        /// </summary>
        /// <param name="value"></param>
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
