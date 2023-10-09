using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("请输入C#源文件的路径：");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath) && filePath.EndsWith(".cs"))
        {
            string fileContent = File.ReadAllText(filePath);

            // 统计原始行数和单词数
            int originalLineCount = File.ReadLines(filePath).Count();
            int originalWordCount = CountWords(fileContent);

            // 删除空行和注释
            string formattedContent = RemoveCommentsAndEmptyLines(fileContent);

            // 统计格式化后的行数和单词数
            int formattedLineCount = formattedContent.Split('\n').Length;
            int formattedWordCount = CountWords(formattedContent);

            Console.WriteLine($"原始行数: {originalLineCount}");
            Console.WriteLine($"原始单词数: {originalWordCount}");
            Console.WriteLine($"格式化后的行数: {formattedLineCount}");
            Console.WriteLine($"格式化后的单词数: {formattedWordCount}");

            // 统计每个单词的出现次数
            Dictionary<string, int> wordFrequency = CountWordFrequency(formattedContent);

            Console.WriteLine("\n单词出现次数：");
            foreach (var pair in wordFrequency)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
        else
        {
            Console.WriteLine("无效的文件路径或文件不是C#源文件。");
        }
    }

    // 统计单词数的辅助方法
    static int CountWords(string text)
    {
        string pattern = @"\b\w+\b"; // 使用正则表达式匹配单词
        MatchCollection matches = Regex.Matches(text, pattern);
        return matches.Count;
    }

    // 删除注释和空行的辅助方法
    static string RemoveCommentsAndEmptyLines(string text)
    {
        string[] lines = text.Split('\n');
        List<string> cleanedLines = new List<string>();

        foreach (string line in lines)
        {
            string trimmedLine = line.Trim();

            // 删除以//开头的注释行
            if (!trimmedLine.StartsWith("//") && !string.IsNullOrWhiteSpace(trimmedLine))
            {
                cleanedLines.Add(line);
            }
        }

        return string.Join("\n", cleanedLines);
    }

    // 统计单词出现次数的辅助方法
    static Dictionary<string, int> CountWordFrequency(string text)
    {
        string[] words = text.Split(new[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        foreach (string word in words)
        {
            string cleanedWord = Regex.Replace(word, @"[^A-Za-z0-9]", ""); // 删除标点符号
            if (!string.IsNullOrWhiteSpace(cleanedWord))
            {
                string lowercaseWord = cleanedWord.ToLower(); // 将单词转换为小写，以区分大小写
                if (wordFrequency.ContainsKey(lowercaseWord))
                {
                    wordFrequency[lowercaseWord]++;
                }
                else
                {
                    wordFrequency[lowercaseWord] = 1;
                }
            }
        }

        return wordFrequency;
    }
}
