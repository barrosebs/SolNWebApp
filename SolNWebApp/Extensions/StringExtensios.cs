namespace System
{
    static class StringExtensios
    {
        /// <summary>
        /// Extension Method for length of the contents of a variable
        /// </summary>
        /// <param name="thisObj"></param>
        /// <param name="count"></param>
        /// <returns>Length of the contents of a variable</returns>
        public static string Cut(this string thisObj, int count)
        {
            if (thisObj.Length <= count)
            {
                return thisObj;
            }
            else
            {
                return thisObj.Substring(0, count) + "...";
            }
        }
    }
}
