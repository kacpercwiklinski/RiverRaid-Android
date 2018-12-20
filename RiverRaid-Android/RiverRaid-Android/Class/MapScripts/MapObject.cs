using RiverRaid_Android;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RiverRaider.Class.Objects;
using RiverRaider.Class.Tiles;
using System;

public enum MapObjectTexture { Plane, Helicopter, Ship, Fuel}

namespace RiverRaider.Class.MapScripts {

    class MapObject {
        public String label;
        public Vector2 pos;
        public Texture2D texture;
        public Texture2D explosionTexture = Game1.textureManager.fuel_explosion;
        public Rectangle boundingBox;
        public Boolean isTriggerable;
        public Boolean onScreen;
        public float disappearTime = 1f;
        public Boolean isHit = false;
        public float speed = 120f;
        int direction = 1;
        public Color[] colorData;
        SpriteEffects s = SpriteEffects.None;
        private bool hit = true;

        public MapObject(String label,Texture2D texture,Vector2 position) {
            this.label = label;
            this.pos = position;
            this.texture = texture;
            onScreen = true;
            isTriggerable = true;
        }

        public MapObject(Vector2 position) {
            this.label = "Default";
            this.pos = Vector2.Zero;
            this.texture = Game1.textureManager.fuel;
            onScreen = true;
            isTriggerable = true;
        }

        public void resetPosition() {
            this.pos.X = this.pos.X - this.texture.Width / 2;
        }

        public virtual void updateObject(GameTime theTime) {
            updateObjectPos(theTime);

            checkCollisions();

            updateBoundingBox(theTime);
            
            if (isHit && hit) {
                changeTexture();
                //Game1.audioManager.boom.Play();
                this.isTriggerable = false;
                this.label = "Explosion";
                disappearTime -= (float)theTime.ElapsedGameTime.TotalSeconds;
                hit = false;
            }
            if(disappearTime <= 0f) {
                this.onScreen = false;
            }
        }

        private void checkCollisions() {
            Tile currentTile = Map.tiles.Find((tile) => this.pos.Y <= tile.pos.Y + tile.texture.Height && this.pos.Y >= tile.pos.Y);

            if(currentTile != null) {
                if (currentTile.boundingBox.Intersects(boundingBox)) {
                    bool collision = false;
                    if(currentTile.tileType != TileType.FullTile) {
                        collision = PerPixelCollisionManager.IntersectsPixel(boundingBox, this.colorData, currentTile.boundingBox, currentTile.colorData);

                    }
                    if (this.pos.X <= currentTile.pos.X) collision = true;
                    if (this.pos.X + this.texture.Width >= currentTile.pos.X + currentTile.texture.Width) collision = true;
                
                    if (collision) {
                        if(this.direction == 1) {
                            this.pos.X -= 5;
                            this.direction = -1;
                        } else if(this.direction == -1) {
                            this.pos.X += 5;
                            this.direction = 1;
                        }
                    }
                }
            }
        }

        private void updateObjectPos(GameTime theTime) {
            if (!this.label.Equals("Fuel") && !this.label.Equals("Explosion")) {
                this.pos.X += this.direction * this.speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            }
        }

        private void updateBoundingBox(GameTime theTime) {
            boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        public void draw(SpriteBatch theBatch) {
            if (this.onScreen) {
                if(this.label.Equals("Ship")) {
                    if(this.direction == 1) {
                        s = SpriteEffects.FlipHorizontally;
                    } else {
                        s = SpriteEffects.None;
                    }
                }else if (this.label.Equals("Helicopter")) {
                    if (this.direction == -1) {
                        s = SpriteEffects.FlipHorizontally;
                    } else {
                        s = SpriteEffects.None;
                    }
                } else if (this.label.Equals("Plane")) {
                    if (this.direction == 1) {
                        s = SpriteEffects.FlipHorizontally;
                    } else {
                        s = SpriteEffects.None;
                    }
                }
                theBatch.Draw(this.texture, new Rectangle((int)this.pos.X,(int)this.pos.Y,this.texture.Width,this.texture.Height),null, Color.White,0.0f,new Vector2(0,0),s,0.0f);
            }
        }

        private void changeTexture() {
            this.texture = this.explosionTexture;
        }

        public void getColorData() {
            colorData = new Color[texture.Width * texture.Height];
            texture.GetData(colorData);
        }
    }
}
