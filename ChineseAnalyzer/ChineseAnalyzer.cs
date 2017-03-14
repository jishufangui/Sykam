using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using Lucene.Net;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using System.Web;
namespace ChineseAnalyzer
{
    public class ChineseAnalyzer : Analyzer
    {
    

        // Fields
        public static readonly string[] CHINESE_ENGLISH_STOP_WORDS = new string[0x141];
        //public string NoisePath = (Environment.CurrentDirectory + @"\data\sNoise.txt");
        public string NoisePath = System.Web.HttpContext.Current.Server.MapPath("/data/sNoise.txt");

        // Methods
        public ChineseAnalyzer()
        {
            StreamReader reader = new StreamReader(this.NoisePath, Encoding.UTF8);
            string str = reader.ReadLine();
            for (int i = 0; !string.IsNullOrEmpty(str); i++)
            {
                CHINESE_ENGLISH_STOP_WORDS[i] = str;
                str = reader.ReadLine();
            }
        }

        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            TokenStream stream = new ChineseTokenizer(reader);
            return new StopFilter(new StandardFilter(stream), CHINESE_ENGLISH_STOP_WORDS);
        }


    }

    internal class ChineseTokenizer : Tokenizer
    {
        // Fields
        private int bufferIndex = 0;
        private int dataLen = 0;
        private int start;
        private string text;

        // Methods
        public ChineseTokenizer(TextReader reader)
        {
            base.input = reader;
            this.text = base.input.ReadToEnd();
            this.dataLen = this.text.Length;
        }

        public override Lucene.Net.Analysis.Token Next()
        {
            int num3;
            bool flag;
            WordTree tree = new WordTree();
            tree.LoadDict();
            Hashtable chartable = WordTree.chartable;
            string text = string.Empty;
            this.bufferIndex = this.start;
            int start = this.start;
            int bufferIndex = this.bufferIndex;
            string str3 = string.Empty;
            goto Label_0342;
        Label_01E3:
            this.start = num3;
        Label_0213:
            if (chartable.Contains("word"))
            {
                return new Lucene.Net.Analysis.Token(text, this.bufferIndex, this.bufferIndex + text.Length);
            }
            this.start = start + 1;
            return new Lucene.Net.Analysis.Token(str3, bufferIndex, bufferIndex + str3.Length);
        Label_0342:
            flag = true;
            if (this.start >= this.dataLen)
            {
                return null;
            }
            string key = this.text.Substring(this.start, 1);
            if (string.IsNullOrEmpty(key.Trim()))
            {
                this.start++;
                this.bufferIndex = this.start;
            }
            else if (chartable.Contains(key))
            {
                text = text + key;
                chartable = (Hashtable)chartable[key];
                if (chartable.Contains("word") || (text.Length == 1))
                {
                    str3 = text;
                    start = this.start;
                    bufferIndex = this.bufferIndex;
                }
                this.start++;
                if (this.start == this.dataLen)
                {
                    if (chartable.Contains("word") || (text.Length == 1))
                    {
                        return new Lucene.Net.Analysis.Token(text, this.bufferIndex, this.bufferIndex + text.Length);
                    }
                    this.start = start + 1;
                    return new Lucene.Net.Analysis.Token(str3, bufferIndex, bufferIndex + str3.Length);
                }
            }
            else
            {
                if (!(text == string.Empty))
                {
                    if (tree.GetCharType(key) == -1)
                    {
                        this.start++;
                    }
                    goto Label_0213;
                }
                num3 = this.start + 1;
                switch (tree.GetCharType(key))
                {
                    case 0:
                        text = text + key;
                        goto Label_01E3;

                    case 1:
                        while (num3 < this.dataLen)
                        {
                            if (tree.GetCharType(this.text.Substring(num3, 1)) != 1)
                            {
                                break;
                            }
                            num3++;
                        }
                        text = text + this.text.Substring(this.start, num3 - this.start).ToLower();
                        goto Label_01E3;

                    case 2:
                        while (num3 < this.dataLen)
                        {
                            if (tree.GetCharType(this.text.Substring(num3, 1)) != 2)
                            {
                                break;
                            }
                            num3++;
                        }
                        text = text + this.text.Substring(this.start, num3 - this.start);
                        goto Label_01E3;
                }
                this.start++;
                this.bufferIndex = this.start;
            }
            goto Label_0342;
        }

    }

    public class WordTree
    {
        // Fields
        public static Hashtable chartable = new Hashtable();
        public static double DictLoad_Span = 0.0;
        private static bool DictLoaded = false;
        private static string DictPath = System.Web.HttpContext.Current.Server.MapPath("/data/sDict.txt");
        public string strChinese = "[一-龥]";
        public string strEnglish = "[a-zA-Z]";
        public string strNumber = "[0-9]";

        // Methods
        private void BuidDictTree()
        {
            long ticks = DateTime.Now.Ticks;
            StreamReader reader = new StreamReader(DictPath, Encoding.UTF8);
            string str2 = reader.ReadLine();
            WordTree.chartable.Add("word", null);
            while (!string.IsNullOrEmpty(str2))
            {
                Hashtable chartable = WordTree.chartable;
                for (int i = 0; i < str2.Length; i++)
                {
                    string key = str2.Substring(i, 1);
                    if (!chartable.Contains(key))
                    {
                        chartable.Add(key, new Hashtable());
                    }
                    chartable = (Hashtable)chartable[key];
                }
                if (!chartable.Contains("word"))
                {
                    chartable.Add("word", null);
                }
                str2 = reader.ReadLine();
            }
            reader.Close();
        }

        public int GetCharType(string Char)
        {
            if (new Regex(this.strChinese).IsMatch(Char))
            {
                return 0;
            }
            if (new Regex(this.strEnglish).IsMatch(Char))
            {
                return 1;
            }
            if (new Regex(this.strNumber).IsMatch(Char))
            {
                return 2;
            }
            return -1;
        }

        public void LoadDict()
        {
            if (!DictLoaded)
            {
                this.BuidDictTree();
                DictLoaded = true;
            }
        }

    }

}
