using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.MapScripts {
    class Ship : MapObject {
        public Ship(Vector2 position) : base(position) {
            label = "Ship";
            this.pos = position;
            texture = Game1.textureManager.ship;
            base.getColorData();
            resetPosition();
        }
    }
}
