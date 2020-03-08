namespace Common.Cryptography.Interface
{
    public interface IBase32Service
    {
        /// <summary>
        /// تبدیل عدد در مبنای 10 به مبنای 32
        /// </summary>
        /// <param name="value">عدد در مبنای ده</param>
        /// <returns>رشته ی عدد در مبنای 32</returns>
        string LongToBase(long value);

        /// <summary>
        /// تبدیل عدد در مبنای 32 به عدد مبنای 10
        /// </summary>
        /// <param name="cypherText">عدد در مبنای 32</param>
        /// <returns>عدد در مبنای 10</returns>
        long BaseToLong(string cypherText);
    }
}