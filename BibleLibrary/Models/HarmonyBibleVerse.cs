using System.Diagnostics.CodeAnalysis;

namespace BibleLibrary.Models
{
    public class HarmonyBibleVerse
    {

        public string Story { get; set; } = String.Empty;

        [AllowNull]
        public string MatthewVerse { get; set; }
        [AllowNull]
        public string MarkVerse { get; set; }
        [AllowNull]
        public string LukeVerse { get; set; }

        [AllowNull]
        public string JohnVerse { get; set; }

        #region Constants
        public const string MatthewName = "Matthew";
        public const string MarkName = "Mark";
        public const string LukeName = "Luke";
        public const string JohnName = "John";
        #endregion

        public bool IsHeading()
        {
            if (String.IsNullOrEmpty(MatthewVerse) &&
                String.IsNullOrEmpty(MarkVerse) &&
                String.IsNullOrEmpty(LukeVerse) &&
                String.IsNullOrEmpty(JohnVerse))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string MatthewChapters
        {
            get
            {
                return GetChapterFromVerse(MatthewVerse);
            }
        }

        public string MarkChapters
        {
            get
            {
                return GetChapterFromVerse(MarkVerse);
            }
        }

        public string LukeChapters
        {
            get
            {
                return GetChapterFromVerse(LukeVerse);
            }
        }

        public string JohnChapters
        {
            get
            {
                return GetChapterFromVerse(JohnVerse);
            }
        }
        private string GetChapterFromVerse(string verse)
        {
            verse = verse.Trim();
            if (string.IsNullOrEmpty(verse) == false)
            {

                List<string> verses = new();
                List<string> chapters = new();

                if (verse.Contains(';'))
                {
                    verses = verse.Split(';').ToList();
                }
                else
                {
                    verses.Add(verse);
                }

                foreach (var entry in verses)
                {
                    var chapter = entry.Substring(0, verse.IndexOf(':'));

                    if (chapters.Contains(chapter) == false)
                    {
                        chapters.Add(chapter);
                    }
                }
                return string.Join(';', chapters);
            }
            else
            {
                return default;
            }
        }
    }

    public enum BookName
    {
        Matthew,
        Mark,
        Luke,
        John,
        All
    }
}
