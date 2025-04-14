using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;  // For UnityTest support
using Gentleland.StemapunkUI.DemoAndExample;

public class BarsFillAnimationsTest
{
    private GameObject testObject;
    private BarsFillAnimations barsFill;
    private GameObject slider1;
    private GameObject slider2;
    private Slider slider1Component;
    private Slider slider2Component;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject to hold the BarsFillAnimations script
        testObject = new GameObject("BarsFillAnimationsTestObject");

        // Add the BarsFillAnimations script dynamically at runtime
        barsFill = testObject.AddComponent<BarsFillAnimations>();

        Assert.IsNotNull(barsFill, "BarsFillAnimations script was not found!");

        // Create sliders and add to the scene
        slider1 = new GameObject("Slider1", typeof(Slider));
        slider2 = new GameObject("Slider2", typeof(Slider));

        slider1Component = slider1.GetComponent<Slider>();
        slider2Component = slider2.GetComponent<Slider>();

        Assert.IsNotNull(slider1Component, "Slider1 component not found!");
        Assert.IsNotNull(slider2Component, "Slider2 component not found!");
    }

    [UnityTest]
    public IEnumerator BarsFillAnimations_ShouldStayWithinSliderBoundaries()
    {
        // Arrange: Let the animation run for a while
        yield return new WaitForSeconds(1f);  // Allow some time for animation to happen

        // Act: Update the sliders manually
        barsFill.UpdateSlidersManually();

        // Assert: Slider values should always be between 0 and 1
        Assert.IsTrue(slider1Component.value >= 0f && slider1Component.value <= 1f, "Slider1 is out of bounds!");
        Assert.IsTrue(slider2Component.value >= 0f && slider2Component.value <= 1f, "Slider2 is out of bounds!");
    }
}
