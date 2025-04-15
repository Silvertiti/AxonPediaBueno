using System.Text.RegularExpressions;

namespace AxonPediaBueno.Helpers
{
    public static class TextFormatter
    {
        public static string ConvertTextWithFormatting(string input)
        {
            string result = input ?? "";

            result = Regex.Replace(result, @"\[t1\](.*?)\;", "<h1>$1</h1>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[t2\](.*?)\;", "<h2>$1</h2>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[t3\](.*?)\;", "<h3>$1</h3>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[t4\](.*?)\;", "<h4>$1</h4>", RegexOptions.Singleline);
            result = Regex.Replace(result, @"\[t5\](.*?)\;", "<h5>$1</h5>", RegexOptions.Singleline);
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
