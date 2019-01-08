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
        
        public static List<MapObject> mapObjects = new List<MapObject>();

        public DownShrinkedTile(Vector2 position) : base(position) {
            
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2, this.pos.Y / 2 - 150));
            spawnPlaces.Add(new Vector2(this.pos.X + texture.Width / 2, this.pos.Y / 2));

            
            texture = Game1.textureManager.downShrinked;
            tileType = TileType.DownShrinked;
            base.setupBoundingBox();
            base.getColorData();

        }

       










    }
}
