using System;
namespace GenericsHomework.Tests;

public class NodeTests
{

    [Fact]
    public void Assert_DuplicateValueTest_ThrowsException()
    {
        Node<int> newNode = new(1);
        Assert.Throws<InvalidOperationException>(() => newNode.Append(1));
    }

    [Fact]
    public void Assert_MultipleValues_Appended_Test()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        newNode.Append(3);
        newNode.Append(4);
        newNode.Append(5);
        Assert.Equal("1 -> 2 -> 3 -> 4 -> 5", newNode.ToString());
    }

    [Fact]
    public void Assert_Clear_Test()
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
    public void Assert_ValuesExist_AndNotExist()
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
    public void Next_PointsToSelf_Test()
    {
        Node<int> newNode = new(1);
        Assert.Equal(newNode, newNode.Next);
    }

    [Fact]
    public void Assert_ToString()
    {
        Node<int> newNode = new(1);
        newNode.Append(2);
        newNode.Append(3);
        Assert.Equal("1 -> 2 -> 3", newNode.ToString());
    }

}
