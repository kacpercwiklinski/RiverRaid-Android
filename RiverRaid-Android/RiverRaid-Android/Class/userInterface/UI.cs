using RiverRaid_Android;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RiverRaider.Class.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRaider.Class.userInterface {
    public class UI {
        Texture2D uiBackgroundTexture { get; set; }
        Texture2D fuelBarTexture { get; set; }
        Vector2 fuelBarPosition;
        Vector2 fuelPointerPosition;
        SpriteFont scoreFont { get; set; }
        public static Button leftArrow;
        public static Button rightArrow;


        public UI(ContentManager theContent ) {
            uiBackgroundTexture = Game1.textureManager.uiBackground;
            fuelBarTexture = Game1.textureManager.fuelBar;

            fuelBarPosition = new Vector2(Game1.WIDTH / 2 - fuelBarTexture.Width / 2, Game1.HEIGHT - uiBackgroundTexture.Height / 1.5f);
            fuelPointerPosition = new Vector2(fuelBarPosition.X + 18, fuelBarPosition.Y + 12);

            leftArrow = new Button("LeftArrow", new Vector2(0,Game1.HEIGHT - Game1.textureManager.left_arrow_btn.Height), Game1.textureManager.left_arrow_btn);
            rightArrow = new Button("RightArrow", new Vector2(leftArrow.pos.X + leftArrow.texture.Width,leftArrow.pos.Y), Game1.textureManager.right_arrow_btn);
        }

        public void updateUI(GameTime theTime) {
            updateFuelPointerPosition(theTime);
        }

        public void drawUI(SpriteBatch theBatch) {
            theBatch.Draw(uiBackgroundTexture, new Vector2(0, Game1.HEIGHT - uiBackgroundTexture.Height), Color.White);
            drawFuelPointer(theBatch);
            theBatch.Draw(fuelBarTexture, fuelBarPosition, Color.White);
            
            leftArrow.drawButton(theBatch);
            rightArrow.drawButton(theBatch);
        }

        private void drawFuelPointer(SpriteBatch theBatch) {
            theBatch.Draw(Game1.textureManager.fuelPointer, fuelPointerPosition, Color.White);
        }

        private void updateFuelPointerPosition(GameTime theTime) {
            fuelPointerPosition = new Vector2(map(Player.fuel, 0, 100, 0, 198-12) + fuelBarPosition.X + 18, fuelBarPosition.Y + 12);
        }

        private float map(float n, float start1, float stop1, float start2, float stop2) {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }

        public class Button {
            public String label;
            public Vector2 pos;
            public Texture2D texture;
            public Rectangle btnRectangle;

            public Button(String label, Vector2 pos, Texture2D texture) {
                this.label = label;
                this.pos = pos;
                this.texture = texture;
                this.btnRectangle = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
            }

            public void drawButton(SpriteBatch theBatch) {
                theBatch.Draw(this.texture, new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height), null, Color.White, 0.0f, new Vector2(0.1f, 0.1f), SpriteEffects.None, 0.0f);
            }
            
        }

    }
}
