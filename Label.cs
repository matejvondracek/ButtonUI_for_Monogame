using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonUI
{
    public class Label : UIObject
    {
        public string text = "";
        public SpriteFont font;
        public Color color;

        Vector2 textPosition, textSize;
        readonly float textScale; 

        public Label(Rectangle _rect, string _text, SpriteFont _font, Color _color) : base(_rect)
        {
            font = _font;
            color = _color;
            text = _text;
            rect = _rect;

            textSize = font.MeasureString(text);
            float xScale = (rect.Width / textSize.X);
            float yScale = (rect.Height / textSize.Y);
            textScale = Math.Min(xScale, yScale);

            int textWidth = (int)Math.Round(textSize.X * textScale);
            int textHeight = (int)Math.Round(textSize.Y * textScale);
            textPosition.X = ((rect.Width - textWidth) / 2) + rect.X;
            textPosition.Y = ((rect.Height - textHeight) / 2) + rect.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, textPosition, color, 0.0f, new Vector2(), textScale, new SpriteEffects(), 0.0f);
        }
    }
}
