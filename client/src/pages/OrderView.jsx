import React, { useEffect, useState } from "react";
import api from "../api/axios";

export default function OrderView({ orderId, goBack }) {
  const [order, setOrder] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    async function fetchOrder() {
      setLoading(true);
      try {
        const res = await api.get(`/orders/get/${orderId}`);
        setOrder(res.data);
      } catch {
        setOrder(null);
      } finally {
        setLoading(false);
      }
    }
    fetchOrder();
  }, [orderId]);

  if (loading) return <p>Загрузка заказа...</p>;
  if (!order) return (
    <div>
      <p>Заказ не найден.</p>
      <button onClick={goBack}>Назад к списку</button>
    </div>
  );

  return (
    <div style={{ maxWidth: 400 }}>
      <h3>Заказ №{order.orderId}</h3>
      <p><b>Город отправителя:</b> {order.senderCity}</p>
      <p><b>Адрес отправителя:</b> {order.senderAddress}</p>
      <p><b>Город получателя:</b> {order.receiverCity}</p>
      <p><b>Адрес получателя:</b> {order.receiverAddress}</p>
      <p><b>Вес груза:</b> {order.packageWeightKg} кг</p>
      <p><b>Дата забора груза:</b> {new Date(order.packagePickupDate).toLocaleDateString()}</p>
      <button onClick={goBack}>Назад к списку</button>
    </div>
  );
}
