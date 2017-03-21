﻿using System;
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
    public class GamePlayText
    {
        String typedText;
        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;
        bool isDumping;
        SpriteFont codersCrux;
        enum lineStatus { ToBePrinted, Printing, Printed };
        List<String> printedText;
        int startingLine;
        Queue<String> textQueue;
        private float displayedTextPosition;

        public float TextPosition()
        {
            return displayedTextPosition;
        }


        String parsedText;

        public GamePlayText(ContentManager contentManager)
        {
            delayInMilliseconds = 75;
            isDoneDrawing = true;

            codersCrux = contentManager.Load<SpriteFont>("CodersCrux28");
            printedText = new List<string>();
            startingLine = 0;
            textQueue = new Queue<string>();
            
        }

        public float Update(GameTime gameTime)
        {
            //RollOutText(gameTime);
            typedText = "";
            KeyboardState kbState = Keyboard.GetState();

            if(kbState.IsKeyDown(Keys.Down))
            {
                startingLine++;
            }
            if (kbState.IsKeyDown(Keys.Up))
            {
                startingLine--;
            }

            if (startingLine > printedText.Count-8)
            {
                startingLine = printedText.Count - 8;
            }
            if (startingLine < 0)
            {
                startingLine = 0;
            }
            
            if(isDoneDrawing && textQueue.Count>0)
            {
                isDoneDrawing = false;
                parsedText = textQueue.Dequeue();
                printedText.Add(String.Empty);
            }

            if(!isDoneDrawing)
            { RollOutText(gameTime); }

            if (printedText.Count <=8)
            { displayedTextPosition = 1.0f; } 
            else if (startingLine == 0)
            { displayedTextPosition = 0.0f; } else
            { displayedTextPosition = ((float)startingLine)/(printedText.Count -8); }

            return displayedTextPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            String display = String.Empty;
            for(int i = 0; i < 8; i++)
            {
                if(i+startingLine < printedText.Count)
                {
                    display = display + printedText[i + startingLine];
                }

            }
            spriteBatch.DrawString(codersCrux, display, new Vector2(24, 400), Color.White);
        
        }

        private void parseText(String text)
        {
            String line = String.Empty;
            String[] wordArray = text.Split(' ');

            foreach (String word in wordArray)
            {
                if (codersCrux.MeasureString(line + word).Length() > GameConstants.TextArea.Width)
                {
                    textQueue.Enqueue(line + '\n');
                    line = String.Empty;
                }

                line = line + word + ' ';
            }

            textQueue.Enqueue(line + '\n');
        }

        private void RollOutText(GameTime gameTime)
        {
            if (isDumping && (!isDoneDrawing || textQueue.Count > 0))
            {

                printedText[printedText.Count-1] = parsedText;
                parsedText = String.Empty;

                for (int i = 0; i < 3; i++)
                {
                    if (i < textQueue.Count)
                    { printedText.Add(textQueue.Dequeue()); }
                }
                isDumping = false;
                isDoneDrawing = true;
                startingLine = printedText.Count - 8;
                if (startingLine < 0)
                { startingLine = 0; }
            }


            if (!isDoneDrawing)
            {
                startingLine = printedText.Count - 8;
                if (startingLine<0)
                { startingLine = 0; }

                if (delayInMilliseconds == 0)
                {
                    typedText = parsedText;
                    isDoneDrawing = true;
                }
                else if (typedTextLength < parsedText.Length)
                {
                    typedTextLength = typedTextLength + gameTime.ElapsedGameTime.TotalMilliseconds / delayInMilliseconds;

                    if (typedTextLength >= parsedText.Length)
                    {
                        typedTextLength = parsedText.Length;
                        isDoneDrawing = true;
                    }

                         printedText[printedText.Count-1] = parsedText.Substring(0, (int)typedTextLength);

                    if(isDoneDrawing)
                    {
                        typedTextLength = 0;
                        parsedText = String.Empty;

                    }
                }
            } 
        }

        public void AddText(String text)
        {
            parseText(text);
        }

        public void Dump()
        {
            if(textQueue.Count > 0 || !isDoneDrawing)
            { isDumping = true; }
        }
    }
}
