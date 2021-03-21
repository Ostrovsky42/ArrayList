using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    public class ArrayList
    {

        
        public int Length{ get; private set; }
        private int[] _array;
        public int this[int index]
        {
            get
            {
                if (index > Length-1)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        public ArrayList()
        {
            Length = 0;
            _array = new int[10];
        }
        public ArrayList(int value)
        {
            Length = 1;
            _array = new int[10];
            _array[0] = value;
        }
        public ArrayList(int[] value)
        {
            Length = value.Length;
            _array = value;
            UpSize();
        }

        public void Add(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            _array[Length] = value;
            Length++;
        }       
        public void AddInFront(int value)
        {
            if (Length == _array.Length)
            {
                UpSize();
            }
            Length++;                        
            for (int i = 0; i < Length; i++)
            {
                _array[Length-i] = _array[Length-i-1];//Отдельный метод и 
            }
            _array[0] = value;
                       
        }       
        public void AddByIndex(int value, int index)
        {
            if (index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (Length == _array.Length)
            {
                UpSize();
            }
            for (int i = Length - 1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }
            _array[index] = value;
            ++Length;
        }
        public void RemoveFromTheEnd()  
        {
            Length--;
            if (Length <= _array.Length / 2)
            {
                DownSize();
            }
        }
        public void RemoveFromTheEnd(int n)
        {
            if (n > Length)
            {
                throw new Exception($"Невозможно удалить {n} элементов из списка длинной {Length} элементов");
            }
            Length -= n;
            if (Length <= _array.Length / 2)
            {
                DownSize();
            }
        }
        public void RemoveFront()
        {
            RemoveByIndex(0);
        }
        public void RemoveFront(int n)
        {
            if (n > Length)
            {
                throw new Exception($"Невозможно удалить {n} элементов из списка длинной {Length} элементов");
            }
            RemoveByIndex(0, n);
        }
        public void RemoveByIndex(int index)
        {

            if (index > Length - 1)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length--;
            if (Length <= _array.Length / 2)
            {
                DownSize();
            }

        }
        public void RemoveByIndex(int index, int n)
        {
            if (index > Length - 1)
            {
                throw new IndexOutOfRangeException();
            }
            if (n > Length - index)
            {
                throw new Exception($"Невозможно удалить {n} элементов n>(Lenght-index)");
            }

            for (int i = 0; i < n; i++)
            {
                RemoveByIndex(index);
            }
        }                           
        public int GetFirstIndexByValue(int value)
        {
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    break;
                }        
            }
            return index;
        }      
        public void Revers()
        {
            int temp;
            for (int i = 0; i < Length / 2; i++)
            { temp = _array[i];
                _array[i] = _array[Length - (i + 1)];
                _array[Length - (i + 1)] = temp;
            }
        }
        public int MaxValue()
        {
            int max = _array[0];           
            for (int i = 1; i < Length; i++)
            {
                if (max < _array[i])
                    max = _array[i];
            }
            return max;            
        }
        public int MinValue()

        {
            int min = _array[0];
            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                    min = _array[i];
            }
            return min;
        }
        public int IndexByMaxValue()
        {            
            int max = _array[0];
            int indexByMaxValue = 0;
            for (int i = 1; i <Length; i++) 
            {
                if (max < _array[i])
                {
                    max = _array[i];
                    indexByMaxValue = i;
                }
            }
            return indexByMaxValue;
      
        }
        public int IndexByMinValue()
        {
            int min = _array[0];
            int indexByMinValue = 0;

            for (int i = 1; i < Length; i++)
            {
                if (min > _array[i])
                {
                    min = _array[i];
                    indexByMinValue = i;
                }
            }
            return indexByMinValue;
        }
        public void SortAscending()
        {
            int temp;

            for (int i = 0; i <Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] < _array[min])
                        min = j;
                }
                temp = _array[min];
                _array[min] = _array[i];
                _array[i] = temp;
            }
            
        }
        public void DescendingSort()
        {
            int temp;

            for (int i = 0; i < Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] > _array[max])
                        max = j;
                }
                temp = _array[max];
                _array[max] = _array[i];
                _array[i] = temp;
            }

        }
        public void RemoveFirstByValue(int value)
        {
            int index = 0;
            for(int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    break;
                }
            }                                   //if(index==-1) не найдено
                RemoveByIndex(index);
        }
        public void RemoveAllByValue(int value)
        {
            int index = 0;           
            for (int i = 0; i < Length; i++)
            {
                do
                {
                    if (_array[i] == value)
                    {
                        index = i;
                        RemoveByIndex(index);
                    }
                } while (_array[i] == value);
            }
        }

        public void AddList(ArrayList list)
        {
            int j = 0;
            int[] tmpArray = new int[(int)((Length + list.Length) * 1.33 + 1)];
            for (int i = 0; i < (Length + list.Length); ++i)
            {
                if (i < Length)
                {
                    tmpArray[i] = _array[i];
                }
                else
                {
                    tmpArray[i] = list[j];
                    j++;
                }
            }
            _array = tmpArray;
            Length += list.Length;
        }
        public void AddListFromTheBeing(ArrayList list)
        {
            int j = 0;
            int[] tmpArray = new int[(int)((Length + list.Length) * 1.33 + 1)];
            for (int i = 0; i < (Length + list.Length); i++)
            {
                if (i < list.Length)
                {
                    tmpArray[i] = list[i];
                }
                else
                {
                    tmpArray[i] = _array[j];
                    j++;
                }
            }
            _array = tmpArray;
            Length += list.Length;
        }
        public void AddListByIndex(ArrayList list, int index)
        {
            if (index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            int j = 0;
            int k = 0;
            int[] tmpArray = new int[(int)((Length + list.Length) * 1.33 + 1)];
            for (int i = 0; i < (Length + list.Length); i++)
            {
                if (i < index)
                {
                    tmpArray[i] = _array[k];
                    k++;
                } 
                else if (i < index + list.Length)
                {
                    tmpArray[i] = list[j];
                    j++;
                }
                else
                {
                    tmpArray[i] = _array[k];
                    k++;
                }
            }
            _array = tmpArray;
            Length += list.Length;
        }
        
        private void UpSize()
    {
        int newLenght = (int)(_array.Length * 1.33 + 1);
        int[] tmpArray = new int[newLenght];
        for (int i = 0; i < _array.Length; i++)
        {
            tmpArray[i] = _array[i];
        }

        _array = tmpArray;
    }
        private void DownSize()
        {int newLenght = (int)(_array.Length * 0.67 + 1);
        int[] tmpArray = new int[newLenght];
        for (int i = 0; i < tmpArray.Length; i++)
        {
            tmpArray[i] = _array[i];
        }

        _array = tmpArray;

        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;
            if (Length != arrayList.Length)
            {
                return false;
            }
            for(int i=0; i < Length; i++)
            {
                if (_array[i] != arrayList._array[i])    //arrayList.array[]?
                {
                    return false;
                }
            }
            return true;
        }
        public override string ToString()
        {
            string s = "";
            for(int i = 0; i < Length; i++)
            {
                s += _array[i] + " ";
            }
            return s;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }



    }


    }
                                            //  Состояние             Тесты
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
//реверс (123 -> 321)                               +                   +
//поиск значения максимального элемента             +                   +
//поиск значения минимального элемента              +                   +
//поиск индекс максимального элемента               +                   +
//поиск индекс минимального элемента                +                   +
//сортировка по возрастанию                         +                   +
//сортировка по убыванию                            +                   +
//удаление по значению первого (?вернуть индекс)    +                   +
//удаление по значению всех (?вернуть кол-во)       +                   +   
//3 конструктора                                    +                   +
//добавление списка(вашего) в конец                 +                   +
//добавление списка в начало                        +                   +
//добавление списка по индексу                      +                   +
    
