using CourseEFCore.ValueObjects;
using System;
using System.Collections.Generic;

namespace CourseEFCore.Domain
{
    public class Order
    {
        public int Id { get; set;}
        public int ClientId { get; set;}
        public Client Client { get; set;}
        public DateTime StartedIn { get; set;}
        public DateTime FinishedIn { get; set;}
        public DeliveryType DeliveryType { get; set;}
        public OrderStatus Status { get; set;}
        public string Observation { get; set;}
        public ICollection<OrderItem> Items { get; set;}
    }
}