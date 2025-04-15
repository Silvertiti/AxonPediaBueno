using System.Text.RegularExpressions;

namespace AxonPediaBueno.Helpers
{
    public static class TextFormatter
    {
        public static string ConvertTextWithFormatting(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";
            int[] counters = new int[5];
            string result = input;
            string ReplaceTitle(string content, int level)
            {
                counters[level - 1]++;
                for (int i = level; i < counters.Length; i++) counters[i] = 0;

                string numbering = string.Join(".", counters.Take(level).Where(c => c > 0));
                return $"<h{level}>{numbering} {content}</h{level}>";
            }
            result = Regex.Replace(result, @"\[t1\](.*?)\;", m => ReplaceTitle(m.Groups[1].Value.Trim(), 1), RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[t2\](.*?)\;", m => ReplaceTitle(m.Groups[1].Value.Trim(), 2), RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[t3\](.*?)\;", m => ReplaceTitle(m.Groups[1].Value.Trim(), 3), RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[t4\](.*?)\;", m => ReplaceTitle(m.Groups[1].Value.Trim(), 4), RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[t5\](.*?)\;", m => ReplaceTitle(m.Groups[1].Value.Trim(), 5), RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[img\](.*?)\;", "<img src=\"$1\" class=\"clickable-image\" style=\"max-width: 100%; height: auto; cursor: zoom-in;\" />", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[g\](.*?)\;", "<strong>$1</strong>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[ita\](.*?)\;", "<em>$1</em>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[web\](.+?)\s*@\s*(.+?)\;", m =>
            {
                string linkText = m.Groups[1].Value.Trim();
                string url = m.Groups[2].Value.Trim();
                return $"<a href=\"{url}\" target=\"_blank\">{linkText}</a>";
            }, RegexOptions.Singleline);

            result = Regex.Replace(result, @"\[ul\](.*?)\;", m =>
            {
                var items = m.Groups[1].Value
                    .Split('\n')
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => $"<li>{line.TrimStart('-', ' ')}</li>");
                return $"<ul>{string.Join("", items)}</ul>";
            }, RegexOptions.Singleline);

            result = result.Replace("\r\n", "<br />").Replace("\n", "<br />");
            return result;
        }
    }
}
