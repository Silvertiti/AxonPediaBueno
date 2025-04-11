using System.Text.RegularExpressions;

namespace AxonPediaBueno.Helpers
{
    public static class TextFormatter
    {
        public static string ConvertTextWithFormatting(string input)
        {
            string result = input ?? "";

            result = Regex.Replace(result, @"\[t\](.*?)\;", "<h1>$1</h1>");
            result = Regex.Replace(result, @"\[s-t\](.*?)\;", "<h2>$1</h2>");
            result = Regex.Replace(result, @"\[ita\](.*?)\;", "<em>$1</em>");
            result = Regex.Replace(result, @"\[g\](.*?)\;", "<strong>$1</strong>");
            result = Regex.Replace(result, @"\[web\](.+?)\s*@\s*(.+?)\;", m =>
            {
                string linkText = m.Groups[1].Value.Trim();
                string url = m.Groups[2].Value.Trim();
                return $"<a href=\"{url}\" target=\"_blank\">{linkText}</a>";
            });

            // Convertir les retours à la ligne en <br />
            result = result.Replace("\r\n", "<br />").Replace("\n", "<br />");

            return result;
        }
    }
}
