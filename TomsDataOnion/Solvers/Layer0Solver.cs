﻿namespace TomsDataOnion.Solvers;

/// <summary>
/// ASCII85 decoder
/// </summary>
public class Layer0Solver : ISolver
{
    public string Solve(string content)
    {
        var decodedBytes = GetSolutionAsBytes(content);

        return SolverHelper.BytesToString(decodedBytes);
    }

    public static byte[] GetSolutionAsBytes(string content)
    {
        content = content.Replace("\n", "");
        content = content.Replace("\r", "");
        content = content.Replace("\t", "");
        content = content.Remove(0, 2);
        content = content.Remove(content.Length - 3, 2);

        var endPaddingCount = content.Length % 5;
        content = content.PadRight(content.Length + 5 - endPaddingCount, 'u');

        var powers85 = new[] { 85 * 85 * 85 * 85, 85 * 85 * 85, 85 * 85, 85, 1 };
        var decodedBytes = new List<byte>();

        for (var i = 0; i < content.Length; i += 5)
        {
            var fiveCharTuple = content.Substring(i, 5);

            var sum = 0;

            for (var j = 0; j < fiveCharTuple.Length; j++)
            {
                var c = (byte)fiveCharTuple[j];
                c -= 33;
                sum += c * powers85[j];
            }

            var bytes = BitConverter.GetBytes(sum).Reverse().ToArray();
            decodedBytes.AddRange(bytes);
        }

        return decodedBytes.ToArray();
    }
}