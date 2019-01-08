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
            
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2, this.pos.Y - texture.Height / 2));
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2, this.pos.Y - texture.Height + texture.Height/8));

            texture = Game1.textureManager.upShrinked;
            tileType = TileType.UpShrinked;
            base.setupBoundingBox();
            base.getColorData();
        }
    }
}
