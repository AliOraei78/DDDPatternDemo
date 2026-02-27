using System;
using System.Collections.Generic;
using System.Text;

namespace DDDPatternDemo.Domain.Shipping
{
    /// <summary>
    /// Shipment model in the Shipping Bounded Context
    /// Completely different from the Sales Order model
    /// </summary>
    public class Order
    {
        public Guid ShipmentId { get; private set; }
        public string TrackingNumber { get; private set; } = string.Empty;
        public string ReceiverAddress { get; private set; } = string.Empty;
        public decimal WeightInKg { get; private set; }
        public string Status { get; private set; } = "Preparing";

        private Order() { }

        public static Order Create(string trackingNumber, string address, decimal weight)
        {
            return new Order
            {
                ShipmentId = Guid.NewGuid(),
                TrackingNumber = trackingNumber,
                ReceiverAddress = address,
                WeightInKg = weight,
                Status = "Preparing"
            };
        }

        public void MarkAsShipped()
        {
            if (Status != "Preparing")
                throw new InvalidOperationException("Only shipments in Preparing status can be shipped.");

            Status = "Shipped";
        }
    }
}
