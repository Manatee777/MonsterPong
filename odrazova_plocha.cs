using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace skakacka
{
    class odrazova_plocha : herni_objekt
    {

        public odrazova_plocha(Texture2D textura, Vector2 pozice) : base(textura, pozice)
        {
            this.textura = textura;
            this.pozice = pozice;
        }

        public void Draw(SpriteBatch spriteBarch)
        {
            spriteBarch.Draw(textura, pozice, Color.White);
        }

    }
}
