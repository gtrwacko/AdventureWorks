using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
    internal static class MapViewer
    {

        internal static int centerCellX = 50;
        internal static int centerCellY = 50;

        internal static void Update(int i, int j)
        {
            centerCellX += i;
            centerCellY += j;
        }

        internal static void Draw(SpriteBatch spriteBatch, MainCharacter character, TileMap currentMap, SpriteFont font)
        {
            currentMap.DrawMap(spriteBatch, centerCellX, centerCellY);
            DrawMapIndex(spriteBatch, currentMap, font);
            character.Draw(spriteBatch, centerCellX, centerCellY);
        }

        internal static void DrawMapIndex(SpriteBatch spriteBatch, TileMap currentMap, SpriteFont font)
        {
            Vector2 position;
            for (int i = 0; i < currentMap.gridSize.X; i += 1)
            {
                for (int j = 0; j < currentMap.gridSize.Y; j += 1)
                {
                    int x = (i - centerCellX) * currentMap.tileSize.X + GameConstants.MapArea.Center.X - currentMap.tileSize.X / 2;
                    int y = (j - centerCellY) * currentMap.tileSize.Y + GameConstants.MapArea.Center.Y - currentMap.tileSize.Y / 2;
                    position = new Vector2(x, y);
                    spriteBatch.DrawString(font, i.ToString() + "," + j.ToString(), position, Color.White, rotation: 0, origin: new Vector2(), scale: 1, effects: SpriteEffects.None, layerDepth: .9f);
                }
            }
        }

        internal static void MoveCharacter(AdventureWorks.MainCharacter.Direction direction, MainCharacter character, TileMap currentMap)
        {
            Point previousPosition = character.GetPosistion();
            int mapBoundryX = GameConstants.MapArea.Width / currentMap.tileSize.X / 2;
            int mapBoundryY = GameConstants.MapArea.Height / currentMap.tileSize.Y / 2;

            character.Update(direction);

            if (!currentMap.IsPassable(character.GetPosistion()))
            {
                character.SetPosition(previousPosition);
            } 

            if (character.GetPosistion().Y >= mapBoundryY && character.GetPosistion().Y <= currentMap.gridSize.Y - mapBoundryY)
            {
                centerCellY = character.GetPosistion().Y;

            }
            if (character.GetPosistion().X >= mapBoundryX && character.GetPosistion().X <= currentMap.gridSize.X - mapBoundryX)
            {
                centerCellX = character.GetPosistion().X;

            }
        }
    }    

}
