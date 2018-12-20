using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverRaider.Class {
    class GameObject {
        public List<String> labels = new List<string>();

        public Texture2D texture;
        public Vector2 pos;
        public Rectangle boundingBox { get; set; }
        public Boolean isTriggerable { get; set; }
        public Boolean isDrawable { get; set; }
        public Color[] colorData;

        public GameObject(String labels, Texture2D texture, Vector2 position) {
            this.labels = labels.Split(' ').ToList();
            this.pos = position;
            this.texture = texture;
            this.isTriggerable = true;
            this.isDrawable = true;
            this.boundingBox = new Rectangle((int)this.pos.X-this.texture.Width/2, (int)this.pos.Y-this.texture.Height/2, this.texture.Width, this.texture.Height);
        }

        public void getColorData() {
            colorData = new Color[texture.Width * texture.Height];
            texture.GetData(colorData);
        }
    }
}
