using System;
using System.Collections.Generic;

class Labirent
{
    // 4 yönlü hareket (sağ, sol, yukarı, aşağı)
    static readonly int[] dx = { 0, 0, -1, 1 };
    static readonly int[] dy = { 1, -1, 0, 0 };

    // Labirent sınırlarını kontrol eden yardımcı fonksiyon
    static bool IsInBounds(int x, int y, int N)
    {
        return x >= 0 && y >= 0 && x < N && y < N;
    }

    // BFS ile en kısa yolu bulma fonksiyonu
    static int FindShortestPath(int[,] grid, int N)
    {
        // Eğer başlangıç noktası veya bitiş noktası 1 değilse yol yoktur
        if (grid[0, 0] == 0 || grid[N - 1, N - 1] == 0)
            return -1;

        // Ziyaret edilen noktaları işaretlemek için bir visited dizisi
        bool[,] visited = new bool[N, N];
        visited[0, 0] = true;

        // Kuyruk (queue) ile BFS başlatılır (konum ve adım sayısı tutuyoruz)
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        queue.Enqueue(new Tuple<int, int, int>(0, 0, 1)); // (x, y, adım sayısı)

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int x = current.Item1;
            int y = current.Item2;
            int steps = current.Item3;

            // Eğer hedefe ulaşıldıysa adım sayısını döndür
            if (x == N - 1 && y == N - 1)
                return steps;

            // 4 yöne doğru hareket et
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];

                // Yeni pozisyon geçerli mi ve daha önce ziyaret edilmemiş mi?
                if (IsInBounds(newX, newY, N) && grid[newX, newY] == 1 && !visited[newX, newY])
                {
                    visited[newX, newY] = true;
                    queue.Enqueue(new Tuple<int, int, int>(newX, newY, steps + 1));
                }
            }
        }

        // Eğer kuyruğu bitirip hedefe ulaşılmadıysa, yol yok demektir
        return -1;
    }

    // Ana fonksiyon
    static void Main(string[] args)
    {
        // Örnek labirent (1: geçilebilir, 0: geçilemez)
        int[,] grid = {
            { 1, 0, 0, 0 },
            { 1, 1, 0, 1 },
            { 0, 1, 1, 1 },
            { 0, 0, 0, 1 }
        };

        int N = grid.GetLength(0); // Labirentin boyutu (NxN)

        // En kısa yolu bul
        int result = FindShortestPath(grid, N);

        if (result != -1)
        {
            Console.WriteLine("En Kısa Yol: " + result + " adım");
        }
        else
        {
            Console.WriteLine("Yol Yok");
        }

        // Konsolun kapanmaması için kullanıcıdan bir giriş bekle
        Console.WriteLine("Çıkmak için bir tuşa basın...");
        Console.ReadLine();
    }
}
