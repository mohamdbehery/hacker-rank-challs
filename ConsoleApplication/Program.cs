using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections;

namespace HackerRank30DaysCode
{
    public class Person
    {
        public string Name { get; set; }
    }
    class Check<T>
    {
        // Gerefic function to compare all data types  
        public bool Compare(T var1, T var2)
        {
            if (var1.Equals(var2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string x = "Eric";
            Person p = new Person();
            p.Name = "Eric";
            UpdateName(p);
            StringReferenceType(x);

            Console.WriteLine(p.Name);
            Console.WriteLine(x);

            Check<int> obj1 = new Check<int>();
            bool intResult = obj1.Compare(2, 3);

            Console.ReadLine();
        }
        static void UpdateName(Person p)
        {
            p.Name = "Joe";
        }

        static void StringReferenceType(string x)
        {
            x = "Joe";
        }

        static int beautifulDays(int i, int j, int k)
        {
            int beautifulDays = 0;
            for (int ii = i; ii <= j; ii++)
            {
                int n = ii, reverse = 0, rem;
                while (n != 0)
                {
                    rem = n % 10;
                    reverse = reverse * 10 + rem;
                    n /= 10;
                }
                if ((ii - reverse) % k == 0)
                    beautifulDays++;
            }
            return beautifulDays;
        }

        static string angryProfessor(int k, int[] a)
        {
            return a.Count(s => s <= 0) < k ? "YES" : "NO";
        }

        static int utopianTree(int n)
        {
            int growth = 1;
            int doubleCyclesCount = Math.Abs(n / 2);
            bool singleCycle = n % 2 > 0;
            int counter = singleCycle ? doubleCyclesCount + 1 : doubleCyclesCount;
            for (int i = 1; i <= counter; i++)
            {
                if (singleCycle && i == counter)
                    growth *= 2;
                else
                    growth = growth * 2 + 1;
            }
            return growth;
        }
        static int designerPdfViewer(int[] h, string word)
        {
            List<int> lettersSize = new List<int>();
            foreach (var letter in word)
            {
                int letterIndex = char.ToUpper(letter) - 65;
                lettersSize.Add(h[letterIndex]);
            }
            return lettersSize.Max() * word.Length;
        }

        static int hurdleRace(int k, int[] height)
        {
            return Math.Max(height.Max() - k, 0);
        }

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            var st = new Stack<int>();
            foreach (var score in scores.Distinct())
                st.Push(score);

            var ranks = new List<int>();
            foreach (var score in alice)
            {
                while ((st.Count > 0) && score > st.Peek())
                    st.Pop();
                ranks.Add(st.Count + (st.Count > 0 && score == st.Peek() ? 0 : 1));
            }

            return ranks.ToArray();
        }

        public static int pickingNumbers(List<int> a)
        {
            int maxLength = 0;
            Dictionary<int, List<int>> props = new Dictionary<int, List<int>>();
            for (int i = 0; i < a.Count - 1; i++)
            {
                List<int> numCount = new List<int>();
                for (int j = i + 1; j < a.Count; j++)
                {
                    if (numCount.Count == 0) numCount.Add(a[i]);
                    bool add = true;
                    foreach (var item in numCount)
                    {
                        if (Math.Abs(item - a[j]) > 1) add = false;
                    }
                    if (add)
                        numCount.Add(a[j]);
                }

                props.Add(i, numCount);
            }
            maxLength = props.Max(x => x.Value.Count);
            return maxLength;
        }

        static int formingMagicSquare(int[][] s)
        {
            List<int> totals = new List<int>();

            int[][,] arr = new int[8][,]
            {
                        new int[,] { {8, 1, 6}, {3, 5, 7}, {4, 9, 2} },
                        new int[,] { {6, 1, 8}, {7, 5, 3}, {2, 9, 4} },
                        new int[,] { {4, 9, 2}, {3, 5, 7}, {8, 1, 6} },
                        new int[,] { {2, 9, 4}, {7, 5, 3}, {6, 1, 8} },
                        new int[,] { {8, 3, 4}, {1, 5, 9}, {6, 7, 2} },
                        new int[,] { {4, 3, 8}, {9, 5, 1}, {2, 7, 6} },
                        new int[,] { {6, 7, 2}, {1, 5, 9}, {8, 3, 4} },
                        new int[,] { {2, 7, 6}, {9, 5, 1}, {4, 3, 8} }

            };

            int total;

            for (int i = 0; i < arr.Length; i++)
            {
                total = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    for (int k = 0; k < s.Length; k++)
                    {

                        total += Math.Abs(s[j][k] - arr[i][j, k]);


                    }
                }
                totals.Add(total);
            }
            return totals.Min();
        }

