
namespace myApp {
class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一组整数");
            int length =
                Convert.ToInt32(Console.ReadLine());
            int[] arry = new int[length];
            for (int i = 0; i < length; i++)
            {
                arry[i]=
                    Convert.ToInt32(Console.ReadLine());}
            for (int j = 0; j < length; j++)
            {

                for (int m = 2; m <= arry[j]; m++)
                {
                    if (arry[j] % m == 0)
                        break;
                    if (m == arry[j])
                        Console.WriteLine(arry[j]);
                }
                                      
            }
        }
    }


}