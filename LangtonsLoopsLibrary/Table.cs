using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangtonsLoopsLibrary
{
    public class Table
    {
        private int m_states;

        private Neighbourhood m_neighbourhood;

        private Dictionary<int, Dictionary<string, int>> m_table;

        public Table(string path)
        {
            string[] file = File.ReadAllLines(path);

            m_states = int.Parse(file[0]);
            Neighbourhood.TryParse(file[1], out m_neighbourhood);

            m_table = new Dictionary<int, Dictionary<string, int>>();

            for (int i = 2; i < file.Length; i++)
            {
                int state = int.Parse(file[i][0].ToString());
                string input = file[i].Substring(1, 4);
                int next = int.Parse(file[i][5].ToString());
                if (m_table.ContainsKey(state) == false)
                {
                    m_table.Add(state, new Dictionary<string, int>());
                }
                m_table[state].Add(input, next);
            }
        }

        public int States
        {
            get { return m_states; }
        }

        public Neighbourhood Neighbourhood
        {
            get { return m_neighbourhood; }
        }

        public int Next(int current, string input)
        {
            // todo: rotation
            return m_table[current][input];
        }
    }
}