        static bool loadBalancer(int[] A)
        {
            List<int> machines = new List<int>();
            int segment = 0;
            int segmentIndex = Math.Abs((A.Length - 2) / 3);
            for (int i = 0; i < A.Length; i++)
            {
                if (i == segmentIndex || i == (segmentIndex * 2) + 1)
                {
                    machines.Add(segment);
                    segment = 0;
                    continue;
                }
                if (i == A.Length - 1)
                {
                    segment += A[i];
                    machines.Add(segment);
                }
                segment += A[i];
            }
            if (machines.Count == 3 && machines.Count(x => x == machines[0]) == 3)
                return true;
            return false;
        }

        static int minRounds(int N, int K)
        {
            if (K == 0)
                return N - 1;

            int chips = N;
            int rounds = 0;
            for (int i = N; i > 0; i--)
            {
                if (chips == 0)
                    break;

                if (K > 0)
                {
                    rounds++;
                    chips /= 2;
                    K--;
                }
                else
                {
                    rounds++;
                    chips--;
                }
            }
            return rounds;
        }

        static void addKey(ref Dictionary<string, int> magicNums, string key, int itemSum)
        {
            //if (magicNums.ContainsKey(itemSum))
            //    magicNums[itemSum] += 1;
            //else
            magicNums.Add(key, itemSum);
        }
        static string catAndMouse(int x, int y, int z)
        {
            if (Math.Abs(z - x) < Math.Abs(z - y))
                return "Cat A";
            else if (Math.Abs(z - x) > Math.Abs(z - y))
                return "Cat B";
            else
                return "Mouse C";
        }

        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            List<int> moneySpent = new List<int>();
            foreach (var keybord in keyboards)
            {
                foreach (var drive in drives)
                {
                    if (keybord + drive <= b)
                        moneySpent.Add(keybord + drive);
                }
            }
            int max = -1;
            if (moneySpent.Count > 0)
                max = moneySpent.Max();

            return max;
        }

        static int pageCount(int n, int p)
        {
            return Math.Min(p / 2, n / 2 - p / 2);
        }

        static long repeatedString(string s, long n)
        {
            long repeats = Math.Abs(n / s.Length);
            long occurance = repeats * s.Count(x => x == 'a');
            long remaining = n - (s.Length * repeats);
            if (remaining > 0)
            {
                for (int i = 0; i < remaining; i++)
                {
                    if (s[i] == 'a')
                        occurance++;
                }
            }
            return occurance;
        }

