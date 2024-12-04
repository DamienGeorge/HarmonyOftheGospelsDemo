using System.Net.Http;
using System.Text;

namespace BibleLibrary.Models
{
    public class ApiResponse
    {
        public string query { get; set; }
        public string canonical { get; set; }
        public int[][] parsed { get; set; }
        public Passage_Meta[] passage_meta { get; set; }
        public string[] passages { get; set; }
        public string Display()
        {
            StringBuilder stringContent = new();
            stringContent.Append(query);
            stringContent.AppendLine(canonical);
            foreach (var line in passages)
            {
                stringContent.AppendLine(line);
            }

            return stringContent.ToString();
        }

        public string DisplayPassage()
        {
            if (passages is not null)
            {
                string mergedPassage = string.Join("\n\r", passages);
                return mergedPassage;

            }
            else
            {
                return default;
            }
        }
    }

    public class Passage_Meta
    {
        public string canonical { get; set; }
        public int[] chapter_start { get; set; }
        public int[] chapter_end { get; set; }
        public int prev_verse { get; set; }
        public int next_verse { get; set; }
        public int[] prev_chapter { get; set; }
        public int[] next_chapter { get; set; }
    }
}