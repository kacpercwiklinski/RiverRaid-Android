using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class DownShrinkedMidObstacleTile : Tile{
        public DownShrinkedMidObstacleTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.downShrinked_mid_obstacle;
            tileType = TileType.DownShrinked_mid_obstacle;
            base.setupBoundingBox();
            base.getColorData();
        }

        public override void calculateSpawnPlaces() {
            spawnPlaces.Clear();
            spawnPlaces.Add(new Vector2(this.pos.X + 75, this.pos.Y + 83));
            spawnPlaces.Add(new Vector2(this.pos.X + 539, this.pos.Y + 73));
            spawnPlaces.Add(new Vector2(this.pos.X + 303, this.pos.Y + 368));
            base.calculateSpawnPlaces();
        }
    }
}
