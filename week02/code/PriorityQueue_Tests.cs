using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with varying priorities, then dequeue repeatedly.
    // Expected Result: Items dequeued in descending priority order; highest priority first.
    // Defect(s) Found: Dequeue did not remove the highest priority item correctly and did not remove the item from the queue.
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with equal highest priority and ensure FIFO among them.
    // Expected Result: The first inserted item with the highest priority is dequeued first.
    // Defect(s) Found: Dequeue used >= when comparing priorities so later equal-priority items were selected first.
    public void TestPriorityQueue_TiebreakerPreservesFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 4);
        priorityQueue.Enqueue("SecondHigh", 4);
        priorityQueue.Enqueue("Lower", 2);

        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Lower", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty." is thrown.
    // Defect(s) Found: Dequeue did not throw when the queue was empty or may have thrown the wrong exception.
    public void TestPriorityQueue_EmptyThrowsInvalidOperationException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}
