namespace LeetCode.Tests;

/*
Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Implement the MinStack class:

    MinStack() initializes the stack object.
    void push(int val) pushes the element val onto the stack.
    void pop() removes the element on the top of the stack.
    int top() gets the top element of the stack.
    int getMin() retrieves the minimum element in the stack.

You must implement a solution with O(1) time complexity for each function.

Example 1:

Input
["MinStack","push","push","push","getMin","pop","top","getMin"]
[[],[-2],[0],[-3],[],[],[],[]]

Output
[null,null,null,null,-3,null,0,-2]

Explanation
MinStack minStack = new MinStack();
minStack.push(-2);
minStack.push(0);
minStack.push(-3);
minStack.getMin(); // return -3
minStack.pop();
minStack.top();    // return 0
minStack.getMin(); // return -2
 */

public class MinStackTests
{
   
    [Fact]
    public void Test1()
    {
        MinStack minStack = new MinStack();
        minStack.Top().Should().Be(0);
        
        minStack.Push(-2);
        minStack.Top().Should().Be(-2);
       
        minStack.Push(0);
        minStack.Top().Should().Be(0);

        minStack.Push(-3);
        minStack.Top().Should().Be(-3);
      

        minStack.GetMin().Should().Be(-3);
        minStack.Pop();
        minStack.Top().Should().Be(0);
        
        minStack.Top().Should().Be(0);    
        minStack.GetMin().Should().Be(-2);
    }


    [Fact]
    public void Test2()
    {
        MinStack minStack = new MinStack();
        minStack.Top().Should().Be(0);

        minStack.Push(-2);
        minStack.Top().Should().Be(-2);

        minStack.Push(0);
        minStack.Top().Should().Be(0);

        minStack.Push(-1);
        minStack.Top().Should().Be(-1);


        minStack.GetMin().Should().Be(-2);
        minStack.Pop();
        minStack.Top().Should().Be(0);

        minStack.Top().Should().Be(0);
        minStack.GetMin().Should().Be(-2);
    }

}