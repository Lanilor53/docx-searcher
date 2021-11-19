using System;
using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml.Packaging;

namespace SearcherBackend
{
    public static class Searcher
    {
        public static Boolean FindKeyword(String keyword, String filename, Boolean isCaseSensitive=true)
        {
            using (WordprocessingDocument document = WordprocessingDocument.Open(filename, false))
            {
                // ReSharper disable once PossibleNullReferenceException
                String text = document.MainDocumentPart.Document.InnerText;
                if(isCaseSensitive)
                {
                    if (text.Contains(keyword))
                    {
                        return true;
                    }
                }
                else
                {
                    if (text.ToLower().Contains(keyword.ToLower()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static List<String> FindKeywordInDir(String keyword, String dirPath, Boolean isCaseSensitive = true)
        {
            String[] allFiles = Directory.GetFiles(dirPath, "*.docx");
            List<String> matchingFiles = new List<String>();
            foreach (String file in allFiles)
            {
                if (FindKeyword(keyword, file, isCaseSensitive))
                {
                    matchingFiles.Add(file);
                }
            }
            return matchingFiles;
        }
    }
    
}

