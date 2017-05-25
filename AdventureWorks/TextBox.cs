using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
    class TextBox
    {
        Rectangle textArea;
        Rectangle scrollArea;
        Texture2D overlayBackground;
        Texture2D arkanaLook;
        Rectangle[,] slice9 = new Rectangle[3, 3];
        GameState currentState;

        float displayedTextPosition;

        GamePlayText gameText;
        GameOverlay textBoxOverlay;
        GameOverlay scrollBarOverlay;
        VerticalScrollBar scrollBar;

        public TextBox(ContentManager contentManager, GameState currentState)
        {
            overlayBackground = contentManager.Load<Texture2D>("brown");
            arkanaLook = contentManager.Load<Texture2D>("ArkanaLook");
            textArea = GameConstants.TextArea;
            scrollArea = GameConstants.ScrollBarArea;
            textBoxOverlay = new GameOverlay(overlayBackground, textArea);
            scrollBarOverlay = new GameOverlay(overlayBackground, scrollArea);
            gameText = new GamePlayText(contentManager);
            scrollBar = new VerticalScrollBar(scrollArea,arkanaLook);
        }

        public void Update(GameTime gameTime, GameState gameState)
        {
            displayedTextPosition = gameText.Update(gameTime,textArea);
            scrollBar.Update(displayedTextPosition);

            if(gameState.GetState() == GameState.State.map)
            {
                textArea = GameConstants.TextArea;
                scrollArea = GameConstants.ScrollBarArea;
            }
            if (gameState.GetState() == GameState.State.intro)
            {
                textArea = GameConstants.TextAreaIntro;
                scrollArea = GameConstants.ScrollBarAreaIntro;
            }
        }

        public void AddText(String textAdded)
        {
            gameText.AddText(textAdded);
        }

        public void AddText(String textAdded, int delay)
        {
            gameText.AddText(textAdded, delay);
        }

        public void Dump()
        {
            gameText.Dump();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            textBoxOverlay.Draw(spriteBatch,textArea);
            scrollBarOverlay.Draw(spriteBatch,scrollArea);
            gameText.Draw(spriteBatch,textArea);
            scrollBar.Draw(spriteBatch,scrollArea);

        }
    }
}
