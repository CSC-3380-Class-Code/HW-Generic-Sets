namespace Set;
using Node;

[TestFixture]
public class SetTests
{

    Set<int> intSet;
    Set<double> doubleSet;
    Set<string> stringSet;
    Set<Node> NodeSet;
    Set<Node> NodeSetCopy;
    Set<Node> emptyNode;
    Set<Node> NodeSet2;
    Set<Node> IntersectNode;
    Set<Node> UnionNode;
    Set<Node> SubtractNode;
    Set<Node> AddNode;

    [SetUp]
    public void CreateSets()
    {
        intSet = new Set<int>([1,4,5]);
        doubleSet = new Set<double>([1,-2.3,5.4]);
        stringSet = new Set<string>(["Hello", "Bye", "World"]);
        emptyNode = new Set<Node>();
        NodeSet = new Set<Node>([new Node(1),new Node(2),new Node(3),new Node(4),new Node(5),new Node(6)]);
        NodeSetCopy = new Set<Node>([new Node(1),new Node(2),new Node(3),new Node(4),new Node(5),new Node(6)]);
        NodeSet2 = new Set<Node>([new Node(1),new Node(3),new Node(5),new Node(7)]);
        IntersectNode = new Set<Node>([new Node(1),new Node(3),new Node(5)]);
        UnionNode = new Set<Node>([new Node(1),new Node(2),new Node(3),new Node(4),new Node(5),new Node(6),new Node(7)]);
        SubtractNode = new Set<Node>([new Node(2),new Node(4),new Node(6)]);
        AddNode = new Set<Node>([new Node(1),new Node(2),new Node(3),new Node(4),new Node(5),new Node(6),new Node(9)]);
    }

    [Test]
    public void TestGeneric()
    {
        Assert.True(intSet.Count > 0);
        Assert.True(doubleSet.Count > 0);
        Assert.True(stringSet.Count > 0);
        Assert.True(NodeSet.Count > 0);
    }

    [Test]
    public void TestDuplicateRemoval()
    {
        Assert.True((new Set<int>([1,2,2,3])).Count == 3);
        Assert.True((NodeSet + new Node(1)) == NodeSetCopy);
    }

    [Test]
    public void TestEquality()
    {
        Assert.True(new Node(4) == new Node(4));
        Assert.False(new Node(3) == new Node(4));

        Assert.True(new Node(3) != new Node(4));
        Assert.False(new Node(4) != new Node(4));
    }

    [Test]
    public void TestIndexer()
    {
        Assert.True(NodeSet[3] == new Node(4));
    }

    [Test]
    public void TestAdd()
    {
        Assert.True((NodeSet + new Node(9)) == AddNode);
    }

    [Test]
    public void TestSubtract()
    {
        Assert.True((NodeSet - NodeSet2) == SubtractNode);
    }

    [Test]
    public void TestUnion()
    {
        Assert.True((NodeSet | NodeSet2) == UnionNode);
    }

    [Test]
    public void TestIntersect()
    {
        Assert.True((NodeSet & NodeSet2) == IntersectNode);
    }

    [Test]
    public void TestTruthValue()
    {
        Assert.NotNull(emptyNode);
        Assert.NotNull(NodeSet);

        if(emptyNode){
            Assert.Fail();
        }
        else{
            if(NodeSet){
                Assert.Pass();
            }
            else{
                Assert.Fail();
            }
        }
    }

    [Test]
    public void TestSubset()
    {
        Assert.True(NodeSet > IntersectNode);
        Assert.False(NodeSet < IntersectNode);
        Assert.True(NodeSet < UnionNode);
        Assert.False(NodeSet > UnionNode);

        Assert.False(NodeSet > NodeSet);
        Assert.False(NodeSet < NodeSet);
        Assert.True(NodeSet >= NodeSet);
        Assert.True(NodeSet <= NodeSet);

        Assert.True(NodeSet >= IntersectNode);
        Assert.False(NodeSet <= IntersectNode);
        Assert.True(NodeSet <= UnionNode);
        Assert.False(NodeSet >= UnionNode);
    }

}