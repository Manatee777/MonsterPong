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
    class herni_jadro
    {

        private Game1 game;
        private bool stisknuto_hrac1; //mozna nepouziji
        private bool stisknuto_hrac2;

        private List<strela> list_strel;
        private List<strela> list_strel2;

        private List<prekazka> list_prekazek;

        private List<odrazova_plocha> list_odrazovych_ploch;

        private List<Hrac1> list_hrac1;
        private List<Hrac2> list_hrac2;


        //textury pro herni logiku
        private Texture2D vystrel;
        private Texture2D vystrel2;


        public herni_jadro(Game1 game, List<strela> list_strel, List<strela> list_strel2,
            List<prekazka> list_prekazek, List<odrazova_plocha> list_odrazovych_ploch, 
            List<Hrac1> list_hrac1, List<Hrac2> list_hrac2,
            Texture2D vystrel, Texture2D vystrel2)
            //zde musi byt VSECHNY komponenty, ktere musi znat game1 a nejsou v jine tride, game1 je zde proto, aby slo hru poustet z vice game komponent
        {
            this.game = game;
            this.vystrel = vystrel;
            this.vystrel2 = vystrel2;
            this.list_strel = list_strel;
            this.list_strel2 = list_strel2;
            this.list_prekazek = list_prekazek;
            this.list_odrazovych_ploch = list_odrazovych_ploch;
            this.list_hrac1 = list_hrac1;
            this.list_hrac2 = list_hrac2;
            stisknuto_hrac1 = false;
            stisknuto_hrac2 = false;
            
        }


        public void Update(KeyboardState keyboard, Hrac1 hrac, Hrac2 hrac_2, GameTime gameTime)
        {
            if (keyboard.IsKeyDown(Keys.Space) && !stisknuto_hrac1)
            {
                list_strel.Add(new strela(vystrel, new Vector2(hrac.VratPozici().X + hrac.VratRectangle().Width / 2 - vystrel.Width / 2, hrac.VratPozici().Y - vystrel.Height / 2 - 10), 2));
                stisknuto_hrac1 = true;
                //vytvorit se nova strela v kolekci, ktera ma texturu, slozitejsi pozici a rychlost
            }


            if (keyboard.IsKeyUp(Keys.Space) && stisknuto_hrac1)
                stisknuto_hrac1 = false;


            //hrac2

            if (keyboard.IsKeyDown(Keys.Q) && !stisknuto_hrac2)
            {
                list_strel2.Add(new strela(vystrel2, new Vector2(hrac_2.VratPozici().X + hrac_2.VratRectangle().Width / 2 - vystrel2.Width / 2, hrac_2.VratPozici().Y - vystrel2.Height / 2 + hrac_2.VratRectangle().Width + 35) , -2)); //3 na konci je posun strely od kolize pryc
                stisknuto_hrac2 = true;
                //vytvorit se nova strela v kolekci, ktera ma texturu, slozitejsi pozici a rychlost
            }


            if (keyboard.IsKeyUp(Keys.Q) && stisknuto_hrac2)
                stisknuto_hrac2 = false;




           


            foreach (strela item in list_strel)
            {
                item.Update(gameTime);
            }

            foreach (strela item in list_strel2)
            {
                item.Update(gameTime);
            }








            //<SEKCE> KOLIZNÍ SYSTÉM <SEKCE>



            //PRUCHOD NEODRAZEJICI PLOCHOU HRAC1

            foreach (strela item in list_strel)
            {
                item.Update(gameTime);
                foreach (prekazka prekazka_item in list_prekazek)
                {
                    item.Kolize_prekazka1(prekazka_item, game);
                }

            } 
                
            

            for (int i = 0; i < list_strel.Count; i++)
            {
                if (list_strel[i].smazani_strely) //bool ze tridy strela
                {
                    list_strel.RemoveAt(i);
                }
            }


            //kolizni system
            //PRUCHOD NEODRAZEJICI PLOCHOU HRAC2

            foreach (strela item in list_strel2)
            {
                item.Update(gameTime);
                foreach (prekazka prekazka_item in list_prekazek)
                {
                    item.Kolize_prekazka1(prekazka_item, game);
                }
            } 

            

            for (int i = 0; i < list_strel2.Count; i++) //nejprve se pro vsechny strely v kolekci zavola kolize a ta se nasledne iteraci pole vyhodnoti pro smazani
            {
                if (list_strel2[i].smazani_strely)
                {
                    list_strel2.RemoveAt(i);
                }
            }


            //kolizni system
            //PRUCHOD ODRAZEJICI PLOCHOU HRAC1


            foreach (strela item in list_strel)
            {
                item.Update(gameTime);
                foreach (odrazova_plocha odraz_item in list_odrazovych_ploch)
                {
                    item.Kolize_odrazova_plocha(odraz_item, game);
                }

            }



            //kolizni system
            //PRUCHOD ODRAZEJICI PLOCHOU HRAC2


            foreach (strela item in list_strel2)
            {
                item.Update(gameTime);
                foreach (odrazova_plocha odraz_item in list_odrazovych_ploch)
                {
                    item.Kolize_odrazova_plocha(odraz_item, game);
                }

            }


        


           foreach (Hrac2 item in list_hrac2)
           {
               item.Update(gameTime); //musi byt, jinak se vubec neprovede pohyb z update bloku hrac2 tridy
               foreach (prekazka objekt in list_prekazek)
               {
                   item.Kolize_prekazka_Top(objekt, game);
                   item.Kolize_prekazka_Bottom(objekt, game);
                   item.Kolize_prekazka_Left(objekt, game);
                   item.Kolize_prekazka_Right(objekt, game);
                   
               }

           }


           foreach (Hrac1 item in list_hrac1)
           {
                //musi byt, jinak se vubec neprovede pohyb z update bloku hrac2 tridy
               item.Update(gameTime);
               foreach (prekazka objekt in list_prekazek)
               {
                   item.Kolize_prekazka_Top(objekt, game);
                   item.Kolize_prekazka_Bottom(objekt, game);
                   item.Kolize_prekazka_Left(objekt, game);
                   item.Kolize_prekazka_Right(objekt, game);

               }

           }






           foreach (Hrac1 item in list_hrac1)
           {
               //musi byt, jinak se vubec neprovede pohyb z update bloku hrac2 tridy
               
               foreach (odrazova_plocha objekt in list_odrazovych_ploch)
               {
                   item.Kolize_odraz_Bottom(objekt, game);
                   item.Kolize_odraz_Top(objekt, game);
                   item.Kolize_odraz_Right(objekt, game);
                   item.Kolize_odraz_Left(objekt, game);

               }

           }


            foreach (Hrac2 item in list_hrac2)
           {
               //musi byt, jinak se vubec neprovede pohyb z update bloku hrac2 tridy
               
               foreach (odrazova_plocha objekt in list_odrazovych_ploch)
               {
                   item.Kolize_odraz_Bottom(objekt, game);
                   item.Kolize_odraz_Top(objekt, game);
                   item.Kolize_odraz_Right(objekt, game);
                   item.Kolize_odraz_Left(objekt, game);

               }

           }



            //player vs player


           foreach (Hrac1 item in list_hrac1)
           {
               //musi byt, jinak se vubec neprovede pohyb z update bloku hrac2 tridy
               
               foreach (Hrac2 objekt in list_hrac2)
               {
                   item.Kolize_prekazka_Top(objekt, game);
                   item.Kolize_prekazka_Bottom(objekt, game);
                   item.Kolize_prekazka_Left(objekt, game);
                   item.Kolize_prekazka_Right(objekt, game);

               }

           }


           foreach (Hrac2 item in list_hrac2)
           {
               //musi byt, jinak se vubec neprovede pohyb z update bloku hrac2 tridy

               foreach (Hrac1 objekt in list_hrac1)
               {
                   item.Kolize_prekazka_Top(objekt, game);
                   item.Kolize_prekazka_Bottom(objekt, game);
                   item.Kolize_prekazka_Left(objekt, game);
                   item.Kolize_prekazka_Right(objekt, game);

               }

           }


           //pro hrac vs strela
           foreach (strela item in list_strel)
           {
              

               foreach (Hrac1 objekt in list_hrac1)
               {
                   item.Kolize_hrac1(objekt, game);
                 

               }

           }


           foreach (strela item in list_strel2)
           {
               foreach (Hrac2 objekt in list_hrac2)
               {
                   item.Kolize_hrac2(objekt, game);
               }
           }


         //hrac2


           foreach (strela item in list_strel2)
           {


               foreach (Hrac1 objekt in list_hrac1)
               {
                   item.Kolize_hrac1(objekt, game);


               }

           }


           foreach (strela item in list_strel)
           {


               foreach (Hrac2 objekt in list_hrac2)
               {
                   item.Kolize_hrac2(objekt, game);
                   


               }

           }

           

        }

    }
}


