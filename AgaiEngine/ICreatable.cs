using System;
using System.Collections.Generic;
using System.Text;

namespace AgaiEngine
{
    public interface ICreatable
    {
        string Id { get; set; }
        uint Version { get; }
        string Creator { get; }
        string LastEditBy { get; }
        string Name { get; set; }
    }

    public static class ICreateableExtensions
    {
        public static bool IsValid(this ICreatable c, uint oldVersion = 0)
        {
            return !String.IsNullOrEmpty(c.Id)
                && !String.IsNullOrEmpty(c.Creator)
                && !String.IsNullOrEmpty(c.LastEditBy)
                && c.Version >= oldVersion
                ;
        }

        public static void VerifyCreatable(this ICreatable c)
        {
            if (string.IsNullOrWhiteSpace(c.Id))
            {
                c.Id = Guid.NewGuid().ToString();
            }
            if (!c.IsValid())
                throw new ArgumentException($"Failed to verify ICreatable.");
        }
    }
}
