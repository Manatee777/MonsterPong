#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

#endregion

namespace skakacka
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        private Hrac1 hracuv_objekt;
        private Hrac2 hracuv_objekt_2;

        private herni_jadro zastupce_herniho_jadra;
        private List<strela> list_strel;
        private List<strela> list_strel2;
        private List<prekazka> list_prekazek;
        private List<odrazova_plocha> list_odrazovych_ploch;
        private List<Hrac1> list_hrac1;
        private List<Hrac2> list_hrac2;

        
      

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 660;
            graphics.PreferredBackBufferWidth = 960;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            list_strel = new List<strela>();
            list_strel2 = new List<strela>();
            list_prekazek = new List<prekazka>();
            list_odrazovych_ploch = new List<odrazova_plocha>();
            list_hrac1 = new List<Hrac1>();
            list_hrac2 = new List<Hrac2>();
            //nutno udelat, jinak nebude list existovat pred stiskem klavesy



            base.Initialize();//musi byt na konci tohohle eventu!
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 


        public Vector2 GetScreenSize()
        {
            return new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);  //metda vratí vzdy novy vektor sirky a vysky herniho okna
        }

     
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            hracuv_objekt = new Hrac1(Content.Load<Texture2D>("hrac1"), new Vector2(30, 600), this);
            hracuv_objekt_2 = new Hrac2(Content.Load<Texture2D>("hrac2"), new Vector2(900, 20), this);
            list_hrac1.Add(hracuv_objekt);
            list_hrac2.Add(hracuv_objekt_2);


            zastupce_herniho_jadra = new herni_jadro(this, list_strel, list_strel2, list_prekazek, list_odrazovych_ploch, list_hrac1, list_hrac2, Content.Load<Texture2D>("strela1"), Content.Load<Texture2D>("strela2"));

           
            //list_strel musi byt v game1 deklarovan proto, aby naplnil konstruktor herni logiky a zajistil fyzicke vykreslovani grafiky, 
            //konstruktoru se rekne ze instance ma dany listbox + texturu jeho členů

            list_prekazek.Add(new prekazka(Content.Load<Texture2D>("prekazka1"), new Vector2(650, 80)));
            list_prekazek.Add(new prekazka(Content.Load<Texture2D>("strom2"), new Vector2(300, 250)));

            list_prekazek.Add(new prekazka(Content.Load<Texture2D>("prekazka3"), new Vector2(550, 450)));
            list_prekazek.Add(new prekazka(Content.Load<Texture2D>("strom2"), new Vector2(200, 450)));
            list_prekazek.Add(new prekazka(Content.Load<Texture2D>("strom2"), new Vector2(750,200)));
            list_prekazek.Add(new prekazka(Content.Load<Texture2D>("strom2"), new Vector2(770,500)));
            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("prekazka3"), new Vector2(250, 150)));


            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("skala"), new Vector2(50, 150)));
            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("skala"), new Vector2(500, 200)));
            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("prekazka2"), new Vector2(300, 100)));
            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("prekazka2"), new Vector2(400, 180)));



            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("skala"), new Vector2(30, 550)));
            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("skala"), new Vector2(200, 400)));
            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("prekazka2"), new Vector2(300, 500)));
            list_odrazovych_ploch.Add(new odrazova_plocha(Content.Load<Texture2D>("prekazka2"), new Vector2(550, 380)));
         

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyboard = Keyboard.GetState();
            // TODO: Add your update logic here
            
            
           
            zastupce_herniho_jadra.Update(keyboard, hracuv_objekt, hracuv_objekt_2, gameTime);

            


            base.Update(gameTime);


           

           
           
            

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
         
            // TODO: Add your drawing code here
            GraphicsDevice.Clear(Color.ForestGreen);

            spriteBatch.Begin();



            foreach (Hrac1 item in list_hrac1)
            {
                item.Draw(spriteBatch);
            }


            foreach (Hrac2 item in list_hrac2)
            {
                item.Draw(spriteBatch);
            }


            foreach (strela item in list_strel)
            {
                item.Draw(spriteBatch);
            }

            foreach (strela item in list_strel2)
            {
                item.Draw(spriteBatch);
            }

            foreach (prekazka item in list_prekazek)
            {
                item.Draw(spriteBatch);
            }

            foreach (odrazova_plocha item in list_odrazovych_ploch)
            {
                item.Draw(spriteBatch);
            }

            spriteBatch.End();
            // // //// // //// // //// // //// // //



            base.Draw(gameTime);
        }
    }
}

static class RectanglePomoc
{
    
}