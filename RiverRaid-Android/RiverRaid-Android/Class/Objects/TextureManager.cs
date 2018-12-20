using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRaider.Class.Objects {
    public class TextureManager {
        //Background
        public Texture2D splashScreenBackground;

        // Debug
        public Texture2D centerLine;
        public Texture2D debugPoint;

        // Map Objects
        public  Texture2D fuel;
        public  Texture2D helicopter_1;
        public  Texture2D helicopter_2;
        public  Texture2D plane;
        public  Texture2D ship;

        // Explosions
        public Texture2D fuel_explosion;

        // Object
        public  Texture2D bullet;
        public  Texture2D player;
        public  Texture2D player_left;
        public  Texture2D player_right;

        // Tiles
        public  Texture2D fullTile;
        public  Texture2D upShrinked;
        public  Texture2D downShrinked;
        public  Texture2D downShrinked_mid_obstacle;
        public  Texture2D upShrinked_mid_obstacle;

        // UI
        public  Texture2D uiBackground;
        public  Texture2D fuelBar;
        public Texture2D fuelPointer;

        public TextureManager(ContentManager theContent) {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent) {
            // Background
            splashScreenBackground = theContent.Load<Texture2D>("textures/background/splashScreenBackground");

             // Debug
            centerLine = theContent.Load<Texture2D>("textures/debugTextures/centerLine");
            debugPoint = theContent.Load<Texture2D>("textures/debugTextures/debugPoint");

            // Map Object
            fuel = theContent.Load<Texture2D>("textures/mapObjects/fuel");
            helicopter_1 = theContent.Load<Texture2D>("textures/mapObjects/helicopter_1");
            helicopter_2 = theContent.Load<Texture2D>("textures/mapObjects/helicopter_2");
            plane = theContent.Load<Texture2D>("textures/mapObjects/plane");
            ship = theContent.Load<Texture2D>("textures/mapObjects/ship");
            fuel_explosion = theContent.Load<Texture2D>("textures/mapObjects/fuel_explosion");

            // Object
            bullet = theContent.Load<Texture2D>("textures/object/bullet");
            player = theContent.Load<Texture2D>("textures/object/player");
            player_left = theContent.Load<Texture2D>("textures/object/player_left");
            player_right = theContent.Load<Texture2D>("textures/object/player_right");

            // Tiles
            fullTile = theContent.Load<Texture2D>("textures/tiles/fullTile");
            upShrinked = theContent.Load<Texture2D>("textures/tiles/upShrinked");
            downShrinked = theContent.Load<Texture2D>("textures/tiles/downShrinked");
            downShrinked_mid_obstacle = theContent.Load<Texture2D>("textures/tiles/downShrinked_mid_obstacle");
            upShrinked_mid_obstacle = theContent.Load<Texture2D>("textures/tiles/upShrinked_mid_obstacle");

            // UI
            uiBackground = theContent.Load<Texture2D>("textures/ui/uiBackground");
            fuelBar = theContent.Load<Texture2D>("textures/ui/fuelBar");
            fuelPointer = theContent.Load<Texture2D>("textures/ui/fuelPointer");
        }

    }
}
