using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.MapScripts {
    class Helicopter : MapObject {
        public Helicopter(Vector2 position) : base(position) {
            label = "Helicopter";
            this.pos = position;
            texture = Game1.textureManager.helicopter_1;
            base.getColorData();
            resetPosition();
        }
    }
}
