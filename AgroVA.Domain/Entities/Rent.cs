﻿using AgroVA.Domain.Messages;
using AgroVA.Domain.Validation;
using System;

namespace AgroVA.Domain.Entities
{
    public sealed class Rent : EntityBase
    {
        public string Person { get; private set; }
        public float Percent { get; private set; }
        public float Value { get; private set; }
        public string? Annotation { get; private set; }

        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        public int HarvestId { get; set; }
        public Harvest Harvest { get; set; }

        public Rent(int id, string? person, float percent, float value, string? annotation)
        {
            DomainExceptionValidation.When(id < 1, RentMessage.InvalidId);
            Id = id;
            ValidateDomain(person, percent, value, annotation);
        }

        public Rent(string? person, float percent, float value, string? annotation)
        {
            ValidateDomain(person, percent, value, annotation);
        }

        public void Update(string? person, float percent, float value, string? annotation, int farmerId, int harvestId)
        {
            ValidateDomain(person, percent, value, annotation);
            FarmerId = farmerId;
            HarvestId = harvestId;
        }

        public void ValidateDomain(string? person, float percent, float value, string? annotation)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(person), RentMessage.InvalidPerson);
            DomainExceptionValidation.When(percent < 0 || percent > 100, RentMessage.InvalidPercent);
            DomainExceptionValidation.When(value < 0, RentMessage.InvalidValue);
            DomainExceptionValidation.When(string.Empty.Equals(annotation), RentMessage.InvalidAnnotation);

            Person = person;
            Percent = percent;
            Value = value;
            Annotation = annotation;
        }
    }
}
