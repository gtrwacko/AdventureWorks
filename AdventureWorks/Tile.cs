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
    class Tile
    {
        public Texture2D texture;
        public Rectangle sourceRectangle;
        public Vector2 origin;
        public Color color;
        public bool passable;
		float layerDepth;


		public Tile(Texture2D texture, Rectangle sourceRectangle, Vector2 origin, Color color, float layerDepth)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            this.origin = origin;
            this.color = color;
            this.passable = true;
			this.layerDepth = layerDepth;
        }

        public Tile(Texture2D texture, Rectangle sourceRectangle, Vector2 origin, Color color, float layerDepth, bool passable)
        {
            this.texture = texture;
            this.sourceRectangle = sourceRectangle;
            this.origin = origin;
            this.color = color;
            this.passable = passable;
			this.layerDepth = layerDepth;
		}

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
		{
			spriteBatch.Draw(texture, position, sourceRectangle: sourceRectangle, color: color, origin: origin, layerDepth: layerDepth);
		}

    }
}
