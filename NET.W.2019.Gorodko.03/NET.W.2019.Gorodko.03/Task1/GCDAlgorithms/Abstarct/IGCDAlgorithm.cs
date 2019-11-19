namespace NET.W._2019.Gorodko._03.Task1.GCDAlgorithms.Abstarct
{
    /// <summary>
    /// Contains method for calculation the greatest common divisor
    /// </summary>
    public interface IGCDAlgorithm
    {
        /// <summary>
        /// Calculates the greatest common divisor
        /// </summary>
        /// <param name="number1">The number for calculation GCD</param>
        /// <param name="number2">The number for calculation GCD</param>
        /// <returns>The greatest common divisor</returns>
        int Execute(int number1, int number2);
    }
}
