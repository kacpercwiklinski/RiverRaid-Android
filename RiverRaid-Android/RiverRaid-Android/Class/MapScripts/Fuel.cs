using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using RiverRaid_Android;

namespace RiverRaider.Class.MapScripts {
    class Fuel : MapObject {
        
        public Fuel(Vector2 position) : base(position) {
            label = "Fuel";
            this.pos = position;
            texture = Game1.textureManager.fuel;
            explosionTexture = Game1.textureManager.fuel_explosion;
            resetPosition();
            base.getColorData();
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
            
            disappearTime = 1f;
            isHit = false;
        }
    }
}
