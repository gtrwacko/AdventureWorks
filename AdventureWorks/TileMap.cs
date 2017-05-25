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
    class TileMap
    {
        Tile[,] tileGrid;
        public GameObjectList gameObjectList;
        bool[,] passableGrid;

        int gridSizeX;
        int gridSizeY;
        int tileWidth;
        int tileHeight;

        Dictionary<Point, Point> actionLinkDictionary;

        public Point gridSize
        { get {return new Point(gridSizeX, gridSizeY); } }

        public Point tileSize
        { get { return new Point(tileWidth, tileHeight); } }

        public TileMap(int mapSizeX, int mapSizeY, int tileHeight, int tileWidth)
        {
            //Creates Empty Map
            this.gridSizeX = mapSizeX;
            this.gridSizeY = mapSizeY;
            this.tileHeight = tileHeight;
            this.tileWidth = tileWidth;
            tileGrid = new Tile[mapSizeX, mapSizeY];
            gameObjectList = new GameObjectList();
            passableGrid = new bool[mapSizeX, mapSizeY];
        }

        public TileMap(Tile baseTile, int girdSizeX, int mapSizeY, Dictionary<Point,Point> actionLinkDictionary)
        {
            //Creates homogenous map
            this.gridSizeX = girdSizeX;
            this.gridSizeY = mapSizeY;
            tileGrid = new Tile[girdSizeX, mapSizeY];
            passableGrid = new bool[gridSizeX, mapSizeY];
            gameObjectList = new GameObjectList();
            tileWidth = baseTile.sourceRectangle.Width;
            tileHeight = baseTile.sourceRectangle.Height;

            this.actionLinkDictionary = actionLinkDictionary;

            for (int i = 0; i < girdSizeX; i++)
            {
                for (int j = 0; j < mapSizeY; j++)
                {
                    tileGrid[i, j] = baseTile;
                    passableGrid[i, j] = true;

                }
            }

        }

        public void AddTile(Tile newTile, int i, int j)
        {
            tileGrid[i, j] = newTile;
            passableGrid[i, j] = newTile.passable;
        }

        public void AddTile(Tile newTile, int i, int j, bool updatedValue)
        {
            tileGrid[i, j] = newTile;
            passableGrid[i, j] = updatedValue;
        }

        public void AddGameObject(GameObject newObject, int i, int j)
        {

        }

        public bool IsPassable(Point position)
        {
            if (position.X < 0 || position.X >= this.gridSizeX || position.Y < 0 || position.Y >= this.gridSizeY)
            { return false; } else
            {
                if(!passableGrid[position.X, position.Y])
                {
                    Game1.newGameText.Add("The way is blocked");
                    Game1.gameTextDelay = 5;
                    return false;
                } else if(!gameObjectList.CheckIfPassable(position))
                {
                    Game1.newGameText.Add("The way is blocked");
                    Game1.gameTextDelay = 5;
                    return false;
                } else
                {
                    return true;
                }
            }

            
                
                    
        }

        public void DrawMap(SpriteBatch spriteBatch, int centerCellX, int centerCellY)
        {
            Vector2 position;
            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    if (tileGrid[i, j] != null)
                    {
                        //Tile tile = map[i, j];
                        int x = (i - centerCellX) * tileWidth + GameConstants.MapArea.Center.X - tileWidth / 2;
                        int y = (j - centerCellY) * tileHeight + GameConstants.MapArea.Center.Y - tileHeight / 2;
                        position = new Vector2(x, y);

                        //spriteBatch.Draw(tile.texture, position, sourceRectangle: tile.sourceRectangle, color: tile.color, origin: tile.origin);
                        tileGrid[i, j].Draw(spriteBatch, position);
                    }
                }
            }

            gameObjectList.Draw(spriteBatch, new Point(centerCellX, centerCellY), tileWidth, tileHeight);

         }


        public List<Actions> Action(Point actionPoint)
        {
			return gameObjectList.GetPossibleActions(actionPoint);
        }

		public string Action(int objectID, Actions.possibleActions actionToPerform)
		{
			return gameObjectList.Action(objectID, actionToPerform);
		}
    }
}
