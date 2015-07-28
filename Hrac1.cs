using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.IO;


namespace skakacka
{
    class Hrac1 : herni_objekt
    {
        //zastupce game1 classy, ktera v sobe ma zakladni operace
        private Game1 game;

        public bool zivot;
        public bool vystreleno;
        public bool skoceno;


        public Vector2 rychlost;

        public Hrac1(Texture2D textura, Vector2 pozice, Game1 game)
            : base(textura, pozice) //textura a pozice derivovany z nadrazene classy
        {
            this.textura = textura;
            this.pozice = pozice;
            this.game = game;
            skoceno = true;
            vystreleno = true;
            zivot = true;
        }


        //update logika
        public void Update(GameTime gameTime)
        {

            pozice += rychlost; //pozice = soucasna pozice + rychlost pri kazdem ticku update

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && pozice.X < game.GetScreenSize().X - textura.Width) rychlost.X = 3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && pozice.X > 0) rychlost.X = -3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Up) && pozice.Y > 370) rychlost.Y = -3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Down) && pozice.Y < 660 - textura.Height) rychlost.Y = 3f;
            else { rychlost.X = 0f; rychlost.Y = 0f; }

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, pozice, Color.White);
        }

      








        //kolize prekazka klasicka

        public void Kolize_prekazka_Top(prekazka objekt, Game1 game)
        {
            if (VratRectangle().vrchol(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_prekazka_Bottom(prekazka objekt, Game1 game)
        {
            if (VratRectangle().spodek(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_prekazka_Left(prekazka objekt, Game1 game)
        {
            if (VratRectangle().levy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    rychlost.X = 0f;
                }

            }


        }


        public void Kolize_prekazka_Right(prekazka objekt, Game1 game)
        {
            if (VratRectangle().pravy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    rychlost.X = 0f;
                }

            }



        }





        //kolize prekazka odrazova



        public void Kolize_odraz_Top(odrazova_plocha objekt, Game1 game)
        {
            if (VratRectangle().vrchol(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_odraz_Bottom(odrazova_plocha objekt, Game1 game)
        {
            if (VratRectangle().spodek(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_odraz_Left(odrazova_plocha objekt, Game1 game)
        {
            if (VratRectangle().levy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    rychlost.X = 0f;
                }

            }


        }


        public void Kolize_odraz_Right(odrazova_plocha objekt, Game1 game)
        {
            if (VratRectangle().pravy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    rychlost.X = 0f;
                }

            }



        }

        //kolize player vs player




        public void Kolize_prekazka_Top(Hrac2 objekt, Game1 game)
        {
            if (VratRectangle().vrchol(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_prekazka_Bottom(Hrac2 objekt, Game1 game)
        {
            if (VratRectangle().spodek(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_prekazka_Left(Hrac2 objekt, Game1 game)
        {
            if (VratRectangle().levy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    rychlost.X = 0f;
                }

            }


        }


        public void Kolize_prekazka_Right(Hrac2 objekt, Game1 game)
        {
            if (VratRectangle().pravy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    rychlost.X = 0f;
                }

            }



        }





      
    }
}