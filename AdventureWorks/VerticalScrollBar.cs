using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AdventureWorks
{
    class VerticalScrollBar
    {
        Rectangle rectangle;
        Texture2D texture;
        float displayedTextPosition;
        float depth = .11f;

        public VerticalScrollBar(Rectangle rectangle, Texture2D texture)
        {
            this.rectangle = rectangle;
            this.texture = texture;
        }

        public void Update(float displayedTextPosition)
        {
            this.displayedTextPosition = displayedTextPosition;
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle rectangle)
        {
            int centerLine = rectangle.X + rectangle.Width / 2;

            for (int i = 6; i < rectangle.Height - 8; i++)
            { spriteBatch.Draw(texture, position: new Vector2(centerLine - GameConstants.VDecoScrollbarBarEnabled.Width / 2, rectangle.Y + i), sourceRectangle: GameConstants.VDecoScrollbarBarEnabled, color: Color.White, layerDepth: depth + .01f); }

            Vector2 upArrowPosition = new Vector2(centerLine - GameConstants.VDecoScrollbarUpNormal.Width / 2, rectangle.Y + 4);
            Vector2 dnArrowPOsition = new Vector2(centerLine - GameConstants.VDecoScrollbarDownNormal.Width / 2, rectangle.Y + rectangle.Height - GameConstants.VDecoScrollbarDownNormal.Height - 6);

            int thumbX = centerLine - GameConstants.VDecoScrollbarBarThumbNormal.Width / 2;
            int thumbTop = rectangle.Y + GameConstants.VDecoScrollbarUpNormal.Height + 4;
            int thumbHeight = rectangle.Height - (2 * GameConstants.VDecoScrollbarUpNormal.Height) - 18;

            Vector2 thumbPosition = new Vector2(thumbX, displayedTextPosition * thumbHeight + thumbTop);

            //up arrow
            spriteBatch.Draw(texture, position: upArrowPosition, sourceRectangle: GameConstants.VDecoScrollbarUpNormal, color: Color.White, layerDepth: depth);

            //down arrow
            spriteBatch.Draw(texture, position: dnArrowPOsition, sourceRectangle: GameConstants.VDecoScrollbarDownNormal, color: Color.White, layerDepth: depth);

            //center thing
            spriteBatch.Draw(texture, position: thumbPosition, sourceRectangle: GameConstants.VDecoScrollbarBarThumbNormal, color: Color.White, layerDepth: depth);
        }
    }
}
