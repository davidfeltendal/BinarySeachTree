using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinærSøgetræ
{
    class Program
    {
        static void Main(string[] args)
        {
            Træ træ = new Træ();
            træ.Indsæt(10);
            træ.Indsæt(5);
            træ.Indsæt(20);
            træ.Indsæt(15);
            træ.Indsæt(30);

            træ.print();
            Console.WriteLine(træ.find(15));
        }
    }

    class Træ
    {
        public Node Root;

        public bool find(int i)
        {
            bool svar = false;
            Node tmp = Root;
            while (tmp != null)
            {
                if (tmp.data == i)
                {
                    svar = true;
                    break;
                }
                else
                {
                    tmp = tmp.data > i ? tmp.Left : tmp.Right; //En anden måde at skrive if-sætning på!!(er det samme som det der står nedenunder...)
                    //if (tmp.data > i) //left
                    //{
                    //    tmp = tmp.Left;
                    //}
                    //else//right
                    //{
                    //    tmp = tmp.Right;
                    //}
                }
            }
            return svar;
        }
        public void print()
        {
            printHelp(Root);
        }

        private void printHelp(Node n)
        {
            //Console.WriteLine(n.data);//Udskriver fra venstre først
            if(n.Left != null)
                printHelp(n.Left);
            Console.WriteLine(n.data);//Udskriver sorteret
            if(n.Right != null)
                printHelp(n.Right);
            //Console.WriteLine(n.data);//Udskriver fra højre først (Bunden)
        }
        public void Indsæt(int i)
        {
            Node n = new Node();
            n.data = i;

            if (Root == null)
            {
                Root = n;
            }
            else
            {
                Node tmp = Root;
                while (tmp != null)
                {
                    if (n.data > tmp.data) //til højre
                    {
                        if (tmp.Right == null)
                        {
                            tmp.Right = n;
                            break;
                        }
                        else
                        {
                            tmp = tmp.Right;
                        }
                    }
                    else //til venstre
                    {
                        if (tmp.Left == null)
                        {
                            tmp.Left = n;
                            break;
                        }
                        else
                        {
                            tmp = tmp.Left;
                        }
                    }
                }
            }
        }
    }

    class Node
    {
        public Node Left;
        public Node Right;
        public int data;
    }
}
