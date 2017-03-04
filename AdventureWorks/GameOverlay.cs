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

        Texture2D grey;
        Rectangle[,] slice9 = new Rectangle[3,3];
        

        public GameOverlay(ContentManager contentManager)
        {
            textBox = contentManager.Load<Texture2D>("TextField");
            textArea = new Rectangle(0, 400, 800, 200);
            mainBox = contentManager.Load<Texture2D>("MainField");
            mainArea = new Rectangle(0, 0, 800, 400);
            grey = contentManager.Load<Texture2D>("grey");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    slice9[i, j] = new Rectangle(i * 16, j * 16, 16, 16);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(textBox, textArea, Color.White);
            //spriteBatch.Draw(mainBox, mainArea, Color.White);

            //for(int i =0; i < 800; i+=16)
            //{
            //    for(int j =0; j < 400; j+=16)
            //    {
            //        int a, b;

            //        if (i==0)
            //        { a = 0; }
            //        else if(i==784)
            //        { a = 2; }
            //        else { a = 1; }

            //        if (j == 0)
            //        { b = 0; }
            //        else if (j == 384)
            //        { b = 2; }
            //        else { b = 1; }

            //        spriteBatch.Draw(grey, new Rectangle(i, j, 16, 16), slice9[a, b], Color.White);
            //    }
            //}

            spanDraw(spriteBatch, grey, 16, 8, 8, 49, 23);
            spanDraw(spriteBatch, grey, 16, 8, 384, 49, 13);


            //for (int i = 0; i < 800; i += 16)
            //{
            //    for (int j = 600-176; j <= 600-16; j += 16)
            //    {
            //        int a, b;

            //        if (i == 0)
            //        { a = 0; }
            //        else if (i == 784)
            //        { a = 2; }
            //        else { a = 1; }

            //        if (j == 600-176)
            //        { b = 0; }
            //        else if (j == 600-16)
            //        { b = 2; }
            //        else { b = 1; }

            //        spriteBatch.Draw(grey, new Rectangle(i, j, 16, 16), slice9[a, b], Color.White);
            //    }
            //}


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
    }
}
