namespace BuildingBlocks.Masseging.Event
{
    public record IntegrationEvent
    {
        public Guid EventId { get; init; }
        public DateTime CreationDate => DateTime.Now;
        public string EventName => GetType().AssemblyQualifiedName!;
    }
}
