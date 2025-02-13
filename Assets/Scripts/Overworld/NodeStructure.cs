﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* NodeStructure Description: 
 * This is an abstract class for all Node Structures. The Node class will maintain a reference to a NodeStructure. This is effectively a Strategy design pattern.
 * 
 * A list of implementing NodeStructures:
 *      - Friendly
 *      - Enemy
 */

public abstract class NodeStructure
{
    // fields (required by each NodeStructure)

    public abstract string Type { get; } // String representation of nodestruct type

    public abstract Sprite Sprite { get; } // Sprite associated with nodestruct


    // methods (to be implemented by specific NodeStructures)


    public abstract void AttachToNode(GameObject node); // To be overridden: called when nodestruct is bound to Node
    public abstract void nAttachToNode(GameObject node); // To be overridden: experimental version of AttachToNode
    public abstract void OnClicked(string nodeIdentifier); // To be overridden: the behavior for a node when it is clicked on varies depending on the NodeStruct
}
