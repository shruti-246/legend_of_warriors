using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class VolumeSliderTest
{
    private GameObject testGO;

    [SetUp]
    public void Setup()
    {
        testGO = new GameObject("VolumeSliderTestObject");
    }

    [Test]
    public void VolumeSliderTest_SimplePasses()
    {
        Assert.IsNotNull(testGO);
    }

    [Test]
    public void VolumeSliderTest_ComponentCheck()
    {
        var rb = testGO.AddComponent<Rigidbody>();
        Assert.IsNotNull(rb);
    }

    [Test]
    public void VolumeSliderTest_InactiveGameObject()
    {
        testGO.SetActive(false);
        Assert.IsFalse(testGO.activeSelf);
    }

    [Test]
    public void VolumeSliderTest_PositionBoundaryCheck()
    {
        testGO.transform.position = new Vector3(0, 1000, 0);
        Assert.GreaterOrEqual(testGO.transform.position.y, 0);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(testGO);
    }
}