using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadLibsGame
{
    class AbstractClass
    {
        public enum WordType
        {
            NOUN,
            VERB,
            ADJECTIVE,
            ADVERB
        }

        abstract class Word
        {

            protected WordType wordType { get; set; }

            public Word(WordType wordType)
            {
                this.wordType = wordType;
            }

            public override string ToString()
            {
                return wordType.ToString();
            }
        }

        class Nouns : Word
        {
            private string word { get; set; }


            public Nouns(string word, WordType wordType = WordType.NOUN) : base(wordType)
            {
                this.word = word;
            }

            public override string ToString()
            {
                return word + " " + wordType.ToString();
            }

        }

        class Verbs : Word
        {
            private string word { get; set; }


            public Verbs(string word, WordType wordType = WordType.VERB) : base(wordType)
            {
                this.word = word;
            }

            public override string ToString()
            {
                return word + " " + wordType.ToString();
            }

        }

        class Adjectives : Word
        {
            private string word { get; set; }


            public Adjectives(string word, WordType wordType = WordType.ADJECTIVE) : base(wordType)
            {
                this.word = word;
            }

            public override string ToString()
            {
                return word + " " + wordType.ToString();
            }

        }

        class Adverbs : Word
        {
            private string word { get; set; }


            public Adverbs(string word, WordType wordType = WordType.ADVERB) : base(wordType)
            {
                this.word = word;
            }

            public override string ToString()
            {
                return word + " " + wordType.ToString();
            }

        }
    }
}
