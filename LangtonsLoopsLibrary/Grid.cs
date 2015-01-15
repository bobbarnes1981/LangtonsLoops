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
        private int[,] m_cells;
        private Table m_table;

        public Grid(int width, int height, Table table)
        {
            m_width = width;
            m_height = height;
            m_table = table;
            m_cells = new int[m_width, m_height];
            for (int x = 0; x < m_width; x++)
            {
                for (int y = 0; y < m_height; y++)
                {
                    m_cells[x, y] = 0;
                }
            }
        }

        public void Load(int xOffset, int yOffset, int[,] data)
        {
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    m_cells[x + xOffset, y + yOffset] = data[x, y];
                }
            }
        }

        public void Step()
        {
            int[,] nextCells = new int[m_width, m_height];

            for (int x = 0; x < m_width; x++)
            {
                for (int y = 0; y < m_height; y++)
                {
                    string neighbourhood;
                    switch (m_table.Neighbourhood)
                    {
                        case Neighbourhood.VonNeumann:
                            neighbourhood = GetVonNeumannNeighbourhood(x, y);
                            break;
                        default:
                            throw new Exception("Unhandled neighbourhood");
                    }

                    nextCells[x, y] = m_table.Next(m_cells[x, y], neighbourhood);
                }
            }

            m_cells = nextCells;
        }

        /// <summary>
        /// Return VonNeumann neighbourhood as string TRBL
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string GetVonNeumannNeighbourhood(int x, int y)
        {
            string neighbourhood = "";
            if (y - 1 > -1)
            {
                neighbourhood += m_cells[x, y - 1];
            }
            else
            {
                neighbourhood += "0";
            }
            if (x + 1 < m_width)
            {
                neighbourhood += m_cells[x + 1, y];
            }
            else
            {
                neighbourhood += "0";
            }
            if (y + 1 < m_height)
            {
                neighbourhood += m_cells[x, y + 1];
            }
            else
            {
                neighbourhood += "0";
            }
            if (x - 1 > -1)
            {
                neighbourhood += m_cells[x - 1, y];
            }
            else
            {
                neighbourhood += "0";
            }

            return neighbourhood;
        }

        public void RotateState(int x, int y)
        {
            m_cells[x, y]++;
            if (m_cells[x, y] >= m_table.States)
            {
                m_cells[x, y] = 0;
            }
        }

        public int[,] Cells
        {
            get { return m_cells; }
        }
    }
}
