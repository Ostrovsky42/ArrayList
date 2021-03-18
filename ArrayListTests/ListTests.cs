using NUnit.Framework;

namespace ArrayList

{
    public class Tests
    {


        [SetUp]
        public void Setup()
        {
        }

       

        [TestCase(new int[] { 1, 1, 1, 1, 1 }, 0, new int[]{1,1,1,1,1,0})]
       
        public void AddTestTest(int[] baseArray, int value, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.Add(value);            
           
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, 0, new int[] { 0,1, 1, 1, 1, 1})]
        public void AddInFrontTest(int[] baseArray, int value, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.AddInFront(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 1, 1, 1, 1 }, 0, 3, new int[] {  1, 1, 1, 0, 1, 1 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, 0, 5, new int[] {  1, 1, 1, 1, 1, 0 })]
        [TestCase(new int[] { }, 0, 0, new int[] { 0 })]
        public void AddByIndexTest(int[] baseArray, int value, int index, int[] expectedArray )
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.AddByIndex(value,index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 },  new int[] { 1, 2, 3, 4, 5, 6 })]
        public void RemoveFromTheEndTest(int[] baseArray,  int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.RemoveFromTheEnd();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1,2,3,4,5,6,7 }, new int[] {  2, 3, 4, 5, 6, 7 })]
        public void RemoveFrontTest(int[] baseArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.RemoveFront();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 1,2, 3, 5, 6, 7 })]
        public void RemoveByIndexTest(int[] baseArray, int index, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.RemoveByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 1, 2, 3, 4,  })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, new int[] { 1 })]
        public void RemoveFromTheEndTest(int[] baseArray, int n, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.RemoveFromTheEnd(n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] {  4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6, new int[] {  7 })]
        public void RemoveFrontTest(int[] baseArray, int n, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.RemoveFront(n);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2,4, new int[] { 1, 2, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 5,2, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4,3, new int[] { 1, 2, 3, 4})]
        public void RemoveElementsByIndexTest(int[] baseArray, int index, int n, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.RemoveElementsByIndex(index, n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 3 )]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 2, 1 )]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7, 6 )]
        public void GetFirstIndexByValueTest(int[] baseArray, int value, int expected)
        {            
            ArrayList arr = new ArrayList(baseArray);
            int actual=arr.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 7,6,5,4,3,2,1 })]
        public void ReversTest(int[] baseArray,  int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.Revers();

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 },7)]
        public void MaxValueTest(int[] baseArray, int expected)
        {
            ArrayList list = new ArrayList(baseArray);
            int actual = list.MaxValue();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 1)]
        public void MinValueTest(int[] baseArray, int expected)
        {
            ArrayList list = new ArrayList(baseArray);
            int actual = list.MinValue();
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 6)]
        public void IndexByMaxValueTest(int[] baseArray, int expected)
        {
            ArrayList list = new ArrayList(baseArray);
            int actual = list.IndexByMaxValue();
            Assert.AreEqual(expected, actual);
        }
    
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0)]
        public void IndexByMinValueTest(int[] baseArray, int expected)
        {
            ArrayList list = new ArrayList(baseArray);
            int actual = list.IndexByMinValue();
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] { 7, 6, 5, 4, 3, 2, 1 },new int[] { 1, 2, 3, 4, 5, 6, 7 } )]
        public void SortAscendingTest(int[] baseArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.SortAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 7, 6, 5, 4, 3, 2, 1 })]
        public void DescendingSortTest(int[] baseArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.DescendingSort();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, new int[] { 1, 2, 3, 5, 6, 7 })]
        public void RemoveFirstByValueTest(int[] baseArray, int value, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.RemoveFirstByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, new int[] { 1, 2, 3, 5, 6, 7 })]
        [TestCase(new int[] { 1, 4, 3, 4, 5, 4, 7 }, 4, new int[] { 1, 3, 5, 7 })]
        public void RemoveAllByValueTest(int[] baseArray, int value, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);

            ArrayList actual = new ArrayList(baseArray);
            actual.RemoveAllByValue(value);

            Assert.AreEqual(expected, actual);
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 3, 2, 1 })]
        public void AddListTest(int[] baseArray, int[] addArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList addList = new ArrayList(addArray);
            ArrayList actual = new ArrayList(baseArray);

            actual.AddList(addList);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 3, 2, 1 }, new int[] { 3,2,1,1, 2, 3, 4, 5, 6, 7 })]
        public void AddListFromTheBeingTest(int[] baseArray, int[] addArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList addList = new ArrayList(addArray);
            ArrayList actual = new ArrayList(baseArray);

            actual.AddListFromTheBeing(addList);

            Assert.AreEqual(expected, actual);

        }
        [TestCase(3, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 3, 2, 1 }, new int[] {  1, 2, 3, 3, 2, 1, 4, 5, 6, 7 })]
        public void AddListByIndexTest(int index, int[] baseArray, int[] addArray, int[] expectedArray)
        {
            ArrayList expected = new ArrayList(expectedArray);
            ArrayList addList = new ArrayList(addArray);
            ArrayList actual = new ArrayList(baseArray);

            actual.AddListByIndex(addList,index);

            Assert.AreEqual(expected, actual);
        }

     
        private static int[] GetMock(int num)
        {
            int[] result = new int[0];
            switch (num)
            {
                case 0:
                    result = new int[] { };
                    break;
                case 1:
                    result = new int[] {1,2,3,4,5 };
                    break;
                case 2:
                    result = new int[] {1,1,1,1,1 };
                    break;
                case 3:
                    result = new int[] { };
                    break;
                case 4:
                    result = new int[] { };
                    break;
                                     
            }
            return result;
        }
    
    }
}