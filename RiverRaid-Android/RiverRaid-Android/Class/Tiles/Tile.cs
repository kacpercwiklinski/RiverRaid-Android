using RiverRaid_Android;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RiverRaider.Class.MapScripts;
using RiverRaider.Class.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

public enum TileType { UpShrinked, FullTile, DownShrinked, UpShrinked_mid_obstacle, DownShrinked_mid_obstacle }

namespace RiverRaider.Class.Tiles {
    class Tile {
        Random random = new Random();
        public int maxEnemies = 5;
        int spawnedPlanes = 3;
        public Texture2D texture;
        public Vector2 pos;
        public Rectangle boundingBox;
        public Boolean onScreen = true;
        public TileType tileType;
        public Color[] colorData;
        public List<Vector2> spawnPlaces;
        public bool generatedEnemies;
        private float planeSpawnChance = 0.33f;

        public Tile(Texture2D texture,Vector2 position, TileType tileType) {
            pos = position;
            this.texture = texture;
            this.tileType = tileType;
            generatedEnemies = false;
            this.spawnPlaces = new List<Vector2>();
        }

        public Tile(Vector2 position) {
            pos = position;
            this.texture = Game1.textureManager.fullTile;
            this.tileType = TileType.FullTile;
            generatedEnemies = false;
            this.spawnPlaces = new List<Vector2>();
        }

        public void generateMapObject(Vector2 vector2)
        {
            int r = random.Next(0, 3);

            switch (r) {
                case 0:
                    Map.mapObjects.Add(new Ship(vector2));
                    break;
                case 1:
                    Map.mapObjects.Add(new Helicopter(vector2));
                    break;
                case 2:
                    Map.mapObjects.Add(new Fuel(vector2));
                    break;
            }
        }

        public void spawnPlaneEnemy() {
            if (random.NextDouble() <= planeSpawnChance && spawnedPlanes > 0) {
                Map.mapObjects.Add(new MapScripts.Plane(new Vector2(-Game1.textureManager.plane.Width,random.Next((int)this.pos.Y,(int)this.pos.Y + 250)),random.Next(0,2)));
                spawnedPlanes--;
            }
        }

        public void update(GameTime theTime) {
            if (this.pos.Y > Game1.HEIGHT) this.onScreen = false;

            this.spawnPlaneEnemy();
            this.pos.Y += Map.mapMovingSpeed * (float)theTime.ElapsedGameTime.TotalSeconds;
            this.updateBoundingBox();
        }

        public void generateEnemies() {
            List<Vector2> tempPlaces = this.spawnPlaces;
            if (!generatedEnemies) {
                this.calculateSpawnPlaces();
                for (int x = 0; x < this.maxEnemies; x++) {
                    if (tempPlaces.Count() > 0) {
                        Vector2 randomPlace = tempPlaces.ElementAt(random.Next(0, tempPlaces.Count()));
                        tempPlaces.Remove(randomPlace);
                        generateMapObject(randomPlace);
                    }
                }
            }
            generatedEnemies = true;
        }

        public virtual void calculateSpawnPlaces() {

        }

        public virtual void setupBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, Game1.textureManager.fullTile.Width, Game1.textureManager.fullTile.Height);
        }

        public void drawTile(SpriteBatch theBatch) {
            theBatch.Draw(Game1.textureManager.fullTile, this.pos, Color.White);
            theBatch.Draw(this.texture, this.pos, Color.White);
        }

        public void updateBoundingBox() {
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, Game1.textureManager.fullTile.Width, Game1.textureManager.fullTile.Height);
        }

        public void getColorData() {
            colorData = new Color[texture.Width * texture.Height];
            texture.GetData(colorData);
        }
    }
}
