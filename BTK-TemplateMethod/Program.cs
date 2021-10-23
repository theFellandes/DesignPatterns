using System;

namespace BTK_TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            
            Console.WriteLine("Men");
            algorithm = new MensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0,2,34)));

            Console.WriteLine("-----------------------------------------------------------------------");
            
            Console.WriteLine("Women");
            algorithm = new WomensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));
            
            Console.WriteLine("-----------------------------------------------------------------------");
            
            Console.WriteLine("Children");
            algorithm = new ChildrensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            //Template methodlar var ve farklı enjeksiyonlar yaparak bunlar değişecek.
            int score = CalculateBaseScore(hits);
            //kişinin çocuk, erkek, kadın olmasına göre score'lar değişecek
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }
        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateBaseScore(int hits);
        public abstract int CalculateReduction(TimeSpan time);

    }

    class MensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int) time.TotalSeconds / 5;
        }
    }
    
    class WomensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int) time.TotalSeconds / 3;
        }
    }
    
    class ChildrensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int) time.TotalSeconds / 2;
        }
    }
}