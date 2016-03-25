using System;

namespace GrainLibraryProject
{
    [Serializable]
    public class GenericWrapper<T>
    {
         public T Content { get; set; }
    }
}