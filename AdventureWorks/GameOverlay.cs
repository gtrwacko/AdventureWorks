using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
    class GameOverlay
    {
        Texture2D textBox;
        Rectangle textArea;
        Texture2D mainBox;
        Rectangle mainArea;

        Texture2D overlayBackground;
        Texture2D arkanaLook;
        Rectangle[,] slice9 = new Rectangle[3,3];

        float displayedTextPosition;
        

        public GameOverlay(ContentManager contentManager)
        {
            overlayBackground = contentManager.Load<Texture2D>("brown");
            arkanaLook = contentManager.Load<Texture2D>("ArkanaLook");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    slice9[i, j] = new Rectangle(i * 16, j * 16, 16, 16);
                }
            }
        }

        public void Update(float textPosition)
        {
            displayedTextPosition = textPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Map Area
            //spanDraw(spriteBatch, overlayBackground, 16, 8, 8, 49, 23);
            //spanDraw(spriteBatch, overlayBackground, 16, GameConstants.MapArea);

            //Draw Text Area
            spanDraw(spriteBatch, overlayBackground, 16, GameConstants.TextArea);

            //draw scroll bar Area
            spanDraw(spriteBatch, overlayBackground, 16, GameConstants.ScrollBarArea);

            drawVertScrollBar(spriteBatch,GameConstants.ScrollBarArea);

        }

        public void spanDraw(SpriteBatch spriteBatch,Texture2D texture,int textureSize,int x, int y, int widthCount, int heightCount)
        {
            for (int i = x; i < x+(textureSize*widthCount); i += textureSize)
            {
                for (int j = y; j < y+(textureSize*heightCount); j += textureSize)
                {
                    int a, b;

                    if (i == x)
                    { a = 0; }
                    else if (i == (x + (textureSize * (widthCount-1))))
                    { a = 2; }
                    else { a = 1; }

                    if (j == y)
                    { b = 0; }
                    else if (j == (y + (textureSize * (heightCount-1))))
                    { b = 2; }
                    else { b = 1; }

                    spriteBatch.Draw(texture, new Rectangle(i, j, 16, 16), slice9[a, b], Color.White);
                }
            }
        }

        public void spanDraw(SpriteBatch spriteBatch, Texture2D texture, int textureSize, Rectangle rectangle)
        {
            int a, b;

            for (int i = 0; i < rectangle.Width - textureSize; i += textureSize)
            {
                if (i == 0)
                { a = 0; }
                else { a = 1; }

                for (int j = 0; j < rectangle.Height - textureSize; j += textureSize)
                {
                    if (j == 0)
                    { b = 0; }
                    else { b = 1; }

                    spriteBatch.Draw(texture, new Rectangle(i + rectangle.X, j + rectangle.Y, 16, 16), slice9[a, b], Color.White);
                }

                spriteBatch.Draw(texture, new Rectangle(i + rectangle.X, rectangle.Height - textureSize + rectangle.Y, 16, 16), slice9[a, 2], Color.White);
            }

            for (int j = 0; j < rectangle.Height - textureSize; j += textureSize)
            {
                if (j == 0)
                { b = 0; }
                else { b = 1; }

                spriteBatch.Draw(texture, new Rectangle(rectangle.Width - textureSize + rectangle.X, j + rectangle.Y, 16, 16), slice9[2, b], Color.White);
            }

            spriteBatch.Draw(texture, new Rectangle(rectangle.Width - textureSize + rectangle.X, rectangle.Height - textureSize + rectangle.Y, 16, 16), slice9[2,2], Color.White);
        }


        private void drawVertScrollBar(SpriteBatch spriteBatch, Rectangle rectangle)
        {
            int centerLine = rectangle.X + rectangle.Width / 2;

            for (int i = 6; i < rectangle.Height - 8; i++)
            { spriteBatch.Draw(arkanaLook, new Vector2(centerLine - GameConstants.VDecoScrollbarBarEnabled.Width / 2, rectangle.Y + i), GameConstants.VDecoScrollbarBarEnabled, Color.White); }

            Vector2 upArrowPosition = new Vector2(centerLine - GameConstants.VDecoScrollbarUpNormal.Width / 2, rectangle.Y + 4) ;
            Vector2 dnArrowPOsition = new Vector2(centerLine - GameConstants.VDecoScrollbarDownNormal.Width / 2, rectangle.Y + rectangle.Height - GameConstants.VDecoScrollbarDownNormal.Height - 6);
            Vector2 thumbPosition = new Vector2(centerLine - GameConstants.VDecoScrollbarBarThumbNormal.Width / 2, displayedTextPosition*(rectangle.Height-GameConstants.VDecoScrollbarUpNormal.Height*2)*.9f + 404);

            //up arrow
            spriteBatch.Draw(arkanaLook, upArrowPosition, GameConstants.VDecoScrollbarUpNormal, Color.White);

            //down arrow
            spriteBatch.Draw(arkanaLook, dnArrowPOsition, GameConstants.VDecoScrollbarDownNormal, Color.White);

            //center thing
            spriteBatch.Draw(arkanaLook, thumbPosition, GameConstants.VDecoScrollbarBarThumbNormal, Color.White);
        }


    } //End of Class

} // End of Namespace
