using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LangtonsLoopsLibrary
{
    public class Grid
    {
        private int m_width;
        private int m_height;
        private Cell[,] m_cells;

        public Grid(int width, int height)
        {
            m_width = width;
            m_height = height;
            m_cells = new Cell[m_width, m_height];
            for (int x = 0; x < m_width; x++)
            {
                for (int y = 0; y < m_height; y++)
                {
                    m_cells[x, y] = new Cell(8, 0);
                }
            }
        }

        public void Step()
        {
            for (int x = 0; x < m_width; x++)
            {
                for (int y = 0; y < m_height; y++)
                {
                    m_cells[x, y].React(GetVonNeumannNeighbourhood(x, y));
                }
            }
        }

        public int[] GetVonNeumannNeighbourhood(int x, int y)
        {
            int[] neighbourhood = new int[4];
            if (y - 1 > -1)
            {
                neighbourhood[0] = m_cells[x, y - 1].State;
            }
            if (x - 1 > -1)
            {
                neighbourhood[1] = m_cells[x - 1, y].State;
            }
            if (y + 1 < m_width)
            {
                neighbourhood[2] = m_cells[x, y + 1].State;
            }
            if (x + 1 < m_height)
            {
                neighbourhood[3] = m_cells[x + 1, y].State;
            }

            return neighbourhood;
        }
    }
}
