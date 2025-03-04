﻿using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;

namespace AgroVA.Domain.Entities
{
    public sealed class Annotation : EntityBase
    {
        public string Observation { get; private set; }
        public DateTime Timestamp { get; private set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

        public Annotation(int id, string? observation, DateTime timestamp)
        {
            DomainExceptionValidation.When(id < 1, AnnotationMessage.InvalidId);
            Id = id;
            ValidateDomain(observation, timestamp);
        }

        public Annotation(string? observation, DateTime timestamp)
        {
            ValidateDomain(observation, timestamp);
        }

        public void Update(string? observation, DateTime timestamp, int farmerId, int harvestId)
        {
            ValidateDomain(observation, timestamp);
            FarmerId = farmerId;
            HarvestId = harvestId;
        }

        public void ValidateDomain(string? observation, DateTime timestamp)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(observation), AnnotationMessage.InvalidObservation);
            Observation = observation;
            DomainExceptionValidation.When(timestamp == DateTime.MinValue, AnnotationMessage.InvalidTimestamp);
            Timestamp = timestamp;
        }
    }
}
