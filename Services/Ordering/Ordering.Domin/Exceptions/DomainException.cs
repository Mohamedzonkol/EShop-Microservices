﻿namespace Ordering.Domin.Exceptions
{
    public class DomainException(string message) : Exception($"Domain Exception: \"{message}\" throws from Domain Layer.");
}