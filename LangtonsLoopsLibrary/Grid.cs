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
            Cell[,] nextCells = new Cell[m_width, m_height];

            for (int x = 0; x < m_width; x++)
            {
                for (int y = 0; y < m_height; y++)
                {
                    try
                    {
                        nextCells[x, y] = m_cells[x, y].React(GetVonNeumannNeighbourhood(x, y));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("{0},{1} {2}", x, y, e.Message);
                    }
                }
            }

            m_cells = nextCells;
        }

        public string GetVonNeumannNeighbourhood(int x, int y)
        {
            string neighbourhood = "";
            if (y - 1 > -1)
            {
                neighbourhood += m_cells[x, y - 1].State;
            }
            else
            {
                neighbourhood += "0";
            }
            if (x - 1 > -1)
            {
                neighbourhood += m_cells[x - 1, y].State;
            }
            else
            {
                neighbourhood += "0";
            }
            if (x + 1 < m_width)
            {
                neighbourhood += m_cells[x + 1, y].State;
            }
            else
            {
                neighbourhood += "0";
            }
            if (y + 1 < m_height)
            {
                neighbourhood += m_cells[x, y + 1].State;
            }
            else
            {
                neighbourhood += "0";
            }

            return neighbourhood;
        }

        public Cell[,] Cells
        {
            get { return m_cells; }
        }
    }
}
