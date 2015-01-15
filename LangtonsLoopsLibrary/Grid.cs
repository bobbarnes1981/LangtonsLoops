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
        private int m_states;
        private int[,] m_cells;
        private Dictionary<int, Dictionary<string, int>> m_table = new Dictionary<int, Dictionary<string, int>>
        {
            { 0, new Dictionary<string, int>
                {
                    {"0000", 0},
                    {"0002", 0},
                    {"0010", 0},
                    {"0020", 0},
                    {"0100", 0},
                    {"0200", 0},
                    {"0201", 0},
                    {"0202", 0},
                    {"0206", 2},
                    {"0207", 0},
                    {"0600", 2},
                    {"0700", 0},
                    {"1200", 0},
                    {"2000", 0},
                    {"2002", 0},
                    {"2012", 0},
                    {"2072", 1},
                    {"2112", 0},
                    {"2122", 1},
                    {"2162", 1},
                    {"2172", 1},
                    {"2200", 0},
                    {"2712", 1},
                    {"6200", 2},
                    {"7200", 0},
                }
            },
            { 1, new Dictionary<string, int>
                {
                    {"0000", 1},
                    {"0100", 1},
                    {"0600", 6},
                    {"2002", 1},
                    {"2012", 1},
                    {"2022", 0},
                    {"2062", 0},
                    {"2072", 7},
                    {"2102", 1},
                    {"2112", 1},
                    {"2122", 1},
                    {"2162", 1},
                    {"2172", 1},
                    {"2602", 6},
                    {"2612", 6},
                    {"2622", 6},
                    {"2702", 7},
                    {"2712", 7},
                    {"2722", 7},
                }
            },
            { 2, new Dictionary<string, int>
                {
                    {"0000", 2},
                    {"0026", 2},
                    {"0027", 2},
                    {"0020", 2},
                    {"0021", 2},
                    {"0100", 2},
                    {"0200", 2},
                    {"0201", 2},
                    {"0206", 2},
                    {"0207", 2},
                    {"0221", 2},
                    {"0220", 2},
                    {"0226", 2},
                    {"0227", 2},
                    {"0700", 7},
                    {"1020", 2},
                    {"1200", 2},
                    {"1220", 2},
                    {"6020", 2},
                    {"6200", 2},
                    {"6220", 2},
                    {"7020", 2},
                    {"7200", 2},
                    {"7220", 2},
                }
            },
            { 6, new Dictionary<string, int>
                {
                    {"0000", 1},
                    {"2012", 0},
                    {"2112", 1},
                }
            },
            { 7, new Dictionary<string, int>
                {
                    {"0000", 1},
                    {"2012", 0},
                    {"2022", 0},
                    {"2102", 0},
                    {"2112", 1},
                    {"2122", 1},
                }
            },
        };

        public Grid(int width, int height, int states)
        {
            m_width = width;
            m_height = height;
            m_states = states;
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
                    if (m_table.ContainsKey(m_cells[x, y]) == false)
                    {
                        Console.WriteLine(string.Format("State {0} not implemented.", m_cells[x, y]));
                        nextCells[x, y] = m_cells[x, y];
                        continue;
                    }

                    string neighbourhood = GetVonNeumannNeighbourhood(x, y);

                    if (m_table[m_cells[x, y]].ContainsKey(neighbourhood) == false)
                    {
                        Console.WriteLine(string.Format("State {0} input {1} not implemented.", m_cells[x, y], neighbourhood));
                        nextCells[x, y] = m_cells[x, y];
                        continue;
                    }

                    nextCells[x, y] = m_table[m_cells[x, y]][neighbourhood];
                }
            }

            m_cells = nextCells;
        }

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
            if (x - 1 > -1)
            {
                neighbourhood += m_cells[x - 1, y];
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

            return neighbourhood;
        }

        public void RotateState(int x, int y)
        {
            m_cells[x, y]++;
            if (m_cells[x, y] >= m_states)
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
