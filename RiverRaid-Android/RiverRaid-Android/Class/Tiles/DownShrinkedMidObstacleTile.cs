using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class DownShrinkedMidObstacleTile : Tile
    {
        public DownShrinkedMidObstacleTile(Vector2 position) : base(position) {
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2, this.pos.Y + texture.Height / 2 + 50));
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 8, this.pos.Y + texture.Height / 8));

            texture = Game1.textureManager.downShrinked_mid_obstacle;
            tileType = TileType.DownShrinked_mid_obstacle;
            base.setupBoundingBox();
            base.getColorData();
        }
    }
}
