using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using RiverRaider.Class.Objects;
using RiverRaider.Class.userInterface;
using RiverRaider.Class.MapScripts;
using RiverRaid_Android;

namespace RiverRaider.Class.ScreenScripts {
    public class GameScreen : Screen {

        const int mapTilesNumber = 100;
        Player player;
        Map map;
        UI ui;
        ContentManager cm;

        public static int score = 0;
        private SpriteFont scoreFont;


        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent) {
            cm = theContent;
            
            player = new Player("Player", Game1.textureManager.player, new Vector2(0,0));
            scoreFont = theContent.Load<SpriteFont>("font/scoreFont");
            ui = new UI(theContent);
            map = new Map(theContent,mapTilesNumber);
        }

        public override void Update(GameTime theTime) {
             // Update map
            map.updateMap(theTime);
            // Update player logic
            player.update(theTime);
            // Update UI
            ui.updateUI(theTime);

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch) {
            // Draw Map
            map.drawMap(theBatch);

            // Draw player texture
            player.drawPlayer(theBatch);

            // Draw UI
            ui.drawUI(theBatch);

            // Draw player score on screen
            theBatch.DrawString(scoreFont, ""+score, new Vector2(630, 545), Color.Yellow);

            base.Draw(theBatch);
        }
        
        public void StartGame() {
            player = new Player("Player", Game1.textureManager.player, new Vector2(0, 0));
            player.resetPlayerPos();
            Map.mapObjects = new List<MapObject>();
            ui = new UI(cm);
            map = new Map(cm, mapTilesNumber);
        }
    }
}

