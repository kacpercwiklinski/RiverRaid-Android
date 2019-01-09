using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiverRaider.Class.Tiles {
    class FullTile : Tile {
        public FullTile(Vector2 position) : base(position) {
            this.texture = Game1.textureManager.fullTile;
            tileType = TileType.FullTile;
            base.setupBoundingBox();
            base.getColorData();
        }

        public override void calculateSpawnPlaces() {
            spawnPlaces.Clear();
            spawnPlaces.Add(new Vector2(this.pos.X + 112, this.pos.Y + 98));
            spawnPlaces.Add(new Vector2(this.pos.X + 298, this.pos.Y + 263));
            spawnPlaces.Add(new Vector2(this.pos.X + 454, this.pos.Y + 424));
            base.calculateSpawnPlaces();
        }
    }
}
