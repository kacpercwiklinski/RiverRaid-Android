using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiverRaid_Android;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RiverRaider.Class.MapScripts;
using RiverRaider.Class.Tiles;
using Microsoft.Xna.Framework.Input.Touch;

namespace RiverRaider.Class.Objects {
    class Player : GameObject {
        public static List<Bullet> bullets;
        float speed = 200f;
        float shootCooldown;
        float acceleration;
        float fuelUsageRate;
        public static float fuel;
        bool fueling = false;
        public TouchCollection touchCollection;

        public Player(string labels, Texture2D texture, Vector2 position) : base(labels, texture, position) {
            bullets = new List<Bullet>();
            speed = 200f;
            shootCooldown = 0.2f;
            acceleration = 400f;
            fuelUsageRate = 1f;
            fuel = 100f;
            fueling = false;
            base.getColorData();
        }

        public void update(GameTime theTime) {
            // Handle shooting timer
            handleShootCooldown(theTime);
            
            // Handle player movement
            handleMovement(theTime);

            // Update player boundingBox
            updateBoundingBox();

            // Handle tiles collisions
            handleTilesCollisions();

            // Handle map objects collisions
            handleMapObjectsCollisions();

            // Fueling
            refueling(theTime);

            // Update bullets
            bullets.ForEach((bullet) => bullet.updateBullet(theTime));
            bullets = bullets.FindAll((bullet) => bullet.isDrawable);
        }

