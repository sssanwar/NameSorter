using System;
namespace NameSorter.Data
{
    public class InvalidAssignmentException : Exception
    {
        public InvalidAssignmentException() : base("Name cannot be assigned twice.") { }
    }
}
