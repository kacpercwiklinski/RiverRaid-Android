using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.MapScripts {
    class Plane : MapObject {
        public Plane(Vector2 position, int direction) : base(position) {
            this.label = "Plane";
            this.pos = position;
            this.speed = 300f;
            this.texture = Game1.textureManager.plane;
            this.direction = direction == 0 ? 1 : -1;
            base.getColorData();
            resetPosition();
        }

        public override void updateObject(GameTime theTime) {
            if (!this.label.Equals("Explosion")) {
                this.pos.X += this.direction * this.speed * (float)theTime.ElapsedGameTime.TotalSeconds;
                if (this.direction == 1 && this.pos.X > Game1.WIDTH) {
                    this.pos.X = -this.texture.Width;
                } else if (this.direction == -1 && this.pos.X < -this.texture.Width) {
                    this.pos.X = Game1.WIDTH;
                }
            }
            base.updateObject(theTime);
        }
    }
}
