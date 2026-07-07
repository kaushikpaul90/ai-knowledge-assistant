namespace AIKnowledgeAssistant.Application.Interfaces;

public interface ISimilarityCalculator
{
    double Calculate(float[] vectorA, float[] vectorB);
}