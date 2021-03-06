﻿using kbs2.View.GUI;
using kbs2.World;
using kbs2.World.Structs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace kbs2.UserInterface
{
    public class MiniMapBar : IGuiViewImage
    {
        public GraphicsDevice GraphicsDevice { get; set; }

        public Coords coords => new Coords
        {
            x = 0,
            y = (int) (GraphicsDevice.Viewport.Height * .70)
        };

        public FloatCoords Coords
        {
            get { return (FloatCoords) coords; }
            set { ; }
        }

        public float Height
        {
            get { return (int) (GraphicsDevice.Viewport.Height * .30); }
            set { ; }
        }

        public float Width
        {
            get { return (int) (GraphicsDevice.Viewport.Width * .15); }
            set { ; }
        }

        public string Texture
        {
            get { return "bottombarleft"; }
            set { ; }
        }

        public Color Colour
        {
            get { return Color.White; }
            set { ; }
        }

        public int ZIndex
        {
            get { return 1; }
            set { ; }
        }

        public ViewMode ViewMode => ViewMode.Full;

        public void Click()
        {
        }

        public MiniMapBar(GraphicsDevice GraphicsDevice)
        {
            this.GraphicsDevice = GraphicsDevice;
        }
    }
}