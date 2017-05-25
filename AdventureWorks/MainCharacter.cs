using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace AdventureWorks
{
    class MainCharacter
    {
        Texture2D dungeonCrawlSheet;
        Texture2D characterSheet;
        public enum Direction { North , South, East, West };
        Rectangle source;
        Rectangle sourceNorth;
        Rectangle sourceSouth;
        Rectangle sourceWest;
        Rectangle sourceEast;
        Point position = new Point(50, 50);
        Direction currentDirection;

        public MainCharacter(ContentManager contentManager)
        {
            dungeonCrawlSheet = contentManager.Load<Texture2D>("DungeonCrawl_ProjectUtumnoTileset");
            characterSheet = contentManager.Load<Texture2D>("RPGCharacterSprites32x32");

            source = new Rectangle(4 * 32, 2 * 32, 32, 32);
            sourceNorth =    new Rectangle(5 * 32, 2 * 32, 32, 32);
            sourceSouth =  new Rectangle(1 * 32, 2 * 32, 32, 32);
            sourceWest =  new Rectangle(9 * 32, 2 * 32, 32, 32);
            sourceEast = new Rectangle(9 * 32, 2 * 32, 32, 32);

            currentDirection = Direction.South;
        }

        public void Update(Direction direction)
        {

            if (currentDirection == direction)
            {
                switch (direction)
                {
                    case Direction.North:
                        position.Y--;
                        break;
                    case Direction.South:
                        position.Y++;
                        break;
                    case Direction.West:
                        position.X--;
                        break;
                    case Direction.East:
                        position.X++;
                        break;
                }

                Game1.newGameText.Add("You moved " + direction.ToString());
                Game1.gameTextDelay = 1;
            }
            else
            {
                currentDirection = direction;
                Game1.newGameText.Add("You turned to the " + direction.ToString());
                Game1.gameTextDelay = 1;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, int centerCellX, int centerCellY)
        {
            int x;
            int y;

            x = GameConstants.MapArea.Center.X + (position.X - centerCellX) * source.Width;
            y = GameConstants.MapArea.Center.Y + (position.Y - centerCellY) * source.Height;

            Vector2 characterPosition = new Vector2(x,y);
            

            switch (currentDirection)
            {
                case Direction.North:
                    spriteBatch.Draw(characterSheet, position: characterPosition, sourceRectangle: sourceNorth, color: Color.White, origin: new Vector2(source.Width / 2, source.Height / 2));
                    break;
                case Direction.South:
                    spriteBatch.Draw(characterSheet, position: characterPosition, sourceRectangle: sourceSouth, color: Color.White, origin: new Vector2(source.Width / 2, source.Height / 2));
                    break;
                case Direction.West:
                    spriteBatch.Draw(characterSheet, position: characterPosition, sourceRectangle: sourceWest, color: Color.White, origin: new Vector2(source.Width / 2, source.Height / 2), effects: SpriteEffects.FlipHorizontally);
                    break;
                case Direction.East:
                    spriteBatch.Draw(characterSheet, position: characterPosition, sourceRectangle: sourceEast, color: Color.White, origin: new Vector2(source.Width / 2, source.Height / 2));
                    break;
            }
        }

        public Point GetPosistion()
        { return position; }

        public void SetPosition(Point position)
        {
            this.position = position;
        }

        public Point Action()
        {
            Point actionPosition = position;

            switch (currentDirection)
            {
                case Direction.North:
                    actionPosition.Y = position.Y - 1;
                    break;
                case Direction.South:
                    actionPosition.Y = position.Y + 1;
                    break;
                case Direction.West:
                    actionPosition.X = position.X - 1;
                    break;
                case Direction.East:
                    actionPosition.X = position.X + 1;
                    break;
            }

            return actionPosition;
        }
    }
}
