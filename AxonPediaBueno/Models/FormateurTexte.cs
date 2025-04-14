using System.Text.RegularExpressions;

namespace AxonPediaBueno.Helpers
{
    public static class TextFormatter
    {
        public static string ConvertTextWithFormatting(string input)
        {
            string result = input ?? "";

            // Titre
            result = Regex.Replace(result, @"\[t\](.*?)\;", "<h1>$1</h1>", RegexOptions.Singleline);
            // Sous-titre
            result = Regex.Replace(result, @"\[s-t\](.*?)\;", "<h2>$1</h2>", RegexOptions.Singleline);
            // Texte en italique
            result = Regex.Replace(result, @"\[ita\](.*?)\;", "<em>$1</em>", RegexOptions.Singleline);
            // Texte en gras
            result = Regex.Replace(result, @"\[g\](.*?)\;", "<strong>$1</strong>", RegexOptions.Singleline);
            // Lien hypertexte
            result = Regex.Replace(result, @"\[web\](.+?)\s*@\s*(.+?)\;", m =>
            {
                string linkText = m.Groups[1].Value.Trim();
                string url = m.Groups[2].Value.Trim();
                return $"<a href=\"{url}\" target=\"_blank\">{linkText}</a>";
            }, RegexOptions.Singleline);

            // Remplacer les retours à la ligne par des <br />
            result = result.Replace("\r\n", "<br />").Replace("\n", "<br />");

            return result;
        }
    }
}
