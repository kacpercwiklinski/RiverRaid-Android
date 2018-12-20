using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRaider.Class.Objects {
    static class PerPixelCollisionManager {

        public static bool IntersectsPixel(Rectangle hitbox1, Color[] colorData1, Rectangle hitbox2, Color[] colorData2) {

            int top = Math.Max(hitbox1.Top, hitbox2.Top);
            int bottom = Math.Min(hitbox1.Bottom, hitbox2.Bottom);
            int left = Math.Max(hitbox1.Left, hitbox2.Left);
            int right = Math.Min(hitbox1.Right, hitbox2.Right);

            for (int y = top; y < bottom; y++) {
                for (int x = left; x < right; x++) {
                    int idx1 = (x - hitbox1.Left) + (y - hitbox1.Top) * hitbox1.Width;
                    int idx2 = (x - hitbox2.Left) + (y - hitbox2.Top) * hitbox2.Width;
                    
                    Color color1 = colorData1[idx1];
                    Color color2 = colorData2[idx2];
        
            if (color1.A != 0 && color2.A != 0)
                        return true;
                }
            }
            return false;
        }
    }
}
