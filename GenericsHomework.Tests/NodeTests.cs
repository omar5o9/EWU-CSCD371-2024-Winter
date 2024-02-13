namespace GenericsHomework.Tests;

public class NodeTests
{

    [Fact]
    public void DuplicateValueTest()
    {
        Node<int> newNode = new(1);
        Assert.Throws<InvalidOperationException>(() => newNode.Append(1));
    }

    [Fact]
    public void AppendTest()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        newNode.Append(3);
        newNode.Append(4);
        newNode.Append(5);
        Assert.Equal("1 -> 2 -> 3 -> 4 -> 5", newNode.ToString());
    }

    [Fact]
    public void ClearTest()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        newNode.Append(3);
        newNode.Append(4);
        newNode.Append(5);
        newNode.Clear();
        Assert.Equal("1", newNode.ToString());
    }

    [Fact]
    public void ExistsTest()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        newNode.Append(3);
        newNode.Append(4);
        newNode.Append(5);
        Assert.True(newNode.Exists(3));
        Assert.False(newNode.Exists(6));
    }

    [Fact]
    public void NextPointsToSelfTest()
    {
        Node<int> newNode = new(1);
        Assert.Equal(newNode, newNode.Next);
    }

}
