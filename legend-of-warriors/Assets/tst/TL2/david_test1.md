# README: Stress and Boundary Tests for EnemyMovement

## Introduction
This document provides a list of stress and boundary tests implemented in the `david_test1.cs` script for the `EnemyMovement` component in Unity. These tests ensure that the game mechanics function correctly under normal and extreme conditions.

### **Boundary Testing**
Boundary testing ensures that the system behaves correctly at the limits of its expected input or state. These tests verify movement constraints, jumping rules, and action triggers to prevent unexpected behavior at edge cases.

### **Stress Testing**
Stress testing evaluates how the system performs under high-load or extreme conditions, ensuring stability and responsiveness. These tests simulate prolonged movement, rapid inputs, and high-speed interactions to check performance limits.

## **List of Tests**
### **Boundary Tests**
| Test Name | Description |
|-----------|-------------|
| `Enemy_Jumps_WhenUpArrowPressed` | Ensures the enemy jumps only when grounded, preventing mid-air jumps. |
| `Enemy_DoesNotDoubleJump_WhenNotGrounded` | Ensures the enemy cannot double-jump, enforcing proper jump mechanics. |
| `Enemy_MovesRight_WhenRightArrowPressed` | Confirms that movement occurs only when the correct input is provided. |
| `Enemy_MovesLeft_WhenLeftArrowPressed` | Ensures the enemy moves left only when the left arrow key is pressed. |
| `Enemy_Kicks_WhenDownArrowPressed` | Verifies that the kick action is triggered only when the down arrow key is pressed. |
| `Enemy_DucksAndRolls_WhenDownAndRightArrowPressed` | Ensures rolling right works only when both `Down + Right` are pressed. |
| `Enemy_DucksAndRolls_WhenDownAndLeftArrowPressed` | Ensures rolling left works only when both `Down + Left` are pressed. |

### **Stress Tests**
| Test Name | Description |
|-----------|-------------|
| `Enemy_MovesRight_WhenRightArrowPressed` | Simulates prolonged movement to ensure continuous movement stability. |
| `Enemy_MovesLeft_WhenLeftArrowPressed` | Tests prolonged left movement to check for responsiveness and drift. |
| `Enemy_DucksAndRolls_WhenDownAndRightArrowPressed` | Simulates rapid input combinations to verify smooth rolling without glitches. |
| `Enemy_DucksAndRolls_WhenDownAndLeftArrowPressed` | Repeats rolling left actions to ensure stability under rapid input. |

## **Usage Instructions**
1. Ensure the **Unity Test Framework** is installed.
2. Place `DavidTest1.cs` inside the `Assets/Tests/` folder.
3. Open **Test Runner** (`Window → General → Test Runner`).
4. Select **Play Mode Tests** and click **Run All**.