# Unity Coding Standards: File Layout

## Code File Layout

### Usings

- **Library usings** should be the first lines of a file, followed by **typedef-like** usings.
- Usings should be defined in the following order:
  1. **System or .NET libraries**
  2. **Unity libraries**
  3. **Third-Party plugins** (e.g., Asset Store)
  4. **Your own utility libraries**
  5. **Project namespaces**
  6. **Type name aliases**
  
  All namespace categories should be grouped together without spaces or comments separating them, with an exception for typedef-like usings, which should be separated from library usings with an empty line.

### Example:
```csharp
// File: AiPathfinder.cs
using System.Collections.Generic;
using UnityEngine;

using WaypointMap = Dictionary<Vector3,Waypoint>;

namespace MyGame.AiNavigation
{
    public class AiPathfinder
    {
        ...
    }
}
```

### Correct Order of Usings:
```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ExampleCompany;
using OtherCompany.BoostedInspector;
using MyUtilityLib;
using MyUtilityLib.DebugUtilities;
using MyOtherLib.Patterns;
using ThisProject;
using ThisProject.Audio;
using ThisProject.Combat;

using EntityPrefabMap = Dictionary<EntityType,GameObject>;
```

---

### Class Definition

- Put every **class definition** inside an appropriate **namespace**.
- Prefer defining **only one class per file**.
- The **file name** should be the same as the class name.

### Example:
```csharp
public class MyClass : MonoBehaviour
{
    private class MyNestedClass
    {
        ...
    }

    private const int SOME_CONSTANT = 1;

    public enum SomeEnum
    {
        FirstElement,
        SecondElement
    }

    public int SomeProperty
    {
        get => someField;
    }

    private int someField;

    private void Start()
    {
        ...
    }

    public void SomePublicMethod()
    {
        ...
    }

    private void SomePrivateMethod()
    {
        ...
    }
}
```

---

### Class Member Order

Define a class in the following order:

1. **Nested classes**
2. **Constants**
3. **Enums**
4. **Properties**
5. **Fields**
6. **Constructors** (if applicable)
7. **Unity Messages** (e.g., `Start`, `Update`, etc.)
8. **Public methods**
9. **Private methods**

---

### Method Definition Order

Prefer defining methods in the following order:

1. **Initialization methods**
2. **Core functionality methods**
3. **Helper or explanatory methods**

### Example:
```csharp
// Initialization
private void Initialize()
{
    ...
}

// Core functionality
private void Move(Vector3 direction)
{
    ...
}

// Helper
private bool CheckIfPositionIsWalkable(Vector3 position)
{
    ...
}
```