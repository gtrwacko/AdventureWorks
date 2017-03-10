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
    class GamePlayText
    {
        String typedText;
        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;
        SpriteFont codersCrux;
        enum lineStatus { ToBePrinted, Printing, Printed };
        List<String> printedText;
        int startingLine;
        int lastPrintedLine;
        Queue<String> textQueue;


        String parsedText;

        public GamePlayText(ContentManager contentManager)
        {
            delayInMilliseconds = 50;
            isDoneDrawing = true;

            codersCrux = contentManager.Load<SpriteFont>("CodersCrux28");
            printedText = new List<string>();
            startingLine = 0;
            lastPrintedLine = 0;
            textQueue = new Queue<string>();
            
        }

        public void Update(GameTime gameTime)
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
            }

            if(!isDoneDrawing)
            { RollOutText(gameTime); }
            
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
                if (codersCrux.MeasureString(line + word).Length() > 752)
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
            if (!isDoneDrawing)
            {
                startingLine = lastPrintedLine - 7;
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

                    if(lastPrintedLine >= printedText.Count())
                    { printedText.Add(String.Empty); }
                         printedText[lastPrintedLine] = parsedText.Substring(0, (int)typedTextLength);

                    if(isDoneDrawing)
                    {
                        lastPrintedLine++;
                        typedTextLength = 0;
                    }
                }
            } 
        }

        public void AddText(String text)
        {
            parseText(text);
        }
    }
}
