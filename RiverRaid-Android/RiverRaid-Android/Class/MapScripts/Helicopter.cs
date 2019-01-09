
using RiverRaid_Android;
using Microsoft.Xna.Framework;

namespace RiverRaider.Class.MapScripts {
    class Helicopter : MapObject {

        private float animationCounter = 0.1f;
        private float animationIdx = 0;

        public Helicopter(Vector2 position) : base(position) {
            label = "Helicopter";
            this.pos = position;
            texture = Game1.textureManager.helicopter_1;
            base.getColorData();
            resetPosition();
        }

        public override void updateObject(GameTime theTime) {
            animate(theTime);
            base.updateObject(theTime);
        }

        public void animate(GameTime theTime) {
            this.animationCounter -= (float)theTime.ElapsedGameTime.TotalSeconds;
            if(animationCounter <= 0f && !isHit) {
                switch (this.animationIdx) {
                    case 0:
                        this.texture = Game1.textureManager.helicopter_2;
                        this.animationIdx = 1;
                        break;
                    case 1:
                        this.texture = Game1.textureManager.helicopter_1;
                        this.animationIdx = 0;
                        break;
                }
                this.animationCounter = 0.1f;
            }
        }
    }
}
