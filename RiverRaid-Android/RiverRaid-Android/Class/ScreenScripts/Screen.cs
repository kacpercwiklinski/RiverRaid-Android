using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiverRaider.Class {
    public class Screen {

        protected static PlayerIndex PlayerOne;
        protected EventHandler ScreenEvent;
        public Screen(EventHandler theScreenEvent) {
            ScreenEvent = theScreenEvent;
        }

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {

        }
    }
}
