using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
public class GarbCollection : IDisposable
{
    private bool _disposedObject;
    // create safe handle instance 
    private SafeHandle? _safeHandle=new SafeFileHandle(IntPtr.Zero,true);
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    // protected implmentation of the dispose pattern
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedObject)
        {
            if (disposing)
            {
                _safeHandle?.Dispose();
                _safeHandle=null;
            }
            _disposedObject=true;
        }
    }
}