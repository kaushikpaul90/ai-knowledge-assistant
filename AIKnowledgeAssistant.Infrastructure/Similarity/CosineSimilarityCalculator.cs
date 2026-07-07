using AIKnowledgeAssistant.Application.Interfaces;

namespace AIKnowledgeAssistant.Infrastructure.Similarity;

public sealed class CosineSimilarityCalculator : ISimilarityCalculator
{
    public double Calculate(float[] vectorA, float[] vectorB)
    {
        if (vectorA.Length != vectorB.Length)
        {
            throw new ArgumentException("Vectors must have the same dimension.");
        }

        double dotProduct = 0.0;
        double magnitudeA = 0.0;
        double magnitudeB = 0.0;

        for (int i = 0; i < vectorA.Length; i++)
        {
            dotProduct += vectorA[i] * vectorB[i];
            magnitudeA += Math.Pow(vectorA[i], 2);
            magnitudeB += Math.Pow(vectorB[i], 2);
        }

        magnitudeA = Math.Sqrt(magnitudeA);
        magnitudeB = Math.Sqrt(magnitudeB);

        if (magnitudeA == 0 || magnitudeB == 0)
        {
            return 0.0;
        }

        return dotProduct / (magnitudeA * magnitudeB);
    }
}