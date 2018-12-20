using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.MapScripts {
    class Plane : MapObject {
        public Plane(Vector2 position) : base(position) {
            label = "Plane";
            this.pos = position;
            texture = Game1.textureManager.plane;
            base.getColorData();
            resetPosition();
        }
    }
}
