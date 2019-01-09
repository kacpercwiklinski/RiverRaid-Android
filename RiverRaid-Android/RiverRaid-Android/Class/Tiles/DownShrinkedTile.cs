using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;
using RiverRaider.Class.MapScripts;

namespace RiverRaider.Class.Tiles {
    class DownShrinkedTile : Tile {
        public DownShrinkedTile(Vector2 position) : base(position) {
            texture = Game1.textureManager.downShrinked;
            tileType = TileType.DownShrinked;
            base.setupBoundingBox();
            base.getColorData();
        }

       public override void calculateSpawnPlaces() {
            spawnPlaces.Clear();
            spawnPlaces.Add(new Vector2(this.pos.X + 106, this.pos.Y + 73));
            spawnPlaces.Add(new Vector2(this.pos.X + 297, this.pos.Y + 215));
            spawnPlaces.Add(new Vector2(this.pos.X + 301, this.pos.Y + 371));
       }
    }
}
