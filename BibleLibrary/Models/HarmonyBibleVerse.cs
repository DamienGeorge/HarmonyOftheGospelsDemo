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
    }

}
