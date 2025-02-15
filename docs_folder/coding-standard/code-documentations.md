# Code Documentation Best Practices

## Self-Documenting Code
Write self-documenting code whenever possible. Use descriptive variable names that convey the meaning of their values.

### Bad Example:
```csharp
p = p + v * dt;
```

### Good Example:
```csharp
position = position + velocity * deltaTime;
```

You can also improve readability by introducing explanatory variables to avoid complex expressions:

### Bad Example:
```csharp
pos = Vector3.Lerp(targetEnemy.position, player.GetComponent<AutoMovementController>().targetWaypoint.nextPosition, elapsedTime / max);
```

### Good Example:
```csharp
var waypoint = player.GetComponent<AutoMovementController>().targetWaypoint;
var startPosition = targetEnemy.position;
var finalPosition = waypoint.nextPosition;
var lerpPoint = elapsedTime / maxMovementTime;
position = Vector3.Lerp(startPosition, finalPosition, lerpPoint);
```

## Writing Useful Comments
Avoid redundant comments that restate what the code already makes clear. Focus on providing additional context that might not be immediately obvious.

### Bad Example:
```csharp
// increment player id
playerId++;
```

### Good Example:
```csharp
// A new player has joined, so we generate a new identifier.
playerId++;
```

## Avoid Commenting Bad or Unreadable Code
If the code is hard to understand, prefer refactoring it instead of adding comments to explain it.

### Bad Example:
```csharp
// Increase current position by the velocity scaled by deltaTime to perform movement.
p = p + v * dt;
```

### Good Example:
```csharp
position = position + velocity * deltaTime;
```

## Avoid Contradicting the Code in Comments
Make sure that comments accurately reflect the behavior of the code. Don’t include contradictory statements.

### Bad Example:
```csharp
// Health value should be between 0 and 100.
private int health;

...

this.health = 150;
```

### Good Example:
```csharp
// Base health values should be between 0 and 100.
private int health;

...

// Apply the temporary health buff from consuming potion.
this.health = 150;
```
```
