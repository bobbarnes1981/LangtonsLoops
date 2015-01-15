using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LangtonsLoopsLibrary
{
    public delegate string GetNeighbourhood(int x, int y);

    public class Grid
    {
        private int m_width;
        private int m_height;
        private int[,] m_cells;
        private Table m_table;
        private Dictionary<Neighbourhood, GetNeighbourhood> m_fetchneighbourhood;

        public Grid(Table table, int width, int height)
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

            m_fetchneighbourhood = new Dictionary<Neighbourhood, GetNeighbourhood>
            {
                { Neighbourhood.VonNeumann, GetVonNeumannNeighbourhood }
            };
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
            for (int x = 1; x < m_width-1; x++)
            {
                for (int y = 1; y < m_height-1; y++)
                {
                    nextCells[x, y] = m_table.Next(m_cells[x, y], m_fetchneighbourhood[m_table.Neighbourhood](x, y));
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
            return string.Format("{0}{1}{2}{3}", m_cells[x, y - 1], m_cells[x + 1, y], m_cells[x, y + 1], m_cells[x - 1, y]);
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
