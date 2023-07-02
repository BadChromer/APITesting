namespace RestAPI.Utilities
{
    public static class RandomGenerator
    {
        private static readonly Random random = new();

        private const string presetString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+=-?:;";

        public static string GenerateRandomString(int stringLength, string chars = presetString)
        {
            var inputChars = Enumerable.Range(0, stringLength).Select(_ => chars[random.Next(chars.Length)]).ToArray();
            return new string(inputChars);
        }
    }
}