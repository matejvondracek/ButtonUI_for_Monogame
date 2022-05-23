using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    /// <summary>
    /// Static class for drawing simple shapes. Before using any other method Load() must be called.
    /// </summary>
    public static class DrawShape
    {
        private static Texture2D WhitePixel;

        /// <summary>
        /// Enables DrawShape class to generate textures and other methods to be called.
        /// </summary>
        /// <param name="graphicsDevice"></param>
        public static void Load(GraphicsDevice graphicsDevice)
        {
            WhitePixel = new Texture2D(graphicsDevice, 1, 1);
            WhitePixel.SetData(new[] { Color.White});
        }

        /// <summary>
        /// Draws a line from Vector2 start to Vector2 end. Can be called only between spriteBatch.Begin() and spriteBatch.End().
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        public static void Line(SpriteBatch spriteBatch, Vector2 start, Vector2 end, int width, Color color)
        {
            Vector2 vector = end - start;
            int length = (int)vector.Length();
            vector.Normalize();
            float rotation = (float)Math.Acos(vector.X);

            if (end.Y < start.Y) rotation = -rotation;
          
            Rectangle lineRect = new Rectangle((int)start.X, (int)start.Y, length, width);
            spriteBatch.Draw(WhitePixel, lineRect, new Rectangle(), color, rotation, new Vector2(), new SpriteEffects(), 0.0f);
        }

        /// <summary>
        /// Draws a simple rectangle. Must be called only between spriteBatch.Begin() and spriteBatch.End().
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="rectangle"></param>
        /// <param name="color"></param>
        public static void Rectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color)
        {
            spriteBatch.Draw(WhitePixel, rectangle, color);
        }

        /// <summary>
        /// Draws a rectangle with outline. Must be called only between spriteBatch.Begin() and spriteBatch.End().
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="rectangle"></param>
        /// <param name="baseColor"></param>
        /// <param name="outlineWidth"></param>
        /// <param name="outlineColor"></param>
        public static void Rectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color baseColor, int outlineWidth, Color outlineColor)
        {
            spriteBatch.Draw(WhitePixel, rectangle, outlineColor);
            Rectangle baseRect = new Rectangle(rectangle.X + outlineWidth, rectangle.Y + outlineWidth, rectangle.Width - 2 * outlineWidth, rectangle.Height - 2 * outlineWidth);
            spriteBatch.Draw(WhitePixel, baseRect, baseColor);
        }
    }
}
