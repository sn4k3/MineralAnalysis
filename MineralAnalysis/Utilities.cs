using System;

namespace MineralAnalysis
{
    public static class Utilities
    {
        private static readonly string[] SuffixSize = {  "B", "KB", "MB", "GB", "TB", "PB", "EB" };
        private static readonly string[] SuffixSizeFull = {  "Byte(s)", "Kilobyte(s)", "Megabyte(s)", "Gigabytge(s)", "Terabyte(s)", "Petabyte(s)", "Exabyte(s)" };

        /// <summary>
        /// Convert bytes to a readable string with proper sufix
        /// </summary>
        /// <param name="byteCount"></param>
        /// <param name="shortSuffix"></param>
        /// <returns></returns>
        public static string BytesToString(long byteCount, bool shortSuffix = true)
        {
            if (byteCount == 0)
                return "0" + SuffixSize[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return $"{Math.Sign(byteCount) * num} {(shortSuffix ? SuffixSize[place] : SuffixSizeFull[place])}";
        }

        /// <summary>
        /// Convert bytes to a readable string with proper sufix
        /// </summary>
        /// <param name="byteCount"></param>
        /// <param name="suffix"></param>
        /// <param name="shortSuffix"></param>
        /// <returns></returns>
        public static string BytesToString(long byteCount, out string suffix, bool shortSuffix = true)
        {
            suffix = shortSuffix ? SuffixSize[0] : SuffixSizeFull[0];
            if (byteCount == 0)
                return "0" + suffix;
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            suffix = shortSuffix ? SuffixSize[place] : SuffixSizeFull[place];
            return $"{Math.Sign(byteCount) * num} {suffix}";
        }
    }
}