        static int jumpingOnClouds(int[] c)
        {
            int count = 0;
            List<int> countedSteps = new List<int>();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 0 && (i == 0) || (i > 0 && !countedSteps.Contains(i - 1)))
                {
                    count++;
                    countedSteps.Add(i);
                }
            }
            return count;
        }

        static int sockMerchant(int n, int[] ar)
        {

            int count = 0;
            var array = ar.Distinct();
            foreach (var item in array)
            {
                int colorCount = ar.Count(x => x == item);
                count += Math.Abs(colorCount / 2);
            }
            return count;
        }

        private static void bitwiseAnd()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(nums[0]);
                int k = Convert.ToInt32(nums[1]);
                int i, j, max = 0;
                for (i = 1; i <= n; i++)
                {
                    for (j = i + 1; j <= n; j++)
                    {
                        int ans = 0;
                        ans = i & j;
                        if (ans > max && ans < k)
                            max = ans;
                    }
                }
                Console.WriteLine(max);
            }
        }

        private static void regExpression()
        {
            List<string> Names = new List<string>();

            string pattern = "@gmail.com$";
            int N = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < N; a0++)
            {
                string[] tokens_firstName = Console.ReadLine().Split(' ');
                string firstName = tokens_firstName[0];
                string emailID = tokens_firstName[1];

                Regex rgx = new Regex(pattern);
                if (rgx.IsMatch(emailID))
                {
                    Names.Add(firstName);
                }
            }

            Names.Sort();

            foreach (string name in Names)
            {
                Console.WriteLine(name);
            }
        }

        static string dayOfProgrammer(int year)
        {
            if (year % 4 == 0 && (year < 1918 || year % 400 == 0 || year % 100 != 0))
                return "12.09." + year;
            else if (year == 1918)
                return "26.09.1918";
            return "13.09." + year;
        }

        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int num = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        num++;
                }
            }
            return num;
        }

        static int birthday(List<int> s, int d, int m)
        {
            int num = 0;
            for (int i = 0; i < s.Count; i++)
            {
                var dd = s.Skip(i).Take(m).Sum();
                if (dd == d)
                    num++;
            }

            return num;
        }

        static int[] breakingRecords(int[] scores)
        {
            int scoreLength = scores.Length;

            int mostScore = scores[0];
            int worstScore = scores[0];
            int mostScoreIncreased = 0;
            int worstScoreDecreased = 0;

            for (int i = 0; i < scoreLength; i++)
            {
                int curScore = scores[i];

                if (mostScore < curScore)
                {
                    mostScore = curScore;
                    mostScoreIncreased++;
                }
                if (worstScore > curScore)
                {
                    worstScore = curScore;
                    worstScoreDecreased++;
                }
            }
            return new int[] { mostScoreIncreased, worstScoreDecreased };
        }

        public static int getTotalX(List<int> a, List<int> b)
        {
            int total = 0;
            int number = a.Max();

            Enumerable.Range(number, b.Min())
                .ToList()
                .ForEach(n =>
                {
                    if (a.All(e => number % e == 0 || e % number == 0)
                        && b.All(e => number % e == 0 || e % number == 0))
                        total++;

                    number++;
                });

            return total;
        }

        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            string canMeet = "NO";
            for (int i = 1; i <= 10000; i++)
            {
                if (x1 + (v1 * i) == x2 + (v2 * i))
                {
                    canMeet = "YES";
                    break;
                }
            }
            return canMeet;
        }

        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int[] landedApples = apples.Select(x => x + a).ToArray();
            int[] landedOranges = oranges.Select(x => x + b).ToArray();
            Console.WriteLine(landedApples.Where(x => x >= s && x <= t).Count());
            Console.WriteLine(landedOranges.Where(x => x >= s && x <= t).Count());
            Console.ReadLine();
        }

        private static void latePenalty()
        {
            string[] actual = Console.ReadLine().Split(' ');
            string[] due = Console.ReadLine().Split(' ');
            DateTime actualDate = new DateTime(Convert.ToInt32(actual[2]), Convert.ToInt32(actual[1]), Convert.ToInt32(actual[0]));
            DateTime dueDate = new DateTime(Convert.ToInt32(due[2]), Convert.ToInt32(due[1]), Convert.ToInt32(due[0]));
            int fine = 0;
            if (DateTime.Compare(actualDate, dueDate) > 0)
            {
                if (actualDate.Year != dueDate.Year)
                    fine = 10000;
                else if (actualDate.Month != dueDate.Month)
                    fine = 500 * (actualDate.Month - dueDate.Month);
                else if (actualDate.Day != dueDate.Day)
                    fine = 15 * (actualDate.Day - dueDate.Day);
            }
            Console.WriteLine(fine);
            Console.ReadLine();
        }

        private static void primeNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                string Prime = "";
                if (number == 2)
                    Prime = "Prime";
                if (number == 1 || number % 2 == 0)
                    Prime = "Not prime";

                for (int j = 3; j * j <= number;)
                {
                    if (number % j == 0)
                    {
                        Prime = "Not prime";
                        break;
                    }
                    j += 2; // no need to check even so increment to next odd number.
                }
                Console.WriteLine(Prime);
            }
            Console.ReadLine();
        }

        public static List<int> sortDates(List<int> list)
        {
            return list.Select(x => new { x, count = list.Where(y => y == x).Count() }).Distinct().Where(z => z.count == 1).Select(z => z.x).Take(2).ToList();
        }

        public static string reverseWords(string inputWords)
        {
            var xx = inputWords.Split(' ').ToList();
            xx.Reverse();
            return xx.Aggregate((x, z) => x + " " + z);
        }

        public static void PrintArray<E>(E[] A)
        {
            foreach (var item in A)
            {
                Console.WriteLine(item);
            }
        }
        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> gradesResult = new List<int>();
            foreach (var grade in grades)
            {
                if (grade < 38)
                    gradesResult.Add(grade);
                else
                {
                    int nextMultipleOf5 = (grade / 5 + 1) * 5;
                    if (nextMultipleOf5 - grade < 3)
                        gradesResult.Add(nextMultipleOf5);
                    else
                        gradesResult.Add(grade);
                }
            }
            return gradesResult;
        }

        static string timeConversion(string s)
        {
            string newFormat = "";
            string[] timePeices = s.Split(':');
            if (timePeices.Length == 3)
            {
                string seconds = timePeices[2];
                seconds = seconds.Substring(0, 2);
                int hours = Convert.ToInt32(timePeices[0]);
                if (timePeices[2].Contains("PM") && hours < 12)
                    hours += 12;
                else if (timePeices[2].Contains("AM") && hours == 12)
                    hours = 0;

                newFormat = string.Format("{0}:{1}:{2}", hours < 10 ? "0" + hours.ToString() : hours.ToString(), timePeices[1], seconds);
            }
            return newFormat;
        }

        public static void bubbleSort(int[] a)
        {
            int numberOfSwaps = 0;
            int endPosition = a.Length - 1;
            int swapPosition;
            while (endPosition > 0)
            {
                swapPosition = 0;
                for (int i = 0; i < endPosition; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        int tmp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = tmp;
                        numberOfSwaps++;
                        swapPosition = i;
                    }
                }
                endPosition = swapPosition;
            }
            Console.WriteLine("Array is sorted in " + numberOfSwaps + " swaps.");
            Console.WriteLine("First Element: " + a[0]);
            Console.WriteLine("Last Element: " + a[a.Length - 1]);
        }


        static void miniMaxSum(int[] arr)
        {
            long result1 = 0;
            long result2 = 0;
            long max = arr.Max();
            long min = arr.Min();
            for (int i = 0; i < arr.Length; i++)
            {
                result1 += arr[i];
                result2 += arr[i];
            }
            Console.WriteLine("{0} {1}", result1 - max, result2 - min);
        }

        public static int divisorSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                    sum += i;
            }
            return sum;
        }
        private static void stairCase()
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
                Console.WriteLine(new String('#', i + 1).PadLeft(N, ' '));

            //int n = Convert.ToInt32(Console.ReadLine());
            //for (int i = 1; i <= n; i++)
            //{
            //    StringBuilder line = new StringBuilder();
            //    for (int j = n; j > 0; j--)
            //    {
            //        if (j <= i)
            //            line.Append("#");
            //        else
            //            line.Append(" ");
            //    }
            //    Console.WriteLine(line);
            //}
            Console.ReadLine();
        }

        static void plusMinus(int[] arr)
        {
            int posCount = 0, negCount = 0, zeroCount = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                    posCount++;
                else if (arr[i] < 0)
                    negCount++;
                else
                    zeroCount++;
            }
            var pos = (double)posCount / (double)arr.Length;
            var neg = (double)negCount / (double)arr.Length;
            var zero = (double)zeroCount / (double)arr.Length;
            Console.WriteLine(string.Format("{0:0.000000}", pos));
            Console.WriteLine(string.Format("{0:0.000000}", neg));
            Console.WriteLine(string.Format("{0:0.000000}", zero));
        }
        public static int diagonalDifference(int[,] arr, int n)
        {
            int d1 = 0, d2 = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        d1 += arr[i, j];

                    if (i == n - j - 1)
                        d2 += arr[i, j];
                }
            }
            return Math.Abs(d1 - d2);
        }
    }
    class Student
    {
        private int[] testScores;
        /*	
        *   Class Constructor
        *   
        *   Parameters: 
        *   firstName - A string denoting the Person's first name.
        *   lastName - A string denoting the Person's last name.
        *   id - An integer denoting the Person's ID number.
        *   scores - An array of integers denoting the Person's test scores.
        */
        public Student(string firstName, string lastName, int id, int[] scores)
        {
            testScores = scores;
            Console.WriteLine("Name: " + lastName + ", " + firstName);
            Console.WriteLine("ID: " + id);
        }

        /*	
        *   Method Name: Calculate
        *   Return: A character denoting the grade.
        */
        public char Calculate()
        {
            double average = testScores.Average();
            if (average < 40)
                return 'T';
            else if (average >= 40 && average < 55)
                return 'D';
            else if (average >= 55 && average < 70)
                return 'P';
            else if (average >= 70 && average < 80)
                return 'A';
            else if (average >= 80 && average < 90)
                return 'E';
            else if (average >= 90 && average <= 100)
                return 'O';

            return 'W';
        }
    }

    class Calculator
    {
        public int power(int n, int p)
        {
            double result = 0;
            if (n < 0 || p < 0)
            {
                throw new Exception("n and p should be non-negative.");
            }
            else
            {
                result = Math.Pow(n, p);
            }
            return Convert.ToInt32(result);
        }
    }
    class AngryAnimals
    {

        public static long factorial(int n)
        {
            return (n == 1) ? 1 : n * factorial(n - 1);
        }


        public static int angryAnimals1(int n, List<int> a, List<int> b)
        {
            int cabins = 0;
            Dictionary<int, List<int>> animalEnimies = getAnimalEnimies(a, b, n);
            int count = 1, i = 1;
            while (i <= n)
            {
                string cabin = Enumerable.Range(count, i - count + 1).ToList().ConvertAll(x => x.ToString()).Aggregate((x, y) => x + " " + y);
                var subset = cabin.Split(' ').ToList().ConvertAll(x => int.Parse(x.ToString()));
                if (subset.Count == 1)
                    cabins++;
                else
                {
                    var subsetWithoutNext = subset.OrderBy(x => x).Take(subset.Count - 1).ToList();
                    int currentAnimal = subset[0];
                    int nextAnimal = subset[subset.Count - 1];
                    if ((!animalEnimies.ContainsKey(currentAnimal) || !animalEnimies[currentAnimal].Distinct().Contains(nextAnimal)) &&
                        !(nextAnimal - currentAnimal > 1 && animalEnimies.ContainsKey(nextAnimal) && animalEnimies[nextAnimal].Any()) || !(animalEnimies[nextAnimal].Distinct().Intersect(subsetWithoutNext).Any()))
                    {
                        cabins++;
                    }
                    else
                    {
                        i = ++count;
                        continue;
                    }
                }
                if (i == n)
                    i = ++count;
                else
                    i++;
            }
            return cabins;
        }

        public static long angryAnimals(int n, List<int> a, List<int> b)
        {
            int cabins = 0;
            Dictionary<int, List<int>> animalEnimies = getAnimalEnimies(a, b, n);
            for (int currentAnimal = 1; currentAnimal <= n; currentAnimal++)
            {
                cabins++;
                List<int> cabin = new List<int>() { currentAnimal };
                for (int nextAnimal = currentAnimal + 1; nextAnimal <= n; nextAnimal++)
                {
                    if ((!animalEnimies.ContainsKey(currentAnimal) || !animalEnimies[currentAnimal].Contains(nextAnimal)) &&
                        !(nextAnimal - currentAnimal > 1 && animalEnimies.ContainsKey(nextAnimal) && animalEnimies[nextAnimal].Any()) || !(animalEnimies[nextAnimal].Intersect(cabin).Any()))
                    {
                        cabin.Add(nextAnimal);
                        cabins++;
                    }
                    else
                        break;
                }
            }
            return cabins;
        }

        public static Dictionary<int, List<int>> getAnimalEnimies(List<int> a, List<int> b, int n)
        {
            Dictionary<int, List<int>> animalsEnimies = new Dictionary<int, List<int>>();
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] <= n)
                {
                    if (animalsEnimies.ContainsKey(a[i]))
                        animalsEnimies[a[i]].Add(b[i]);
                    else
                        animalsEnimies.Add(a[i], new List<int> { b[i] });
                }
                if (b[i] <= n)
                {
                    if (animalsEnimies.ContainsKey(b[i]))
                        animalsEnimies[b[i]].Add(a[i]);
                    else
                        animalsEnimies.Add(b[i], new List<int> { a[i] });
                }
            }
            return animalsEnimies;
        }


        static void openAndClosePrices(string firstDate, string lastDate, string weekDay)
        {
            WebClient client = new WebClient();
            List<DayPriceModel> results = new List<DayPriceModel>();
            results = getAllData(client, results, 1);
            DateTime formatedFirstDate = Convert.ToDateTime(firstDate);
            DateTime formatedLastDate = Convert.ToDateTime(lastDate);
            var output = (from result in results
                          where Convert.ToDateTime(result.date) >= formatedFirstDate &&
                          Convert.ToDateTime(result.date) <= formatedLastDate &&
                          Convert.ToDateTime(result.date).DayOfWeek.ToString().Contains(weekDay)
                          select result.date + " " + result.open + " " + result.close).ToList();
            output.ForEach(i => Console.WriteLine("{0}", i));
            Console.ReadLine();
        }

        static List<DayPriceModel> getAllData(WebClient webClient, List<DayPriceModel> results, int pageNumber)
        {
            int page = pageNumber;
            List<DayPriceModel> allResults = results;
            var callResult = webClient.DownloadString("https://jsonmock.hackerrank.com/api/stocks?page=" + page);
            DayModel response = JsonConvert.DeserializeObject<DayModel>(callResult);
            allResults.AddRange(response.data);
            if (response.page <= response.total_pages)
                getAllData(webClient, allResults, page + 1);

            return allResults;
        }
        class DayModel
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<DayPriceModel> data { get; set; }
        }

        class DayPriceModel
        {
            private string _date = "";
            public string date
            {
                get { return _date; }
                set
                {
                    DateTime temp = Convert.ToDateTime(value);
                    _date = temp.ToString("d-MMMM-yyyy");
                }
            }

            public float open { get; set; }
            public float close { get; set; }
            public float high { get; set; }
            public float low { get; set; }
        }

        public static void runLargeMatrix()
        {
            List<List<int>> list0 = new List<List<int>>()
            {
                new List<int>(){0, 0, 0},
                new List<int>(){0, 0, 0},
                new List<int>(){0, 0, 0},
            };

            List<List<int>> list1 = new List<List<int>>()
            {
                new List<int>(){1, 1, 1},
                new List<int>(){1, 1, 0},
                new List<int>(){1, 0, 1},
            };

            List<List<int>> list2 = new List<List<int>>()
            {
                new List<int>(){0, 1, 1},
                new List<int>(){1, 1, 0},
                new List<int>(){1, 0, 1},
            };
            List<List<int>> list3 = new List<List<int>>()
            {
                new List<int>(){1, 1, 1, 1, 1},
                new List<int>(){1, 1, 1, 0, 0},
                new List<int>(){1, 1, 1, 0, 0},
                new List<int>(){1, 1, 1, 0, 0},
                new List<int>(){1, 1, 1, 1, 1}
            };
            List<List<int>> list4 = new List<List<int>>()
            {
                new List<int>(){1, 1, 1, 1, 1, 1},
                new List<int>(){1, 1, 1, 0, 0, 1},
                new List<int>(){1, 1, 1, 1, 1, 1},
                new List<int>(){1, 1, 1, 1, 1, 1},
                new List<int>(){1, 1, 1, 1, 1, 1},
                new List<int>(){1, 1, 1, 1, 1, 1}
            };
            Console.WriteLine(largestMatrix(list0));
            Console.ReadLine();
        }

        public static int largestMatrix(List<List<int>> arr)
        {
            int maxWhiteSquare = 0;
            bool hasWhiteCells = false;
            List<int> whiteSquares = new List<int>();
            for (int row = 0; row < arr.Count - 1; row++)
            {
                for (int column = 0; column < arr[row].Count - 1; column++)
                {
                    int pointRow = row, pointColumn = column;
                    int point = 0;
                    for (int i = row; i < arr[row].Count; i++)
                    {
                        if (pointRow < arr.Count && pointColumn < arr[row].Count && arr[pointRow][pointColumn] == 1 &&
                            isRowWhite(arr, row, pointRow, pointColumn) && isColumnWhite(arr, column, pointRow, pointColumn))
                        {
                            hasWhiteCells = true;
                            point++;
                            pointRow++;
                            pointColumn++;
                        }
                        else
                            break;
                    }
                    if (!whiteSquares.Contains(point))
                        whiteSquares.Add(point);
                    maxWhiteSquare = whiteSquares.Count > 0 ? whiteSquares.Max() : 0;
                }
            }
            maxWhiteSquare = hasWhiteCells ? maxWhiteSquare : 0;
            return maxWhiteSquare;
        }

        private static bool isRowWhite(List<List<int>> arr, int row, int pointRow, int pointColumn)
        {
            for (int i = row; i <= pointRow; i++)
            {
                if (arr[i][pointColumn] == 0)
                    return false;
            }
            return true;
        }
        private static bool isColumnWhite(List<List<int>> arr, int column, int pointRow, int pointColumn)
        {
            for (int i = column; i <= pointColumn; i++)
            {
                if (arr[pointRow][i] == 0)
                    return false;
            }
            return true;
        }

        public static int largestMatrix2(List<List<int>> arr)
        {
            int maxWhiteSquare = 0;
            bool hasWhiteCells = false;
            List<int> whiteSquares = new List<int>();
            for (int cell = 0; cell < arr.Count; cell++)
            {
                int maxRow = 0;
                int maxColumn = 0;
                for (int i = cell; i < arr.Count; i++)
                {
                    bool stop = false;
                    for (int j = 0; j < arr[i].Count; j++)
                    {
                        if (arr[i][j] == 1 && (i == 0 || arr[i - 1][j] == 1) && (j == 0 || arr[i][j - 1] == 1) &&
                            (maxColumn == arr[i].Count - 1 || arr[i][maxColumn] == 1))
                        {
                            hasWhiteCells = true;
                            maxRow = i;
                            maxColumn = j;
                        }
                        else
                        {
                            stop = true;
                            break;
                        }
                    }
                    if (stop && i == maxColumn)
                        break;
                }
                maxRow = maxRow == 0 ? 0 : maxRow - cell;
                if (maxRow == maxColumn && !whiteSquares.Contains(maxRow))
                    whiteSquares.Add(maxRow);
            }
            maxWhiteSquare = whiteSquares.Count > 0 ? whiteSquares.Max() : 0;
            maxWhiteSquare = hasWhiteCells ? maxWhiteSquare + 1 : 0;
            return maxWhiteSquare;
        }
        static List<string> packNumbers(List<int> arr)
        {
            // arr = new List<int>() {5, 5, 5, 7, 7, 3, 4, 7};
            List<string> packedArr = new List<string>();
            if (arr.Count > 0)
            {
                int prev = -1;
                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i] != prev)
                    {
                        packedArr.Add(arr[i] + ":" + 1);
                        prev = arr[i];
                    }
                    else
                    {
                        var prevSpit = packedArr[packedArr.Count - 1].Split(':');
                        packedArr[packedArr.Count - 1] = prevSpit[0] + ":" + (Int32.Parse(prevSpit[1]) + 1);
                    }
                }


                for (var i = 0; i < packedArr.Count; i++)
                {
                    if (packedArr[i].Split(':')[1] == "1")
                        packedArr[i] = packedArr[i].Split(':')[0];
                }
            }

            return packedArr;
        }
        static int getLuckyFloorNumber(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i.ToString().Contains("4") || i.ToString().Contains("13"))
                {
                    n++;
                }
            }

            return n;
        }
    }


}
