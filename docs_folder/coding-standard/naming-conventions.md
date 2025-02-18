# Unity Coding Standards: Naming Conventions

## General Naming Guidelines

- **Identifiers** for classes, methods, namespaces, enums, properties, attributes, and coroutines should be written in **PascalCase**.

### Example:
```csharp
namespace OpenSoulsGame.Debug
public class RichTextFormatter
public string StringToBold(this string inputString)
public float DefaultSpacing
{
    ...
}
[ConsoleAttribute] private int letterSpacing;
```

- **Identifiers** for fields, local variables, and parameters should be written in **camelCase**.

### Example:
```csharp
public int playerId;
private InputHandler playerInput;
private float health;
var name = GetPlayerName(playerId);
```

- **Constants** should be written in **UPPER_CASE**.

### Example:
```csharp
public const int MAX_SCENE_OBJECTS = 256;
```

- **Acronyms** should be treated as words and written in **PascalCase**.

### Example:
```csharp
public class XmlFormatter
public class AiBehaviour
```

- The casing conventions are unaffected by the modifiers (`public`, `private`, `protected`, `internal`, `static`, or `readonly`).

---

## Naming Conventions for Specific Elements

### Namespace Identifiers
- **Namespace identifiers** should briefly describe the systems or sets of definitions contained in the namespace.

### Example:
```csharp
namespace Utilities.Debug
namespace TowerDefenseGame.Combat
namespace TowerDefenseGame.UI
```

### Class Identifiers
- **Class identifiers** should briefly describe the responsibilities or data.
- Prefer including the suffix **"Base"** in **abstract classes** where applicable.

### Example:
```csharp
// A class responsible for performing movement on the player character's transform
class PlayerMotor

// An abstract class for implementing behaviors for AI Agents
abstract class AiBehaviourBase
```

### Interface Identifiers
- **Interfaces** should include the prefix **"I"**. The interface name should briefly describe the purpose of its members or the components it interacts with.

### Example:
```csharp
interface IMotorTarget
interface IUiElement
```

### Method Identifiers
- **Method identifiers** should describe the effect caused by the method, or the return value if the method has no effect.
- Typically, the identifier for methods without a return type should be a **verb**.

### Example:
```csharp
// A method that performs movement on the player character
public void Move(Vector3 movement)
{
    ...
}

// A method that converts radians to degrees
private float RadianToDegrees(float radians)
{
    ...
}

// A method to determine if a position in the world can be traversed by the player
private bool IsPositionWalkable(Vector3 position)
{
    ...
}
```

### Coroutine Identifiers
- **Coroutines** should be written with the prefix **‘CO_’**, and the rest of its identifier should follow the same rules as methods.

### Example:
```csharp
IEnumerator CO_SpawnPlayer(int playerId)
```