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
                    {"0022", 0},
                    {"0100", 0},
                    {"0200", 0},
                    {"0201", 0},
                    {"0202", 0},
                    {"0206", 2},
                    {"0207", 2},
                    {"0600", 2},
                    {"0700", 1},
                    {"1200", 0},
                    {"1224", 1},
                    {"1227", 1},
                    {"1242", 1},
                    {"1247", 1},
                    {"1272", 1},
                    {"2000", 0},
                    {"2002", 0},
                    {"2012", 0},
                    {"2020", 0},
                    {"2072", 1},
                    {"2112", 0},
                    {"2122", 1},
                    {"2142", 1},
                    {"2162", 1},
                    {"2172", 1},
                    {"2200", 0},
                    {"2214", 1},
                    {"2217", 1},
                    {"2412", 1},
                    {"2421", 1},
                    {"2712", 1},
                    {"2721", 1},
                    {"4142", 1},
                    {"4221", 1},
                    {"6200", 2},
                    {"7172", 1},
                    {"7200", 2},
                    {"7221", 1},
                }
            },
            { 1, new Dictionary<string, int>
                {
                    {"0000", 1},
                    {"0100", 1},
                    {"0102", 1},
                    {"0221", 1},
                    {"0224", 4},
                    {"0227", 7},
                    {"0400", 4},
                    {"0402", 4},
                    {"0600", 6},
                    {"0700", 7},
                    {"0702", 7},
                    {"1012", 0},
                    {"1112", 1},
                    {"1202", 1},
                    {"1212", 1},
                    {"1220", 1},
                    {"1221", 1},
                    {"1227", 7},
                    {"1712", 7},
                    {"2002", 1},
                    {"2012", 1},
                    {"2021", 1},
                    {"2022", 0},
                    {"2024", 4},
                    {"2027", 7},
                    {"2042", 4},
                    {"2062", 0},
                    {"2072", 7},
                    {"2102", 1},
                    {"2112", 1},
                    {"2121", 1},
                    {"2122", 1},
                    {"2127", 7},
                    {"2162", 1},
                    {"2172", 7},
                    {"2210", 1},
                    {"2211", 1},
                    {"2240", 4},
                    {"2270", 7},
                    {"2271", 7},
                    {"2402", 4},
                    {"2412", 4},
                    {"2602", 6},
                    {"2612", 6},
                    {"2622", 6},
                    {"2702", 7},
                    {"2712", 7},
                    {"2722", 7},
                    {"4202", 4},
                    {"4220", 4},
                    {"7202", 7},
                    {"7212", 7},
                    {"7220", 7},
                    {"7221", 7},
                }
            },
            { 2, new Dictionary<string, int>
                {
                    {"0000", 2},
                    {"0002", 2},
                    {"0012", 2},
                    {"0024", 2},
                    {"0026", 2},
                    {"0027", 2},
                    {"0020", 2},
                    {"0021", 2},
                    {"0042", 2},
                    {"0072", 2},
                    {"0100", 2},
                    {"0102", 2},
                    {"0122", 2},
                    {"0200", 2},
                    {"0201", 2},
                    {"0204", 2},
                    {"0206", 2},
                    {"0207", 2},
                    {"0212", 2},
                    {"0221", 2},
                    {"0220", 2},
                    {"0224", 2},
                    {"0226", 2},
                    {"0227", 2},
                    {"0242", 2},
                    {"0272", 2},
                    {"0402", 2},
                    {"0700", 7},
                    {"0702", 2},
                    {"1020", 2},
                    {"1022", 2},
                    {"1122", 2},
                    {"1200", 2},
                    {"1202", 2},
                    {"1212", 2},
                    {"1220", 2},
                    {"1272", 2},
                    {"1422", 2},
                    {"1722", 2},
                    {"2000", 2},
                    {"2002", 2},
                    {"2010", 2},
                    {"2012", 2},
                    {"2020", 2},
                    {"2021", 2},
                    {"2040", 2},
                    {"2042", 2},
                    {"2070", 2},
                    {"2072", 2},
                    {"2102", 2},
                    {"2120", 2},
                    {"2121", 2},
                    {"2124", 2},
                    {"2127", 2},
                    {"2201", 2},
                    {"2204", 2},
                    {"2207", 2},
                    {"2210", 2},
                    {"2211", 2},
                    {"2217", 2},
                    {"2241", 2},
                    {"2271", 2},
                    {"2402", 2},
                    {"2420", 2},
                    {"2424", 2},
                    {"2702", 2},
                    {"2720", 2},
                    {"2721", 2},
                    {"2727", 2},
                    {"4020", 2},
                    {"4022", 2},
                    {"4200", 2},
                    {"4212", 2},
                    {"4220", 2},
                    {"6020", 2},
                    {"6200", 2},
                    {"6220", 2},
                    {"7020", 2},
                    {"7022", 2},
                    {"7122", 2},
                    {"7200", 2},
                    {"7212", 2},
                    {"7220", 2},
                }
            },
            { 4, new Dictionary<string, int>
                {
                    {"0221", 0},
                    {"0212", 0},
                    {"1012", 0},
                    {"1220", 0},
                    {"2012", 0},
                    {"2102", 0},
                    {"2120", 0},
                    {"2201", 0},
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
                    {"0212", 0},
                    {"0221", 0},
                    {"1012", 0},
                    {"1220", 0},
                    {"2012", 0},
                    {"2022", 0},
                    {"2102", 0},
                    {"2112", 1},
                    {"2120", 0},
                    {"2122", 1},
                    {"2201", 0},
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
                        Console.WriteLine("{0},{1} state {2} not implemented.", x, y, m_cells[x, y]);
                        nextCells[x, y] = m_cells[x, y];
                        continue;
                    }

                    string neighbourhood = GetVonNeumannNeighbourhood(x, y);

                    if (m_table[m_cells[x, y]].ContainsKey(neighbourhood) == false)
                    {
                        Console.WriteLine("{0},{1} state {2} input {3} not implemented.", x, y, m_cells[x, y], neighbourhood);
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
