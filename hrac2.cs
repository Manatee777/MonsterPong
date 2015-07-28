using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace skakacka
{
    class Hrac2 : herni_objekt
    {
        //zastupce game1 classy, ktera v sobe ma zakladni operace
        private Game1 game;

        public bool zivot;
        public bool vystreleno;
        public bool skoceno;
        public bool prilnuta_kolize_bottom_Y;

        public float smer = 0;
        public Vector2 rychlost;
        public float rotace = 0;
        private SpriteEffects efekt;
        private float meritko;
        private Vector2 bod_rotace;

        public Hrac2(Texture2D textura, Vector2 pozice, Game1 game)
            : base(textura, pozice) //textura a pozice derivovany z nadrazene classy
        {
            this.textura = textura;
            this.pozice = pozice;
            this.game = game;
            skoceno = true;
            vystreleno = true;
            zivot = true;
            prilnuta_kolize_bottom_Y = true;
            efekt = SpriteEffects.None;
            meritko = 1.0f;
            bod_rotace = new Vector2(textura.Width / 2.0f, textura.Height / 2.0f);
        }


        //update logika
        public void Update(GameTime gameTime)
        {

            pozice += rychlost; //pozice = soucasna pozice + rychlost pri kazdem ticku update

            if (Keyboard.GetState().IsKeyDown(Keys.D) && pozice.X < game.GetScreenSize().X - textura.Width) rychlost.X = 3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.A) && pozice.X > 0) rychlost.X = -3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.W) && pozice.Y > 0) rychlost.Y = -3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.S) && pozice.Y < 290 - textura.Height) rychlost.Y = 3f;
            else { rychlost.X = 0f; rychlost.Y = 0f; }

        }



        public void Draw(SpriteBatch spriteBatch)
        {
          //  spriteBatch.Draw(textura, pozice, null, Color.White, rotace, bod_rotace, meritko, efekt, 0);
            spriteBatch.Draw(textura, pozice, Color.White);
        }


        public void Kolize_prekazka_Top(prekazka objekt, Game1 game)
        {
            if (VratRectangle().vrchol(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    rychlost.Y = 0f;
                }

            }

            
        }


        public void Kolize_prekazka_Bottom(prekazka objekt, Game1 game)
        {
            if (VratRectangle().spodek(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_prekazka_Left(prekazka objekt, Game1 game)
        {
            if (VratRectangle().levy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    rychlost.X = 0f;
                }

            }


        }


        public void Kolize_prekazka_Right(prekazka objekt, Game1 game)
        {
            if (VratRectangle().pravy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    rychlost.X = 0f;
                }

            }


        }








        public void Kolize_odraz_Top(odrazova_plocha objekt, Game1 game)
        {
            if (VratRectangle().vrchol(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_odraz_Bottom(odrazova_plocha objekt, Game1 game)
        {
            if (VratRectangle().spodek(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_odraz_Left(odrazova_plocha objekt, Game1 game)
        {
            if (VratRectangle().levy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    rychlost.X = 0f;
                }

            }


        }


        public void Kolize_odraz_Right(odrazova_plocha objekt, Game1 game)
        {
            if (VratRectangle().pravy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    rychlost.X = 0f;
                }

            }



        }


        //hrac vs hrac


        public void Kolize_prekazka_Top(Hrac1 objekt, Game1 game)
        {
            if (VratRectangle().vrchol(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_prekazka_Bottom(Hrac1 objekt, Game1 game)
        {
            if (VratRectangle().spodek(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    rychlost.Y = 0f;
                }

            }


        }


        public void Kolize_prekazka_Left(Hrac1 objekt, Game1 game)
        {
            if (VratRectangle().levy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    rychlost.X = 0f;
                }

            }


        }


        public void Kolize_prekazka_Right(Hrac1 objekt, Game1 game)
        {
            if (VratRectangle().pravy(objekt.VratRectangle()))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    rychlost.X = 0f;
                }

            }



        }
       

    }
}


static class Kolize_helper
{
    const int okraj_const = 1;


    public static bool vrchol(this Rectangle rec1, Rectangle rec2)
    {
        
        return (rec1.Bottom >= rec2.Top - okraj_const && rec1.Bottom <= rec2.Top + 1 &&
            rec1.Right >= rec2.Left + 5 &&
            rec1.Left <= rec2.Right - 5);
    }


    public static bool spodek(this Rectangle rec1, Rectangle rec2)
    {

        return (rec1.Top >= rec2.Bottom - okraj_const && rec1.Top <= rec2.Bottom + 1 &&
            rec1.Right >= rec2.Left + 5 &&
            rec1.Left <= rec2.Right - 5);
    }


    public static bool levy(this Rectangle rec1, Rectangle rec2)
    {

        return (rec1.Right >= rec2.Left - okraj_const && rec1.Right<= rec2.Left + 1 &&
            rec1.Top <= rec2.Bottom + 5 &&
            rec1.Bottom >= rec2.Top - 5);
    }



    public static bool pravy(this Rectangle rec1, Rectangle rec2)
    {

        return (rec1.Left >= rec2.Right - okraj_const && rec1.Left <= rec2.Right + 1 &&
           rec1.Top <= rec2.Bottom + 5 &&
           rec1.Bottom >= rec2.Top - 5);
    }



}

