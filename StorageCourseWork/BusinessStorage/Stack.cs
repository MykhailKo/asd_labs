using System;
using System.Linq;
using System.Threading;

namespace BusinessStorage
{
    public class StStack
    {
        public static StorageEventHandler OutputDel;
        public event StorageEventHandler LackOfItems;
        private static int _counter;
        public int Id { get; }
        public Good Sample { get; private set; }
        public Good[] Contents { get; private set; }

        public StStack(Good sample, int quantity)
        {
            _counter++;
            Id = _counter;
            Sample = sample;
            Contents = new Good[quantity];
            LackOfItems = OutputDel;
            for (int i = 0; i < quantity; i++) Contents[i] = (Good)sample.Clone();
        }

        public void Refill(int quant = 0)
        {
            if (quant < 0) throw new ArgumentException("The quantity of refilling cannot be negative.");
            Good[] temp = new Good[Contents.Length + quant];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = i < Contents.Length ? Contents[i] : (Good) Sample.Clone();
            }
            Contents = temp;
        }

        public Good[] Withdraw(int quant)
        {
            if (quant < 0) throw new ArgumentException("The quantity of withdrawing cannot be negative.");
            if (quant > Contents.Length)
            {
                LackOfItems?.Invoke(this, new EventArgs("There isn't enough items '" + Sample.Name + "' available, ordering new items..."));
                Refill(quant - Contents.Length + 10);
                Thread.Sleep(5000);
            }
            Good[] temp = new Good[Contents.Length - quant];
            Good[] withdPart = new Good[quant];
            for (int i = 0; i < Contents.Length; i++)
            {
                if (i < quant) withdPart[i] = Contents[i];
                else temp[i - quant] = Contents[i];
            }
            Contents = temp;
            return withdPart;
        }
    }
}