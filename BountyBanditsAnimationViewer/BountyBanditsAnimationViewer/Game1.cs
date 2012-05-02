using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BountyBanditsAnimationViewer
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private AnimationController controller;
        private UI ui;
        
        public Game1(string[] args)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            if (args.Length > 0)
                loadController(args[0]);
            ui = new UI(this);
            ui.Visible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent(){}

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if(controller != null)
                controller.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void loadController(String path)
        {
            controller = new AnimationController();
            controller.fromXML(Content, path, this);
            ui.animCombo.Enabled = true;
            ui.animCombo.Items.Clear();
            foreach (AnimationInfo animation in controller.animations)
                ui.animCombo.Items.Add(animation.name);
            ui.animCombo.SelectedText = controller.animations[0].name;
        }

        public void setAnimation(string animation)
        {
            controller.changeAnimation(animation);
        }
    }
}
