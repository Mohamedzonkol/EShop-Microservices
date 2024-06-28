﻿namespace BuildingBlocks.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException(string message, string details) : base(message)
        {
            Details = details;
        }
        public string? Details { get; }
    }
}
