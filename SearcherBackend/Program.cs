using System;
using System.Collections.Generic;

namespace SearcherBackend
{
    class Program
    {
        public static void Main(string[] args)
        {
            // const String fileName = @"C:\Users\lanil\OneDrive\Рабочий стол\Db\samples\sample2.docx";
            //Console.Write(Searcher.FindKeyword("Lorem", fileName, true));
            const String dirName = @"C:\Users\lanil\OneDrive\Рабочий стол\Db\samples";
            List<String> matches = Searcher.FindKeywordInDir("a", dirName, true);
            foreach (var file in matches)
            {
                Console.WriteLine("Found: {0}", file);
            }
        }
    }
}