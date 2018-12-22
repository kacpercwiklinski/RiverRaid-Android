using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using RiverRaid_Android;
using Microsoft.Xna.Framework.Input.Touch;

namespace RiverRaider.Class {
    class ControllerDetectScreen : Screen {

        Texture2D mControllerDetectScreenBackground;

        public ControllerDetectScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent) {
            mControllerDetectScreenBackground = Game1.textureManager.splashScreenBackground;
        }

        public override void Update(GameTime theTime) {

            TouchCollection touchPanelState = TouchPanel.GetState();

            foreach (var touch in touchPanelState) {
                if(touch.State == TouchLocationState.Pressed) {
                    ScreenEvent.Invoke(this, new EventArgs());
                }
            }

            for (int aPlayer = 0; aPlayer < 4; aPlayer++) {
                if (GamePad.GetState((PlayerIndex)aPlayer).Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A) == true || Keyboard.GetState().IsKeyDown(Keys.Space)) {
                    PlayerOne = (PlayerIndex)aPlayer;
                    ScreenEvent.Invoke(this, new EventArgs());
                    return;
                }
            }

            base.Update(theTime);
        }

        //Draw all of the elements that make up the Controller Detect Screen
        public override void Draw(SpriteBatch theBatch) {
            theBatch.Draw(mControllerDetectScreenBackground, Vector2.Zero, Color.White);
            base.Draw(theBatch);
        }


    }
}
