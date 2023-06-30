using System.Text;

namespace Shared.DatEntity.Parsing
{
    public class GenericParser
    {
        private IEnumerable<string> ParseTextFromFile()
        {
            using var stream = new StreamReader(FileAddress, Encoding.Default);
            var content = stream.ReadToEnd();
            var i = 0;
            return content.Split(Delimiter).Select(s => $"{(i++ == 0 ? "" : Delimiter)}{s}");
        }

        private string FileAddress { get; set; }
        private byte FirstIndex { get; set; }
        private string Delimiter { get; set; }

        public GenericParser(string delimiter, string path, byte index, string separator = "\t")
        {
            Dictionary = new List<Dictionary<string, string[][]>>();
            Delimiter = delimiter;
            FileAddress = path;
            FirstIndex = index;

            foreach (var block in ParseTextFromFile())
            {
                var lines = block.Split(
                        new[] { "\r\n", "\r", "\n" },
                        StringSplitOptions.None
                    )
                    .Select(s => s.Split(separator))
                    .Where(s => s.Length > FirstIndex)
                    .GroupBy(x => x[FirstIndex]).ToDictionary(x => x.Key, y => y.ToArray());

                if (lines.Count == 0) continue;

                Dictionary.Add(lines);
            }
        }

        public List<Dictionary<string, string[][]>> Dictionary { get; set; }
    }
}
