using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;


namespace RiverRaider.Class.Objects
{
    public class AudioManager
    {

        public SoundEffect shoot;
        public SoundEffect boom;
        public SoundEffect fuel;

        public AudioManager(ContentManager theContent)
        {
            loadAudios(theContent);
        }

        private void loadAudios(ContentManager theContent)
        {
            shoot = theContent.Load<SoundEffect>("audio/shoot");
            boom = theContent.Load<SoundEffect>("audio/boom");
            fuel = theContent.Load<SoundEffect>("audio/fuel");
        }
    }
}
