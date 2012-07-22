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
using FlatRedBall;
using FlatRedBall.Graphics;
using FlatRedBall.Utilities;
using FlatRedBall.Input;

using PureFooty.Screens;

namespace PureFooty
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
			
			BackStack<string> bs = new BackStack<string>();
			bs.Current = string.Empty;
        }

        protected override void Initialize()
        {
            Renderer.UseRenderTargets = false;
            FlatRedBallServices.InitializeFlatRedBall(this, graphics);
			CameraSetup.SetupCamera(SpriteManager.Camera);
			GlobalContent.Initialize();


            

            /*if (FlatRedBall.Input.InputManager.Xbox360GamePads[0].IsConnected == false)
            {
                FlatRedBall.Input.InputManager.Xbox360GamePads[0].CreateDefaultButtonMap();
                FlatRedBall.Input.InputManager.Xbox360GamePads[0].ButtonMap.A = Keys.OemPeriod;
                FlatRedBall.Input.InputManager.Xbox360GamePads[0].ButtonMap.B = Keys.OemComma;
                FlatRedBall.Input.InputManager.Xbox360GamePads[1].CreateDefaultButtonMap();
                FlatRedBall.Input.InputManager.Xbox360GamePads[1].ButtonMap.LeftAnalogUp = Keys.D;
                FlatRedBall.Input.InputManager.Xbox360GamePads[1].ButtonMap.LeftAnalogLeft = Keys.X;
                FlatRedBall.Input.InputManager.Xbox360GamePads[1].ButtonMap.LeftAnalogRight = Keys.V;
                FlatRedBall.Input.InputManager.Xbox360GamePads[1].ButtonMap.LeftAnalogDown = Keys.C;
                FlatRedBall.Input.InputManager.Xbox360GamePads[1].ButtonMap.A = Keys.A;
            }*/


            
            IsMouseVisible = true;
            
			Screens.ScreenManager.Start(typeof(PureFooty.Screens.MatchScreen).FullName);

            base.Initialize();
        }


        protected override void Update(GameTime gameTime)
        {
            FlatRedBallServices.Update(gameTime);

            ScreenManager.Activity();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FlatRedBallServices.Draw();

            base.Draw(gameTime);
        }
    }
}
