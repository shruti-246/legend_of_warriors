using NUnit.Framework;
using UnityEngine;
using TMPro;

namespace Gentleland.StemapunkUI.DemoAndExample
{
    [TestFixture]
    public class CharacterStatTest
    {
        private GameObject testObject;
        private TextMeshProUGUI textMesh;
        private CharacterStat characterStat;

        [SetUp]
        public void SetUp()
        {
            // Create a new GameObject for the test
            testObject = new GameObject("TestObject");

            // Check if the GameObject already has a TextMeshProUGUI component
            textMesh = testObject.GetComponent<TextMeshProUGUI>();
            if (textMesh == null)
            {
                // Add the TextMeshProUGUI component if it's not already there
                textMesh = testObject.AddComponent<TextMeshProUGUI>();
            }

            // Optionally, set up the TextMeshProUGUI component's initial properties
            textMesh.text = "0";  // Initial value of the text

            // Create and set up the CharacterStat component
            characterStat = testObject.AddComponent<CharacterStat>();

            // Ensure the characterStat is using the correct TextMeshProUGUI reference
            characterStat.SetTextMeshProUGUI(textMesh);
        }

        [Test]
        public void TestIncrement()
        {
            // Arrange
            int initialValue = int.Parse(textMesh.text);

            // Act
            characterStat.Increment();

            // Assert
            Assert.AreEqual(initialValue + 1, int.Parse(textMesh.text), "The value should increment by 1.");
        }

        [Test]
        public void TestDecrement()
        {
            // Arrange
            int initialValue = int.Parse(textMesh.text);

            // Act
            characterStat.Decrement();

            // Assert
            Assert.AreEqual(initialValue - 1, int.Parse(textMesh.text), "The value should decrement by 1.");
        }
    }
}
