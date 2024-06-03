using TomsDataOnion.Solvers;

namespace TomsDataOnion;

class Program
{
    private static readonly string[] layers = new[] { "layer0.txt" };
    private static readonly ISolver[] solvers = new[] { new Layer0Solver() };
    private static void Main(string[] args)
    {
        const int layerIndex = 0;
        var result = SolveLayer(layerIndex);
        File.WriteAllText($"out{layerIndex}.txt", result);
    }

    private static string SolveLayer(int layerIndex)
    {
        var content = File.ReadAllText($"Layers/layer{layerIndex}.txt");
        
        return solvers[layerIndex].Solve(content);
    }
}