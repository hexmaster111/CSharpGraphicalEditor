# The SharpGOOP system

## Example C# Class Node code

```csharp
SimpleClassNode.cs

[GraphicalNode(name: "class Node", description: "A class node.")]
public class SimpleNode 
{ 
    public string Func1(int a, bool b)
    {
        return $"{a} is {b}";
    }

}
```

```csharp
UserSettings.cs

public class UserSettings
{
    public string Setting1 {get; set}
    public string Setting2 {get; set}
    public string Setting3 {get; set}
    
}
```

```csharp
ComplexClassNode.cs

using UserSettings;

[GraphicalNode(name: "complex class node", description: "A class node.")]
public class ComplexClass
{

    private static UserSettings settings;

    public UserSettings GetSettings()
    {
        return settings;
    }
}
```

## Things To Think About

- How to handle static/non-static classes
    - This shouldnt be too bad, if its a static class, treat it like an instance
- How to handle inheritance
- How to handle interfaces
- How to handle generics
    - I dont think that we are gonna, the nodes should be like the top level stuff that falls into more real code

## The process

- The user imports the node dll
    - The Dll Gets loaded in and such, scanning for `[GraphicalNode]` classes
        - Each Graphical Node gets parsed, and added into a node

```csharp
               InitializeComponent();

//Create a new viewmodel for the NetworkView
            var network = new NetworkViewModel();

//Create the node for the first node, set its name and add it to the network.
            var node1 = new NodeViewModel();
            node1.Name = "Node 1";
            network.Nodes.Add(node1);

//Create the viewmodel for the input on the first node, set its name and add it to the node.
            var node1Input = new NodeInputViewModel();
            node1Input.Name = "Node 1 input";
            node1.Inputs.Add(node1Input);

//Create the second node viewmodel, set its name, add it to the network and add an output in a similar fashion.
            var node2 = new NodeViewModel();
            node2.Name = "Node 2";
            network.Nodes.Add(node2);

            var node2Output = new NodeOutputViewModel();
            node2Output.Name = "Node 2 output";
            node2.Outputs.Add(node2Output);

//Assign the viewmodel to the view.
            networkView.ViewModel = network;
```