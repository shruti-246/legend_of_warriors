public static class GameSettings
{
    public enum Difficulty
    {
        BC,
        Medium,
        Impossible
    }

    public static Difficulty CurrentDifficulty = Difficulty.Medium;
}