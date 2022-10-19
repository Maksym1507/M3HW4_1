namespace M3HW4_1
{
    internal class Program
    {
        private static int _result;

        public static event Func<int, int, int> SumHandler;

        public static void SumResult(int x, int y)
        {
            TryCatch(() =>
            {
                var listOfDelegate = SumHandler.GetInvocationList();

                foreach (var item in listOfDelegate)
                {
                    _result += (int)item.DynamicInvoke(x, y);
                }
            });
        }

        public static int Sum(int x, int y) => x + y;

        public static void TryCatch(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Main()
        {
            SumHandler += Sum;
            SumHandler += Sum;

            SumResult(10, 15);

            Console.WriteLine($"The sum of the result of the two methods = {_result}");
        }
    }
}