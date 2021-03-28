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
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)                         //ИквелсБлэт 
            {
                if (Length == 0)
                {
                    Add(value);
                }else
                AddInFront(value);
            }
            else
            {
                Node current = NodeByIndex(index - 1);
                Node tmp = new Node(value);

                tmp.Next = current.Next;

                current.Next = tmp;

                Length++;
            }

        } 
        public void RemoveFromTheEnd()
        {
            Node current = NodeByIndex(Length-1);
            current.Next = null;
            Length--;
            if (Length == 0)
            {
                _root = null;
                _tail = _root;
            }
        }
        public void RemoveFromTheEnd(int n)
        {
            Node current = NodeByIndex(Length - n);
                current.Next = null;
            Length -= n;
            if (Length == 0)
            {
                _root = null;
                _tail = _root;
            }
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
        public void RemoveByIndex(int index, int n)
        {
            Node current = NodeByIndex(index - 1);
            current.Next = NodeByIndex(index +n);
            Length -= n;
        }


        public int GetFirstIndexByValue(int value)
        {

            int index = -1;
            Node current = _root;
            for (int i = 0; i < Length; i++)
            {
                if (value == current.Value)
                {
                    index = i;
                    break;
                }
                current = current.Next;
            }
            return index;
        }

        public void Revers()
        {
            Node current = _root;
            Node tmp=current.Next;

            while(!(current.Next is null))
            {
                current.Next = tmp.Next;
                tmp.Next = _root;
                _root = tmp;
              
            _tail = current;
            }
        }

        public int MaxValue()
        {
            int max = _root.Value;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return max;
        }
        public int  MinValue()
        {
            int min = _root.Value;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return min;
        }
        public int IndexByMaxValue()
        {
            int max = _root.Value;
            int index = 0;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (max < tmp.Value)
                {
                    max = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }
        public int IndexByMinValue()
        {
            int min = _root.Value;
            int index = 0;
            Node tmp = _root.Next;
            for (int i = 1; i < Length; i++)
            {
                if (min > tmp.Value)
                {
                    min = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }
        public void RemoveFirstByValue( int value)
        {
            RemoveByIndex(GetFirstIndexByValue(value));

        }
        public void RemoveAllByValue( int value)
        {
           
            for (int i = 0; i < Length; i++)
            {
                if (GetNodeByIndex(i) == value)
                {
                    RemoveByIndex(i);
                    i--;
                    
                }
            }

        }



        public void AddList(LinkedList list)
        {
           AddListByIndex(list, Length);
        }

        public void AddListFromTheBeing(LinkedList list)
        {
          
            AddListByIndex(list, 0);
        }
        public void AddListByIndex(LinkedList list, int index)
        {
           

            if (index >= Length + 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

           

            if (Length == 0) 
            {
                _root = list._root;
                _tail = list._tail;
            }
            else if (list.Length > 0) 
            {
                if (index == 0) 
                {
                    list._tail.Next = _root;
                    _root = list._root;
                }
                else if (index == Length) 
                {
                    _tail.Next = list._root;
                    _tail = list._tail;
                }
                else //добавление в середину
                {
                    list._tail.Next = NodeByIndex(index);
                    NodeByIndex(index - 1).Next = list._root;
                }
            }
            this.Length += list.Length;
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
            Node currentThis = _root;
            Node currentList = list._root;
           

            if (Length <= 1)
            {
                if ( this._root == list._root)
                {
                    return true;
                }
              
            }
            while (!(currentThis.Next is null))
            {
                if (currentThis.Value != currentList.Value)
                {
                    return false;
                }
                currentThis = currentThis.Next;
                currentList = currentList.Next;
            }
           

            return true;
        }    


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //сортировка за один проход +2 переменные
    }
}
//добавление значения в конец                       +                   +   
//добавление значения в начало                      +                   +
//добавление значения по индексу                    +                   +
//удаление из конца одного элемента                 +                   +
//удаление из начала одного элемента                +                   +
//удаление по индексу одного элемента               +                   +
//удаление из конца N элементов                     +                   +
//удаление из начала N элементов                    +                   +
//удаление по индексу N элементов                   +                   +
//вернуть длину                                     +                   +
//доступ по индексу                                 +                   +
//первый индекс по значению                         +                   +
//изменение по индексу                              +                   +
//реверс (123 -> 321)                                                 +
//поиск значения максимального элемента             +                   +
//поиск значения минимального элемента              +                   +
//поиск индекс максимального элемента               +                   +
//поиск индекс минимального элемента                +                   +
//сортировка по возрастанию                                           +
//сортировка по убыванию                                              +
//удаление по значению первого (?вернуть индекс)    +                   +
//удаление по значению всех (?вернуть кол-во)       +                +   
//3 конструктора                                    +                  +
//добавление списка(вашего) в конец                 +                   +
//добавление списка в начало                        +                 +
//добавление списка по индексу                      +                 +

