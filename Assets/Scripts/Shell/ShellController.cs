using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Object = UnityEngine.Object;

public class ShellController
{
    private ShellView shellView;
    private ShellModel shellModel;

    public ShellController(ShellView shellView, ShellModel shellModel,Transform shellTransform)
    {
        this.shellModel = shellModel;
        this.shellView = Fire(shellView,shellTransform);
    }

    private ShellView Fire(ShellView shellView, Transform shellTransform)
    {
        GameObject shellGameObject = Object.Instantiate(shellView.gameObject, shellTransform.position, shellTransform.rotation);
        
        return shellGameObject.GetComponent<ShellView>();
    }
    
    
    
    
}
