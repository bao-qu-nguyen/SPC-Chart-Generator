using System.Xml.Linq;
using System.Diagnostics;

namespace SPC_Chart_Generator
{
    public partial class SPCChart : Form
    {
        public List<List<float>> UserData { get; set; }
        public SPCChart()
        {
            InitializeComponent();
            List<string> header = new List<string> { "id", "col1", "col2", "col3", "col4", "col5" };
            var spc = new MakeSPC();
            UserData = GenerateUserData();
            var result = spc.InitializeSPC(header, UserData);
            foreach (var kvp in result)
            {
                string key = kvp.Key;
                List<float> floats = kvp.Value.Item1;
                List<int> ints = kvp.Value.Item2;

                Debug.WriteLine($"Key: {key}");
                Debug.WriteLine($"  Floats: {string.Join(", ", floats)}");
                Debug.WriteLine($"  Ints: {string.Join(", ", ints)}");
            }
        }

        public static List<List<float>> GenerateUserData(int rowCount = 30, int columnCount = 5)
        {
            var rand = new Random(42);
            var userData = new List<List<float>>();

            for (int i = 0; i < rowCount; i++)
            {
                var row = new List<float> { i }; // First column as index

                for (int j = 0; j < columnCount; j++)
                {
                    row.Add((float)(rand.NextDouble() * 9.0 + 1.0)); // Random between 1 and 10
                }

                userData.Add(row);
            }

            // Add 2–3 values > 10 for each column (excluding index column)
            for (int col = 1; col <= columnCount; col++)
            {
                int numHigh = rand.Next(2, 4); // 2 to 3
                var indices = new HashSet<int>();

                while (indices.Count < numHigh)
                {
                    indices.Add(rand.Next(0, rowCount));
                }

                foreach (int rowIndex in indices)
                {
                    userData[rowIndex][col] = (float)(rand.NextDouble() * 5.0 + 10.0); // Random between 10 and 15
                }
            }

            return userData;
        }


    }
}
