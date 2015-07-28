using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace skakacka
{
    class herni_objekt
    {
        //vidí jen subclassy
        protected Texture2D textura;
        protected Vector2 pozice;


        public herni_objekt(Texture2D textura, Vector2 pozice)
        {
            this.textura = textura;
            this.pozice = pozice;
        }



        //funkce pro základní pozicování a texturování

        public Vector2 VratPozici()
        {
            return pozice;
        }

        public void ZiskejPozici(Vector2 ziskana_pozice)
        {
            pozice = ziskana_pozice;
        }

        public Texture2D VratTexturu()
        {
            return textura;
        }

        public Vector2 VratVelikostTextury()
        {
            return new Vector2(textura.Width, textura.Height);
        }

        public Vector2 VratStredObjektu()
        {
            return new Vector2(pozice.X + textura.Width / 2, pozice.Y + textura.Height / 2);
        }


        //základní obkresleni rectanglu

        public Rectangle VratRectangle()
        {
            return new Rectangle((int)pozice.X,(int)pozice.Y,(int)textura.Width, (int)textura.Height);
        }
        
    }
}
