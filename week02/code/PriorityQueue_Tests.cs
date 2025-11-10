using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Verify that Enqueue correctly adds new items to the back of the queue without removing or reordering existing ones.
    // Expected Result: After three Enqueue calls, queue contains A (1), B (2), C (3) in that order.
    // Defect(s) Found: None expected, Enqueue works as intended.
    public void TestPriorityQueue_AddsToBack()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 3);

        string result = pq.ToString();
        StringAssert.Contains(result, "A (Pri:1)");
        StringAssert.Contains(result, "B (Pri:2)");
        StringAssert.Contains(result, "C (Pri:3)");
    }
    
      [TestMethod]
    // Scenario: Verify that Enqueue adds items to the back of the queue and that
    // Dequeue removes items in order of highest priority first.
    // Expected Result: Items should be dequeued in order C, B, A because priorities are 3 > 2 > 1.
    // Defect(s) Found: The for-loop condition `index < _queue.Count - 1` skips the last item,
    // causing the last enqueued high-priority item to be ignored.
    public void TestPriorityQueue_HighestPriorityRemovedFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 3);

        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Verify that when multiple items have the same highest priority,
    // the one closest to the front of the queue is removed first (FIFO behavior).
    // Expected Result: If A and B both have priority 2, A (first inserted) is removed before B.
    // Defect(s) Found: The code uses `>=` in comparison, so it removes the last matching item
    // instead of the first, breaking FIFO behavior.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 1);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Verify that an InvalidOperationException is thrown when trying to Dequeue from an empty queue.
    // Expected Result: Exception message should be "The queue is empty."
    // Defect(s) Found: None if message matches exactly.
    public void TestPriorityQueue_EmptyQueueException()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}