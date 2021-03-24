using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
  public  class LinkedList
    {
     

        public int Length { get; private set; }
        public int this[int index]
        {
            get
            {
                int value = GetNodeByIndex(index);
                return value;
            }
            set
            {
                Node current = NodeByIndex(index);
                current.Value = value;
            }

        }
        private Node _root;
        private Node _tail;

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }
        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }
        public LinkedList(int[] values)
        {
            Length = values.Length;
            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        public void Add(int value)
        {
            if (Length == 0)
            {
                Length++;
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Length++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
        }
        public void AddInFront(int value)
        {
            
            Node tmp =new Node(value);
            tmp.Next = _root;
            _root = tmp;

            Length++;


        }
        public void AddByIndex(int value, int index)
        {
            Node current = NodeByIndex(index-1);
            Node tmp = current.Next.Next;

            current.Next = new Node(value);

            current.Next.Next = tmp;

            Length++;

        } 
        public void RemoveFromTheEnd()
        {
            Node current = NodeByIndex(Length-1);
            current.Next = null;
            Length--;
        }
        public void RemoveFromTheEnd(int n)
        {
            Node current = NodeByIndex(Length - n);
                current.Next = null;
            Length -= n;
        }
        public void RemoveFront()
        {
            _root = _root.Next;
            Length--;
        }
        public void RemoveFront(int n)
        {
            _root = NodeByIndex(n);
            Length -= n;

        }
        public void RemoveByIndex(int index)
        {
            Node current = NodeByIndex(index - 1);
            current.Next = current.Next.Next;
            Length--;
        }
        public void RemoveByIndex(int index,int n)
        {
            Node current = NodeByIndex(index - 1);
            current.Next = NodeByIndex(index+4);
            Length -= n;
        }

        public int GetFirstIndexByValue(int value)
        {   int index = -1;
            int count = 0;
            Node current = _root;
            do
            {
                if (current.Value == value)
                {
                    index = count;
                    return index;
                }
                current = current.Next;
                count++;

            }
            while (!(current.Next is null));
            return index;
        }

        public void Revers()
        {
            Node current = _root;
            int intTmp;
           
            for(int i=0; i < Length / 2; i++)
            { Node tmp = NodeByIndex((Length-1) - i);
                intTmp = tmp.Value;
                tmp.Value = current.Value;
                current.Value = intTmp;
                current = current.Next;
            }
        }



        private int GetNodeByIndex(int index)
        {
            Node current = NodeByIndex(index);
            return current.Value;
        }
        private Node NodeByIndex(int index)
        {
            Node current = _root;
            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public override string ToString()
        {
            if (Length == 0)
            {
                return String.Empty;
            }
            else
            {
                Node current = _root;
                string s = current.Value + " ";
                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }
                return s;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList list = (LinkedList)obj;
            if (this.Length != list.Length)
            {
                return false;
            }
            Node currentThis = this._root;
            Node currentList = list._root;

            do
            {
                if (currentThis.Value != currentList.Value)
                    return false;

                currentList = currentList.Next;
                currentThis = currentThis.Next;
            }
            while (!(currentThis.Next is null));
            return true;
        }
        

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //сортировка за один проход +2 переменные
    }
}

