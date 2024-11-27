using System;

class Program
{
    static void Main(string[] args)
    {
        // Kullanıcıdan matris boyutunu alma
        Console.Write("NxN boyutunda bir matris için N değerini girin: ");
        int N = int.Parse(Console.ReadLine());

        // N x N boyutunda bir matris oluşturma
        int[,] matrix = new int[N, N];

        // Spiral şekilde matrisi doldurma
        FillSpiral(matrix, N);

        // Matrisi yazdırma
        Console.WriteLine("\nSpiral Doldurulmuş Matris:");
        PrintMatrix(matrix, N);

        // Konsolun kapanmaması için kullanıcıdan bir giriş bekle
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine();
    }

    static void FillSpiral(int[,] matrix, int N)
    {
        int value = 1; // Başlangıç değeri
        int top = 0, bottom = N - 1, left = 0, right = N - 1;

        while (top <= bottom && left <= right)
        {
            // Üst kenar
            for (int i = left; i <= right; i++)
            {
                matrix[top, i] = value++;
            }
            top++;

            // Sağ kenar
            for (int i = top; i <= bottom; i++)
            {
                matrix[i, right] = value++;
            }
            right--;

            // Alt kenar
            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    matrix[bottom, i] = value++;
                }
                bottom--;
            }

            // Sol kenar
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    matrix[i, left] = value++;
                }
                left++;
            }
        }
    }

    static void PrintMatrix(int[,] matrix, int N)
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
