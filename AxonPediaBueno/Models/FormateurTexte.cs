using System.Text.RegularExpressions;

namespace AxonPediaBueno.Helpers
{
    public static class TextFormatter
    {
        public static string ConvertTextWithFormatting(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";
            string result = input;
            int[] counters = new int[5];
            result = Regex.Replace(result, @"\[t([1-5])\](.*?)\;", match =>
            {
                int level = int.Parse(match.Groups[1].Value);
                counters[level - 1]++;

                for (int i = level; i < counters.Length; i++)
                {
                    counters[i] = 0;
                }
                var numbering = string.Join('.', counters.Take(level));
                var title = match.Groups[2].Value.Trim();

                return $"<h{level}>{numbering} {title}</h{level}>";

            }, RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[g\](.*?)\;", "<strong>$1</strong>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[ita\](.*?)\;", "<em>$1</em>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[web\](.+?)\s*@\s*(.+?)\;", m =>
            {
                string txt = m.Groups[1].Value.Trim();
                string url = m.Groups[2].Value.Trim();
                return $"<a href=\"{url}\" target=\"_blank\">{txt}</a>";
            }, RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[img\](.*?)\;", "<img src=\"$1\" class=\"clickable-image\" style=\"max-width: 100%; height: auto; cursor: zoom-in;\" />", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[ul\](.*?)\;", m =>
            {
                var items = m.Groups[1].Value
                    .Split('\n')
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => $"<li>{line.TrimStart('-', ' ')}</li>");
                return $"<ul>{string.Join("", items)}</ul>";
            }, RegexOptions.Singleline);
            return result.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

    }
}
