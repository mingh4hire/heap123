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
        public int Peek()
        {
            return (int)l[0];
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
            for(var i =0; i < cnt ; i++)
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
            List<int> ns = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            Console.WriteLine("Hello World!");
            var hTop = new Heap(false);
            var hBottom = new Heap();
 
            for (int i =0; i < ns.Count; i++)
            {
                if (i == 0)
                {
                    hBottom.Add(ns[i]);
                 }
                else if (i == 1)
                {
                    var r= hBottom.Remove();
                    if (r < ns[i])
                    {
                        hBottom.Add(r);
                        hTop.Add(ns[i]);
                     }
                    else
                    {
                        hBottom.Add(ns[i]);
                        hTop.Add(r);
                    }
                }
                else if (i % 2 == 0)
                {
                    var higher = hTop.Remove();
                    if (ns[i]  < higher)
                    {
                        hBottom.Add(ns[i]);
                        hTop.Add(higher);
                    }
                    else
                    {
                        hTop.Add(ns[i]);
                        hBottom.Add(higher);
                    }
                }
                else
                {
                    if (ns[i] < hBottom.Peek())
                    {
                        hTop.Add(hBottom.Remove());

                        var r = hBottom.Remove();
                        if (r < ns[i])
                        {
                            hTop.Add(ns[i]);
                            hBottom.Add(r);
                        }
                        else
                        {
                            hTop.Add(r);
                            hBottom.Add(ns[i]);
                        }
                    }
                    else
                    {
                        hTop.Add(ns[i]);
                    }
                }
                Console.WriteLine(" i is " + i);
                hTop.Print();
                hBottom.Print();
            }
            hTop.Print();
            Console.WriteLine(  );
            hBottom.Print();
            Console.WriteLine();
            if (ns.Count % 2 == 0)
            {
                Console.WriteLine(hTop.Peek());
            }
            else
            {
                Console.WriteLine(hTop.Peek() + " " + hBottom.Peek());
            }
        }
    }
}
