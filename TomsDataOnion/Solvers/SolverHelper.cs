using System.Text;

namespace TomsDataOnion.Solvers;

public static class SolverHelper
{
    public static string BytesToString(byte[] bytes)
    {
        var builder = new StringBuilder();

        for (var i = 0; i < bytes.Length; i += 4)
        {
            var fourBytes = bytes[i..(i + 4)];
            var decoded = Encoding.ASCII.GetString(fourBytes);
            builder.Append(decoded);
        }

        return builder.ToString();
    }
}