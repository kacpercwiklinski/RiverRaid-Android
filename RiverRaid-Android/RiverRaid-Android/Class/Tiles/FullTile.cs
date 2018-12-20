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
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width/2 , this.pos.Y + texture.Height/2));
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2 - texture.Width/4, this.pos.Y + texture.Height / 2 - texture.Width/4));

            this.texture = Game1.textureManager.fullTile;
            tileType = TileType.FullTile;
            base.setupBoundingBox();
            base.getColorData();
        }
    }
}
