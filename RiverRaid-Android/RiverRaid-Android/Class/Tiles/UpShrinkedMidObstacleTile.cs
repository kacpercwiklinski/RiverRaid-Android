using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class UpShrinkedMidObstacleTile : Tile {
        public UpShrinkedMidObstacleTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.upShrinked_mid_obstacle;
            tileType = TileType.UpShrinked_mid_obstacle;
            base.setupBoundingBox();
            base.getColorData();
        }

        public override void calculateSpawnPlaces() {
            spawnPlaces.Clear();
            spawnPlaces.Add(new Vector2(this.pos.X + 80, this.pos.Y + 467));
            spawnPlaces.Add(new Vector2(this.pos.X + 551, this.pos.Y + 474));
            spawnPlaces.Add(new Vector2(this.pos.X + 309, this.pos.Y + 169));
            base.calculateSpawnPlaces();
        }
    }
}
