# Enemy.prefab — README Documentation

The `Enemy.prefab` is a versatile 2D AI-controlled game object designed to challenge players by tracking, attacking, and interacting dynamically within the game environment. This prefab serves as a foundational enemy unit, offering customizable behavior and animation synchronization. It is powered by the `EnemyControllerAutoAttack.cs` script, which handles core AI functionalities.

For a visual demonstration of the `Enemy.prefab` in action, refer to the following video:

[![Enemy.prefab Demo](https://img.youtube.com/vi/your_video_id/0.jpg)](../demo.mp4)

- **File Location**: `Assets/tst/TL2/demo.mp4`  
- **Description**: This video showcases the enemy prefab's movement, attack behavior, and interaction with the player in a test environment.

## Components

| **Component**              | **Purpose**                                                                 |
|-----------------------------|-----------------------------------------------------------------------------|
| `Rigidbody2D`              | Enables physics-based movement in 2D space.                                |
| `Animator`                 | Controls sprite animations, transitioning between idle, movement, and attack states. |
| `EnemyControllerAutoAttack.cs` | Governs AI behavior, including player tracking, sprite flipping, and attack logic. |
| `Collider2D`     | Provides collision boundaries for physical interactions or hit detection.   |

### Component Details

- **Rigidbody2D**:  
    - Set body type to `Dynamic` for responsive movement.  
    - Gravity scale should be `0` to ensure the enemy remains in the 2D plane.  
    - Freeze the Z-axis to prevent unintended rotations.

- **Animator**:  
    - Synchronizes animations with enemy actions, such as walking, attacking, and idle states.  
    - Requires an `AnimatorController` (e.g., `EnemyAnimator.controller`) to function correctly.

- **Collider2D**:  
    - Use a `BoxCollider2D` or `CircleCollider2D` for hit detection.  
    - Ensure the collider is appropriately sized to match the enemy's sprite.

---

## Script: `EnemyControllerAutoAttack.cs`

The `EnemyControllerAutoAttack.cs` script is the core AI logic for this prefab. It provides the following functionalities:

- **Player Tracking**: Detects and moves toward the player using Unity's physics system.  
- **Sprite Flipping**: Automatically flips the enemy sprite based on the player's position on the X-axis.  
- **Attack Logic**: Executes attacks when the player is within range, with cooldown enforcement to prevent spamming.  
- **Animation Updates**: Updates animation parameters to reflect the enemy's current state (e.g., moving, attacking).  

---

## Setup Instructions

1. Drag the `Enemy.prefab` into your scene and position it on the desired tilemap or environment.  
2. Assign the following required components in the Unity editor:  
     - **AnimatorController**: Link to an appropriate controller (e.g., `EnemyAnimator.controller`).  
     - **Player Tag**: Ensure the player object is tagged as `Player` for proper detection.  
3. Configure the prefab's properties:  
     - Adjust movement speed, attack range, and cooldowns in the `EnemyControllerAutoAttack.cs` script.  
     - Verify collider sizes and positions for accurate hit detection.  

---

## Test Cases

| **Test Name**                     | **Purpose**                                                              |
|------------------------------------|--------------------------------------------------------------------------|
| `Enemy_Moves_Toward_Player`       | Confirms the enemy tracks and moves toward the player.                   |
| `Enemy_Only_Flips_On_X_Axis`      | Ensures the sprite flips horizontally but not vertically.                |
| `Enemy_Stops_When_Player_Destroyed` | Verifies the enemy stops moving when the player is destroyed.            |
| `Enemy_Respects_Attack_Cooldown`  | Validates that the enemy adheres to attack cooldowns.                    |
| `Enemy_Attacks_When_In_Range`     | Ensures the enemy attacks when the player is within range.               |

---

## Suggested Enhancements

- Add a health bar prefab using the `CharacterHealth.cs` script for visual feedback.  
- Create enemy variants (e.g., `Enemy_Enraged.prefab`, `Enemy_Normal.prefab`) to diversify gameplay.  
- Refactor AI logic into a state machine or behavior tree for improved modularity and scalability.  

---

## Requirements

- **Unity Version**: 2020.3.0f1 or later  
- **Dependencies**:  
    - AnimatorController (e.g., `EnemyAnimator.controller`)  
    - Player object tagged as `Player`  

---

## File Location

- **Path**: `Assets/Prefabs/TL2/david/Enemy.prefab`  
- **Tested in**:  
    - Scene: `new-playground`  
    - Requires: `AnimatorController` and properly tagged player object  

