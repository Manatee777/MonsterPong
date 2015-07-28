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
    class strela : herni_objekt
    {
        private int rychlost_strely;
        public bool smazani_strely { get; set; }

        public strela(Texture2D textura, Vector2 pozice, int rychlost_strely)
            : base(textura, pozice)
        {
            this.textura = textura;
            this.pozice = pozice;
            this.rychlost_strely = rychlost_strely;
            this.smazani_strely = false;
        }




        public void Update(GameTime gameTime)
        {
            pozice.Y -= rychlost_strely;
        }


        //kolizní systém

        public void Kolize_prekazka1(prekazka objekt, Game1 game)
        {
            if (VratRectangle().Intersects(objekt.VratRectangle()))
            {

                this.smazani_strely = true;
            }

        }


        public void Kolize_odrazova_plocha(odrazova_plocha objekt, Game1 game) //vzdycky musi byt v parametru zastupce tridy s kterou jdeme komunikovat
        {
            if (VratRectangle().Intersects(objekt.VratRectangle()))
            {
             rychlost_strely *= -1;
            }

        }

        public void Kolize_hrac1(Hrac1 objekt, Game1 game) //vzdycky musi byt v parametru zastupce tridy s kterou jdeme komunikovat
        {
            if (VratRectangle().Intersects(objekt.VratRectangle()))
            {
                this.smazani_strely = true;
                objekt.ZiskejPozici(new Vector2(30, 600));
              

            }

        }

          public void Kolize_hrac2(Hrac2 objekt, Game1 game) //vzdycky musi byt v parametru zastupce tridy s kterou jdeme komunikovat
        {
            if (VratRectangle().Intersects(objekt.VratRectangle()))
            {
                this.smazani_strely = true;
                objekt.ZiskejPozici(new Vector2(900, 20));
                    
            }

        }
       






        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, pozice, Color.White);
        }


        

       

    }
}
