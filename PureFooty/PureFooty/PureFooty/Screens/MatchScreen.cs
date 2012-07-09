using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Graphics.Model;
using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using FlatRedBall.Input;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
#endif

namespace PureFooty.Screens
{
	public partial class MatchScreen
	{
        float CameraSpeed = 500;
		void CustomInitialize()
		{
            SpriteManager.Camera.Z = 1000;
            SpriteManager.Camera.FarClipPlane = 5000;
            PlayerInstance.Z = 100.00001f;
            PlayerInstance.X = 0;
            PlayerInstance.Y = 0;
            //PlayerInstance.ZAcceleration = -1;

		}

		void CustomActivity(bool firstTimeCalled)
		{
            if (InputManager.Keyboard.KeyDown(Keys.Right))
                SpriteManager.Camera.XVelocity = CameraSpeed;
            else if (InputManager.Keyboard.KeyDown(Keys.Left))
                SpriteManager.Camera.XVelocity = -CameraSpeed;
            else
                SpriteManager.Camera.XVelocity = 0;
            if (InputManager.Keyboard.KeyDown(Keys.Up))
                SpriteManager.Camera.YVelocity = CameraSpeed;
            else if (InputManager.Keyboard.KeyDown(Keys.Down))
                SpriteManager.Camera.YVelocity = -CameraSpeed;
            else
                SpriteManager.Camera.YVelocity = 0;
            //SpriteManager.Camera.X = PlayerInstance.X;
            //SpriteManager.Camera.Y = PlayerInstance.Y;
            if (InputManager.Keyboard.KeyDown(Keys.OemPeriod))
                SpriteManager.Camera.ZVelocity = CameraSpeed;
            else if (InputManager.Keyboard.KeyDown(Keys.OemComma))
                SpriteManager.Camera.ZVelocity = -CameraSpeed;
            else
                SpriteManager.Camera.ZVelocity = 0;
            if (InputManager.Keyboard.KeyDown(Keys.M))
                SpriteManager.Camera.RotationX = 10;
            else
                SpriteManager.Camera.RotationX = 0;
            //SpriteManager.Camera.Z += 1;

            PlayerActivity();
            

		}

        private void PlayerActivity()
        {
            if (InputManager.Keyboard.KeyDown(Keys.D) && !PlayerInstance.IsAirbone)
                PlayerInstance.XVelocity = 100;
            else if (InputManager.Keyboard.KeyDown(Keys.A) && !PlayerInstance.IsAirbone)
                PlayerInstance.XVelocity = -100;
            else if (!PlayerInstance.IsAirbone)
                PlayerInstance.XVelocity = 0;
            if (InputManager.Keyboard.KeyDown(Keys.W) && !PlayerInstance.IsAirbone)
                PlayerInstance.YVelocity = 100;
            else if (InputManager.Keyboard.KeyDown(Keys.S) && !PlayerInstance.IsAirbone)
                PlayerInstance.YVelocity = -100;
            else if (!PlayerInstance.IsAirbone)
                PlayerInstance.YVelocity = 0;
            if (!PlayerInstance.IsAirbone && InputManager.Keyboard.KeyDown(Keys.Space))
            {
                PlayerInstance.ZVelocity = 1000;
                PlayerInstance.ZAcceleration = -1000;
                PlayerInstance.IsAirbone = true;
            }
            else if (PlayerInstance.IsAirbone && PlayerInstance.Z <= 0)
            {
                PlayerInstance.Z = 0;
                PlayerInstance.ZVelocity = 0;
                PlayerInstance.ZAcceleration = 0;
                PlayerInstance.IsAirbone = false;
            }
        }

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
