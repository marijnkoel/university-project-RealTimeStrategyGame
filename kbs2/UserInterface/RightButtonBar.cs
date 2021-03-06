﻿using kbs2.View.GUI;
using kbs2.World;
using kbs2.World.Structs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace kbs2.UserInterface
{
    class RightButtonBar : IGuiViewImage
    {
        public GraphicsDevice GraphicsDevice { get; set; }

        public Coords coords => new Coords
        {
            x = (int) (GraphicsDevice.Viewport.Width - Width),
            y = 0
        };


        public FloatCoords Coords
        {
            get { return (FloatCoords) coords; }
            set { ; }
        }

        public float Height
        {
            get { return (int) (GraphicsDevice.Viewport.Width * .03); }
            set { ; }
        }

        public float Width
        {
            get { return (int) (GraphicsDevice.Viewport.Width * .12); }
            set { ; }
        }

        public string Texture
        {
            get { return "topbarright"; }
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

        public RightButtonBar(GraphicsDevice GraphicsDevice)
        {
            this.GraphicsDevice = GraphicsDevice;
        }
    }
}