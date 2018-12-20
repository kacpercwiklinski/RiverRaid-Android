using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RiverRaider.Class.MapScripts;

namespace RiverRaider.Class.Objects {
    class Bullet : GameObject {
        float speed = 800f;
        public Bullet(string labels, Texture2D texture, Vector2 position) : base(labels, texture, position) {

        }

        public void updateBullet(GameTime theTime) { 
            handleCollisions();
            moveBullet(theTime);
            updateBoundingBox();
        }

        private void updateBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X-this.texture.Width/2, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        private void handleCollisions() {
            Map.mapObjects.ForEach((mapObject) => {
                if (mapObject.boundingBox.Intersects(this.boundingBox) && mapObject.isTriggerable) {
                    this.isDrawable = false;
                    mapObject.isHit = true;
                    mapObject.isTriggerable = false;
                }
            });
        }

        private void moveBullet(GameTime theTime) {
            this.pos.Y -= this.speed * (float)theTime.ElapsedGameTime.TotalSeconds;
        }

        public void drawBullet(SpriteBatch theBatch) {
            if (this.isDrawable) {
                theBatch.Draw(this.texture, new Vector2(this.pos.X - this.texture.Width / 2, this.pos.Y), Color.White);
               // LineBatch.drawBoundingBox(this.boundingBox, theBatch);
            }
        }
    }
}
