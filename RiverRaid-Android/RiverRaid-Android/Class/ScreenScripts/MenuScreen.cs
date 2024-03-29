﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using RiverRaid_Android;
using Microsoft.Xna.Framework.Input.Touch;

namespace RiverRaider.Class {
    class MenuScreen : Screen {

        //Background texture for the Title screen
        Texture2D mTitleScreenBackground;
        public SpriteFont optionsFont;
        public List<Optionn> options;
        float counter = 0.2f;



        public MenuScreen(ContentManager theContent,EventHandler theScreenEvent) : base(theScreenEvent) {
       //     mTitleScreenBackground = theContent.Load<Texture2D>("textures/TitleScreen");

            options = new List<Optionn>();
            options.Add(new Optionn("Play", true));
            options.Add(new Optionn("Exit", false));

            optionsFont = theContent.Load<SpriteFont>("font/optionFont");
        }

        public void drawOptions(SpriteBatch spriteBatch) {
            int index = 0;
            options.ForEach((option) => {
                Color fontColor = option.active ? Color.DeepSkyBlue : Color.DarkBlue;
                float fontLenght = optionsFont.MeasureString(option.label).Length();
                spriteBatch.DrawString(optionsFont, option.label, new Vector2((float)(Game1.WIDTH/2) - fontLenght / 2, (float)(Game1.HEIGHT / 3) + index * 100), fontColor);
                index++;
            });
        }

        public override void Update(GameTime theTime) {
            var kstate = Keyboard.GetState();
            var touchCol = TouchPanel.GetState();

            if (GamePad.GetState(PlayerOne).Buttons.B == ButtonState.Pressed || kstate.IsKeyDown(Keys.B) == true) {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            while (TouchPanel.IsGestureAvailable) {
                GestureSample gs = TouchPanel.ReadGesture();

                if(gs.GestureType == GestureType.VerticalDrag) {
                    if(gs.Delta.Y > 0) {
                        changeActiveOption(-1, theTime);
                    } else {
                        changeActiveOption(1, theTime);
                    }
                }
            }
            
            foreach (var touch in touchCol) {
                if (touch.State == TouchLocationState.Pressed) {
                    ScreenEvent.Invoke(this, new EventArgs());
                }
            }

            /*
            foreach (var touch in touchCol) {

                if (touch.State != TouchLocationState.Released)
                    continue;

                TouchLocation prevLoc;

                if (!touch.TryGetPreviousLocation(out prevLoc) || prevLoc.State != TouchLocationState.Moved)
                    continue;

                var delta = touch.Position - prevLoc.Position;

                // Usually you don't want to do something if the user drags 1 pixel.
                if (delta.LengthSquared() < 30f)
                    continue;

                if (delta.X < 0 || delta.Y < 0)
                    Debug.WriteLine("Swipe w prawo");

                if (delta.X > 0 || delta.Y > 0)
                    Debug.WriteLine("Swipe w lewo");
            }
            */

            updateCounter(theTime);

            if (kstate.IsKeyDown(Keys.Up)) changeActiveOption(1, theTime);
            if (kstate.IsKeyDown(Keys.Down)) changeActiveOption(-1, theTime);

            if (kstate.IsKeyDown(Keys.Enter) && counter <= 0f) {
                ScreenEvent.Invoke(this, new EventArgs());
                counter = 0.2f;
            }

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch) {

            drawOptions(theBatch);

            base.Draw(theBatch);
        }

        public void updateCounter(GameTime gameTime) {
            counter -= (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public void changeActiveOption(int input, GameTime gameTime) {
            if (counter <= 0f) {
                int currentIndex = options.FindIndex((option) => option.active == true);
                if (input == -1) {
                    if (options.ElementAtOrDefault(currentIndex + 1) != null) {
                        options.ElementAt(currentIndex).active = false;
                        options.ElementAt(currentIndex + 1).active = true;
                    } else {
                        options.ElementAt(currentIndex).active = false;
                        options.ElementAt(0).active = true;
                    }
                } else if (input == 1) {
                    if (options.ElementAtOrDefault(currentIndex - 1) != null) {
                        options.ElementAt(currentIndex).active = false;
                        options.ElementAt(currentIndex - 1).active = true;
                    } else {
                        options.ElementAt(currentIndex).active = false;
                        options.Last().active = true;
                    }
                }
                counter = 0.2f;
            }

        }

        public class Optionn {
            public String label;
            public bool active;

            public Optionn(String label, bool active) {
                this.label = label;
                this.active = active;
            }
        }
    }
}
