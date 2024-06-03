namespace TomsDataOnion.Solvers;

public class Layer1Solver : ISolver
{
    public string Solve(string content)
    {
        var decodedBytes = Layer0Solver.GetSolutionAsBytes(content);
        FlipEverySecondBit(decodedBytes);
        RotateToTheRight(decodedBytes);

        return SolverHelper.BytesToString(decodedBytes);
    }

    private static void FlipEverySecondBit(byte[] bytes)
    {
        const byte mask = 0b_0101_0101;

        for (var i = 0; i < bytes.Length; i++)
        {
            bytes[i] ^= mask;
        }
    }

    private static void RotateToTheRight(byte[] bytes)
    {
        for (var i = 0; i < bytes.Length; i++)
        {
            var lastBit = (byte)(bytes[i] & 0b_0000_0001);
            var lastBitMovedToBeginning = (byte)(lastBit << 7);
            bytes[i] >>= 1;
            bytes[i] |= lastBitMovedToBeginning;
        }
    }
}