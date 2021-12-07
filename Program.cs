using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Heap
    {
        List<int?> l = new List<int?>();
        int cnt = 0;
        int dir = 1;
        public Heap(bool dir = true)
        {
            cnt = 0;
            l = new List<int?>();
            this.dir = dir ? 1 : -1;
        }
        public void Swap(int i, int j)
        {
            var d = l[i];
            l[i] = l[j];
            l[j] = d;
        }
        public void Add(int i)
        {
            this.cnt++;
            l.Add(i);
            var index = l.Count - 1;
            while (index > 0)
            {
                var par = index - 1;
                if (dir*i > dir * l[par])
                {
                    Swap(index, par);
                }
                index = par;
            }
        }
        public int Remove()
        {
            if (cnt == 0 || l[0] == null)
            {
                throw new Exception("empty");
            }
            var top = (int)l[0];
            var i = 0;

            while (i*2+1 < cnt)
            {
                if (l[i*2+1] == null || i*2+2<= cnt - 1 && l[i*2+2] == null)
                {
                    break;
                }
                int larger;
                var left = l[i * 2 + 1];
                int? right = null;
                    if (i*2+2 <= cnt - 1)
                {
                      right = l[i * 2 + 2];

                }
                if (left == null)
                {
                    larger = i * 2 + 2;
                }
                else if (right == null)
                {
                    larger = i * 2 + 1;
                }
                else
                {
                    larger = i * 2 + 1;
                    if (dir*right > dir* left)
                    {
                        larger = i * 2 + 2;
                    }
                }
                l[i] = l[larger];
                i = larger;
                l[larger] = null;
            }
            cnt--;
            return top;
        }
        public void Print()
        {
            for(var i =0; i < l.Count; i++)
            {
                Console.Write(l[i] + " ");
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var h = new Heap(false);
            h.Add(3);
            h.Add(4);
            h.Add(234);
            h.Add(11);
            h.Print();
           var r= h.Remove();
            Console.WriteLine(r);

            h.Print();
            
        }
    }
}
