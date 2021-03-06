﻿using System;
using SQLite;

namespace TodoTask.Core.Model
{
    public abstract class TodoItem : IComparable<TodoItem>
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public bool Finished { get; set; }
       
        public int CompareTo(TodoItem other)
        {
            return this.DateTime.CompareTo(other.DateTime);
        }
    }
}
