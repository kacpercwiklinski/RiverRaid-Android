using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.Tiles {
    class UpShrinkedTile : Tile {
        public UpShrinkedTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.upShrinked;
            tileType = TileType.UpShrinked;
            base.setupBoundingBox();
            base.getColorData();
        }

        public override void calculateSpawnPlaces() {
            spawnPlaces.Clear();
            spawnPlaces.Add(new Vector2(this.pos.X + 306, this.pos.Y + 166));
            spawnPlaces.Add(new Vector2(this.pos.X + 296, this.pos.Y + 295));
            spawnPlaces.Add(new Vector2(this.pos.X + 551, this.pos.Y + 474));
            base.calculateSpawnPlaces();
        }
    }
}
