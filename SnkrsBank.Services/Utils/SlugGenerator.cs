namespace SnkrsBank.Services.Utils
{
    using System.Globalization;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class SlugGenerator
    {
        public static string GenerateSlug(string phrase)
        {
            string str = RemoveDiacritics(phrase).ToLower();

            // invalid chars
            str = Regex.Replace(str, @"[^a-z0-9\s-]", string.Empty);

            // convert multiple spaces into one space
            str = Regex.Replace(str, @"\s+", " ").Trim();

            // cut and trim
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens

            return str;
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