        private void refueling(GameTime theTime) {
            if (fuel <= 0f) explode();

            if (fuel > 0) {
                fuel -= fuelUsageRate * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else fuel = 0;

            if (fueling && fuel < 100f) {
                fuel += 10f * (float)theTime.ElapsedGameTime.TotalSeconds;
                if(fuel > 100f) {
                    fuel = 100f;
                }
            }

            fueling = false;
        }

        private void updateBoundingBox() {
            boundingBox = new Rectangle((int)this.pos.X- this.texture.Width/2, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        private void handleMapObjectsCollisions() {
            Map.mapObjects.FindAll((mapObject) => mapObject.pos.Y > -Game1.textureManager.fullTile.Height - 20).ForEach((mapObject) => {
                if (mapObject.boundingBox.Intersects(this.boundingBox) && mapObject.isTriggerable == true) {
                    if (mapObject.label.Equals("Fuel")) {
                        fueling = true;
                    } else {
                        explode();
                    }
                }
            });
        }

        private void handleTilesCollisions() {
            List<Tile> tempTiles = new List<Tile>();

            Tile currentTile = Map.tiles.Find((tile) => (pos.Y + texture.Height + 5) >= tile.pos.Y && pos.Y <= (tile.pos.Y + tile.texture.Height));
            
            if (currentTile != null) {
                Tile nextTile = Map.tiles.Find((tile) => tile.pos.Y <= currentTile.pos.Y - tile.texture.Height + 10 && tile.pos.Y >= currentTile.pos.Y - tile.texture.Height - 10);

                if (nextTile != null) {
                    tempTiles.Add(currentTile);
                    tempTiles.Add(nextTile);

                    tempTiles.ForEach((tempTile) => {
                        if (tempTile.boundingBox.Intersects(boundingBox) && tempTile.tileType != TileType.FullTile) {
                            bool collision = PerPixelCollisionManager.IntersectsPixel(boundingBox, colorData, tempTile.boundingBox, tempTile.colorData);
                            if (collision) explode();
                        }
                    });
                }
            }
        }

        private void handleMovement(GameTime theTime) {
            var kstate = Keyboard.GetState();


            touchCollection = TouchPanel.GetState();



            bool CheckLeftMoveTouch(Rectangle target, TouchCollection touchCollection)
            {
                if (touchCollection.Count > 0)
                {
                    foreach (var touch in touchCollection)
                    {
                        if (target.Contains(touch.Position) && this.pos.X > Game1.WIDTH / 4 + 8 + this.texture.Width / 2)
                        {
                            this.texture = Game1.textureManager.player_left;
                            this.pos.X += -1 * speed * (float)theTime.ElapsedGameTime.TotalSeconds;
                            return true;
                        }
                        else
                        {
                            this.texture = Game1.textureManager.player;
                        }
                    }
                }
                return false;
            }

            bool CheckRightMoveTouch(Rectangle target, TouchCollection touchCollection)
            {
                if (touchCollection.Count > 0)
                {
                    foreach (var touch in touchCollection)
                    {
                        if (target.Contains(touch.Position) && this.pos.X < Game1.WIDTH - Game1.WIDTH / 4 - 8 - this.texture.Width / 2)
                        {
                            this.texture = Game1.textureManager.player_right;
                            this.pos.X += 1 * speed * (float)theTime.ElapsedGameTime.TotalSeconds;
                            return true;
                        }
                        else
                        {
                            this.texture = Game1.textureManager.player;
                        }
                    }
                }
                return false;
            }


            bool CheckShootTouch(Rectangle target, TouchCollection touchCollection)
            {
                if (touchCollection.Count > 0)
                {
                    foreach (var touch in touchCollection)
                    {
                        if (target.Contains(touch.Position) && touch.State ==  TouchLocationState.Pressed)
                        {
                            shoot();
                            this.shootCooldown = 0.2f;
                            return true;
                        }
                    }
                }
                return false;
            }

            CheckLeftMoveTouch(new Rectangle((int)Game1.WIDTH / 8, (int)Game1.HEIGHT / 8, Game1.textureManager.left_arrow_btn.Width*2, Game1.textureManager.left_arrow_btn.Height*2), touchCollection);
            CheckRightMoveTouch(new Rectangle((int)(Game1.WIDTH / 8)*2, (int)Game1.HEIGHT / 8, Game1.textureManager.left_arrow_btn.Width*2, Game1.textureManager.left_arrow_btn.Height*2), touchCollection);
            //CheckShootTouch(new Rectangle(940, 0, 340, 720), touchCollection);

            CheckShootTouch(new Rectangle(Game1.WIDTH/2 + Game1.WIDTH/4, 0, Game1.WIDTH/2, Game1.HEIGHT), touchCollection);






            if (kstate.IsKeyDown(Keys.A) && this.pos.X > Game1.WIDTH/4 + 8 + this.texture.Width/2) {
                this.texture = Game1.textureManager.player_left;
                this.pos.X += -1 * speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else if (kstate.IsKeyDown(Keys.D) && this.pos.X < Game1.WIDTH - Game1.WIDTH/ 4 - 8 - this.texture.Width / 2) {
                this.texture = Game1.textureManager.player_right;
                this.pos.X += 1 * speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else {
                this.texture = Game1.textureManager.player;
            }

            if (kstate.IsKeyDown(Keys.W) && Map.mapMovingSpeed <= Map.maxMovingSpeed) {
                Map.mapMovingSpeed += acceleration * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else if (kstate.IsKeyDown(Keys.S) && Map.mapMovingSpeed >= Map.minMovingSpeed) {
                Map.mapMovingSpeed -= acceleration * (float)theTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Space) && this.shootCooldown <= 0) {
                shoot();
                this.shootCooldown = 0.2f;
            }
        }

        private void handleShootCooldown(GameTime theTime) {
            if(this.shootCooldown > 0) {
                this.shootCooldown -= (float)theTime.ElapsedGameTime.TotalSeconds;
            }
        }

        private void shoot() {
            bullets.Add(new Bullet("Bullet",Game1.textureManager.bullet,this.pos));
            //Game1.audioManager.shoot.Play();
        }

        public void drawPlayer(SpriteBatch theBatch) {
            theBatch.Draw(this.texture, new Vector2(this.pos.X-this.texture.Width/2,pos.Y), Color.White);
          //  LineBatch.drawBoundingBox(this.boundingBox, theBatch);
            bullets.ForEach((bullet) => bullet.drawBullet(theBatch));
        }

        public void resetPlayerPos() {
            this.pos = new Vector2(Game1.WIDTH / 2, Game1.HEIGHT / 1.45f);
        }

        private void explode() {
            Game1.mGameScreen.StartGame();
        }
    }
}
