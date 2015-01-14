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
            if (m_state > m_states)
            {
                m_state = 0;
            }
        }

        public void React(int[] neighbourhood)
        {
            
        }
    }
}
