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
        Rectangle areaRectangle;
        Texture2D tileTexture;
        Rectangle[,] slice9 = new Rectangle[3,3];       

        public GameOverlay(Texture2D tileTexture, Rectangle areaRectangle)
        {
            this.tileTexture = tileTexture;
            this.areaRectangle = areaRectangle;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    slice9[i, j] = new Rectangle(i * 16, j * 16, 16, 16);
                }
            }
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Rectangle areaRectangle)
        {
            //Draw Text Area
            spanDraw(spriteBatch, tileTexture, tileTexture.Width/3, areaRectangle);

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

    } //End of Class

} // End of Namespace
