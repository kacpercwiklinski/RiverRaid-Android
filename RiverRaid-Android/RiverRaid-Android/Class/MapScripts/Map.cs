using RiverRaid_Android;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RiverRaider.Class.Objects;
using RiverRaider.Class.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRaider.Class.MapScripts {
    class Map {
        Random r;
        public const float maxMovingSpeed = 500f, minMovingSpeed = 100f;
        Tile firstTile, currentTile, secondTile;
        public static List<Tile> tiles;

        public static List<MapObject> mapObjects = new List<MapObject>();
        public static float mapMovingSpeed;
        
        public Map(ContentManager theContent, int tilesNumber) {
            r = new Random();
            mapMovingSpeed = 100f;
            tiles = new List<Tile>();
            firstTile = new FullTile(new Vector2(Game1.WIDTH / 4, 0));
            secondTile = new UpShrinkedTile(new Vector2(Game1.WIDTH / 4, -firstTile.texture.Height));
            tiles.Add(firstTile);
            tiles.Add(secondTile);

            currentTile = secondTile;
            generateMap(tilesNumber);

         //   firstTile.generateEnemies();
          //  secondTile.generateEnemies();
        }

        private void generateMap(int tilesNumber) {
            Tile nextTile = new FullTile(new Vector2(Game1.WIDTH / 4, 0));

            for (int i = 2; i <= tilesNumber; i++) {
                if (currentTile.tileType == TileType.FullTile) {
                    int random = r.Next(0, 2);
                    if (random == 0) {
                        nextTile = new UpShrinkedTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked.Height - 1));
                    } else if (random == 1) {
                        nextTile = new UpShrinkedMidObstacleTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked_mid_obstacle.Height - 1));
                    }
                } else if (currentTile.tileType == TileType.UpShrinked) {
                    int random = r.Next(0, 2);
                    if (random == 0) {
                        nextTile = new DownShrinkedTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.downShrinked.Height - 1));
                    } else if (random == 1) {
                        nextTile = new DownShrinkedMidObstacleTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.downShrinked_mid_obstacle.Height - 1));
                    }
                } else if (currentTile.tileType == TileType.DownShrinked) {
                    int random = r.Next(0, 3);
                    if (random == 0) {
                        nextTile = new UpShrinkedTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked.Height - 1));
                    } else if (random == 1) {
                        nextTile = new FullTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.fullTile.Height - 1));
                        
                    } else if (random == 2) {
                        nextTile = new UpShrinkedMidObstacleTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked_mid_obstacle.Height - 1));
                    }
                } else if (currentTile.tileType == TileType.UpShrinked_mid_obstacle) {
                    nextTile = new DownShrinkedTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.downShrinked.Height - 1));
                } else if (currentTile.tileType == TileType.DownShrinked_mid_obstacle) {
                    int random = r.Next(0, 2);
                    if (random == 0) {
                        nextTile = new FullTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.fullTile.Height - 1));
                    } else if (random == 1) {
                        nextTile = new UpShrinkedMidObstacleTile(new Vector2(Game1.WIDTH / 4, 0 - i * Game1.textureManager.upShrinked_mid_obstacle.Height - 1));
                    } 
                }
                tiles.Add(nextTile);
                currentTile = nextTile;
            }
        }

        public void updateMap(GameTime theTime) {
            // Remove bullets above the screen
            removeHiddenBullets();

            // Move and remove objects below screen
            mapObjects.ForEach((mapobject) => {
                mapobject.updateObject(theTime);
                if (mapobject.pos.Y >= Game1.textureManager.fullTile.Height + mapobject.texture.Height) mapobject.onScreen = false;
                mapobject.pos.Y += mapMovingSpeed * (float)theTime.ElapsedGameTime.TotalSeconds;
            });

            // Move and remove tiles below screen
            tiles.ForEach((tile) => {
                if (tile.pos.Y > Game1.HEIGHT) tile.onScreen = false;

                tile.pos.Y += mapMovingSpeed * (float)theTime.ElapsedGameTime.TotalSeconds;

                tile.updateBoundingBox();
            });

            // Generate currentTiles enemies
            tiles.FindAll((tile) => tile.pos.Y >= -tile.texture.Height).ForEach((tile) => tile.generateEnemies());

            mapObjects = mapObjects.FindAll((mapObject) => mapObject.onScreen);//.FindAll((mapObject)  => mapObject.isTriggerable);

            tiles = tiles.FindAll((tile) => tile.onScreen);
        }

        public void drawMap(SpriteBatch theBatch) {
            tiles.FindAll((tile) => tile.pos.Y > -Game1.textureManager.fullTile.Height -20).ForEach((tile)  => {
                tile.drawTile(theBatch);
            });

            mapObjects.FindAll((mapObject) => mapObject.pos.Y > -Game1.textureManager.fullTile.Height - 20).FindAll((mapObject)=> mapObject.onScreen).ForEach((mapObject) => {
                mapObject.draw(theBatch);
            });
        }

        private void removeHiddenBullets() {
            Player.bullets = Player.bullets.FindAll((bullet) => bullet.pos.Y > -bullet.texture.Height);
        }
    }
}
