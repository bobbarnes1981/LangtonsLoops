using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using LangtonsLoopsLibrary;
using SdlDotNet.Core;
using SdlDotNet.Input;
using SdlDotNet.Graphics;

namespace LangtonsLoopsSDL
{
    public class Viewer
    {
        private Surface m_video;

        private Grid m_grid;

        private float m_elapsed;

        private float m_step;

        private int m_xScale;

        private int m_yScale;

        private int m_width;

        private int m_height;

        private bool m_running;

        public Viewer(Table table, int gridWidth, int gridHeight, int scale, float step)
        {
            m_grid = new Grid(table, gridWidth, gridHeight);
            m_xScale = scale;
            m_yScale = scale;
            m_width = gridWidth * m_xScale;
            m_height = gridHeight * m_yScale;
            m_step = step;
            m_running = false;
        }

        public void Load(int x, int y, int[,] data)
        {
            m_grid.Load(x, y, data);
        }

        public void Run()
        {
            m_elapsed = 0;
            m_video = Video.SetVideoMode(m_width, m_height, 32, false, false, false, true);
            Events.Quit += new EventHandler<QuitEventArgs>(ApplicationQuitEventHandler);
            Events.Tick += new EventHandler<TickEventArgs>(ApplicationTickEventHandler);
            Events.KeyboardDown += new EventHandler<KeyboardEventArgs>(ApplicationKeyboardEventHandler);
            Events.KeyboardUp += new EventHandler<KeyboardEventArgs>(ApplicationKeyboardEventHandler);
            Events.MouseButtonDown += new EventHandler<MouseButtonEventArgs>(ApplicationMouseEventHandler);
            Events.Run();
        }

        private Color[] m_colors = new Color[]
        {
            Color.Black,
            Color.Blue,
            Color.Red,
            Color.GreenYellow,
            Color.Yellow,
            Color.Fuchsia,
            Color.White,
            Color.Aqua,
        };

        private void ApplicationTickEventHandler(object sender, TickEventArgs args)
        {
            m_elapsed += args.SecondsElapsed;
            Video.WindowCaption = string.Format("Langton's Loops [FPS: {0} | Elapsed: {1}]", args.Fps, m_elapsed);
            if (m_elapsed > m_step)
            {
                if (m_running)
                {
                    m_grid.Step();
                }

                m_elapsed -= m_step;
            }

            for (int y = 0; y < m_grid.Cells.GetLength(1); y++)
            {
                for (int x = 0; x < m_grid.Cells.GetLength(0); x++)
                {
                    m_video.Draw(new SdlDotNet.Graphics.Primitives.Box(new Point(x * m_xScale, y * m_yScale), new Size(m_xScale, m_yScale)), m_colors[m_grid.Cells[x, y]], false, true);
                }
            }

            m_video.Update();
        }

        private void ApplicationKeyboardEventHandler(object sender, KeyboardEventArgs args)
        {
            switch(args.Key)
            {
                case Key.Return:
                    if (args.Down)
                    {
                        m_running = !m_running;
                    }
                    break;
            }
        }

        private void ApplicationMouseEventHandler(object sender, MouseButtonEventArgs args)
        {
            if (args.Button == MouseButton.PrimaryButton && args.ButtonPressed)
            {
                m_grid.RotateState(args.Position.X / m_xScale, args.Position.Y / m_yScale);
            }
        }

        private void ApplicationQuitEventHandler(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }
    }
}
