﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kbs2.GamePackage;
using kbs2.GamePackage.Interfaces;
using kbs2.World;
using kbs2.World.Structs;
using Microsoft.Xna.Framework;

namespace kbs2.UserInterface
{
	public class ActionBarView : IViewImage
	{
		public GameController gameController { get; set; }
		public Coords coords => new Coords
		{
			x = (int)(gameController.GraphicsDevice.Viewport.Width * .85),
			y = (int)(gameController.GraphicsDevice.Viewport.Height * .70)
		};

		public FloatCoords Coords { get { return (FloatCoords)coords; } set {; } }
		public float Height { get { return (int)(gameController.GraphicsDevice.Viewport.Height * .30); } set {; } }
		public float Width { get { return (int)(gameController.GraphicsDevice.Viewport.Width * .15); } set {; } }
		public string Texture { get { return "bottombarright"; } set {; } }
		public Color Colour { get { return Color.White; } set {; } }
		public int ZIndex { get { return 1; } set {; } }


		public ActionBarView(GameController gameController)
		{
			this.gameController = gameController;
		}
	}
}