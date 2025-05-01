using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GraphicsToggleTest
{
    private GameObject testGO;

    [SetUp]
    public void Setup()
    {
        testGO = new GameObject("GraphicsToggleTestObject");
    }

    [Test]
    public void GraphicsToggleTest_SimplePasses()
    {
        Assert.IsNotNull(testGO);
    }

    [Test]
    public void GraphicsToggleTest_ComponentCheck()
    {
        var rb = testGO.AddComponent<Rigidbody>();
        Assert.IsNotNull(rb);
    }

    [Test]
    public void GraphicsToggleTest_InactiveGameObject()
    {
        testGO.SetActive(false);
        Assert.IsFalse(testGO.activeSelf);
    }

    [Test]
    public void GraphicsToggleTest_PositionBoundaryCheck()
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
