using System;
using System.Collections.Generic;

class TechCityRescue
{
    // 4 yönlü hareket (sağ, sol, yukarı, aşağı)
    static readonly int[] dx = { 0, 0, -1, 1 };
    static readonly int[] dy = { 1, -1, 0, 0 };

    // Grid sınırlarını kontrol eden yardımcı fonksiyon
    static bool IsInBounds(int x, int y, int N)
    {
        return x >= 0 && y >= 0 && x < N && y < N;
    }

    // BFS algoritması ile robotun yayılabileceği tüm düğümleri bulma fonksiyonu
    static int BFS(int[,] grid, bool[,] visited, int startX, int startY, int N)
    {
        // Başlangıç noktası zarar görmüşse robot başlayamaz
        if (grid[startX, startY] == 0) return 0;

        int rescuedNodes = 0;
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(startX, startY));
        visited[startX, startY] = true;
        rescuedNodes++;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;

            // Komşu düğümleri kontrol et
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                // Grid sınırları içinde mi ve zarar görmemiş mi?
                if (IsInBounds(newX, newY, N) && grid[newX, newY] == 1 && !visited[newX, newY])
                {
                    visited[newX, newY] = true;
                    queue.Enqueue(new Tuple<int, int>(newX, newY));
                    rescuedNodes++;
                }
            }
        }

        return rescuedNodes;
    }

    // Ana fonksiyon: Grid ve robotların başlangıç noktalarını alır, kurtarılan düğüm sayısını döner
    public static int RescueNodes(int[,] grid, List<Tuple<int, int>> robotStarts)
    {
        int N = grid.GetLength(0); // Grid boyutu (NxN)
        bool[,] visited = new bool[N, N];
        int totalRescued = 0;

        // Her robot için BFS çalıştır
        foreach (var start in robotStarts)
        {
            int startX = start.Item1;
            int startY = start.Item2;
            totalRescued += BFS(grid, visited, startX, startY, N);
        }

        return totalRescued;
    }

    // Test fonksiyonu
    static void Main(string[] args)
    {
        // Örnek grid (1: kurtarılabilir, 0: zarar görmüş)
        int[,] grid = {
            { 1, 1, 0, 1 },
            { 0, 1, 0, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 1, 1 }
        };

        // Robotların başlangıç konumları
        List<Tuple<int, int>> robotStarts = new List<Tuple<int, int>> {
            new Tuple<int, int>(0, 0), // Robot 1
            new Tuple<int, int>(2, 2), // Robot 2
            new Tuple<int, int>(3, 3)  // Robot 3
        };

        // Kaç düğüm kurtarılabilir?
        int result = RescueNodes(grid, robotStarts);
        Console.WriteLine("Kurtarılan toplam düğüm sayısı: " + result);

        // Konsolun kapanmaması için kullanıcıdan bir giriş bekle
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine();
    }
}
