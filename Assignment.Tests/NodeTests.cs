using GenericsHomework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



}
