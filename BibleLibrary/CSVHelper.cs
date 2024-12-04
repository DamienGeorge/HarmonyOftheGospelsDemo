﻿using BibleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleLibrary
{
    public class CSVHelper
    {
        public string FilePath { get; set; }
        public CSVHelper(string filePath)
        {
            FilePath = filePath;
        }


        public List<string> GetStories()
        {
            List<string> stories = new();
            ReadHarmonyFile().ForEach(x => stories.Add(x.Story));

            return stories;
        }

        private List<HarmonyBibleVerse> ReadHarmonyFile()
        {
            List<HarmonyBibleVerse> harmonyBibleVerses = new();
            try
            {
                var fileData = File.ReadAllLines(FilePath);

                foreach (var line in fileData)
                {
                    string[] entry = line.Split(',');

                    HarmonyBibleVerse harmonyVerse = MapHarmonyVerse(entry);
                    harmonyBibleVerses.Add(harmonyVerse);

                }
            }
            catch
            {
                //Log error    
            }

            return harmonyBibleVerses;
        }

        public HarmonyBibleVerse GetVersesByStory(string story)
        {
            HarmonyBibleVerse harmonyBible = new();

            harmonyBible = ReadHarmonyFile()
                .Where(x => x.Story == story)
                .FirstOrDefault();

            return harmonyBible;

        }

        private HarmonyBibleVerse MapHarmonyVerse(string[] entry)
        {
            HarmonyBibleVerse harmonyVerse = new();
            harmonyVerse.Story = entry[0];
            harmonyVerse.MatthewVerse = entry[1];
            harmonyVerse.MarkVerse = entry[2];
            harmonyVerse.LukeVerse = entry[3];
            harmonyVerse.JohnVerse = entry[4];

            return harmonyVerse;
        }
    }
}