using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeBeginInvoke.Controller
{
    public class Task1Controller
    {
//        Задание 1 
//Создайте оконное приложение, которое позволяет пользователю запустить несколько потоков.Один поток генерирует числа, другой буквы, третий символы. Реализуйте возможность установки пользователем приоритета для каждого из потоков.Данные необходимо выводить в оконный интерфейс.

        public static void BeginTask1(SynchronizationContext ctx,ListBox listBox)
        {
            Func<int, int, int, List<int>> func = GenerateNumber ;

            func.BeginInvoke(20, -20, 20,Task1CallBack, Tuple.Create(func, ctx, listBox));
  
        }
        public static void Task1(SynchronizationContext ctx, ListBox listBox)
        {
            Func<int, int, int, List<int>> func = GenerateNumber;

           IAsyncResult ar= func.BeginInvoke(20, -20, 20, null,null);
            List<int> list =func.EndInvoke(ar);

            ctx.Send(s => listBox.Items.AddRange(list.Cast<object>().ToArray()), null);

        }
        private static void Task1CallBack(IAsyncResult ar)
        {
            if (ar.AsyncState is Tuple<Func<int, int, int, List<int>>, SynchronizationContext, ListBox> state)
            {
                var func_ = state.Item1;
                var ctx = state.Item2;
                var lb = state.Item3;
                List<int> list = func_.EndInvoke(ar);

                ctx.Send(s => lb.Items.AddRange(list.Cast<object>().ToArray()), null);
            }

      
            
         

        }

        public static List<int> GenerateNumber(int numberCount,int minNum, int maxNum)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < numberCount; i++)
            {
                Random random = new Random();
                result.Add(random.Next(minNum,maxNum));
               Thread.Sleep(100);
            }
            return result;
        }




    }
}
