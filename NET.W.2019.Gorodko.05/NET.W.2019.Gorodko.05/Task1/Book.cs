namespace NET.W._2019.Gorodko._05.Task1
{
    public class Book
    {
        #region Properties

        public string ISBN { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public int Year { get; set; }

        public int Pages { get; set; }

        public decimal Price { get; set; }

        #endregion

        #region Object overrides

        /// <summary>
        /// Overrides method Equals of System.Object
        /// </summary>
        /// <param name="obj">Object for compairing</param>
        /// <returns>Are objects the same</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!(obj is Book book))
            {
                return false;
            }

            if (this.ISBN == book.ISBN)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Overrides method GetHashCode of System.Object
        /// </summary>
        /// <returns>Hash code of the book</returns>
        public override int GetHashCode()
        { 
            return 1;
        }

        #endregion
    }
}
