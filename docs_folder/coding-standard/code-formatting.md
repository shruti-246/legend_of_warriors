# Unity Coding Standards

## Code Formatting

- Use **spaces** instead of **tabs**. Do not mix spaces and tabs.
- Each indentation level should be **4 spaces wide**.
- Each **brace** should have its **own line**.

### Example:
#### ❌ Avoid
```csharp
if(playerWasHit) {
    PlaySound(playerHitSound);
    Damage(player, damageAmount);
}
```
#### ✅ Prefer
```csharp
if(playerWasHit)
{
    PlaySound(playerHitSound);
    Damage(player, damageAmount);
}
```

---

## Properties

- **Do not** write property getters and setters in a single line.
- Use **expression body definition operator (`=>`)** for **simple, single-statement properties**.

### Example:
#### ❌ Bad
```csharp
public float Health { get { return health; } }
```
#### ✅ Good
```csharp
public float Health
{
    get
    {
        return health;
    }
}
```
#### ✅ Allowed (For single-statement properties)
```csharp
public float Health
{
    get => health;
    set => health = value;
}
```

---

## Conditionals

- **Always** use braces `{}` after conditionals, even for single statements.

### Example:
#### ❌ Bad
```csharp
if(enemyInRange)
    Explode();
```
#### ✅ Good
```csharp
if(enemyInRange)
{
    Explode();
}
```

---

## Ternary Operator

- **Avoid** using the **ternary operator** for clarity.

---

## String Interpolation

- Use **string interpolation (`$"..."`)** instead of `LogFormat()` for better readability.

### Example:
#### ❌ Avoid
```csharp
Debug.Log("Player " + playerId + " took a hit from " + damageSource + " for " + damageAmount + " damage.");
```
```csharp
Debug.LogFormat("Player {0} took a hit from {1} for {2} damage.", playerId, damageSource, damageAmount);
```
#### ✅ Prefer
```csharp
Debug.Log($"Player {playerId} took a hit from {damageSource} for {damageAmount} damage.");
```

---

## Switch-Case

- **Wrap** switch-case statements inside **braces `{}`**.

### Example:
#### ✅ Correct
```csharp
switch(colorId)
{
    case PlayerBodyColors.White:
    {
        playerBody.SetTexture(whiteTexture);
    }
    break;
    
    case PlayerBodyColors.Red:
    {
        playerBody.SetTexture(redTexture);
    }
    break;
    
    default:
    {
        playerBody.SetTexture(defaultTexture);
    }
    break;
}
```

---

## Encoding & End-Of-Line Character

- Encode the document in **UTF-8** if possible.
- Use **CRLF** (`\r\n`) as the End-Of-Line character.
```