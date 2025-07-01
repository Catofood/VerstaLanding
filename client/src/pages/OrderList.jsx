import React, { useEffect, useState } from "react";
import api from "../api/axios";

export default function OrdersList({ onOrderClick }) {
  const [orders, setOrders] = useState([]);
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(10); // default page size
  const [totalPages, setTotalPages] = useState(1);
  const [loading, setLoading] = useState(false);

  async function fetchOrders(pageNumber, size) {
    setLoading(true);
    try {
      const res = await api.get("/orders/get", { params: { page: pageNumber, pageSize: size } });
      setOrders(res.data.items);
      setPage(res.data.pageNumber);
      setTotalPages(res.data.totalPages);
    } catch {
      setOrders([]);
      setPage(1);
      setTotalPages(1);
    } finally {
      setLoading(false);
    }
  }

  // обновляем при изменении page или pageSize
  useEffect(() => {
    fetchOrders(page, pageSize);
  }, [page, pageSize]);

  function onPageSizeChange(e) {
    const newSize = Math.min(100, Math.max(1, Number(e.target.value)));
    setPageSize(newSize);
    setPage(1); // при изменении размера страницы сбрасываем на первую страницу
  }

  if (loading) return <p>Загрузка...</p>;
  if (!orders.length) return <p>Заказов нет.</p>;

  return (
    <div>
      <div style={{ marginBottom: 10 }}>
        <label>
          Размер страницы:&nbsp;
          <select value={pageSize} onChange={onPageSizeChange}>
            {[10, 20, 50, 100].map(size => (
              <option key={size} value={size}>
                {size}
              </option>
            ))}
          </select>
        </label>
      </div>

      <table border="1" cellPadding="5" style={{ borderCollapse: "collapse", width: "100%" }}>
        <thead>
          <tr>
            <th>Номер заказа</th>
            <th>Город отправителя</th>
            <th>Адрес отправителя</th>
            <th>Город получателя</th>
            <th>Адрес получателя</th>
            <th>Вес (кг)</th>
            <th>Дата забора</th>
          </tr>
        </thead>
        <tbody>
          {orders.map(o => (
            <tr key={o.id} onClick={() => onOrderClick(o.id)} style={{ cursor: "pointer" }}>
              <td>{o.id}</td>
              <td>{o.senderCity}</td>
              <td>{o.senderAddress}</td>
              <td>{o.receiverCity}</td>
              <td>{o.receiverAddress}</td>
              <td>{o.packageWeightKg}</td>
              <td>{new Date(o.packagePickupDate).toLocaleDateString()}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <div style={{ marginTop: 10 }}>
        <button onClick={() => setPage(p => Math.max(1, p - 1))} disabled={page === 1}>
          Назад
        </button>
        <span style={{ margin: "0 10px" }}>
          {page} / {totalPages}
        </span>
        <button onClick={() => setPage(p => Math.min(totalPages, p + 1))} disabled={page === totalPages}>
          Вперед
        </button>
      </div>
    </div>
  );
}
