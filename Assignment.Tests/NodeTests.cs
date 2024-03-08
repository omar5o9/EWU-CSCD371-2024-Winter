using GenericsHomework;

namespace Assignment.Tests;
public class NodeTests
{
    [Fact]
    public void Node_NextReferencePointToSecondNode_Success()
    {
        Node<int> node = new(1);
        node.Append(3);
        Assert.NotEqual(node.Data, node.Next.Data);
    }

    [Fact]
    public void Node_ReturnsTrueForExistingValue_Success()
    {
        Node<int> node = new(1);
        node.Append(3);
        node.Append(5);
        Assert.True(node.Exists(3));
    }

    [Fact]
    public void Node_ReturnsFalseForNonExistingValue_Failure()
    {
        Node<int> node = new(1);
        node.Append(3);
        node.Append(5);
        Assert.False(node.Exists(7));
    }

   
    [Fact]
    public void Node_IterateThroughNodes_ReturnsCorrectSequence()
    {
        Node<int> node = new(1);
        node.Append(3);
        node.Append(5);

        int[] expectedSequence = { 1, 3, 5 };
        int index = 0;

        foreach (var n in node)
        {
            Assert.Equal(expectedSequence[index], n.Data);
            index++;
        }

    }

}
