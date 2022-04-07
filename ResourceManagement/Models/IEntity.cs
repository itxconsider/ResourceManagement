﻿namespace ResourceManagement.Models
{
    public interface IEntity<TId> : IEntity 
    {
        public TId Id { get; set; }
    }
    public interface IEntity
    {
    }
}