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
	public class StatusBar : IViewImage
	{
		public GameController GameController { get; set; }
		public Coords coords => new Coords
		{
			x = (int)(GameController.GraphicsDevice.Viewport.Width * .15),
			y = 0
		};


		public FloatCoords Coords { get { return (FloatCoords)coords; } set {; } }
		public float Height { get { return (int)(GameController.GraphicsDevice.Viewport.Width * .03); } set {; } }
		public float Width { get { return (int) (GameController.GraphicsDevice.Viewport.Width * .70); } set {; } }
		public string Texture { get { return "topbarmid"; } set {; } }
		public Color Colour { get { return Color.White; } set {; } }
		public int ZIndex { get { return 1; } set {; } }

		public StatusBar(GameController controller)
		{
			this.GameController = controller;
		}
	}
}
