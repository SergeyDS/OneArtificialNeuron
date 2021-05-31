using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neyron
{
    class Program
    {
        
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smothing { get; set; } = 0.00001m;
            public decimal ProcessInputData(decimal input)
            {
                return input * weight;

            }
            public decimal RestoreInputData(decimal output)
            {
                return output / weight;

            }

            public void Train(decimal input,decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult)*Smothing;
                weight += correction;
            }
        }
        
        static void Main(string[] args)
        {

            decimal usd = 1;
            decimal rub = 74.09m;
            Neuron neuron = new Neuron();
            int i = 0;
            do
            {
                i++;
                neuron.Train(usd, rub);
                if(i % 100000==0)
                {
                    Console.WriteLine($"Интерация : {i}\tОшибка: {neuron.LastError}");
                }

                
            } while (neuron.LastError>neuron.Smothing || neuron.LastError < - neuron.Smothing);
            Console.WriteLine("Обучение завершено");
            
            Console.WriteLine($"{neuron.ProcessInputData(100)} rub в {100} usd");
            Console.WriteLine($"{neuron.ProcessInputData(541)} rub в {541} usd");
            Console.WriteLine($"{neuron.RestoreInputData(10)} rub в {10} usd");

            Console.ReadLine();

        }
    }
}
