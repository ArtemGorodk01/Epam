# Задание 1.
Даны два целых знаковых четырех байтовых числа и две позиции битов i и j (i<j). Реализовать+ алгоритм InsertNumber вставки битов с j-ого по i-ый бит одного числа в другое так, чтобы биты второго числа занимали позиции с бита j по бит i (биты нумеруются справа налево). Разработать модульные тесты (NUnit и(!) MS Unit Test) для тестирования метода.
### Выполнение
[Решение](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02/Task1/NumberInsertion.cs)<br>
[NUnit тесты](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02.NUnitTests/NumberInsertionTests.cs)<br>
[MS тесты](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorordko.02.MSTests/NumberInsertionTests.cs)
# Задание 2.
Реализовать метод FindNextBiggerNumber, который принимает положительное целое число и возвращает ближайше наибольшее целое, состоящее из цифр исходного числа, и - 1 (null), если такого числа не существует. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.<br>
Примерные тест-кейсы:<br>
[TestCase(12, ExpectedResult = 21)]<br>
[TestCase(513, ExpectedResult = 531)]<br>
[TestCase(2017, ExpectedResult = 2071)]<br>
[TestCase(414, ExpectedResult = 441)]<br>
[TestCase(144, ExpectedResult = 414)]<br>
[TestCase(1234321, ExpectedResult = 1241233)]<br>
[TestCase(1234126, ExpectedResult = 1234162)]<br>
[TestCase(3456432, ExpectedResult = 3462345)]<br>
[TestCase(10, ExpectedResult = -1)]   <br>        	
[TestCase(20, ExpectedResult = -1)]
### Выполнение
[Решение](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02/Task23/Finder.cs)<br>
[NUnit тесты](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02.NUnitTests/FinderTests.cs)<br>
[MS тесты](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorordko.02.MSTests/FinderTests.cs)
# Задание 3.
Добавить к методу FindNextBiggerNumber возможность вернуть время нахождения заданного числа, рассмотрев различные языковые возможности. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.
### Выполнение
[Решение](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02/Task23/Finder.cs)<br>
[NUnit тесты](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02.NUnitTests/FinderTests.cs)
# Задание 4.
Реализовать метод FilterDigit который принимает список целых чисел и фильтрует список, таким образом, чтобы на выходе остались только числа, содержащие заданную цифру. LINQ не использовать! Например, для цифры 7, FilterDigit (7,1,2,3,4,5,6,7,68,69,70, 15,17) -> {7, 70, 17}. Разработать модульные тесты (NUnit или MS Unit Test) для тестирования метода.
### Выполнение
[Решение](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02/Task4/Filter.cs)<br>
[NUnit тесты](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02.NUnitTests/FilterTests.cs)<br>
# Задание 5.
Реализовать алгоритм FindNthRoot, позволяющий вычислять корень n-ой степени ( n∈N ) из числа ( a∈R ) методом Ньютона с заданной точностью. Разработать модульные тесты (NUnit и (или) MS Unit Test) для тестирования метода. <br>
[TestCase(1, 5, 0.0001,ExpectedResult =1)]<br>
[TestCase(8, 3, 0.0001,ExpectedResult = 2)]<br>
[TestCase(0.001, 3, 0.0001,ExpectedResult = 0.1)]<br>
[TestCase(0.04100625,4 , 0.0001, ExpectedResult =0.45)]<br>
[TestCase(8, 3, 0.0001, ExpectedResult =2)]<br>
[TestCase(0.0279936, 7, 0.0001, ExpectedResult =0.6)]<br>
[TestCase(0.0081, 4, 0.1, ExpectedResult =0.3)]<br>
[TestCase(-0.008, 3, 0.1, ExpectedResult =-0.2)]<br>
[TestCase(0.004241979, 9, 0.00000001, ExpectedResult =0.545)]<br>
[TestCase(8, 15, -7, -5)]// <-ArgumentOutOfRangeException<br>
[TestCase(8, 15, -0.6, -0.1)]// <-ArgumentOutOfRangeException
### Выполнение
[Решение](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02/Task5/Math.cs)<br>
[NUnit тесты](https://github.com/ArtemGorodk01/Epam/blob/master/NET.W.2019.Gorodko.02/NET.W.2019.Gorodko.02.NUnitTests/MathTests.cs)<br>
