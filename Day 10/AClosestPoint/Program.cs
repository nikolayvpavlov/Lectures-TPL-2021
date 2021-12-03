using System.Diagnostics;

namespace AClosestPoint;

class Program
{
    static Point[] points = new Point[10_000_000];

    private static void GenerateData()
    {
        Random random = new Random();
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new Point()
            {
                X = random.NextDouble() * 100_000,
                Y = random.NextDouble() * 100_000
            };
        }
    }

    private static Point? FindClosestPointSingleThread(Point[] points, Point p)
    {
        double minDistance = double.MaxValue;
        Point? closestPoint = null;
        for (int i = 0; i < points.Length; i++)
        {
            double currentDistance = points[i].GetDistance(p);
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                closestPoint = points[i];
            }
        }
        return closestPoint;
    }

    private static Point? FindClosestPointMultiThreadChunk(Point[] points, Point p)
    {
        double minDistance = double.MaxValue;
        Point? closestPoint = null;

        int coreCount = Environment.ProcessorCount;
        var chunks = points.Chunk(points.Length / coreCount + 1);
        ManualResetEvent mre = new ManualResetEvent(false);

        var threadMethod = new ParameterizedThreadStart((object? arrayObj) =>
        {
            mre.WaitOne();
            var chunk = (Point[])arrayObj;
            for (int i = 0; i < chunk.Length; i++)
            {
                double currentDistance = chunk[i].GetDistance(p);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestPoint = chunk[i];
                }
            }
        });

        List<Thread> threadList = new List<Thread>();
        foreach (var chunk in chunks)
        {
            var t = new Thread(threadMethod);
            threadList.Add(t);
            t.Start(chunk);
        }
        mre.Set();
        foreach (var t in threadList) t.Join();

        return closestPoint;
    }

    private static Point? FindClosestPointMultiThreadSegment(Point[] points, Point p)
    {
        double minDistance = double.MaxValue;
        Point? closestPoint = null;

        int coreCount = Environment.ProcessorCount;
        var segmentSize = points.Length / coreCount + 1;

        List<ArraySegment<Point>> segments = new List<ArraySegment<Point>>();
        int offset = 0;
        for (int i = 0; i < coreCount; i++)
        {
            if (offset + segmentSize > points.Length)
            {
                segmentSize = points.Length - offset;
            }
            ArraySegment<Point> arrSeg = new ArraySegment<Point>(points, offset, segmentSize);
            segments.Add(arrSeg);
            offset += segmentSize;
        }

        ManualResetEvent mre = new ManualResetEvent(false);

        var threadMethod = new ParameterizedThreadStart((object? segObj) =>
        {
            mre.WaitOne();
            var seg = (ArraySegment<Point>)segObj;
            for (int i = 0; i < seg.Count; i++)
            {
                double currentDistance = seg[i].GetDistance(p);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestPoint = seg[i];
                }
            }
        });

        List<Thread> threadList = new List<Thread>();
        foreach (var seg in segments)
        {
            var t = new Thread(threadMethod);
            threadList.Add(t);
            t.Start(seg);
        }
        mre.Set();
        foreach (var t in threadList) t.Join();

        return closestPoint;
    }

    private static Point? FindClosestPointMultiThreadSegmentLock(Point[] points, Point p)
    {
        double minDistance = double.MaxValue;
        Point? closestPoint = null;

        int coreCount = Environment.ProcessorCount;
        var segmentSize = points.Length / coreCount + 1;

        List<ArraySegment<Point>> segments = new List<ArraySegment<Point>>();
        int offset = 0;
        for (int i = 0; i < coreCount; i++)
        {
            if (offset + segmentSize > points.Length)
            {
                segmentSize = points.Length - offset;
            }
            ArraySegment<Point> arrSeg = new ArraySegment<Point>(points, offset, segmentSize);
            segments.Add(arrSeg);
            offset += segmentSize;
        }

        ManualResetEvent mre = new ManualResetEvent(false);

        var threadMethod = new ParameterizedThreadStart((object? segObj) =>
        {
            mre.WaitOne();
            var seg = (ArraySegment<Point>)segObj;
            for (int i = 0; i < seg.Count; i++)
            {
                double currentDistance = seg[i].GetDistance(p);
                lock (points)
                {
                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        closestPoint = seg[i];
                    }
                }
            }
        });

        List<Thread> threadList = new List<Thread>();
        foreach (var seg in segments)
        {
            var t = new Thread(threadMethod);
            threadList.Add(t);
            t.Start(seg);
        }
        mre.Set();
        foreach (var t in threadList) t.Join();

        return closestPoint;
    }

    private static Point? FindClosestPointParallelNoLock(Point[] points, Point p)
    {
        double minDistance = double.MaxValue;
        Point? closestPoint = null;

        Parallel.For(0, points.Length, i =>
        {
            double currentDistance = points[i].GetDistance(p);
            if (currentDistance < minDistance)
            {
                minDistance = currentDistance;
                closestPoint = points[i];
            }
        });

        return closestPoint;
    }

    private static Point? FindClosestPointParallelLock(Point[] points, Point p)
    {
        double minDistance = double.MaxValue;
        Point? closestPoint = null;

        Parallel.For(0, points.Length, i =>
        {
            double currentDistance = points[i].GetDistance(p);
            lock (points)
            {
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestPoint = points[i];
                }
            }
        });

        return closestPoint;
    }

    private static Point? FindClosestPointParallelInterlocked(Point[] points, Point p)
    {
        double minDistance = double.MaxValue;
        Point? closestPoint = null;

        Parallel.For(0, points.Length, i =>
        {
            double currentDistance = points[i].GetDistance(p);
            double initialMinDistance;
            do
            {
                initialMinDistance = minDistance;
                if (currentDistance >= initialMinDistance)
                {
                    break;
                }
                else
                {
                    closestPoint = points[i];
                }
            }
            while (initialMinDistance != 
              Interlocked.CompareExchange(ref minDistance, currentDistance, initialMinDistance));
        });

        return closestPoint;
    }

    static void Main()
    {
        Console.Write("Generating data...  ");
        GenerateData();
        Console.WriteLine("Done.");
        Console.WriteLine();

        Random random = new Random();
        Point p = new Point()
        {
            X = random.NextDouble() * 100_000,
            Y = random.NextDouble() * 100_000
        };

        Stopwatch watch = new Stopwatch();

        watch.Start();
        Point? closest = FindClosestPointSingleThread(points, p);
        watch.Stop();
        Console.WriteLine($"Closest point - single thread: {watch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Point found: {closest.X}:{closest.Y}");
        Console.WriteLine();

        watch.Reset();
        watch.Start();
        closest = FindClosestPointMultiThreadChunk(points, p);
        watch.Stop();
        Console.WriteLine($"Closest point - multi thread, chunks (no lock): {watch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Point found: {closest.X}:{closest.Y}");
        Console.WriteLine();

        watch.Reset();
        watch.Start();
        closest = FindClosestPointMultiThreadSegment(points, p);
        watch.Stop();
        Console.WriteLine($"Closest point - multi thread, segments (no lock): {watch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Point found: {closest.X}:{closest.Y}");
        Console.WriteLine();

        watch.Reset();
        watch.Start();
        closest = FindClosestPointMultiThreadSegmentLock(points, p);
        watch.Stop();
        Console.WriteLine($"Closest point - multi thread, segments (w/ lock): {watch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Point found: {closest.X}:{closest.Y}");
        Console.WriteLine();

        watch.Reset();
        watch.Start();
        closest = FindClosestPointParallelNoLock(points, p);
        watch.Stop();
        Console.WriteLine($"Closest point - parallel (no lock): {watch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Point found: {closest.X}:{closest.Y}");
        Console.WriteLine();

        watch.Reset();
        watch.Start();
        closest = FindClosestPointParallelLock(points, p);
        watch.Stop();
        Console.WriteLine($"Closest point - parallel (w/ lock): {watch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Point found: {closest.X}:{closest.Y}");
        Console.WriteLine();

        watch.Reset();
        watch.Start();
        closest = FindClosestPointParallelInterlocked(points, p);
        watch.Stop();
        Console.WriteLine($"Closest point - parallel (interlocked): {watch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Point found: {closest.X}:{closest.Y}");
        Console.WriteLine();


        Console.ReadLine();

    }
}