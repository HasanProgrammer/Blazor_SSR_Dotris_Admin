using System.Text;
using RabbitMQ.Client;

namespace Karami.Common.ClassExtensions;

public static class RabbitExtension
{
    public static void QueueDeclare(this IModel Channel, string queue)                                             => Channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
    public static void DirectExchangeDeclare(this IModel Channel, string exchange)                                 => Channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
    public static void FanOutExchangeDeclare(this IModel Channel, string exchange)                                 => Channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout, durable: true, autoDelete: false, arguments: null);
    public static void BindQueueToDirectExchange(this IModel Channel, string exchange, string queue, string route) => Channel.QueueBind(queue: queue, exchange: exchange, routingKey: route, arguments: null);
    public static void BindQueueToFanOutExchange(this IModel Channel, string exchange, string queue)               => Channel.QueueBind(queue: queue, exchange: exchange, routingKey: "", arguments: null);
    
    /*ارسال مستقیم پیام به Queue*/
    public static void PublishMessage(this IModel Channel, string message, string queue)
    {
        //Message => Queue
        
        byte[] Body = Encoding.UTF8.GetBytes(message);

        Channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: Body);
    }
    
    /*ارسال پیام به مبادله گر ( Exchange ) پیام به روش Direct*/
    public static void PublishMessageToDirectExchange(this IModel Channel, string message, string exchange, string route)
    {
        //Message => Exchange => Queue

        byte[] Body = Encoding.UTF8.GetBytes(message);
        
        Channel.BasicPublish(exchange: exchange, routingKey: route, basicProperties: null, body: Body);
    }
    
    /*ارسال پیام به مبادله گر ( Exchange ) پیام به روش Direct | با ارسال Header های اختصاصی*/
    public static void PublishMessageToDirectExchange(this IModel Channel, string message, string exchange, string route, IBasicProperties properties)
    {
        //Message => Exchange => Queue

        byte[] Body = Encoding.UTF8.GetBytes(message);
        
        Channel.BasicPublish(exchange: exchange, routingKey: route, basicProperties: properties, body: Body);
    }
    
    /*ارسال پیام به مبادله گر ( Exchange ) پیام به روش FanOut*/
    public static void PublishMessageToFanOutExchange(this IModel Channel, string message, string exchange)
    {
        //Message => Exchange => Queue
        
        byte[] Body = Encoding.UTF8.GetBytes(message);
        
        Channel.BasicPublish(exchange: exchange, routingKey: "", basicProperties: null, body: Body);
    }
    
    /*ارسال پیام به مبادله گر ( Exchange ) پیام به روش FanOut | با ارسال Header های اختصاصی*/
    public static void PublishMessageToFanOutExchange(this IModel Channel, string message, string exchange, IBasicProperties properties)
    {
        //Message => Exchange => Queue
        
        byte[] Body = Encoding.UTF8.GetBytes(message);
        
        Channel.BasicPublish(exchange: exchange, routingKey: "", basicProperties: properties, body: Body);
    }

    public static uint CountQueue(this IModel Channel, string queue) => Channel.MessageCount(queue);
}