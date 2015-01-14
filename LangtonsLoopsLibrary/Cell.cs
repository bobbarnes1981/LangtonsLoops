using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LangtonsLoopsLibrary
{
    public class Cell
    {
        private int m_states;

        private int m_state;

        private Dictionary<int, Dictionary<string, int>> m_table = new Dictionary<int, Dictionary<string, int>>
        {
            { 0, new Dictionary<string, int>
                {
                    {"0000", 0},
                    {"0002", 0},
                    {"0100", 0},
                    {"0200", 0},
                    {"2000", 0},
                    {"2162", 1},
                    {"2172", 1},
                }
            },
            { 1, new Dictionary<string, int>
                {
                    {"2012", 1},
                    {"2062", 1},
                    {"2072", 1},
                    {"2102", 1},
                    {"2112", 1},
                    {"2162", 1},
                    {"2602", 6},
                    {"2612", 6},
                    {"2702", 7},
                    {"2712", 7},
                }
            },
            { 2, new Dictionary<string, int>
                {
                    {"0026", 2},
                    {"0027", 2},
                    {"0021", 2},
                    {"0201", 2},
                    {"0221", 2},
                    {"0220", 2},
                    {"0226", 2},
                    {"0227", 2},
                    {"1020", 2},
                    {"1200", 2},
                    {"1220", 2},
                    {"6020", 2},
                    {"6220", 2},
                    {"7020", 2},
                    {"7220", 2},
                }
            },
            { 6, new Dictionary<string, int>
                {
                    {"2112", 1},
                    {"2012", 1},
                }
            },
            { 7, new Dictionary<string, int>
                {
                    {"2112", 1},
                    {"2012", 1},
                }
            },
        };

        public Cell(int states, int state)
        {
            m_states = states;
            m_state = state;
        }

        public int State
        {
            get { return m_state; }
        }

        public void RotateState()
        {
            m_state++;
            if (m_state >= m_states)
            {
                m_state = 0;
            }
        }

        public Cell React(string input)
        {
            if (m_table.ContainsKey(m_state) == false)
            {
                throw new Exception(string.Format("State {0} not implemented.", m_state));
            }

            if (m_table[m_state].ContainsKey(input) == false)
            {
                throw new Exception(string.Format("State {0} input {1} not implemented.", m_state, input));
            }

            return new Cell(m_states, m_table[m_state][input]);
        }
    }
}
