namespace CustomLinkedList.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomLinkedListTest
    {
        private DynamicList<string> myStringList = new DynamicList<string>();
        [TestMethod]
        public void GettingEmptyDynamicListShouldReturnZeroCount()
        {
            Assert.AreEqual(0, myStringList.Count, string.Format("Count of DynamicList must be 0 not: {0}", myStringList.Count));
        }

        [TestMethod]
        public void AddindNewitemsinDynamicListShouldReturnCorrectCount()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");
            Assert.AreEqual(3, myStringList.Count,"Method 'Add' does not work correct");
        }

        [TestMethod]
        public void AddindNullitemsinDynamicListShouldReturnCorrectCount()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");            
            myStringList.Add("third_element");
            myStringList.Add(null);
            Assert.AreEqual(4, myStringList.Count, "Method 'Add' does not work correct");
        }

        [TestMethod]
        public void GettingElementFromCorrectIndexPositionShouldReturnCorrectElement()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            Assert.AreEqual("secont_element", myStringList[1],"Expected value of getting element is not correct!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void GettingElementFromIncorrectIndexPisitionWithPositiveIndexSouldThrowExeption()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            Console.WriteLine(myStringList[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void GettingElementFromIncorrectIndexPisitionWithNegativeIndexSouldThrowExeption()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            Console.WriteLine(myStringList[-1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SettingElementInIncorrectPositionShouldThrowExeption()
        {
            myStringList.Add("first_element");
            myStringList[1] = "invalid operation";

        }

        [TestMethod]
        public void SettingElementInCorrectPositionShouldReturnCorrectElement()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            myStringList[0] = "justTest";

            Assert.AreEqual("justTest",myStringList[0],string.Format
                ("Expected value of setting element is not correct"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemovingElementByIncorrectPositiveIndexShouldThrowExeption()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            myStringList.RemoveAt(4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemovingElementByIncorrectNegativeIndexShouldThrowExeption()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            myStringList.RemoveAt(-1);
        }
        
        [TestMethod]
        public void RemovingElementByCorrectIndexShouldReturnCorrectCountAndCorrectObject()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");
            var currentCount = myStringList.Count;

            myStringList.RemoveAt(1);
            
            bool isCorrectRemove =
              myStringList[0] == "first_element" &&
              myStringList[1] == "third_element" &&
              myStringList.Count == currentCount - 1;

            Assert.AreEqual(true, isCorrectRemove, "Method 'RemoveAt' does not work correct");
        }

        [TestMethod]
        public void RemovingElementByIncorrecElementShouldReturnMinusOne()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            var incorrectRemove = myStringList.Remove("Just_test");

            Assert.AreEqual(-1, incorrectRemove, "Method 'Remove' does not work correct!");
        }

        [TestMethod]
        public void RemovingElementByCorrecElementShouldReturnCorrectListAndCount()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");
            var currentCount = myStringList.Count;

            myStringList.Remove("secont_element");

            bool isCorrectRemove =
              myStringList[0] == "first_element" &&
              myStringList[1] == "third_element" &&
              myStringList.Count == currentCount - 1;

            Assert.AreEqual(true, isCorrectRemove, "Method 'RemoveAt' does not work correct");
        }

        [TestMethod]

        public void GettingIndexOfIncorrecElementShouldReturnMinusOne()
        {

            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            var incorrectElement = myStringList.IndexOf("Just_test");

            Assert.AreEqual(-1, incorrectElement, "Method 'IndexOf' does not work correct!");
        }

        [TestMethod]
        public void GettingIndexFromCorrecElementShouldReturnCorrectIndex()
        {

            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            bool correctIndex = myStringList.IndexOf("secont_element") == 1;

            Assert.AreEqual(true, correctIndex, "Method 'IndexOf' does not work correct!");
        }

        [TestMethod]
        public void CheckingForContainsWithIncorrectElementShouldReturnFalse()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            var check = myStringList.Contains("JustTest");

            Assert.AreEqual(false, check, "Method 'Contains' does not work correct!");
        }

        [TestMethod]
        public void CheckingForContainsWithCorrectElementShouldReturnTrue()
        {
            myStringList.Add("first_element");
            myStringList.Add("secont_element");
            myStringList.Add("third_element");

            var check = myStringList.Contains("secont_element");

            Assert.AreEqual(true, check, "Method 'Contains' does not work correct!");
        }

    }
}
