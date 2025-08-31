using System.Text;

namespace TestCompressorKata
{
    internal class TextCompressor
    {
        internal string Compress(string input)
        {
            var resultBuilder = new StringBuilder();

            var characters = input.ToCharArray();

            int count = 1;
            string currentCharacter = characters.First().ToString();
            var characterCount = characters.Length;

            for (var i = 1; i < characterCount; i++)
            {
                bool newCharacter = false;
                if (characters[i].ToString() == currentCharacter)
                {
                    count++;
                }
                else
                {
                    newCharacter = true;
                }

                if (i == characterCount-1 || newCharacter)
                {
                    resultBuilder.Append(currentCharacter);
                    if (count > 1)
                    {
                        resultBuilder.Append(count);
                    }
                    count = 1;
                    currentCharacter = characters[i].ToString();
                }
            }

            return resultBuilder.ToString();
        }

        internal string Decompress(string input)
        {
            var resultBuilder = new StringBuilder();

            var characters = input.ToCharArray();

            var characterCount = characters.Length;

            for (var i = 0; i < characterCount; i++)
            {
                var currentCharacter = characters[i].ToString();
                int currentCharCount;
                var isInt = int.TryParse(currentCharacter, out currentCharCount);

                if (!isInt)
                {
                    resultBuilder.Append(characters[i].ToString());
                }
                else
                {
                    if (i - 1 < 0)
                    {
                        throw new ArgumentException("Invalid string. Cannot begin with int");
                    }

                    resultBuilder.Append(string.Concat(Enumerable.Repeat(characters[i - 1].ToString(), currentCharCount-1)));
                }
            }

            return resultBuilder.ToString();
        }
    }
}