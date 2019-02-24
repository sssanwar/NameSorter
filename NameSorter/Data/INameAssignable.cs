using System;

namespace NameSorter.Data
{
    /// <summary>
    /// Needed to allow a generic type to be instantiated and assigned the name.
    /// This also allows other object types to be added later when required.
    /// </summary>
    public interface INameAssignable
    {
        void AssignName(String name);
    }
}
