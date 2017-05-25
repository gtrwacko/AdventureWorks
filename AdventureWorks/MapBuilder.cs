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
    static class MapBuilder
    {
        public static TileMap BuildBaseMap(ContentManager contentManager)
        {
            TileMap baseMap;

            Texture2D tileArtBatch1;
            Texture2D tileArtBatch2;
            Texture2D tileArtBatch3;
            Texture2D tileArtBatch4;
            Texture2D tileArtBatch5;

            Texture2D doorOpen;
            Texture2D doorClosed;

            int mapSizeX = 100;
            int mapSizeY = 100;

            Tile grassTile;
            Tile grassTile2;
            Tile wallTile;
            Tile openDoorTile;
			Tile closedDoorTile;

            Dictionary<Point, Point> actionLinkDictionary = new Dictionary<Point, Point>();

            tileArtBatch1 = contentManager.Load<Texture2D>(@"tile-art-batch-1");
            tileArtBatch2 = contentManager.Load<Texture2D>(@"tile-art-batch-2");
            tileArtBatch3 = contentManager.Load<Texture2D>(@"tile-art-batch-3");
            tileArtBatch4 = contentManager.Load<Texture2D>(@"tile-art-batch-4");
            tileArtBatch5 = contentManager.Load<Texture2D>(@"tile-art-batch-5");
            doorOpen = contentManager.Load<Texture2D>(@"dc-dngn/dngn_open_door");
            doorClosed = contentManager.Load<Texture2D>(@"dc-dngn/dngn_closed_door");

            grassTile = new Tile(tileArtBatch1, new Rectangle(0, 576, 32, 32), new Vector2(0, 0), Color.White, .60f);
            grassTile2 = new Tile(tileArtBatch1, new Rectangle(0, 640, 32, 32), new Vector2(0, 0), Color.White, .60f);
            wallTile = new Tile(tileArtBatch1, new Rectangle(0, 7 * 32, 32, 32), new Vector2(0, 0), Color.White, .55f, false);
            openDoorTile = new Tile(doorOpen, new Rectangle(0, 0, 32, 32), new Vector2(0, 0), Color.White, .50f);
			closedDoorTile = new Tile(doorClosed, new Rectangle(0, 0, 32, 32), new Vector2(0, 0), Color.White, .50f);

			actionLinkDictionary.Add(new Point(46, 48), new Point(45, 48));
            actionLinkDictionary.Add(new Point(45, 48), new Point(46, 48));

            baseMap = new TileMap(grassTile, mapSizeX, mapSizeY, actionLinkDictionary);
            baseMap.AddTile(grassTile2, 46, 48);
            baseMap.AddTile(grassTile2, 47, 48);
            baseMap.AddTile(grassTile2, 48, 48);
            baseMap.AddTile(grassTile2, 49, 48);
            baseMap.AddTile(grassTile2, 46, 49);
            baseMap.AddTile(grassTile2, 47, 49);
            baseMap.AddTile(grassTile2, 48, 49);
            baseMap.AddTile(grassTile2, 49, 49);
            baseMap.AddTile(grassTile2, 50, 49);
            baseMap.AddTile(grassTile2, 50, 50);
            baseMap.AddTile(grassTile2, 50, 51);
            baseMap.AddTile(wallTile, 51, 48);
            baseMap.AddTile(wallTile, 51, 49);
            baseMap.AddTile(wallTile, 51, 50);
            baseMap.AddTile(wallTile, 51, 51);
            baseMap.AddTile(wallTile, 51, 52);
            baseMap.AddTile(wallTile, 50, 52);
            baseMap.AddTile(wallTile, 49, 52);
            baseMap.AddTile(wallTile, 49, 51);
            baseMap.AddTile(wallTile, 49, 50);
            baseMap.AddTile(wallTile, 50, 48);
            baseMap.AddTile(wallTile, 50, 47);
            baseMap.AddTile(wallTile, 50, 46);
            baseMap.AddTile(wallTile, 50, 45);
            baseMap.AddTile(wallTile, 50, 44);
            baseMap.AddTile(wallTile, 50, 43);
            baseMap.AddTile(wallTile, 49, 47);
            baseMap.AddTile(wallTile, 48, 47);
            baseMap.AddTile(wallTile, 47, 47);
            baseMap.AddTile(wallTile, 46, 47);
            baseMap.AddTile(wallTile, 45, 47);
            baseMap.AddTile(wallTile, 48, 50);
            baseMap.AddTile(wallTile, 47, 50);
            baseMap.AddTile(wallTile, 46, 50);
            baseMap.AddTile(wallTile, 45, 50);
            baseMap.AddTile(wallTile, 44, 50);
            baseMap.AddTile(wallTile, 45, 49);

            Door door1 = new Door("door1", openDoorTile, closedDoorTile, false);
            Door door2 = new Door("door2", openDoorTile, closedDoorTile, false);

            baseMap.gameObjectList.Add(door1, new Point(45, 48));
            baseMap.gameObjectList.Add(door2, new Point(46, 48));

            return baseMap;
        }
    }
}
